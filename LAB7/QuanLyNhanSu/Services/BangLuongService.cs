using System;
using System.Data;
using QuanLyNhanSu.Models;
using static QuanLyNhanSu.Data.Db;
using static QuanLyNhanSu.Models.KetQuaXuLy;

namespace QuanLyNhanSu.Services
{
    public class BangLuongService
    {
        // Công chuẩn: 26 ngày x 8 giờ = 208 giờ/tháng (giả định, đề không quy định)
        const decimal GioChuan = 208m;

        const string SqlTinhLuong = @"
INSERT INTO ChiTietBangLuong(SoBangLuong,MaNV,LuongCoBan,PhuCapLuong,PhuCapDocHai,PhuCapChucVu,
    TongGioLam,TongGioPhuTroi,TienLuongLam,TienPhuTroi,KhauTruBHXH,KhauTruBHYT,TruPhat)
SELECT @so, n.MaNV, l.LuongCoBan, l.PhuCapLuong, l.PhuCapDocHai, ISNULL(cv.PhuCapChucVu,0),
       gl.TongGio, pt.TongGioPT,
       ROUND(l.LuongCoBan * (CASE WHEN gl.TongGio > @gio THEN @gio ELSE gl.TongGio END) / @gio, 0),
       ROUND(l.LuongCoBan / @gio * pt.TongGioQuyDoi, 0),
       ISNULL(ROUND(l.LuongCoBan * bh.MucDongBHXH / 100, 0), 0),
       ISNULL(ROUND(l.LuongCoBan * bh.MucDongBHYT / 100, 0), 0),
       ph.TongPhat
FROM NhanVien n
CROSS APPLY (
    SELECT TOP 1 x.LuongCoBan, x.PhuCapLuong, x.PhuCapDocHai
    FROM (SELECT LuongCoBan, PhuCapLuong, PhuCapDocHai, NgayHieuLuc AS Ngay
          FROM QuyetDinhLuong WHERE MaNV = n.MaNV AND NgayHieuLuc <= @cuoi
          UNION ALL
          SELECT LuongThuViec, 0, 0, NgayBatDauThuViec
          FROM QuyetDinhTuyenDung WHERE MaNV = n.MaNV AND NgayBatDauThuViec <= @cuoi) x
    ORDER BY x.Ngay DESC) l
OUTER APPLY (SELECT TOP 1 PhuCapChucVu FROM QuyetDinhChucVu
             WHERE MaNV = n.MaNV AND NgayHieuLuc <= @cuoi ORDER BY NgayHieuLuc DESC) cv
OUTER APPLY (SELECT ISNULL(SUM(SoGioLam),0) AS TongGio FROM ChiTietChamCong
             WHERE MaNV = n.MaNV AND Ngay BETWEEN @dau AND @cuoi) gl
OUTER APPLY (SELECT ISNULL(SUM(d.SoGioPhuTroi),0) AS TongGioPT,
                    ISNULL(SUM(d.SoGioPhuTroi * p.HeSo),0) AS TongGioQuyDoi
             FROM ChiTietPhieuPhuTroi d JOIN PhieuPhuTroi p ON p.SoPhieuPT = d.SoPhieuPT
             WHERE d.MaNV = n.MaNV AND p.NgayPhuTroi BETWEEN @dau AND @cuoi) pt
LEFT JOIN HoSoBaoHiem bh ON bh.MaNV = n.MaNV AND bh.NgayThamGia <= @cuoi
OUTER APPLY (SELECT ISNULL(SUM(t.SoTien),0) AS TongPhat
             FROM PhieuThuNopPhat t JOIN ChiTietKyLuat k ON k.MaCTKL = t.MaCTKL
             WHERE k.MaNV = n.MaNV AND t.HinhThucThu = N'Trừ lương'
               AND t.NgayThu >= @dau AND t.NgayThu < DATEADD(DAY, 1, @cuoi)) ph
WHERE n.TrangThai IN (N'Thử việc', N'Chính thức')";

        public DataTable LayBangLuong()
        {
            return Query(@"SELECT b.SoBangLuong,b.Thang,b.Nam,b.NgayLap,n.HoTen AS NguoiLap,b.TrangThai,
                           (SELECT COUNT(*) FROM ChiTietBangLuong WHERE SoBangLuong=b.SoBangLuong) AS SoNhanVien,
                           (SELECT ISNULL(SUM(ThucLanh),0) FROM ChiTietBangLuong WHERE SoBangLuong=b.SoBangLuong) AS TongThucLanh
                           FROM BangLuong b JOIN NhanVien n ON n.MaNV=b.MaNVLap ORDER BY b.Nam DESC,b.Thang DESC");
        }
        public DataTable LayChiTiet(string soBL)
        {
            return Query(@"SELECT c.MaNV,n.HoTen,p.TenPB,c.LuongCoBan,c.PhuCapLuong,c.PhuCapDocHai,c.PhuCapChucVu,
                           c.TongGioLam,c.TongGioPhuTroi,c.TienLuongLam,c.TienPhuTroi,c.KhauTruBHXH,c.KhauTruBHYT,c.TruPhat,c.ThucLanh
                           FROM ChiTietBangLuong c JOIN NhanVien n ON n.MaNV=c.MaNV LEFT JOIN PhongBan p ON p.MaPB=n.MaPB
                           WHERE c.SoBangLuong=@s ORDER BY c.MaNV", P("@s", soBL));
        }

        public KetQuaXuLy TinhBangLuong(string soBL, int thang, int nam, string maNVLap)
        {
            if (Ktra.Rong(soBL, maNVLap)) return Fail("Nhập số bảng lương và chọn người lập.");
            if (thang < 1 || thang > 12 || nam < 2000) return Fail("Tháng/năm không hợp lệ.");
            DateTime dau = new DateTime(nam, thang, 1), cuoi = dau.AddMonths(1).AddDays(-1);
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVLap) != "Kế toán") return Fail("Bảng lương phải do Kế toán lập.");
                var cu = Query(cn, tx, "SELECT SoBangLuong,TrangThai FROM BangLuong WHERE Thang=@t AND Nam=@n", P("@t", thang), P("@n", nam));
                if (cu.Rows.Count > 0)
                {
                    if (Convert.ToString(cu.Rows[0]["TrangThai"]) == "Đã chốt") return Fail("Bảng lương tháng này đã chốt, không tính lại được.");
                    string soCu = Convert.ToString(cu.Rows[0]["SoBangLuong"]);
                    Execute(cn, tx, "DELETE FROM ChiTietBangLuong WHERE SoBangLuong=@s", P("@s", soCu));
                    Execute(cn, tx, "DELETE FROM BangLuong WHERE SoBangLuong=@s", P("@s", soCu));
                }
                Execute(cn, tx, "INSERT INTO BangLuong(SoBangLuong,Thang,Nam,NgayLap,MaNVLap,TrangThai) VALUES(@s,@t,@n,@l,@nv,N'Nháp')",
                    P("@s", soBL), P("@t", thang), P("@n", nam), P("@l", DateTime.Now), P("@nv", maNVLap));
                int soDong = Execute(cn, tx, SqlTinhLuong, P("@so", soBL), P("@dau", dau), P("@cuoi", cuoi), P("@gio", GioChuan));
                if (soDong == 0) return Fail("Không có nhân viên nào có quyết định lương trong tháng này.");
                return Ok("Đã tính lương tháng " + thang + "/" + nam + " cho " + soDong + " nhân viên (công chuẩn " + GioChuan + " giờ).");
            });
        }

        public KetQuaXuLy ChotBangLuong(string soBL)
        {
            if (Ktra.Rong(soBL)) return Fail("Chọn bảng lương cần chốt.");
            try
            {
                int n = Execute("UPDATE BangLuong SET TrangThai=N'Đã chốt' WHERE SoBangLuong=@s AND TrangThai=N'Nháp'", P("@s", soBL));
                return n == 0 ? Fail("Bảng lương không tồn tại hoặc đã chốt.") : Ok("Đã chốt bảng lương.");
            }
            catch (Exception ex) { return Fail(ex.Message); }
        }
    }
}
