using System;
using System.Windows.Forms;
using QuanLyBenhAn.Data;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmLichHen : Form
    {
        readonly TiepNhanService s = new TiepNhanService();
        readonly DanhMucService dm = new DanhMucService();
        public FrmLichHen() { InitializeComponent(); }

        private void Frm_Load(object a, EventArgs e)
        {
            var nv = dm.Lay("NhanVien");
            nv.DefaultView.RowFilter = "VaiTro='CSKH'";
            cboNV.DataSource = nv.DefaultView; cboNV.DisplayMember = "HoTen"; cboNV.ValueMember = "MaNV";
            dtHen.Value = DateTime.Now.AddDays(1);
        }

        void Tai() { dgvLich.DataSource = s.LayLich(txtMaHS.Text.Trim()); }
        void H(KetQuaXuLy k) { MessageBox.Show(k.ThongBao); if (k.ThanhCong) Tai(); }

        private void txtMaHS_Leave(object a, EventArgs e) { Tai(); }

        private void dtHen_ValueChanged(object a, EventArgs e)
        { lblQuy.Text = "Quý " + ((dtHen.Value.Month - 1) / 3 + 1) + "/" + dtHen.Value.Year; }

        private void btnDat_Click(object a, EventArgs e)
        { H(s.DatLichDinhKy(txtMaHS.Text.Trim(), dtHen.Value, cboNV.SelectedValue == null ? "" : cboNV.SelectedValue.ToString())); }

        private void btnHuy_Click(object a, EventArgs e)
        {
            if (dgvLich.CurrentRow == null) return;
            H(s.HuyLich(Convert.ToString(dgvLich.CurrentRow.Cells["MaLich"].Value)));
        }
    }
}
