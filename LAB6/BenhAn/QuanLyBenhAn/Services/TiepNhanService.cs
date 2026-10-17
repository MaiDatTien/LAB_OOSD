using System;
using System.Data;
using QuanLyBenhAn.Data;
using static QuanLyBenhAn.Data.KetQuaXuLy;

namespace QuanLyBenhAn.Services
{
    public class TiepNhanService
    {
        // BR01-BR03: phiếu đăng ký + lệ phí + cấp hồ sơ trong một transaction
        public KetQuaXuLy DangKyLanDau(string ten, string diaChi, DateTime ngaySinh, string sdt,
            byte[] anh, decimal tien, string hinhThuc, string maNV)
        {
            if (Db.Rong(ten, sdt, hinhThuc, maNV)) return Fail("Họ tên, điện thoại, hình thức và nhân viên không được để trống.");
            if (ngaySinh.Date >= DateTime.Today) return Fail("Ngày sinh không hợp lệ.");
            if (tien <= 0) return Fail("Lệ phí năm phải lớn hơn 0.");
            return Db.InTx((cn, tx) =>
            {
                int dem = Convert.ToInt32(Db.Cmd(cn, tx,
                    "SELECT COUNT(*) FROM BenhNhan WHERE HoTen=@t AND NgaySinh=@n AND DienThoai=@s",
                    "@t", ten, "@n", ngaySinh.Date, "@s", sdt).ExecuteScalar());
                if (dem > 0) return Fail("Bệnh nhân đã có hồ sơ, hãy tra cứu hoặc gia hạn lệ phí.");

                string bn = Db.NextCode(cn, tx, "BN", "BenhNhan", "MaBN", 6);
                string dk = Db.NextCode(cn, tx, "PDK", "PhieuDangKy", "SoPhieuDK", 6);
                string lp = Db.NextCode(cn, tx, "LP", "LePhiNam", "MaLePhi", 6);
                string hs = Db.NextCode(cn, tx, "HS", "HoSoBenhAn", "MaHS", 6);
                DateTime het = DateTime.Today.AddYears(1);

                Db.Cmd(cn, tx, "INSERT INTO BenhNhan(MaBN,HoTen,DiaChi,NgaySinh,DienThoai,Anh) VALUES(@b,@t,@d,@n,@s,NULLIF(@a,0x))",
                    "@b", bn, "@t", ten, "@d", diaChi, "@n", ngaySinh.Date, "@s", sdt, "@a", anh ?? new byte[0]).ExecuteNonQuery();
                Db.Cmd(cn, tx, "INSERT INTO PhieuDangKy(SoPhieuDK,MaBN,MaNV) VALUES(@p,@b,@nv)",
                    "@p", dk, "@b", bn, "@nv", maNV).ExecuteNonQuery();
                Db.Cmd(cn, tx, "INSERT INTO LePhiNam(MaLePhi,MaBN,SoPhieuDK,SoTien,HinhThuc,NgayHetHan,MaNV) VALUES(@l,@b,@p,@t,@h,@het,@nv)",
                    "@l", lp, "@b", bn, "@p", dk, "@t", tien, "@h", hinhThuc, "@het", het, "@nv", maNV).ExecuteNonQuery();
                Db.Cmd(cn, tx, "INSERT INTO HoSoBenhAn(MaHS,MaBN,NgayHetHan) VALUES(@h,@b,@het)",
                    "@h", hs, "@b", bn, "@het", het).ExecuteNonQuery();
                return Ok("Đã cấp hồ sơ " + hs + ", hiệu lực đến " + het.ToString("dd/MM/yyyy") + ".", hs);
            });
        }

        // BR02, BR06: gia hạn thêm 12 tháng
        public KetQuaXuLy GiaHan(string maHS, decimal tien, string hinhThuc, string maNV)
        {
            if (Db.Rong(maHS, hinhThuc, maNV)) return Fail("Mã hồ sơ, hình thức và nhân viên không được để trống.");
            if (tien <= 0) return Fail("Lệ phí phải lớn hơn 0.");
            return Db.InTx((cn, tx) =>
            {
                var o = Db.Cmd(cn, tx, "SELECT NgayHetHan FROM HoSoBenhAn WITH (UPDLOCK) WHERE MaHS=@h", "@h", maHS).ExecuteScalar();
                if (o == null) return Fail("Không tìm thấy hồ sơ.");
                DateTime goc = Convert.ToDateTime(o);
                DateTime het = (goc > DateTime.Today ? goc : DateTime.Today).AddYears(1);
                string bn = Convert.ToString(Db.Cmd(cn, tx, "SELECT MaBN FROM HoSoBenhAn WHERE MaHS=@h", "@h", maHS).ExecuteScalar());
                string lp = Db.NextCode(cn, tx, "LP", "LePhiNam", "MaLePhi", 6);
                Db.Cmd(cn, tx, "INSERT INTO LePhiNam(MaLePhi,MaBN,SoTien,HinhThuc,NgayHetHan,MaNV) VALUES(@l,@b,@t,@h,@het,@nv)",
                    "@l", lp, "@b", bn, "@t", tien, "@h", hinhThuc, "@het", het, "@nv", maNV).ExecuteNonQuery();
                Db.Cmd(cn, tx, "UPDATE HoSoBenhAn SET NgayHetHan=@het WHERE MaHS=@h", "@het", het, "@h", maHS).ExecuteNonQuery();
                return Ok("Đã gia hạn, hồ sơ có hiệu lực đến " + het.ToString("dd/MM/yyyy") + ".");
            });
        }

        // BR07: tra cứu theo mã hồ sơ, điện thoại, họ tên hoặc ngày sinh
        public DataTable TimHoSo(string tuKhoa)
        {
            string k = (tuKhoa ?? "").Trim();
            return Db.Query(@"SELECT h.MaHS, b.HoTen, b.NgaySinh, b.DienThoai, b.DiaChi, h.NgayCap, h.NgayHetHan,
                CASE WHEN h.NgayHetHan >= CAST(GETDATE() AS date) THEN N'Còn hiệu lực' ELSE N'Hết hạn' END AS TinhTrang
                FROM HoSoBenhAn h JOIN BenhNhan b ON h.MaBN = b.MaBN
                WHERE h.MaHS = @k OR b.DienThoai = @k OR b.HoTen LIKE @l OR CONVERT(varchar(10), b.NgaySinh, 103) = @k
                ORDER BY b.HoTen", "@k", k, "@l", "%" + k + "%");
        }

        public byte[] LayAnh(string maHS)
        {
            object o = Db.Scalar("SELECT b.Anh FROM BenhNhan b JOIN HoSoBenhAn h ON b.MaBN=h.MaBN WHERE h.MaHS=@h", "@h", maHS);
            return o as byte[];
        }

        public DataTable LayLichSuKham(string maHS)
        {
            return Db.Query(@"SELECT p.SoPhieuKham, p.NgayGioKham, p.LoaiKham, bs.HoTen AS BacSi, k.TenKhoa, p.KetLuan, p.TrangThai
                FROM PhieuKham p JOIN BacSi bs ON p.MaBS = bs.MaBS JOIN Khoa k ON p.MaKhoa = k.MaKhoa
                WHERE p.MaHS = @h ORDER BY p.NgayGioKham DESC", "@h", maHS);
        }

        // BR08: tối đa một lịch định kỳ mỗi quý mỗi năm
        public KetQuaXuLy DatLichDinhKy(string maHS, DateTime ngayGio, string maNV)
        {
            if (Db.Rong(maHS, maNV)) return Fail("Phải chọn hồ sơ và nhân viên.");
            if (ngayGio <= DateTime.Now) return Fail("Thời gian hẹn phải ở tương lai.");
            return Db.InTx((cn, tx) =>
            {
                var o = Db.Cmd(cn, tx, "SELECT NgayHetHan FROM HoSoBenhAn WHERE MaHS=@h", "@h", maHS).ExecuteScalar();
                if (o == null) return Fail("Không tìm thấy hồ sơ.");
                if (ngayGio.Date > Convert.ToDateTime(o)) return Fail("Ngày hẹn vượt quá hạn hồ sơ, cần gia hạn lệ phí trước.");
                int quy = (ngayGio.Month - 1) / 3 + 1;
                int dem = Convert.ToInt32(Db.Cmd(cn, tx,
                    "SELECT COUNT(*) FROM LichHen WITH (UPDLOCK,HOLDLOCK) WHERE MaHS=@h AND Quy=@q AND Nam=@n AND TrangThai<>N'Hủy'",
                    "@h", maHS, "@q", quy, "@n", ngayGio.Year).ExecuteScalar());
                if (dem > 0) return Fail("Hồ sơ đã có lịch khám định kỳ trong quý " + quy + "/" + ngayGio.Year + ".");
                string ml = Db.NextCode(cn, tx, "LH", "LichHen", "MaLich", 6);
                Db.Cmd(cn, tx, "INSERT INTO LichHen(MaLich,MaHS,NgayGioHen,MaNV) VALUES(@m,@h,@g,@nv)",
                    "@m", ml, "@h", maHS, "@g", ngayGio, "@nv", maNV).ExecuteNonQuery();
                return Ok("Đã đặt lịch " + ml + " vào quý " + quy + "/" + ngayGio.Year + ".", ml);
            });
        }

        public KetQuaXuLy HuyLich(string maLich)
        {
            if (Db.Rong(maLich)) return Fail("Chưa chọn lịch hẹn.");
            return Db.InTx((cn, tx) =>
            {
                int n = Db.Cmd(cn, tx, "UPDATE LichHen SET TrangThai=N'Hủy' WHERE MaLich=@m AND TrangThai=N'Đã đặt'", "@m", maLich).ExecuteNonQuery();
                return n == 0 ? Fail("Chỉ hủy được lịch đang ở trạng thái Đã đặt.") : Ok("Đã hủy lịch hẹn.");
            });
        }

        public DataTable LayLich(string maHS)
        {
            return Db.Query("SELECT MaLich, NgayGioHen, Quy, Nam, TrangThai FROM LichHen WHERE MaHS=@h ORDER BY NgayGioHen DESC", "@h", maHS);
        }
    }
}
