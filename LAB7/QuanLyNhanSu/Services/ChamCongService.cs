using System;
using System.Collections.Generic;
using System.Data;
using QuanLyNhanSu.Models;
using static QuanLyNhanSu.Data.Db;
using static QuanLyNhanSu.Models.KetQuaXuLy;

namespace QuanLyNhanSu.Services
{
    public class ChamCongService
    {
        public DataTable LayKeHoach()
        {
            return Query(@"SELECT k.SoKH,p.TenPB,k.TuNgay,k.DenNgay,k.NgayLap,n.HoTen AS NguoiLap,k.GhiChu
                           FROM KeHoachPhanCong k JOIN PhongBan p ON p.MaPB=k.MaPB JOIN NhanVien n ON n.MaNV=k.MaNVLap
                           ORDER BY k.TuNgay DESC, k.SoKH");
        }
        public DataTable LayChiTietPhanCong(string soKH)
        {
            return Query(@"SELECT c.Ngay,c.MaNV,n.HoTen,c.MaCa,v.TenCa,c.CoPhuTroi
                           FROM ChiTietPhanCong c JOIN NhanVien n ON n.MaNV=c.MaNV JOIN CaLamViec v ON v.MaCa=c.MaCa
                           WHERE c.SoKH=@s ORDER BY c.Ngay,c.MaNV", P("@s", soKH));
        }
        public DataTable LayBangChamCong()
        {
            return Query(@"SELECT b.SoBCC,p.TenPB,b.Thang,b.Nam,b.NgayLap,n.HoTen AS NguoiLap,
                           (SELECT ISNULL(SUM(SoGioLam),0) FROM ChiTietChamCong WHERE SoBCC=b.SoBCC) AS TongGio
                           FROM BangChamCong b JOIN PhongBan p ON p.MaPB=b.MaPB JOIN NhanVien n ON n.MaNV=b.MaNVLap
                           ORDER BY b.Nam DESC,b.Thang DESC,b.SoBCC");
        }
        public DataTable LayChiTietChamCong(string so)
        {
            return Query(@"SELECT c.Ngay,c.MaNV,n.HoTen,c.MaCa,c.SoGioLam FROM ChiTietChamCong c
                           JOIN NhanVien n ON n.MaNV=c.MaNV WHERE c.SoBCC=@s ORDER BY c.Ngay,c.MaNV", P("@s", so));
        }
        public DataTable LayPhieuPhuTroi()
        {
            return Query(@"SELECT t.SoPhieuPT,t.NgayPhuTroi,t.HinhThuc,p.TenPB,t.HeSo,n.HoTen AS NguoiLap,
                           (SELECT ISNULL(SUM(SoGioPhuTroi),0) FROM ChiTietPhieuPhuTroi WHERE SoPhieuPT=t.SoPhieuPT) AS TongGio
                           FROM PhieuPhuTroi t JOIN PhongBan p ON p.MaPB=t.MaPB JOIN NhanVien n ON n.MaNV=t.MaNVLap
                           ORDER BY t.NgayPhuTroi DESC, t.SoPhieuPT");
        }
        public DataTable LayChiTietPhuTroi(string so)
        {
            return Query(@"SELECT c.MaNV,n.HoTen,c.SoGioPhuTroi FROM ChiTietPhieuPhuTroi c
                           JOIN NhanVien n ON n.MaNV=c.MaNV WHERE c.SoPhieuPT=@s ORDER BY c.MaNV", P("@s", so));
        }

        public KetQuaXuLy LapKeHoach(string soKH, string maPB, DateTime tu, DateTime den, string maNVLap,
                                     string ghiChu, List<PhanCongItem> ds)
        {
            if (Ktra.Rong(soKH, maPB, maNVLap)) return Fail("Kế hoạch phân công chưa đủ thông tin.");
            if (den.Date < tu.Date) return Fail("Đến ngày không được trước từ ngày.");
            if (ds == null || ds.Count == 0) return Fail("Chưa có dòng phân công nào.");
            return Transaction((cn, tx) =>
            {
                if (!Ktra.LaTruongPhong(cn, tx, maNVLap, maPB)) return Fail("Người lập phải là Trưởng phòng của phòng ban này.");
                foreach (var x in ds)
                {
                    if (x.Ngay.Date < tu.Date || x.Ngay.Date > den.Date)
                        return Fail("Ngày " + x.Ngay.ToString("dd/MM/yyyy") + " nằm ngoài khoảng của kế hoạch.");
                    if (!Ktra.ThuocPhongBan(cn, tx, x.MaNV, maPB)) return Fail("Nhân viên " + x.MaNV + " không thuộc phòng ban này.");
                }
                Execute(cn, tx, "INSERT INTO KeHoachPhanCong(SoKH,MaPB,TuNgay,DenNgay,NgayLap,MaNVLap,GhiChu) VALUES(@s,@p,@t,@d,@l,@nv,@g)",
                    P("@s", soKH), P("@p", maPB), P("@t", tu.Date), P("@d", den.Date), P("@l", DateTime.Today),
                    P("@nv", maNVLap), P("@g", Ktra.Null(ghiChu)));
                foreach (var x in ds)
                    Execute(cn, tx, "INSERT INTO ChiTietPhanCong(SoKH,MaNV,Ngay,MaCa,CoPhuTroi) VALUES(@s,@n,@d,@c,@p)",
                        P("@s", soKH), P("@n", x.MaNV), P("@d", x.Ngay.Date), P("@c", x.MaCa), P("@p", x.CoPhuTroi));
                return Ok("Đã lập kế hoạch phân công với " + ds.Count + " dòng.");
            });
        }

        public KetQuaXuLy LapBangChamCong(string so, string maPB, int thang, int nam, string maNVLap, List<ChamCongItem> ds)
        {
            if (Ktra.Rong(so, maPB, maNVLap)) return Fail("Bảng chấm công chưa đủ thông tin.");
            if (thang < 1 || thang > 12 || nam < 2000) return Fail("Tháng/năm không hợp lệ.");
            if (ds == null || ds.Count == 0) return Fail("Chưa có dòng chấm công nào.");
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVLap) != "Ban chấm công") return Fail("Bảng chấm công phải do Ban chấm công lập.");
                foreach (var x in ds)
                {
                    if (x.Ngay.Month != thang || x.Ngay.Year != nam) return Fail("Ngày " + x.Ngay.ToString("dd/MM/yyyy") + " không thuộc tháng " + thang + "/" + nam + ".");
                    if (x.SoGioLam < 0 || x.SoGioLam > 24) return Fail("Số giờ làm phải từ 0 đến 24.");
                    if (!Ktra.ThuocPhongBan(cn, tx, x.MaNV, maPB)) return Fail("Nhân viên " + x.MaNV + " không thuộc phòng ban này.");
                }
                Execute(cn, tx, "INSERT INTO BangChamCong(SoBCC,MaPB,Thang,Nam,NgayLap,MaNVLap) VALUES(@s,@p,@t,@n,@l,@nv)",
                    P("@s", so), P("@p", maPB), P("@t", thang), P("@n", nam), P("@l", DateTime.Now), P("@nv", maNVLap));
                foreach (var x in ds)
                    Execute(cn, tx, "INSERT INTO ChiTietChamCong(SoBCC,MaNV,Ngay,MaCa,SoGioLam) VALUES(@s,@n,@d,@c,@g)",
                        P("@s", so), P("@n", x.MaNV), P("@d", x.Ngay.Date), P("@c", x.MaCa), P("@g", x.SoGioLam));
                return Ok("Đã lập bảng chấm công " + thang + "/" + nam + " với " + ds.Count + " dòng.");
            });
        }

        public KetQuaXuLy LapPhieuPhuTroi(string so, DateTime ngay, string hinhThuc, string maPB, string maNVLap,
                                          string ghiChu, List<PhuTroiItem> ds)
        {
            if (Ktra.Rong(so, hinhThuc, maPB, maNVLap)) return Fail("Phiếu phụ trội chưa đủ thông tin.");
            if (hinhThuc != "Tăng ca" && hinhThuc != "Ngày lễ" && hinhThuc != "Ngày nghỉ") return Fail("Hình thức phụ trội không hợp lệ.");
            if (ds == null || ds.Count == 0) return Fail("Chưa có nhân viên nào trong phiếu phụ trội.");
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVLap) != "Ban chấm công") return Fail("Phiếu phụ trội phải do Ban chấm công lập.");
                foreach (var x in ds)
                {
                    if (x.SoGioPhuTroi <= 0 || x.SoGioPhuTroi > 12) return Fail("Số giờ phụ trội phải > 0 và <= 12.");
                    if (!Ktra.ThuocPhongBan(cn, tx, x.MaNV, maPB)) return Fail("Nhân viên " + x.MaNV + " không thuộc phòng ban này.");
                }
                // HeSo dùng giá trị mặc định 1.5 của CSDL (giờ phụ trội = 1.5 lần giờ thường)
                Execute(cn, tx, "INSERT INTO PhieuPhuTroi(SoPhieuPT,NgayPhuTroi,HinhThuc,MaPB,MaNVLap,GhiChu) VALUES(@s,@n,@h,@p,@nv,@g)",
                    P("@s", so), P("@n", ngay.Date), P("@h", hinhThuc), P("@p", maPB), P("@nv", maNVLap), P("@g", Ktra.Null(ghiChu)));
                foreach (var x in ds)
                    Execute(cn, tx, "INSERT INTO ChiTietPhieuPhuTroi(SoPhieuPT,MaNV,SoGioPhuTroi) VALUES(@s,@n,@g)",
                        P("@s", so), P("@n", x.MaNV), P("@g", x.SoGioPhuTroi));
                return Ok("Đã lập phiếu phụ trội với " + ds.Count + " nhân viên.");
            });
        }
    }
}
