using System;
using System.Windows.Forms;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain() { InitializeComponent(); }

        void Mo(Form f) { using (f) f.ShowDialog(this); }

        private void btnDanhMuc_Click(object s, EventArgs e) { Mo(new FrmDanhMuc()); }
        private void btnTiepNhan_Click(object s, EventArgs e) { Mo(new FrmTiepNhan()); }
        private void btnLichHen_Click(object s, EventArgs e) { Mo(new FrmLichHen()); }
        private void btnKhamBenh_Click(object s, EventArgs e) { Mo(new FrmKhamBenh()); }
        private void btnXetNghiem_Click(object s, EventArgs e) { Mo(new FrmKetQuaXN()); }
        private void btnThanhToan_Click(object s, EventArgs e) { Mo(new FrmThanhToan()); }
        private void btnThongKe_Click(object s, EventArgs e) { Mo(new FrmThongKe()); }
        private void btnThoat_Click(object s, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
        }
    }
}
