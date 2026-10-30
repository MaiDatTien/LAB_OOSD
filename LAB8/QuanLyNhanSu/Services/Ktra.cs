using System;
using System.Data.SqlClient;
using QuanLyNhanSu.Data;

namespace QuanLyNhanSu.Services
{
    public static class Ktra
    {
        public static bool Rong(params string[] giaTri)
        {
            foreach (var g in giaTri) if (string.IsNullOrWhiteSpace(g)) return true;
            return false;
        }
        public static object Null(string s) { return string.IsNullOrWhiteSpace(s) ? null : s.Trim(); }

        public static string VaiTro(SqlConnection cn, SqlTransaction tx, string maNV)
        { return Convert.ToString(Db.Scalar(cn, tx, "SELECT VaiTro FROM NhanVien WHERE MaNV=@m", Db.P("@m", maNV))); }

        public static string TrangThai(SqlConnection cn, SqlTransaction tx, string maNV)
        { return Convert.ToString(Db.Scalar(cn, tx, "SELECT TrangThai FROM NhanVien WHERE MaNV=@m", Db.P("@m", maNV))); }

        public static bool ThuocPhongBan(SqlConnection cn, SqlTransaction tx, string maNV, string maPB)
        {
            return Convert.ToInt32(Db.Scalar(cn, tx,
                "SELECT COUNT(*) FROM NhanVien WHERE MaNV=@n AND MaPB=@p AND TrangThai IN (N'Thử việc',N'Chính thức')",
                Db.P("@n", maNV), Db.P("@p", maPB))) > 0;
        }
        public static bool LaTruongPhong(SqlConnection cn, SqlTransaction tx, string maNV, string maPB)
        {
            return Convert.ToInt32(Db.Scalar(cn, tx,
                "SELECT COUNT(*) FROM NhanVien WHERE MaNV=@n AND MaPB=@p AND VaiTro=N'Trưởng phòng'",
                Db.P("@n", maNV), Db.P("@p", maPB))) > 0;
        }
    }
}
