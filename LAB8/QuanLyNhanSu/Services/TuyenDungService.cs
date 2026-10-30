using System;
using System.Data;
using QuanLyNhanSu.Models;
using static QuanLyNhanSu.Data.Db;
using static QuanLyNhanSu.Models.KetQuaXuLy;

namespace QuanLyNhanSu.Services
{
    public class TuyenDungService
    {
        const string QDMoiNhat = @"q.SoQDTD=(SELECT TOP 1 SoQDTD FROM QuyetDinhTuyenDung
                                   WHERE MaNV=n.MaNV ORDER BY NgayQuyetDinh DESC, SoQDTD DESC)";

        public DataTable LayQDTuyenDung()
        {
            return Query(@"SELECT q.SoQDTD,q.MaNV,n.HoTen,p.TenPB,q.NgayQuyetDinh,q.NgayBatDauThuViec,
                           q.NgayKetThucThuViec,q.LuongThuViec,q.KetQuaThuViec,q.NoiDungDieuKhoan
                           FROM QuyetDinhTuyenDung q JOIN NhanVien n ON n.MaNV=q.MaNV
                           JOIN PhongBan p ON p.MaPB=q.MaPB ORDER BY q.NgayQuyetDinh DESC, q.SoQDTD DESC");
        }
        // Nhân viên đang thử việc kèm QĐ tuyển dụng mới nhất
        public DataTable LayNhanVienThuViec()
        {
            return Query(@"SELECT n.MaNV,n.HoTen,q.SoQDTD,q.NgayKetThucThuViec,q.LuongThuViec,q.KetQuaThuViec,
                           n.HoTen+N' - '+n.MaNV AS HienThi
                           FROM NhanVien n JOIN QuyetDinhTuyenDung q ON q.MaNV=n.MaNV
                           WHERE n.TrangThai=N'Thử việc' AND " + QDMoiNhat + " ORDER BY n.MaNV");
        }
        public DataTable LayNhanVienDatThuViec()
        {
            return Query(@"SELECT n.MaNV,n.HoTen,q.NgayKetThucThuViec,n.HoTen+N' - '+n.MaNV AS HienThi
                           FROM NhanVien n JOIN QuyetDinhTuyenDung q ON q.MaNV=n.MaNV
                           WHERE n.TrangThai=N'Thử việc' AND q.KetQuaThuViec=N'Đạt' AND " + QDMoiNhat + " ORDER BY n.MaNV");
        }
        public DataTable LayHopDong()
        {
            return Query(@"SELECT h.SoHopDong,h.MaNV,n.HoTen,h.LoaiHopDong,h.NgayKy,h.NgayBatDau,h.NgayKetThuc,
                           h.TrangThai,b.SoSoBHXH,b.SoTheBHYT,b.MucDongBHXH,b.MucDongBHYT
                           FROM HopDong h JOIN NhanVien n ON n.MaNV=h.MaNV
                           LEFT JOIN HoSoBaoHiem b ON b.SoHopDong=h.SoHopDong ORDER BY h.NgayKy DESC, h.SoHopDong");
        }

        public KetQuaXuLy LapQDTuyenDung(string soQD, string maNV, string maPB, DateTime ngayQD, DateTime batDau,
                                         DateTime ketThuc, decimal luong, string noiDung, string maNVLap, string maNVKy)
        {
            if (Ktra.Rong(soQD, maNV, maPB, noiDung, maNVLap, maNVKy))
                return Fail("Quyết định tuyển dụng chưa đủ thông tin (kể cả điều khoản hai bên).");
            if (ketThuc.Date < batDau.Date) return Fail("Ngày kết thúc thử việc không được trước ngày bắt đầu.");
            if (luong <= 0) return Fail("Lương thử việc phải lớn hơn 0.");
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVKy) != "Giám đốc") return Fail("Quyết định phải do Giám đốc ký.");
                if (Ktra.VaiTro(cn, tx, maNVLap) != "Nhân sự") return Fail("Người lập quyết định phải là nhân viên Nhân sự.");
                if (Ktra.TrangThai(cn, tx, maNV) != "Chờ tuyển dụng")
                    return Fail("Chỉ lập QĐ tuyển dụng cho nhân viên ở trạng thái Chờ tuyển dụng.");
                Execute(cn, tx, @"INSERT INTO QuyetDinhTuyenDung(SoQDTD,MaNV,MaPB,NgayQuyetDinh,NgayBatDauThuViec,
                        NgayKetThucThuViec,LuongThuViec,NoiDungDieuKhoan,MaNVLap,MaNVKy)
                        VALUES(@s,@nv,@pb,@nq,@bd,@kt,@l,@nd,@lap,@ky)",
                    P("@s", soQD), P("@nv", maNV), P("@pb", maPB), P("@nq", ngayQD.Date), P("@bd", batDau.Date),
                    P("@kt", ketThuc.Date), P("@l", luong), P("@nd", noiDung), P("@lap", maNVLap), P("@ky", maNVKy));
                Execute(cn, tx, "UPDATE NhanVien SET MaPB=@pb, TrangThai=N'Thử việc' WHERE MaNV=@nv",
                    P("@pb", maPB), P("@nv", maNV));
                return Ok("Đã lập quyết định tuyển dụng, nhân viên chuyển sang Thử việc.");
            });
        }

        public KetQuaXuLy DanhGiaThuViec(string soQD, string ketQua)
        {
            if (Ktra.Rong(soQD, ketQua) || (ketQua != "Đạt" && ketQua != "Không đạt"))
                return Fail("Chọn quyết định và kết quả thử việc là Đạt hoặc Không đạt.");
            return Transaction((cn, tx) =>
            {
                var dt = Query(cn, tx, @"SELECT q.MaNV,q.NgayKetThucThuViec,q.KetQuaThuViec,n.TrangThai
                        FROM QuyetDinhTuyenDung q JOIN NhanVien n ON n.MaNV=q.MaNV WHERE q.SoQDTD=@s", P("@s", soQD));
                if (dt.Rows.Count == 0) return Fail("Không tìm thấy quyết định tuyển dụng.");
                var r = dt.Rows[0];
                if (Convert.ToString(r["TrangThai"]) != "Thử việc") return Fail("Nhân viên không ở trạng thái Thử việc.");
                if (!(r["KetQuaThuViec"] is DBNull)) return Fail("Quyết định này đã được đánh giá.");
                if (DateTime.Today < Convert.ToDateTime(r["NgayKetThucThuViec"]).Date)
                    return Fail("Chưa hết thời gian thử việc nên chưa thể đánh giá.");
                Execute(cn, tx, "UPDATE QuyetDinhTuyenDung SET KetQuaThuViec=@k WHERE SoQDTD=@s", P("@k", ketQua), P("@s", soQD));
                if (ketQua == "Không đạt")
                    Execute(cn, tx, "UPDATE NhanVien SET TrangThai=N'Nghỉ việc' WHERE MaNV=@m", P("@m", r["MaNV"]));
                return Ok("Đã ghi nhận kết quả thử việc: " + ketQua + ".");
            });
        }

        public KetQuaXuLy KyHopDong(KyHopDongInput x)
        {
            if (Ktra.Rong(x.SoHopDong, x.MaNV, x.LoaiHopDong, x.SoQDLuong, x.MaNVKy))
                return Fail("Thông tin hợp đồng và quyết định lương chưa đầy đủ.");
            if (x.LoaiHopDong != "Dài hạn" && x.LoaiHopDong != "Ngắn hạn") return Fail("Loại hợp đồng phải là Dài hạn hoặc Ngắn hạn.");
            if (x.LoaiHopDong == "Ngắn hạn" && !x.NgayKetThuc.HasValue) return Fail("Hợp đồng ngắn hạn bắt buộc có ngày kết thúc.");
            if (x.NgayKetThuc.HasValue && x.NgayKetThuc.Value.Date < x.NgayBatDau.Date) return Fail("Ngày kết thúc hợp đồng không được trước ngày bắt đầu.");
            if (x.LuongCoBan <= 0 || x.PhuCapLuong < 0 || x.PhuCapDocHai < 0 || x.PhuCapChucVu < 0) return Fail("Lương cơ bản phải > 0 và các phụ cấp phải >= 0.");
            if (x.LoaiHopDong == "Dài hạn" && Ktra.Rong(x.SoSoBHXH, x.SoTheBHYT))
                return Fail("Hợp đồng dài hạn bắt buộc có hồ sơ BHXH (số sổ) và BHYT (số thẻ).");
            bool coChucVu = !string.IsNullOrWhiteSpace(x.MaCV);
            if (coChucVu && Ktra.Rong(x.SoQDChucVu)) return Fail("Nhập số quyết định chức vụ.");

            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, x.MaNVKy) != "Giám đốc") return Fail("Hợp đồng và quyết định phải do Giám đốc ký.");
                if (Ktra.TrangThai(cn, tx, x.MaNV) != "Thử việc") return Fail("Chỉ ký hợp đồng chính thức cho nhân viên đang Thử việc.");
                var q = Query(cn, tx, @"SELECT TOP 1 SoQDTD,NgayKetThucThuViec,KetQuaThuViec FROM QuyetDinhTuyenDung
                        WHERE MaNV=@m ORDER BY NgayQuyetDinh DESC, SoQDTD DESC", P("@m", x.MaNV));
                if (q.Rows.Count == 0) return Fail("Nhân viên chưa có quyết định tuyển dụng.");
                if (Convert.ToString(q.Rows[0]["KetQuaThuViec"]) != "Đạt") return Fail("Nhân viên chưa được đánh giá Đạt thử việc.");
                DateTime hetTV = Convert.ToDateTime(q.Rows[0]["NgayKetThucThuViec"]).Date;
                if (x.NgayKy.Date < hetTV || x.NgayBatDau.Date < hetTV) return Fail("Hợp đồng chính thức chỉ được ký/bắt đầu từ khi hết thời gian thử việc.");

                Execute(cn, tx, @"INSERT INTO HopDong(SoHopDong,MaNV,SoQDTD,LoaiHopDong,NgayKy,NgayBatDau,NgayKetThuc,NoiDung,MaNVKy)
                        VALUES(@s,@nv,@qd,@l,@k,@bd,@kt,@nd,@ky)",
                    P("@s", x.SoHopDong), P("@nv", x.MaNV), P("@qd", q.Rows[0]["SoQDTD"]), P("@l", x.LoaiHopDong),
                    P("@k", x.NgayKy.Date), P("@bd", x.NgayBatDau.Date),
                    P("@kt", x.NgayKetThuc.HasValue ? (object)x.NgayKetThuc.Value.Date : null),
                    P("@nd", Ktra.Null(x.NoiDung)), P("@ky", x.MaNVKy));
                Execute(cn, tx, @"INSERT INTO QuyetDinhLuong(SoQDL,MaNV,NgayHieuLuc,LuongCoBan,PhuCapLuong,PhuCapDocHai,LyDo,MaNVKy)
                        VALUES(@s,@nv,@n,@l,@pc,@dh,N'Ký chính thức',@ky)",
                    P("@s", x.SoQDLuong), P("@nv", x.MaNV), P("@n", x.NgayBatDau.Date), P("@l", x.LuongCoBan),
                    P("@pc", x.PhuCapLuong), P("@dh", x.PhuCapDocHai), P("@ky", x.MaNVKy));
                if (coChucVu)
                    Execute(cn, tx, @"INSERT INTO QuyetDinhChucVu(SoQDCV,MaNV,MaCV,NgayHieuLuc,PhuCapChucVu,MaNVKy)
                            VALUES(@s,@nv,@cv,@n,@pc,@ky)",
                        P("@s", x.SoQDChucVu), P("@nv", x.MaNV), P("@cv", x.MaCV), P("@n", x.NgayBatDau.Date),
                        P("@pc", x.PhuCapChucVu), P("@ky", x.MaNVKy));
                if (x.LoaiHopDong == "Dài hạn")
                    Execute(cn, tx, @"INSERT INTO HoSoBaoHiem(MaHoSoBH,MaNV,SoHopDong,SoSoBHXH,SoTheBHYT,NgayThamGia,MucDongBHXH,MucDongBHYT)
                            VALUES(@s,@nv,@hd,@xh,@yt,@n,@mx,@my)",
                        P("@s", "BH_" + x.SoHopDong), P("@nv", x.MaNV), P("@hd", x.SoHopDong), P("@xh", x.SoSoBHXH),
                        P("@yt", x.SoTheBHYT), P("@n", x.NgayBatDau.Date), P("@mx", x.MucBHXH), P("@my", x.MucBHYT));
                Execute(cn, tx, "UPDATE NhanVien SET TrangThai=N'Chính thức' WHERE MaNV=@m", P("@m", x.MaNV));
                return Ok("Đã ký hợp đồng " + x.LoaiHopDong.ToLower() + ", nhân viên chuyển sang Chính thức.");
            });
        }
    }
}
