using System;
using System.Data;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmKetQuaXN : Form
    {
        readonly KhamBenhService s = new KhamBenhService();
        readonly DanhMucService dm = new DanhMucService();
        public FrmKetQuaXN() { InitializeComponent(); }

        private void Frm_Load(object a, EventArgs e)
        {
            var nv = dm.Lay("NhanVien");
            nv.DefaultView.RowFilter = "VaiTro='KTV xét nghiệm'";
            cboKTV.DataSource = nv.DefaultView; cboKTV.DisplayMember = "HoTen"; cboKTV.ValueMember = "MaNV";
            Tai();
        }

        void Tai() { dgvChoKQ.DataSource = s.LayXNChoKetQua(); }

        private void btnLuu_Click(object a, EventArgs e)
        {
            if (dgvChoKQ.CurrentRow == null) return;
            string pk = Convert.ToString(dgvChoKQ.CurrentRow.Cells["SoPhieuKham"].Value);
            string xn = Convert.ToString(dgvChoKQ.CurrentRow.Cells["MaLoaiXN"].Value);
            var k = s.NhapKetQuaXN(pk, xn, txtKetQua.Text.Trim(), cboKTV.SelectedValue == null ? "" : cboKTV.SelectedValue.ToString());
            MessageBox.Show(k.ThongBao);
            if (k.ThanhCong) { txtKetQua.Clear(); Tai(); }
        }

        private void btnLamMoi_Click(object a, EventArgs e) { Tai(); }
    }
}
