using System;
using System.Linq;

namespace eShopping.Models
{
    public static class QuyTac
    {
        public const decimal NguongMienPhiNhanh = 1000000m;
        public const decimal NguongMienPhiTrongNgay = 5000000m;
        public const string THUONG = "THUONG";
        public const string NHANH = "NHANH";
        public const string TRONGNGAY = "TRONGNGAY";

        public static bool MienPhiGiao(decimal tienHang, string maLoaiPhieu)
        {
            if (maLoaiPhieu == NHANH) return tienHang >= NguongMienPhiNhanh;
            if (maLoaiPhieu == TRONGNGAY) return tienHang >= NguongMienPhiTrongNgay;
            return false;
        }

        public static decimal PhiGiao(decimal tienHang, string maLoaiPhieu, decimal phiTheoBang)
        {
            return MienPhiGiao(tienHang, maLoaiPhieu) ? 0m : phiTheoBang;
        }

        public static KetQuaXuLy KiemTraThe(ThongTinThe the, LoaiThe loai, DateTime now)
        {
            if (the == null || loai == null) return KetQuaXuLy.Fail("Chưa chọn loại thẻ.");
            if (string.IsNullOrWhiteSpace(the.TenChuThe)) return KetQuaXuLy.Fail("Chưa nhập họ tên chủ thẻ.");
            if (string.IsNullOrEmpty(the.SoThe) || !the.SoThe.All(char.IsDigit) || the.SoThe.Length != loai.SoChuSoThe)
                return KetQuaXuLy.Fail("Số thẻ " + loai.TenLoaiThe + " phải gồm đúng " + loai.SoChuSoThe + " chữ số.");
            if (string.IsNullOrEmpty(the.CSV) || !the.CSV.All(char.IsDigit) || the.CSV.Length != loai.SoChuSoCSV)
                return KetQuaXuLy.Fail("Mã an ninh (CSV) của thẻ " + loai.TenLoaiThe + " phải gồm đúng " + loai.SoChuSoCSV + " chữ số.");
            if (the.ThangHet < 1 || the.ThangHet > 12) return KetQuaXuLy.Fail("Tháng hết hạn không hợp lệ.");
            if (the.NamHet < now.Year || (the.NamHet == now.Year && the.ThangHet < now.Month))
                return KetQuaXuLy.Fail("Thẻ đã hết hạn.");
            return KetQuaXuLy.Ok("Định dạng thẻ hợp lệ.");
        }
    }
}
