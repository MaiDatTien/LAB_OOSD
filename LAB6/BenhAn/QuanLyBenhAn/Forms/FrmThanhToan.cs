using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmThanhToan : Form
    {
        readonly ThanhToanService s = new ThanhToanService();
        readonly DanhMucService dm = new DanhMucService();
        public FrmThanhToan() { InitializeComponent(); }

        string V(ComboBox c) { return c.SelectedValue == null ? "" : c.SelectedValue.ToString(); }

        private void Frm_Load(object a, EventArgs e)
        {
            var nv = dm.Lay("NhanVien");
            nv.DefaultView.RowFilter = "VaiTro='Thu ngân'";
            cboNV.DataSource = nv.DefaultView; cboNV.DisplayMember = "HoTen"; cboNV.ValueMember = "MaNV";
            cboHT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" });
            cboHT.SelectedIndex = 0;
            Tai();
        }

        void Tai()
        {
            cboPhieu.DataSource = s.LayPhieuChoThanhToan();
            cboPhieu.DisplayMember = "SoPhieuKham"; cboPhieu.ValueMember = "SoPhieuKham";
            dgvHD.DataSource = s.LayHoaDon();
        }

        private void btnLapHD_Click(object a, EventArgs e)
        { var k = s.LapHoaDon(V(cboPhieu), V(cboNV)); MessageBox.Show(k.ThongBao); Tai(); }

        private void dgvHD_SelectionChanged(object a, EventArgs e)
        {
            if (dgvHD.CurrentRow == null) return;
            var c = dgvHD.CurrentRow.Cells;
            txtHDChon.Text = Convert.ToString(c["SoHoaDon"].Value);
            txtPhieuChon.Text = Convert.ToString(c["SoPhieuKham"].Value);
            decimal con = Convert.ToDecimal(c["TongTien"].Value) - Convert.ToDecimal(c["DaTra"].Value);
            lblConLai.Text = "Còn phải trả: " + con.ToString("N0");
            numTien.Value = Math.Min(numTien.Maximum, Math.Max(numTien.Minimum, con));
        }

        private void btnThanhToan_Click(object a, EventArgs e)
        { var k = s.ThanhToan(txtHDChon.Text.Trim(), cboHT.Text, numTien.Value); MessageBox.Show(k.ThongBao); Tai(); }

        private void btnHoanTat_Click(object a, EventArgs e)
        { var k = s.HoanTat(txtPhieuChon.Text.Trim()); MessageBox.Show(k.ThongBao); Tai(); }

        private void btnDong_Click(object a, EventArgs e) { Close(); }
    }
}
