using System;
using System.Windows.Forms;
using eShopping.Models;

namespace eShopping.Forms
{
    public class FrmChiTiet : Form
    {
        public FrmChiTiet(SanPham sp, Action<SanPham> themVaoGio)
        {
            Text = sp.TenSP;
            Width = 460;
            Height = 380;
            StartPosition = FormStartPosition.CenterParent;

            var txt = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                Left = 15,
                Top = 15,
                Width = 410,
                Height = 250,
                ScrollBars = ScrollBars.Vertical
            };
            txt.Text = "Mã: " + sp.MaSP
                + "\r\nTên: " + sp.TenSP
                + "\r\nNhà sản xuất: " + sp.NhaSanXuat
                + "\r\nGiá bán: " + sp.GiaBan.ToString("N0") + " đ"
                + "\r\nTình trạng: " + (sp.ConHang ? "Còn hàng" : "Hết hàng")
                + "\r\nMô tả: " + sp.MoTa
                + "\r\nThông số kỹ thuật: " + sp.ThongSoKyThuat
                + "\r\nHình ảnh: " + (sp.HinhAnh.Count == 0 ? "(chưa có)" : string.Join("; ", sp.HinhAnh));
            Controls.Add(txt);

            var btnThem = Ui.Nut(this, "Thêm vào giỏ", 15, 280, 130);
            btnThem.Enabled = sp.ConHang;
            btnThem.Click += (o, e) => themVaoGio(sp);

            var btnDong = Ui.Nut(this, "Đóng", 160, 280, 90);
            btnDong.Click += (o, e) => Close();
        }
    }
}
