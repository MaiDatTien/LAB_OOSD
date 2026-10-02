namespace eShopping.Models
{
    public class BangGia
    {
        public decimal TienHang { get; set; }
        public decimal PhiGiao { get; set; }
        public decimal PhiThe { get; set; }
        public bool MienPhiGiao { get; set; }
        public decimal Tong { get { return TienHang + PhiGiao + PhiThe; } }
    }
}
