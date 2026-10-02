using System;
using System.Text;
using eShopping.Adapters;
using eShopping.Models;

namespace eShopping.Tests
{
    public static class SelfTest
    {
        static int dat;
        static int hong;
        static StringBuilder nhatKy;

        static void So(string ten, object mong, object thuc)
        {
            if (Equals(mong, thuc)) dat++;
            else
            {
                hong++;
                nhatKy.AppendLine("FAIL " + ten + ": mong " + mong + ", nhan " + thuc);
            }
        }

        static ThongTinThe The(string ma, string so, string csv, int thang, int nam)
        {
            return new ThongTinThe { MaLoaiThe = ma, SoThe = so, CSV = csv, ThangHet = thang, NamHet = nam, TenChuThe = "NGUYEN VAN A" };
        }

        public static string Run()
        {
            dat = 0;
            hong = 0;
            nhatKy = new StringBuilder();
            var bay = DateTime.Now;
            int namSau = bay.Year + 1;

            So("TH01", false, QuyTac.MienPhiGiao(999999m, QuyTac.NHANH));
            So("TH02", true, QuyTac.MienPhiGiao(1000000m, QuyTac.NHANH));
            So("TH03", false, QuyTac.MienPhiGiao(4999999m, QuyTac.TRONGNGAY));
            So("TH04", true, QuyTac.MienPhiGiao(5000000m, QuyTac.TRONGNGAY));
            So("TH05", false, QuyTac.MienPhiGiao(1000000m, QuyTac.TRONGNGAY));
            So("TH06", false, QuyTac.MienPhiGiao(10000000m, QuyTac.THUONG));
            So("TH07", true, QuyTac.MienPhiGiao(5000000m, QuyTac.NHANH));
            So("TH08", 0m, QuyTac.PhiGiao(2000000m, QuyTac.NHANH, 30000m));
            So("TH09", 30000m, QuyTac.PhiGiao(500000m, QuyTac.NHANH, 30000m));

            var visa = new LoaiThe { MaLoaiThe = "VISA", TenLoaiThe = "Visa", SoChuSoThe = 16, SoChuSoCSV = 3 };
            var amex = new LoaiThe { MaLoaiThe = "AMEX", TenLoaiThe = "Amex", SoChuSoThe = 15, SoChuSoCSV = 4 };
            int thangTruoc = bay.Month == 1 ? 12 : bay.Month - 1;
            int namThangTruoc = bay.Month == 1 ? bay.Year - 1 : bay.Year;

            So("THE01", true, QuyTac.KiemTraThe(The("VISA", "4111111111111111", "123", 12, namSau), visa, bay).ThanhCong);
            So("THE02", false, QuyTac.KiemTraThe(The("VISA", "411111111111111", "123", 12, namSau), visa, bay).ThanhCong);
            So("THE03", true, QuyTac.KiemTraThe(The("AMEX", "378282246310005", "1234", 12, namSau), amex, bay).ThanhCong);
            So("THE04", false, QuyTac.KiemTraThe(The("AMEX", "378282246310005", "123", 12, namSau), amex, bay).ThanhCong);
            So("THE05", false, QuyTac.KiemTraThe(The("VISA", "4111111111111111", "1234", 12, namSau), visa, bay).ThanhCong);
            So("THE06", false, QuyTac.KiemTraThe(The("VISA", "41111111111111AB", "123", 12, namSau), visa, bay).ThanhCong);
            So("THE07", false, QuyTac.KiemTraThe(The("VISA", "4111111111111111", "123", thangTruoc, namThangTruoc), visa, bay).ThanhCong);
            So("THE08", true, QuyTac.KiemTraThe(The("VISA", "4111111111111111", "123", bay.Month, bay.Year), visa, bay).ThanhCong);
            So("THE09", "1111", The("VISA", "4111111111111111", "123", 1, namSau).Last4);

            var heThong = new MockProductSystem();
            var gio = new GioHang();
            So("GH01", true, gio.Them(heThong.LayChiTiet("TOY01"), 2).ThanhCong);
            So("GH02", false, gio.Them(heThong.LayChiTiet("CAM03"), 1).ThanhCong);
            gio.Them(heThong.LayChiTiet("TOY01"), 1);
            So("GH03", 3, gio.Dong[0].SoLuong);
            So("GH04", false, gio.CapNhatSoLuong("TOY01", 0).ThanhCong);
            gio.CapNhatSoLuong("TOY01", 5);
            So("GH05", 5, gio.Dong[0].SoLuong);
            So("GH06", 2250000m, gio.TongTienHang);
            So("GH07", true, gio.Xoa("TOY01").ThanhCong && gio.Rong);
            So("GH08", false, gio.Xoa("XXX").ThanhCong);

            var cong = new MockPaymentGateway();
            So("PAY01", false, cong.KiemTra(The("VISA", "4111111111110000", "123", 12, namSau), 100000m).ThanhCong);
            So("PAY02", false, cong.KiemTra(The("VISA", "4111111111111111", "123", 12, namSau), 60000000m).ThanhCong);
            So("PAY03", true, cong.KiemTra(The("VISA", "4111111111111111", "123", 12, namSau), 1000000m).ThanhCong);

            return "PASS: " + dat + "   FAIL: " + hong + "\r\n" + nhatKy;
        }
    }
}
