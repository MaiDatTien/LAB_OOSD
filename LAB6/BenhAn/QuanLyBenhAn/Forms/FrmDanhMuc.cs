using System;
using System.Windows.Forms;
using QuanLyBenhAn.Data;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmDanhMuc : Form
    {
        readonly DanhMucService s = new DanhMucService();
        public FrmDanhMuc() { InitializeComponent(); }

        private void Frm_Load(object a, EventArgs e)
        {
            cboNVVaiTro.Items.AddRange(new object[] { "CSKH", "Thu ngân", "KTV xét nghiệm", "Quản lý" });
            cboNVVaiTro.SelectedIndex = 0;
            Tai();
        }

        void Tai()
        {
            dgvKhoa.DataSource = s.Lay("Khoa");
            dgvBS.DataSource = s.Lay("BacSi");
            dgvNV.DataSource = s.Lay("NhanVien");
            dgvTC.DataSource = s.Lay("TrieuChung");
            dgvXN.DataSource = s.Lay("LoaiXetNghiem");
            dgvThuoc.DataSource = s.Lay("Thuoc");
            cboBSKhoa.DataSource = s.Lay("Khoa");
            cboBSKhoa.DisplayMember = "TenKhoa"; cboBSKhoa.ValueMember = "MaKhoa";
        }

        void H(KetQuaXuLy k) { MessageBox.Show(k.ThongBao); if (k.ThanhCong) Tai(); }

        private void btnThemKhoa_Click(object a, EventArgs e)
        { H(s.ThemKhoa(txtKhoaMa.Text.Trim(), txtKhoaTen.Text.Trim(), numKhoaPhi.Value)); }

        private void btnThemBS_Click(object a, EventArgs e)
        {
            H(s.ThemBacSi(txtBSMa.Text.Trim(), txtBSTen.Text.Trim(), txtBSChuyenMon.Text.Trim(),
                cboBSKhoa.SelectedValue == null ? "" : cboBSKhoa.SelectedValue.ToString()));
        }

        private void btnThemNV_Click(object a, EventArgs e)
        { H(s.ThemNhanVien(txtNVMa.Text.Trim(), txtNVTen.Text.Trim(), cboNVVaiTro.Text)); }

        private void btnThemTC_Click(object a, EventArgs e)
        { H(s.ThemTrieuChung(txtTCMa.Text.Trim(), txtTCTen.Text.Trim(), txtTCDonVi.Text.Trim())); }

        private void btnThemXN_Click(object a, EventArgs e)
        { H(s.ThemLoaiXN(txtXNMa.Text.Trim(), txtXNTen.Text.Trim(), numXNGia.Value)); }

        private void btnThemThuoc_Click(object a, EventArgs e)
        {
            H(s.ThemThuoc(txtThuocMa.Text.Trim(), txtThuocTen.Text.Trim(), txtThuocDVT.Text.Trim(),
                txtThuocHC.Text.Trim(), txtThuocCCD.Text.Trim(), numThuocGia.Value));
        }
    }
}
