using System;
using System.Data;
using System.Data.SqlClient;
using eShopping.Data;
using eShopping.Models;

namespace eShopping.Services
{
    public class CauHinhService
    {
        public DataTable LayLoaiPhieu()
        {
            return Db.Query("SELECT * FROM LoaiPhieuDat ORDER BY SoGioXuLy DESC");
        }

        public DataTable LayKhuVuc()
        {
            return Db.Query("SELECT * FROM KhuVucGiao ORDER BY TenKhuVuc");
        }

        public DataTable LayLoaiThe()
        {
            return Db.Query("SELECT * FROM LoaiThe ORDER BY TenLoaiThe");
        }

        public LoaiThe LayLoaiThe(string ma)
        {
            var dt = Db.Query("SELECT * FROM LoaiThe WHERE MaLoaiThe=@m", new SqlParameter("@m", ma ?? ""));
            if (dt.Rows.Count == 0) return null;
            var r = dt.Rows[0];
            return new LoaiThe
            {
                MaLoaiThe = Convert.ToString(r["MaLoaiThe"]),
                TenLoaiThe = Convert.ToString(r["TenLoaiThe"]),
                SoChuSoThe = Convert.ToInt32(r["SoChuSoThe"]),
                SoChuSoCSV = Convert.ToInt32(r["SoChuSoCSV"]),
                LePhi = Convert.ToDecimal(r["LePhi"])
            };
        }

        public decimal? LayPhiGiaoTheoBang(string maKhuVuc, string maLoaiPhieu)
        {
            var o = Db.Scalar("SELECT Phi FROM PhiGiaoHang WHERE MaKhuVuc=@k AND MaLoaiPhieu=@l",
                new SqlParameter("@k", maKhuVuc ?? ""), new SqlParameter("@l", maLoaiPhieu ?? ""));
            if (o == null || o == DBNull.Value) return null;
            return Convert.ToDecimal(o);
        }
    }
}
