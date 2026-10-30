using System;
using System.Data;
using QuanLyNhanSu.Models;
using static QuanLyNhanSu.Data.Db;
using static QuanLyNhanSu.Models.KetQuaXuLy;

namespace QuanLyNhanSu.Services
{
    public class QuyetDinhService
    {
        public DataTable LayQDChucVu()
        {
            return Query(@"SELECT q.SoQDCV,q.MaNV,n.HoTen,c.TenCV,q.NgayHieuLuc,q.PhuCapChucVu,q.GhiChu
                           FROM QuyetDinhChucVu q JOIN NhanVien n ON n.MaNV=q.MaNV JOIN ChucVu c ON c.MaCV=q.MaCV
                           ORDER BY q.NgayHieuLuc DESC, q.SoQDCV");
        }
        public DataTable LayQDLuong()
        {
            return Query(@"SELECT q.SoQDL,q.MaNV,n.HoTen,q.NgayHieuLuc,q.LuongCoBan,q.PhuCapLuong,q.PhuCapDocHai,q.LyDo
                           FROM QuyetDinhLuong q JOIN NhanVien n ON n.MaNV=q.MaNV ORDER BY q.NgayHieuLuc DESC, q.SoQDL");
        }

        public KetQuaXuLy LapQDChucVu(string so, string maNV, string maCV, DateTime ngayHL, decimal phuCap,
                                      string ghiChu, string maNVKy)
        {
            if (Ktra.Rong(so, maNV, maCV, maNVKy)) return Fail("Quyết định chức vụ chưa đủ thông tin.");
            if (phuCap < 0) return Fail("Phụ cấp chức vụ phải >= 0.");
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVKy) != "Giám đốc") return Fail("Quyết định phải do Giám đốc ký.");
                if (Ktra.TrangThai(cn, tx, maNV) != "Chính thức") return Fail("Chỉ bổ nhiệm chức vụ cho nhân viên Chính thức.");
                Execute(cn, tx, @"INSERT INTO QuyetDinhChucVu(SoQDCV,MaNV,MaCV,NgayHieuLuc,PhuCapChucVu,GhiChu,MaNVKy)
                        VALUES(@s,@nv,@cv,@n,@pc,@g,@ky)",
                    P("@s", so), P("@nv", maNV), P("@cv", maCV), P("@n", ngayHL.Date), P("@pc", phuCap),
                    P("@g", Ktra.Null(ghiChu)), P("@ky", maNVKy));
                return Ok("Đã lập quyết định chức vụ.");
            });
        }

        public KetQuaXuLy LapQDLuong(string so, string maNV, DateTime ngayHL, decimal luong, decimal pcLuong,
                                     decimal pcDocHai, string lyDo, string maNVKy)
        {
            if (Ktra.Rong(so, maNV, lyDo, maNVKy)) return Fail("Quyết định lương chưa đủ thông tin.");
            if (lyDo != "Tăng lương" && lyDo != "Điều chỉnh") return Fail("Lý do phải là Tăng lương hoặc Điều chỉnh.");
            if (luong <= 0 || pcLuong < 0 || pcDocHai < 0) return Fail("Lương cơ bản phải > 0, phụ cấp phải >= 0.");
            return Transaction((cn, tx) =>
            {
                if (Ktra.VaiTro(cn, tx, maNVKy) != "Giám đốc") return Fail("Quyết định phải do Giám đốc ký.");
                if (Ktra.TrangThai(cn, tx, maNV) != "Chính thức") return Fail("Chỉ lập quyết định lương mới cho nhân viên Chính thức.");
                var cu = Query(cn, tx, "SELECT TOP 1 LuongCoBan,NgayHieuLuc FROM QuyetDinhLuong WHERE MaNV=@m ORDER BY NgayHieuLuc DESC",
                    P("@m", maNV));
                if (cu.Rows.Count > 0)
                {
                    if (ngayHL.Date <= Convert.ToDateTime(cu.Rows[0]["NgayHieuLuc"]).Date)
                        return Fail("Ngày hiệu lực phải sau quyết định lương hiện hành.");
                    if (lyDo == "Tăng lương" && luong <= Convert.ToDecimal(cu.Rows[0]["LuongCoBan"]))
                        return Fail("Tăng lương thì lương cơ bản mới phải lớn hơn lương hiện hành.");
                }
                Execute(cn, tx, @"INSERT INTO QuyetDinhLuong(SoQDL,MaNV,NgayHieuLuc,LuongCoBan,PhuCapLuong,PhuCapDocHai,LyDo,MaNVKy)
                        VALUES(@s,@nv,@n,@l,@pc,@dh,@ld,@ky)",
                    P("@s", so), P("@nv", maNV), P("@n", ngayHL.Date), P("@l", luong), P("@pc", pcLuong),
                    P("@dh", pcDocHai), P("@ld", lyDo), P("@ky", maNVKy));
                return Ok("Đã lập quyết định lương.");
            });
        }
    }
}
