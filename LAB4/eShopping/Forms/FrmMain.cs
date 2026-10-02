using System;
using System.Drawing;
using System.Windows.Forms;

namespace eShopping.Forms
{
    public class FrmMain : Form
    {
        Label lblTrangThai;
        Button btnDangXuat;

        public FrmMain()
        {
            Text = "eShopping";
            Width = 520;
            Height = 380;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            var tieuDe = new Label
            {
                Text = "HỆ THỐNG CỬA HÀNG ONLINE e-SHOPPING",
                Left = 15,
                Top = 20,
                Width = 480,
                TextAlign = ContentAlignment.MiddleCenter
            };
            tieuDe.Font = new Font(Font.FontFamily, 13, FontStyle.Bold);
            Controls.Add(tieuDe);

            var btnCuaHang = Ui.Nut(this, "Chọn sản phẩm / Giỏ hàng", 70, 80, 360);
            var btnDatHang = Ui.Nut(this, "Tính tiền / Đặt hàng", 70, 120, 360);
            var btnDangNhap = Ui.Nut(this, "Đăng nhập / Đăng ký", 70, 160, 170);
            btnDangXuat = Ui.Nut(this, "Đăng xuất", 260, 160, 170);
            var btnThoat = Ui.Nut(this, "Thoát", 70, 200, 360);

            lblTrangThai = new Label { Left = 15, Top = 260, Width = 480, Height = 40 };
            Controls.Add(lblTrangThai);

            btnCuaHang.Click += (o, e) => { using (var f = new FrmCuaHang()) f.ShowDialog(this); CapNhat(); };
            btnDatHang.Click += (o, e) => { LuongDatHang.TinhTien(this); CapNhat(); };
            btnDangNhap.Click += BtnDangNhap_Click;
            btnDangXuat.Click += BtnDangXuat_Click;
            btnThoat.Click += BtnThoat_Click;
            Activated += (o, e) => CapNhat();
            CapNhat();
        }

        void CapNhat()
        {
            var kh = PhienLamViec.KhachHienTai;
            lblTrangThai.Text = (kh == null ? "Chưa đăng nhập" : "Xin chào, " + kh.HoTen)
                + "   |   Giỏ hàng: " + PhienLamViec.Gio.Dong.Count + " sản phẩm";
            btnDangXuat.Enabled = kh != null;
        }

        void BtnDangNhap_Click(object sender, EventArgs e)
        {
            if (PhienLamViec.KhachHienTai != null)
            {
                MessageBox.Show("Bạn đã đăng nhập.");
                return;
            }
            using (var f = new FrmDangNhap()) f.ShowDialog(this);
            CapNhat();
        }

        void BtnDangXuat_Click(object sender, EventArgs e)
        {
            PhienLamViec.KhachHienTai = null;
            CapNhat();
        }

        void BtnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }
    }
}
