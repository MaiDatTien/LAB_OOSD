using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using QuanLyBenhAn.Data;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmTiepNhan : Form
    {
        readonly TiepNhanService s = new TiepNhanService();
        readonly KhamBenhService kb = new KhamBenhService();
        readonly DanhMucService dm = new DanhMucService();
        byte[] anh;
        public FrmTiepNhan() { InitializeComponent(); }

        string V(ComboBox c) { return c.SelectedValue == null ? "" : c.SelectedValue.ToString(); }
        static Image ToImage(byte[] b)
        { return (b == null || b.Length == 0) ? null : new Bitmap(new MemoryStream(b)); }

        private void Frm_Load(object a, EventArgs e)
        {
            var nv = dm.Lay("NhanVien");
            nv.DefaultView.RowFilter = "VaiTro='CSKH'";
            cboNV.DataSource = nv.DefaultView; cboNV.DisplayMember = "HoTen"; cboNV.ValueMember = "MaNV";
            cboHT.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" });
            cboHTGH.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" });
            cboHT.SelectedIndex = 0; cboHTGH.SelectedIndex = 0;
        }

        private void btnChonAnh_Click(object a, EventArgs e)
        {
            using (var d = new OpenFileDialog { Filter = "Ảnh|*.jpg;*.jpeg;*.png" })
            {
                if (d.ShowDialog() != DialogResult.OK) return;
                var b = File.ReadAllBytes(d.FileName);
                if (b.Length > 2 * 1024 * 1024) { MessageBox.Show("Ảnh tối đa 2 MB."); return; }
                anh = b; picAnh.Image = ToImage(b);
            }
        }

        private void btnDangKy_Click(object a, EventArgs e)
        {
            var k = s.DangKyLanDau(txtTen.Text.Trim(), txtDiaChi.Text.Trim(), dtNgaySinh.Value, txtSDT.Text.Trim(),
                anh, numLePhi.Value, cboHT.Text, V(cboNV));
            MessageBox.Show(k.ThongBao);
            if (k.ThanhCong) lblMaHS.Text = "Mã hồ sơ: " + k.Data;
        }

        private void btnGiaHan_Click(object a, EventArgs e)
        {
            var k = s.GiaHan(txtHSGiaHan.Text.Trim(), numLePhiGH.Value, cboHTGH.Text, V(cboNV));
            MessageBox.Show(k.ThongBao);
        }

        private void btnTim_Click(object a, EventArgs e) { dgvHoSo.DataSource = s.TimHoSo(txtTuKhoa.Text); }

        private void dgvHoSo_SelectionChanged(object a, EventArgs e)
        {
            if (dgvHoSo.CurrentRow == null) return;
            string hs = Convert.ToString(dgvHoSo.CurrentRow.Cells["MaHS"].Value);
            picAnhHS.Image = ToImage(s.LayAnh(hs));
            dgvLichSu.DataSource = s.LayLichSuKham(hs);
        }

        private void dgvLichSu_SelectionChanged(object a, EventArgs e)
        {
            if (dgvLichSu.CurrentRow == null) return;
            string pk = Convert.ToString(dgvLichSu.CurrentRow.Cells["SoPhieuKham"].Value);
            dgvTrieuChung.DataSource = kb.LayTrieuChung(pk);
            dgvXNChon.DataSource = kb.LayXetNghiem(pk);
            dgvToa.DataSource = kb.LayToa(pk);
        }
    }
}
