using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhanSu.Models;

namespace QuanLyNhanSu.Data
{
    public static class Db
    {
        public static string ConnectionString
        { get { return ConfigurationManager.ConnectionStrings["QuanLyNhanSuDB"].ConnectionString; } }

        public static SqlConnection OpenConnection()
        {
            var cn = new SqlConnection(ConnectionString);
            cn.Open();
            return cn;
        }

        public static SqlParameter P(string ten, object giaTri)
        { return new SqlParameter(ten, giaTri ?? DBNull.Value); }

        // ----- Lệnh đơn lẻ: mỗi lệnh một kết nối -----
        public static DataTable Query(string sql, params SqlParameter[] ps)
        { using (var cn = OpenConnection()) return Query(cn, null, sql, ps); }
        public static int Execute(string sql, params SqlParameter[] ps)
        { using (var cn = OpenConnection()) return Execute(cn, null, sql, ps); }
        public static object Scalar(string sql, params SqlParameter[] ps)
        { using (var cn = OpenConnection()) return Scalar(cn, null, sql, ps); }

        // ----- Lệnh dùng chung kết nối/transaction -----
        public static DataTable Query(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tx))
            using (var da = new SqlDataAdapter(cmd))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static int Execute(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tx))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteNonQuery();
            }
        }
        public static object Scalar(SqlConnection cn, SqlTransaction tx, string sql, params SqlParameter[] ps)
        {
            using (var cmd = new SqlCommand(sql, cn, tx))
            {
                if (ps != null) cmd.Parameters.AddRange(ps);
                return cmd.ExecuteScalar();
            }
        }

        public static KetQuaXuLy Run(string sql, string thongBaoOk, params SqlParameter[] ps)
        {
            try { Execute(sql, ps); return KetQuaXuLy.Ok(thongBaoOk); }
            catch (SqlException ex) { return KetQuaXuLy.Fail(DichLoi(ex)); }
            catch (Exception ex) { return KetQuaXuLy.Fail(ex.Message); }
        }

        // work trả Ok -> commit; trả Fail hoặc ném lỗi -> rollback
        public static KetQuaXuLy Transaction(Func<SqlConnection, SqlTransaction, KetQuaXuLy> work)
        {
            using (var cn = OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var kq = work(cn, tx);
                    if (kq.ThanhCong) tx.Commit(); else tx.Rollback();
                    return kq;
                }
                catch (SqlException ex) { HuyTx(tx); return KetQuaXuLy.Fail(DichLoi(ex)); }
                catch (Exception ex) { HuyTx(tx); return KetQuaXuLy.Fail(ex.Message); }
            }
        }
        static void HuyTx(SqlTransaction tx) { try { tx.Rollback(); } catch { } }

        public static string DichLoi(SqlException ex)
        {
            switch (ex.Number)
            {
                case 2627:
                case 2601: return "Dữ liệu bị trùng (mã hoặc giá trị duy nhất đã tồn tại).";
                case 547: return "Vi phạm ràng buộc dữ liệu (khóa ngoại/CHECK) hoặc dữ liệu đang được sử dụng. " + ex.Message;
                case 515: return "Thiếu dữ liệu bắt buộc. " + ex.Message;
                default: return ex.Message;
            }
        }
    }
}
