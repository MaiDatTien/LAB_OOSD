using System;
using eShopping.Models;

namespace eShopping.Adapters
{
    public class MockPaymentGateway : IPaymentGateway
    {
        public decimal HanMuc = 50000000m;

        public KetQuaKiemTraThe KiemTra(ThongTinThe the, decimal soTien)
        {
            if (the.SoThe.EndsWith("0000"))
                return new KetQuaKiemTraThe { HopLe = false, DuKhaNang = false, LyDo = "Thẻ không hợp lệ hoặc đã bị khóa." };
            if (soTien > HanMuc)
                return new KetQuaKiemTraThe { HopLe = true, DuKhaNang = false, LyDo = "Thẻ không đủ khả năng thanh toán." };
            return new KetQuaKiemTraThe
            {
                HopLe = true,
                DuKhaNang = true,
                MaThamChieu = "PAY" + Guid.NewGuid().ToString("N").Substring(0, 12).ToUpper()
            };
        }
    }
}
