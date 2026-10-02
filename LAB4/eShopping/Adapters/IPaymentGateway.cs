using eShopping.Models;

namespace eShopping.Adapters
{
    public interface IPaymentGateway
    {
        KetQuaKiemTraThe KiemTra(ThongTinThe the, decimal soTien);
    }
}
