using System;
using System.Data;
using QuanLyNhanSu.Models;
using static QuanLyNhanSu.Data.Db;
using static QuanLyNhanSu.Models.KetQuaXuLy;

namespace QuanLyNhanSu.Services
{
    public class DanhMucService
    {
        public DataTable LayPhongBan() { return Query("SELECT MaPB,TenPB,MoTa,TenPB AS HienThi FROM PhongBan ORDER BY MaPB"); }
        public DataTable LayChucVu() { return Query("SELECT * FROM ChucVu ORDER BY MaCV"); }
        public DataTable LayCaLamViec()
        {
            return Query(@"SELECT MaCa,TenCa,CONVERT(varchar(5),GioBatDau) AS GioBatDau,
                           CONVERT(varchar(5),GioKetThuc) AS GioKetThuc,SoGio,
                           TenCa+N' ('+CONVERT(varchar(5),GioBatDau)+N'-'+CONVERT(varchar(5),GioKetThuc)+N')' AS HienThi
                           FROM CaLamViec ORDER BY MaCa");
        }
        public DataTable LayNhanVien()
        {
            return Query(@"SELECT n.MaNV,n.HoTen,n.NgaySinh,n.GioiTinh,n.SoCCCD,n.DiaChi,n.SoDienThoai,
                           n.MaPB,p.TenPB,n.VaiTro,n.TrangThai
                           FROM NhanVien n LEFT JOIN PhongBan p ON p.MaPB=n.MaPB ORDER BY n.MaNV");
        }

        // Các hàm nạp ComboBox: cột HienThi = Họ tên - Mã
        public DataTable LayNhanVienTheoTrangThai(string trangThai)
        {
            return Query("SELECT MaNV,HoTen,HoTen+N' - '+MaNV AS HienThi FROM NhanVien WHERE TrangThai=@t ORDER BY MaNV",
                P("@t", trangThai));
        }
        public DataTable LayNhanVienTheoVaiTro(string vaiTro)
        {
            return Query(@"SELECT MaNV,HoTen,HoTen+N' - '+MaNV AS HienThi FROM NhanVien
                           WHERE VaiTro=@v AND TrangThai IN (N'Thử việc',N'Chính thức') ORDER BY MaNV", P("@v", vaiTro));
        }
        public DataTable LayNhanVienTheoPhongBan(string maPB)
        {
            return Query(@"SELECT MaNV,HoTen,HoTen+N' - '+MaNV AS HienThi FROM NhanVien
                           WHERE MaPB=@p AND TrangThai IN (N'Thử việc',N'Chính thức') ORDER BY MaNV", P("@p", maPB));
        }
        public DataTable LayNhanVienDangLamViec()
        {
            return Query(@"SELECT MaNV,HoTen,HoTen+N' - '+MaNV AS HienThi FROM NhanVien
                           WHERE TrangThai IN (N'Thử việc',N'Chính thức') ORDER BY MaNV");
        }

        public KetQuaXuLy ThemPhongBan(string ma, string ten, string moTa)
        {
            if (Ktra.Rong(ma, ten)) return Fail("Mã phòng ban và tên phòng ban không được để trống.");
            return Run("INSERT INTO PhongBan(MaPB,TenPB,MoTa) VALUES(@m,@t,@d)", "Đã thêm phòng ban.",
                P("@m", ma), P("@t", ten), P("@d", Ktra.Null(moTa)));
        }
        public KetQuaXuLy ThemChucVu(string ma, string ten)
        {
            if (Ktra.Rong(ma, ten)) return Fail("Mã chức vụ và tên chức vụ không được để trống.");
            return Run("INSERT INTO ChucVu(MaCV,TenCV) VALUES(@m,@t)", "Đã thêm chức vụ.", P("@m", ma), P("@t", ten));
        }
        public KetQuaXuLy ThemCaLamViec(string ma, string ten, TimeSpan batDau, TimeSpan ketThuc, decimal soGio)
        {
            if (Ktra.Rong(ma, ten)) return Fail("Mã ca và tên ca không được để trống.");
            if (soGio <= 0 || soGio > 24) return Fail("Số giờ của ca phải trong khoảng (0, 24].");
            return Run("INSERT INTO CaLamViec(MaCa,TenCa,GioBatDau,GioKetThuc,SoGio) VALUES(@m,@t,@b,@k,@g)",
                "Đã thêm ca làm việc.", P("@m", ma), P("@t", ten), P("@b", batDau), P("@k", ketThuc), P("@g", soGio));
        }
        public KetQuaXuLy ThemNhanVien(string ma, string ten, DateTime ngaySinh, string gioiTinh, string cccd,
                                       string diaChi, string sdt, string vaiTro)
        {
            if (Ktra.Rong(ma, ten, gioiTinh, cccd, vaiTro)) return Fail("Thông tin nhân viên chưa đầy đủ.");
            if (ngaySinh.Date > DateTime.Today.AddYears(-18)) return Fail("Nhân viên phải đủ 18 tuổi.");
            return Run(@"INSERT INTO NhanVien(MaNV,HoTen,NgaySinh,GioiTinh,SoCCCD,DiaChi,SoDienThoai,VaiTro)
                         VALUES(@m,@t,@ns,@gt,@c,@dc,@sdt,@vt)", "Đã thêm hồ sơ nhân viên (trạng thái Chờ tuyển dụng).",
                P("@m", ma), P("@t", ten), P("@ns", ngaySinh.Date), P("@gt", gioiTinh), P("@c", cccd),
                P("@dc", Ktra.Null(diaChi)), P("@sdt", Ktra.Null(sdt)), P("@vt", vaiTro));
        }
    }
}
