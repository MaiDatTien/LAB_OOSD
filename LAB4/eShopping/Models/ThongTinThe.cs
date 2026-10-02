namespace eShopping.Models
{
    public class ThongTinThe
    {
        public string MaLoaiThe { get; set; }
        public string SoThe { get; set; }
        public int ThangHet { get; set; }
        public int NamHet { get; set; }
        public string TenChuThe { get; set; }
        public string CSV { get; set; }

        public string Last4
        {
            get { return string.IsNullOrEmpty(SoThe) || SoThe.Length < 4 ? "" : SoThe.Substring(SoThe.Length - 4); }
        }
    }
}
