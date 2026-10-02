using System.Collections.Generic;
using eShopping.Models;

namespace eShopping.Adapters
{
    public interface IProductSystem
    {
        IList<NhomSanPham> LayNhom();
        IList<SanPham> LaySanPham(string maNhom);
        SanPham LayChiTiet(string maSP);
    }
}
