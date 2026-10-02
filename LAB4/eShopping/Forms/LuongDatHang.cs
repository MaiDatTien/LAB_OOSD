using System.Windows.Forms;

namespace eShopping.Forms
{
    public static class LuongDatHang
    {
        public static void TinhTien(IWin32Window chu)
        {
            if (PhienLamViec.Gio.Rong)
            {
                MessageBox.Show("Giỏ hàng trống.");
                return;
            }
            if (PhienLamViec.KhachHienTai == null)
            {
                using (var f = new FrmDangNhap())
                {
                    if (f.ShowDialog(chu) != DialogResult.OK) return;
                }
            }
            using (var f = new FrmDatHang())
            {
                f.ShowDialog(chu);
            }
        }
    }
}
