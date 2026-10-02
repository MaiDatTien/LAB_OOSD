using System;
using System.Windows.Forms;
using eShopping.Models;
using eShopping.Services;

namespace eShopping.Forms
{
    public class FrmDangNhap : Form
    {
        readonly KhachHangService dich = new KhachHangService();
        TabControl tab;
        TextBox txtTenDN, txtMatKhau;
        TextBox txtDkTen, txtDkGiayTo, txtDkDiaChi, txtDkDienThoai, txtDkEmail, txtDkTenDN, txtDkMatKhau;
        DateTimePicker dtDkNgaySinh;

        public FrmDangNhap()
        {
            Text = "Đăng nhập / Đăng ký";
            Width = 460;
            Height = 470;
            StartPosition = FormStartPosition.CenterParent;

            tab = new TabControl { Dock = DockStyle.Fill };
            Controls.Add(tab);
            var trangDN = new TabPage("Đăng nhập");
            var trangDK = new TabPage("Đăng ký mới");
            tab.TabPages.Add(trangDN);
            tab.TabPages.Add(trangDK);

            Ui.Nhan(trangDN, "Tên đăng nhập:", 20, 30);
            txtTenDN = Ui.OText(trangDN, 140, 30);
            Ui.Nhan(trangDN, "Mật khẩu:", 20, 70);
            txtMatKhau = Ui.OText(trangDN, 140, 70);
            txtMatKhau.UseSystemPasswordChar = true;
            var btnDangNhap = Ui.Nut(trangDN, "Đăng nhập", 140, 110);
            btnDangNhap.Click += BtnDangNhap_Click;
            AcceptButton = btnDangNhap;

            int y = 15;
            Ui.Nhan(trangDK, "Họ tên:", 20, y); txtDkTen = Ui.OText(trangDK, 150, y); y += 36;
            Ui.Nhan(trangDK, "Ngày sinh:", 20, y);
            dtDkNgaySinh = new DateTimePicker { Left = 150, Top = y, Width = 200, Format = DateTimePickerFormat.Short, Value = new DateTime(2000, 1, 1) };
            trangDK.Controls.Add(dtDkNgaySinh); y += 36;
            Ui.Nhan(trangDK, "CMND/Passport:", 20, y); txtDkGiayTo = Ui.OText(trangDK, 150, y); y += 36;
            Ui.Nhan(trangDK, "Địa chỉ:", 20, y); txtDkDiaChi = Ui.OText(trangDK, 150, y); y += 36;
            Ui.Nhan(trangDK, "Điện thoại:", 20, y); txtDkDienThoai = Ui.OText(trangDK, 150, y); y += 36;
            Ui.Nhan(trangDK, "Email (tùy chọn):", 20, y); txtDkEmail = Ui.OText(trangDK, 150, y); y += 36;
            Ui.Nhan(trangDK, "Tên đăng nhập:", 20, y); txtDkTenDN = Ui.OText(trangDK, 150, y); y += 36;
            Ui.Nhan(trangDK, "Mật khẩu:", 20, y); txtDkMatKhau = Ui.OText(trangDK, 150, y);
            txtDkMatKhau.UseSystemPasswordChar = true; y += 40;
            var btnDangKy = Ui.Nut(trangDK, "Đăng ký", 150, y);
            btnDangKy.Click += BtnDangKy_Click;
        }

        void BtnDangNhap_Click(object sender, EventArgs e)
        {
            var kq = dich.DangNhap(txtTenDN.Text, txtMatKhau.Text);
            if (!kq.ThanhCong)
            {
                MessageBox.Show(kq.ThongBao);
                return;
            }
            PhienLamViec.KhachHienTai = (KhachHang)kq.DuLieu;
            DialogResult = DialogResult.OK;
        }

        void BtnDangKy_Click(object sender, EventArgs e)
        {
            var kh = new KhachHang
            {
                HoTen = txtDkTen.Text,
                NgaySinh = dtDkNgaySinh.Value,
                SoGiayTo = txtDkGiayTo.Text,
                DiaChi = txtDkDiaChi.Text,
                DienThoai = txtDkDienThoai.Text,
                Email = txtDkEmail.Text,
                TenDangNhap = txtDkTenDN.Text
            };
            var kq = dich.DangKy(kh, txtDkMatKhau.Text);
            MessageBox.Show(kq.ThongBao);
            if (kq.ThanhCong)
            {
                txtTenDN.Text = txtDkTenDN.Text;
                tab.SelectedIndex = 0;
                txtMatKhau.Focus();
            }
        }
    }
}
