using System.Collections.Generic;

namespace eShopping.Models
{
    public class SanPham
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public string NhaSanXuat { get; set; }
        public string MaNhom { get; set; }
        public string MoTa { get; set; }
        public string ThongSoKyThuat { get; set; }
        public decimal GiaBan { get; set; }
        public bool ConHang { get; set; }
        public List<string> HinhAnh { get; set; } = new List<string>();
    }
}
