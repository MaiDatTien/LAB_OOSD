namespace eShopping.Models
{
    public class DongGioHang
    {
        public string MaSP { get; set; }
        public string TenSP { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuong { get; set; }
        public decimal ThanhTien { get { return DonGia * SoLuong; } }
    }
}
