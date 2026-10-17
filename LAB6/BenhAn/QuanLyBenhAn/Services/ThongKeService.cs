using System;
using System.Data;
using QuanLyBenhAn.Data;

namespace QuanLyBenhAn.Services
{
    public class ThongKeService
    {
        public DataTable TongHop(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT
              (SELECT COUNT(*) FROM PhieuDangKy WHERE CAST(NgayDangKy AS date) BETWEEN @tu AND @den) AS DangKyMoi,
              (SELECT ISNULL(SUM(SoTien),0) FROM LePhiNam WHERE NgayDong BETWEEN @tu AND @den) AS DoanhThuLePhi,
              (SELECT COUNT(*) FROM PhieuKham WHERE LoaiKham=N'Điều trị' AND CAST(NgayGioKham AS date) BETWEEN @tu AND @den) AS KhamDieuTri,
              (SELECT COUNT(*) FROM PhieuKham WHERE LoaiKham=N'Định kỳ' AND CAST(NgayGioKham AS date) BETWEEN @tu AND @den) AS KhamDinhKy,
              (SELECT COUNT(*) FROM LichHen WHERE TrangThai=N'Đã đặt' AND CAST(NgayGioHen AS date) BETWEEN @tu AND @den) AS LichChoKham,
              (SELECT ISNULL(SUM(TongTien),0) FROM HoaDon WHERE TrangThai=N'Đã thanh toán' AND CAST(NgayLap AS date) BETWEEN @tu AND @den) AS DoanhThuVienPhi",
                "@tu", tu.Date, "@den", den.Date);
        }

        public DataTable ThuocDaKe(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT t.MaThuoc, t.TenThuoc, SUM(c.SoLuong) AS TongSoLuong, SUM(c.SoLuong*t.DonGia) AS TongTien
                FROM ToaThuoc a JOIN ChiTietToa c ON a.SoToa=c.SoToa JOIN Thuoc t ON c.MaThuoc=t.MaThuoc
                WHERE CAST(a.NgayLap AS date) BETWEEN @tu AND @den
                GROUP BY t.MaThuoc, t.TenThuoc ORDER BY TongSoLuong DESC", "@tu", tu.Date, "@den", den.Date);
        }

        public DataTable KhamTheoBacSi(DateTime tu, DateTime den)
        {
            return Db.Query(@"SELECT bs.MaBS, bs.HoTen, COUNT(*) AS SoPhieu,
                SUM(CASE WHEN p.LoaiKham=N'Định kỳ' THEN 1 ELSE 0 END) AS SoDinhKy
                FROM PhieuKham p JOIN BacSi bs ON p.MaBS=bs.MaBS
                WHERE CAST(p.NgayGioKham AS date) BETWEEN @tu AND @den
                GROUP BY bs.MaBS, bs.HoTen ORDER BY SoPhieu DESC", "@tu", tu.Date, "@den", den.Date);
        }
    }
}
