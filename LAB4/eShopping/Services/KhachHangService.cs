using System;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Security.Cryptography;
using eShopping.Data;
using eShopping.Models;

namespace eShopping.Services
{
    public class KhachHangService
    {
        const int SoVongLap = 10000;

        static string BamMatKhau(string matKhau)
        {
            var muoi = new byte[16];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(muoi);
            byte[] bam;
            using (var k = new Rfc2898DeriveBytes(matKhau, muoi, SoVongLap, HashAlgorithmName.SHA256)) bam = k.GetBytes(32);
            var tatCa = new byte[48];
            Buffer.BlockCopy(muoi, 0, tatCa, 0, 16);
            Buffer.BlockCopy(bam, 0, tatCa, 16, 32);
            return Convert.ToBase64String(tatCa);
        }

        static bool KhopMatKhau(string matKhau, string daLuu)
        {
            byte[] tatCa;
            try { tatCa = Convert.FromBase64String(daLuu); }
            catch { return false; }
            if (tatCa.Length != 48) return false;
            var muoi = new byte[16];
            Buffer.BlockCopy(tatCa, 0, muoi, 0, 16);
            byte[] bam;
            using (var k = new Rfc2898DeriveBytes(matKhau, muoi, SoVongLap, HashAlgorithmName.SHA256)) bam = k.GetBytes(32);
            int khac = 0;
            for (int i = 0; i < 32; i++) khac |= bam[i] ^ tatCa[16 + i];
            return khac == 0;
        }

        public KetQuaXuLy DangKy(KhachHang kh, string matKhau)
        {
            if (kh == null || string.IsNullOrWhiteSpace(kh.HoTen) || string.IsNullOrWhiteSpace(kh.SoGiayTo)
                || string.IsNullOrWhiteSpace(kh.DiaChi) || string.IsNullOrWhiteSpace(kh.DienThoai)
                || string.IsNullOrWhiteSpace(kh.TenDangNhap))
                return KetQuaXuLy.Fail("Vui lòng nhập đủ họ tên, số CMND/Passport, địa chỉ, điện thoại, tên đăng nhập.");
            if (kh.NgaySinh.Date >= DateTime.Today) return KetQuaXuLy.Fail("Ngày sinh không hợp lệ.");
            if (string.IsNullOrEmpty(matKhau) || matKhau.Length < 6) return KetQuaXuLy.Fail("Mật khẩu tối thiểu 6 ký tự.");
            if (!string.IsNullOrWhiteSpace(kh.Email))
            {
                try { new MailAddress(kh.Email.Trim()); }
                catch { return KetQuaXuLy.Fail("Địa chỉ email không hợp lệ."); }
            }
            try
            {
                Db.Execute(@"INSERT INTO KhachHang(HoTen,NgaySinh,SoGiayTo,DiaChi,DienThoai,TenDangNhap,MatKhauHash,Email)
                             VALUES(@ht,@ns,@gt,@dc,@dt,@tdn,@mk,@em)",
                    new SqlParameter("@ht", kh.HoTen.Trim()),
                    new SqlParameter("@ns", kh.NgaySinh.Date),
                    new SqlParameter("@gt", kh.SoGiayTo.Trim()),
                    new SqlParameter("@dc", kh.DiaChi.Trim()),
                    new SqlParameter("@dt", kh.DienThoai.Trim()),
                    new SqlParameter("@tdn", kh.TenDangNhap.Trim()),
                    new SqlParameter("@mk", BamMatKhau(matKhau)),
                    new SqlParameter("@em", string.IsNullOrWhiteSpace(kh.Email) ? (object)DBNull.Value : kh.Email.Trim()));
                return KetQuaXuLy.Ok("Đăng ký thành công. Bạn có thể đăng nhập.");
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    if (ex.Message.Contains("UQ_KhachHang_TenDN")) return KetQuaXuLy.Fail("Tên đăng nhập đã tồn tại.");
                    if (ex.Message.Contains("UQ_KhachHang_SoGiayTo")) return KetQuaXuLy.Fail("Số CMND/Passport đã được đăng ký.");
                }
                return KetQuaXuLy.Fail(ex.Message);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }

        public KetQuaXuLy DangNhap(string tenDangNhap, string matKhau)
        {
            if (string.IsNullOrWhiteSpace(tenDangNhap) || string.IsNullOrEmpty(matKhau))
                return KetQuaXuLy.Fail("Nhập tên đăng nhập và mật khẩu.");
            try
            {
                var dt = Db.Query("SELECT * FROM KhachHang WHERE TenDangNhap=@t", new SqlParameter("@t", tenDangNhap.Trim()));
                if (dt.Rows.Count == 0 || !KhopMatKhau(matKhau, Convert.ToString(dt.Rows[0]["MatKhauHash"])))
                    return KetQuaXuLy.Fail("Tên đăng nhập hoặc mật khẩu không đúng.");
                var r = dt.Rows[0];
                var kh = new KhachHang
                {
                    MaKhach = Convert.ToInt32(r["MaKhach"]),
                    HoTen = Convert.ToString(r["HoTen"]),
                    NgaySinh = Convert.ToDateTime(r["NgaySinh"]),
                    SoGiayTo = Convert.ToString(r["SoGiayTo"]),
                    DiaChi = Convert.ToString(r["DiaChi"]),
                    DienThoai = Convert.ToString(r["DienThoai"]),
                    TenDangNhap = Convert.ToString(r["TenDangNhap"]),
                    Email = r["Email"] == DBNull.Value ? null : Convert.ToString(r["Email"])
                };
                return KetQuaXuLy.Ok("Đăng nhập thành công.", kh);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail(ex.Message);
            }
        }
    }
}
