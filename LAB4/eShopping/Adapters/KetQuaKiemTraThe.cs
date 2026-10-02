namespace eShopping.Adapters
{
    public class KetQuaKiemTraThe
    {
        public bool HopLe { get; set; }
        public bool DuKhaNang { get; set; }
        public string MaThamChieu { get; set; }
        public string LyDo { get; set; }
        public bool ThanhCong { get { return HopLe && DuKhaNang; } }
    }
}
