using System;
using System.Drawing;
using System.Windows.Forms;
using eShopping.Models;
using eShopping.Services;

namespace eShopping.Forms
{
    public class FrmDatHang : Form
    {
        readonly DatHangService dich = new DatHangService();
        readonly CauHinhService cauHinh = new CauHinhService();
        ComboBox cboLoaiPhieu, cboKhuVuc, cboLoaiThe;
        TextBox txtTenNhan, txtDiaChiNhan, txtDienThoaiNhan, txtSoThe, txtChuThe, txtCSV;
        CheckBox chkLaToi;
        NumericUpDown numThang, numNam;
        Label lblTienHang, lblPhiGiao, lblPhiThe, lblTong;

        public FrmDatHang()
        {
            Text = "Đặt hàng - Giao hàng và thanh toán";
            Width = 560;
            Height = 640;
            StartPosition = FormStartPosition.CenterParent;

            int y = 15;
            Ui.Nhan(this, "Loại phiếu đặt:", 15, y); cboLoaiPhieu = Ui.OChon(this, 150, y, 370); y += 34;
            Ui.Nhan(this, "Khu vực giao:", 15, y); cboKhuVuc = Ui.OChon(this, 150, y, 370); y += 40;
            chkLaToi = new CheckBox { Text = "Người nhận là chính tôi", Left = 150, Top = y, Width = 250 };
            Controls.Add(chkLaToi); y += 30;
            Ui.Nhan(this, "Họ tên người nhận:", 15, y); txtTenNhan = Ui.OText(this, 150, y, 370); y += 34;
            Ui.Nhan(this, "Địa chỉ nhận:", 15, y); txtDiaChiNhan = Ui.OText(this, 150, y, 370); y += 34;
            Ui.Nhan(this, "Điện thoại nhận:", 15, y); txtDienThoaiNhan = Ui.OText(this, 150, y, 370); y += 44;
            Ui.Nhan(this, "Loại thẻ:", 15, y); cboLoaiThe = Ui.OChon(this, 150, y, 200); y += 34;
            Ui.Nhan(this, "Số thẻ:", 15, y); txtSoThe = Ui.OText(this, 150, y, 250); txtSoThe.MaxLength = 16; y += 34;
            Ui.Nhan(this, "Hết hạn (T/N):", 15, y);
            numThang = Ui.OSo(this, 150, y, 50, 1, 12, 12);
            numNam = Ui.OSo(this, 210, y, 70, DateTime.Now.Year, DateTime.Now.Year + 20, DateTime.Now.Year + 2); y += 34;
            Ui.Nhan(this, "Họ tên chủ thẻ:", 15, y); txtChuThe = Ui.OText(this, 150, y, 370); y += 34;
            Ui.Nhan(this, "Mã an ninh (CSV):", 15, y); txtCSV = Ui.OText(this, 150, y, 80);
            txtCSV.MaxLength = 4; txtCSV.UseSystemPasswordChar = true; y += 44;

            lblTienHang = new Label { Left = 15, Top = y, Width = 500 }; Controls.Add(lblTienHang); y += 24;
            lblPhiGiao = new Label { Left = 15, Top = y, Width = 500 }; Controls.Add(lblPhiGiao); y += 24;
            lblPhiThe = new Label { Left = 15, Top = y, Width = 500 }; Controls.Add(lblPhiThe); y += 24;
            lblTong = new Label { Left = 15, Top = y, Width = 500 };
            lblTong.Font = new Font(Font, FontStyle.Bold);
            Controls.Add(lblTong); y += 36;

            var btnDat = Ui.Nut(this, "Xác nhận đặt hàng", 150, y, 170);
            btnDat.Height = 34;
            btnDat.Click += BtnDat_Click;

            Ui.NapComboBox(cboLoaiPhieu, cauHinh.LayLoaiPhieu(), "TenLoaiPhieu", "MaLoaiPhieu");
            Ui.NapComboBox(cboKhuVuc, cauHinh.LayKhuVuc(), "TenKhuVuc", "MaKhuVuc");
            Ui.NapComboBox(cboLoaiThe, cauHinh.LayLoaiThe(), "TenLoaiThe", "MaLoaiThe");
            cboLoaiPhieu.SelectedIndexChanged += (o, e) => TinhTien();
            cboKhuVuc.SelectedIndexChanged += (o, e) => TinhTien();
            cboLoaiThe.SelectedIndexChanged += (o, e) => TinhTien();
            chkLaToi.CheckedChanged += ChkLaToi_CheckedChanged;
            TinhTien();
        }

        void ChkLaToi_CheckedChanged(object sender, EventArgs e)
        {
            var kh = PhienLamViec.KhachHienTai;
            if (chkLaToi.Checked && kh != null)
            {
                txtTenNhan.Text = kh.HoTen;
                txtDiaChiNhan.Text = kh.DiaChi;
                txtDienThoaiNhan.Text = kh.DienThoai;
            }
            txtTenNhan.ReadOnly = chkLaToi.Checked;
            txtDiaChiNhan.ReadOnly = chkLaToi.Checked;
            txtDienThoaiNhan.ReadOnly = chkLaToi.Checked;
        }

        void TinhTien()
        {
            var kq = dich.TinhGia(PhienLamViec.Gio, Ui.GiaTri(cboLoaiPhieu), Ui.GiaTri(cboKhuVuc), Ui.GiaTri(cboLoaiThe));
            if (!kq.ThanhCong)
            {
                lblTong.Text = kq.ThongBao;
                return;
            }
            var b = (BangGia)kq.DuLieu;
            lblTienHang.Text = "Tiền hàng: " + b.TienHang.ToString("N0") + " đ";
            lblPhiGiao.Text = "Phí giao hàng: " + b.PhiGiao.ToString("N0") + " đ" + (b.MienPhiGiao ? "  (MIỄN PHÍ theo giá trị đơn)" : "");
            lblPhiThe.Text = "Lệ phí thẻ: " + b.PhiThe.ToString("N0") + " đ";
            lblTong.Text = "TỔNG THANH TOÁN: " + b.Tong.ToString("N0") + " đ";
        }

        void BtnDat_Click(object sender, EventArgs e)
        {
            var nguoiNhan = new NguoiNhan
            {
                HoTen = txtTenNhan.Text,
                DiaChi = txtDiaChiNhan.Text,
                DienThoai = txtDienThoaiNhan.Text,
                MaKhuVuc = Ui.GiaTri(cboKhuVuc)
            };
            var the = new ThongTinThe
            {
                MaLoaiThe = Ui.GiaTri(cboLoaiThe),
                SoThe = txtSoThe.Text.Trim(),
                ThangHet = (int)numThang.Value,
                NamHet = (int)numNam.Value,
                TenChuThe = txtChuThe.Text,
                CSV = txtCSV.Text.Trim()
            };
            var kq = dich.DatHang(PhienLamViec.KhachHienTai, PhienLamViec.Gio, Ui.GiaTri(cboLoaiPhieu), nguoiNhan, the, DateTime.Now);
            MessageBox.Show(kq.ThongBao, kq.ThanhCong ? "Thành công" : "Không thể đặt hàng");
            txtSoThe.Clear();
            txtCSV.Clear();
            if (kq.ThanhCong) Close();
            else TinhTien();
        }
    }
}
