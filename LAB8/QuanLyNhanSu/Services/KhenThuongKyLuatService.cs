using System;
using System.Collections.Generic;
using System.Data;
using QuanLyNhanSu.Models;
using static QuanLyNhanSu.Data.Db;
using static QuanLyNhanSu.Models.KetQuaXuLy;

namespace QuanLyNhanSu.Services
{
    public class KhenThuongKyLuatService
    {
        public DataTable LayQDKhenThuong()
        {
            return Query(@"SELECT q.SoQDKT,q.NgayQuyetDinh,q.LoaiKhenThuong,q.LyDo,n.HoTen AS NguoiKy,p.SoPhieuChi,p.TongTien
                           FROM QuyetDinhKhenThuong q JOIN NhanVien n ON n.MaNV=q.MaNVKy
                           LEFT JOIN PhieuChiKhenThuong p ON p.SoQDKT=q.SoQDKT ORDER BY q.NgayQuyetDinh DESC,q.SoQDKT");
        }
        public DataTable LayChiTietKhenThuong(string so)
        {
            return Query(@"SELECT c.MaCTKT,ISNULL(c.MaNV,c.MaPB) AS MaDoiTuong,
                           CASE WHEN c.MaNV IS NOT NULL THEN N'Cá nhân' ELSE N'Tập thể' END AS Loai,
                           ISNULL(n.HoTen,pb.TenPB) AS TenDoiTuong,c.SoTien
                           FROM ChiTietKhenThuong c LEFT JOIN NhanVien n ON n.MaNV=c.MaNV LEFT JOIN PhongBan pb ON pb.MaPB=c.MaPB
                           WHERE c.SoQDKT=@s ORDER BY c.MaCTKT", P("@s", so));
        }
        public DataTable LayQDKyLuat()
        {
            return Query(@"SELECT q.SoQDKL,q.NgayQuyetDinh,q.HinhThucKyLuat,q.LyDo,n.HoTen AS NguoiKy
                           FROM QuyetDinhKyLuat q JOIN NhanVien n ON n.MaNV=q.MaNVKy ORDER BY q.NgayQuyetDinh DESC,q.SoQDKL");
        }
        public DataTable LayChiTietKyLuat(string so)
        {
            return Query(@"SELECT c.MaCTKL,ISNULL(c.MaNV,c.MaPB) AS MaDoiTuong,
                           CASE WHEN c.MaNV IS NOT NULL THEN N'Cá nhân' ELSE N'Tập thể' END AS Loai,
                           ISNULL(n.HoTen,pb.TenPB) AS TenDoiTuong,c.SoTienPhat,t.SoPhieuThu,t.HinhThucThu
                           FROM ChiTietKyLuat c LEFT JOIN NhanVien n ON n.MaNV=c.MaNV LEFT JOIN PhongBan pb ON pb.MaPB=c.MaPB
                           LEFT JOIN PhieuThuNopPhat t ON t.MaCTKL=c.MaCTKL WHERE c.SoQDKL=@s ORDER BY c.MaCTKL", P("@s", so));
        }

        // Câu 6: Lập quyết định khen thưởng cho cá nhân hay tập thể phòng ban (+ phiếu chi)
        public KetQuaXuLy LapQDKhenThuong(string soQD, string soPhieuChi, DateTime ngayQD, string loai, string lyDo,
                                          string maNVKy, string maNVLapPhieu, List<KhenThuongItem> ds)
        {
            if (Ktra.Rong(soQD, soPhieuChi, loai, lyDo, maNVKy, maNVLapPhieu)) return Fail("Quyết định khen thưởng chưa đủ thông tin.");
            if (ds == null || ds.Count == 0) return Fail("Chưa có đối tượng nào được khen thưởng.");
            decimal tong = 0;
            foreach (var x in ds)
            {
                bool caNhan = !string.IsNullOrWhiteSpace(x.MaNV), tapThe = !string.IsNullOrWhiteSpace(x.MaPB);
                if (caNhan == tapThe) return Fail("Mỗi dòng phải là một cá nhân hoặc một phòng ban (không cả hai).");
                if (x.SoTien <= 0) return Fail("Số tiền khen thưởng phải lớn hơn 0.");
                tong += x.SoTien;
            }
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVKy) != "Giám đốc") return Fail("Quyết định khen thưởng phải do Giám đốc ký.");
                if (Ktra.VaiTro(cn, tx, maNVLapPhieu) != "Kế toán") return Fail("Phiếu chi phải do Kế toán lập.");
                Execute(cn, tx, "INSERT INTO QuyetDinhKhenThuong(SoQDKT,NgayQuyetDinh,LoaiKhenThuong,LyDo,MaNVKy) VALUES(@s,@n,@l,@d,@ky)",
                    P("@s", soQD), P("@n", ngayQD.Date), P("@l", loai), P("@d", lyDo), P("@ky", maNVKy));
                foreach (var x in ds)
                    Execute(cn, tx, "INSERT INTO ChiTietKhenThuong(SoQDKT,MaNV,MaPB,SoTien) VALUES(@s,@nv,@pb,@t)",
                        P("@s", soQD), P("@nv", Ktra.Null(x.MaNV)), P("@pb", Ktra.Null(x.MaPB)), P("@t", x.SoTien));
                Execute(cn, tx, "INSERT INTO PhieuChiKhenThuong(SoPhieuChi,SoQDKT,NgayChi,TongTien,MaNVLap) VALUES(@p,@s,@n,@t,@nv)",
                    P("@p", soPhieuChi), P("@s", soQD), P("@n", DateTime.Now), P("@t", tong), P("@nv", maNVLapPhieu));
                return Ok("Đã lập quyết định khen thưởng và phiếu chi, tổng tiền " + tong.ToString("N0") + " đ.");
            });
        }

        public KetQuaXuLy LapQDKyLuat(string soQD, DateTime ngayQD, string hinhThuc, string lyDo, string maNVKy,
                                      string maNVLapPhieu, List<KyLuatItem> ds)
        {
            if (Ktra.Rong(soQD, hinhThuc, lyDo, maNVKy)) return Fail("Quyết định kỷ luật chưa đủ thông tin.");
            if (ds == null || ds.Count == 0) return Fail("Chưa có đối tượng nào bị kỷ luật.");
            bool phatTien = hinhThuc == "Phạt tiền";
            foreach (var x in ds)
            {
                bool caNhan = !string.IsNullOrWhiteSpace(x.MaNV), tapThe = !string.IsNullOrWhiteSpace(x.MaPB);
                if (caNhan == tapThe) return Fail("Mỗi dòng phải là một cá nhân hoặc một phòng ban (không cả hai).");
                if (phatTien && x.SoTienPhat <= 0) return Fail("Hình thức Phạt tiền thì số tiền phạt phải > 0.");
                if (!phatTien && x.SoTienPhat != 0) return Fail("Chỉ hình thức Phạt tiền mới có số tiền phạt.");
                if (x.SoTienPhat > 0)
                {
                    if (Ktra.Rong(x.SoPhieuThu, x.HinhThucThu, maNVLapPhieu)) return Fail("Khoản phạt cần số phiếu thu, hình thức thu và người lập phiếu.");
                    if (x.HinhThucThu != "Nộp tiền mặt" && x.HinhThucThu != "Trừ lương") return Fail("Hình thức thu phải là Nộp tiền mặt hoặc Trừ lương.");
                    if (x.HinhThucThu == "Trừ lương" && !caNhan) return Fail("Trừ lương chỉ áp dụng cho cá nhân; tập thể phải nộp tiền mặt.");
                }
            }
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVKy) != "Giám đốc") return Fail("Quyết định kỷ luật phải do Giám đốc ký.");
                if (phatTien && Ktra.VaiTro(cn, tx, maNVLapPhieu) != "Kế toán") return Fail("Phiếu thu nộp phạt phải do Kế toán lập.");
                Execute(cn, tx, "INSERT INTO QuyetDinhKyLuat(SoQDKL,NgayQuyetDinh,HinhThucKyLuat,LyDo,MaNVKy) VALUES(@s,@n,@h,@d,@ky)",
                    P("@s", soQD), P("@n", ngayQD.Date), P("@h", hinhThuc), P("@d", lyDo), P("@ky", maNVKy));
                foreach (var x in ds)
                {
                    int ma = Convert.ToInt32(Scalar(cn, tx,
                        "INSERT INTO ChiTietKyLuat(SoQDKL,MaNV,MaPB,SoTienPhat) VALUES(@s,@nv,@pb,@t); SELECT CAST(SCOPE_IDENTITY() AS int);",
                        P("@s", soQD), P("@nv", Ktra.Null(x.MaNV)), P("@pb", Ktra.Null(x.MaPB)), P("@t", x.SoTienPhat)));
                    if (x.SoTienPhat > 0)
                        Execute(cn, tx, "INSERT INTO PhieuThuNopPhat(SoPhieuThu,MaCTKL,NgayThu,SoTien,HinhThucThu,MaNVLap) VALUES(@p,@c,@n,@t,@h,@nv)",
                            P("@p", x.SoPhieuThu), P("@c", ma), P("@n", DateTime.Now), P("@t", x.SoTienPhat),
                            P("@h", x.HinhThucThu), P("@nv", maNVLapPhieu));
                }
                return Ok("Đã lập quyết định kỷ luật" + (phatTien ? " và phiếu thu nộp phạt." : "."));
            });
        }
    }
}
