using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyBenhAn.Data
{
    /// <summary>Kết quả xử lý trả về cho Form: thành công/thất bại, thông báo, dữ liệu kèm theo.</summary>
    public class KetQuaXuLy
    {
        public bool ThanhCong; public string ThongBao; public object Data;
        public static KetQuaXuLy Ok(string m, object d = null) { return new KetQuaXuLy { ThanhCong = true, ThongBao = m, Data = d }; }
        public static KetQuaXuLy Fail(string m) { return new KetQuaXuLy { ThanhCong = false, ThongBao = m }; }
    }

    public static class Db
    {
        static string CS { get { return ConfigurationManager.ConnectionStrings["QuanLyBenhAnDB"].ConnectionString; } }
        public static SqlConnection Open() { var cn = new SqlConnection(CS); cn.Open(); return cn; }

        public static bool Rong(params string[] s)
        { foreach (var x in s) if (string.IsNullOrWhiteSpace(x)) return true; return false; }

        // Cmd(cn, tx, sql, "@a", giaTri, "@b", giaTri, ...)
        public static SqlCommand Cmd(SqlConnection cn, SqlTransaction tx, string sql, params object[] kv)
        {
            var c = new SqlCommand(sql, cn, tx);
            for (int i = 0; i + 1 < kv.Length; i += 2)
            {
                string ten = (string)kv[i]; object v = kv[i + 1];
                if (v is byte[]) c.Parameters.Add(ten, SqlDbType.VarBinary, -1).Value = v;
                else c.Parameters.AddWithValue(ten, v ?? DBNull.Value);
            }
            return c;
        }

        public static DataTable Query(string sql, params object[] kv)
        {
            using (var cn = Open()) using (var c = Cmd(cn, null, sql, kv)) using (var da = new SqlDataAdapter(c))
            { var dt = new DataTable(); da.Fill(dt); return dt; }
        }

        public static object Scalar(string sql, params object[] kv)
        { using (var cn = Open()) using (var c = Cmd(cn, null, sql, kv)) return c.ExecuteScalar(); }

        // Sinh mã tăng dần theo tiền tố, ví dụ HS000001 (gọi trong transaction)
        public static string NextCode(SqlConnection cn, SqlTransaction tx, string prefix, string bang, string cot, int width)
        {
            string sql = "SELECT ISNULL(MAX(CAST(SUBSTRING(" + cot + "," + (prefix.Length + 1) + ",20) AS int)),0)+1 FROM "
                       + bang + " WITH (UPDLOCK,HOLDLOCK) WHERE " + cot + " LIKE '" + prefix + "%'";
            int n = Convert.ToInt32(Cmd(cn, tx, sql).ExecuteScalar());
            return prefix + n.ToString().PadLeft(width, '0');
        }

        public static string Dich(SqlException ex)
        {
            if (ex.Number == 2627 || ex.Number == 2601) return "Dữ liệu bị trùng (vi phạm ràng buộc duy nhất).";
            if (ex.Number == 547) return "Vi phạm khóa ngoại hoặc ràng buộc kiểm tra.";
            return ex.Message;
        }

        // Chạy nghiệp vụ trong một transaction: Ok thì Commit, Fail hoặc lỗi thì Rollback
        public static KetQuaXuLy InTx(Func<SqlConnection, SqlTransaction, KetQuaXuLy> work)
        {
            using (var cn = Open()) using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var r = work(cn, tx);
                    if (r.ThanhCong) tx.Commit(); else tx.Rollback();
                    return r;
                }
                catch (SqlException ex) { try { tx.Rollback(); } catch { } return KetQuaXuLy.Fail(Dich(ex)); }
                catch (Exception ex) { try { tx.Rollback(); } catch { } return KetQuaXuLy.Fail(ex.Message); }
            }
        }

        public static KetQuaXuLy Insert1(string sql, string okMsg, params object[] kv)
        {
            return InTx((cn, tx) => { Cmd(cn, tx, sql, kv).ExecuteNonQuery(); return KetQuaXuLy.Ok(okMsg); });
        }
    }
}
