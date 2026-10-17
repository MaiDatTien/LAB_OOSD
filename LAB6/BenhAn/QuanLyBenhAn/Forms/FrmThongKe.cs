using System;
using System.Windows.Forms;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmThongKe : Form
    {
        readonly ThongKeService s = new ThongKeService();
        public FrmThongKe()
        {
            InitializeComponent();
            dtTu.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            dtDen.Value = DateTime.Today;
        }

        private void btnTK_Click(object a, EventArgs e)
        {
            if (dtDen.Value.Date < dtTu.Value.Date) { MessageBox.Show("Đến ngày không được trước từ ngày."); return; }
            dgvTongHop.DataSource = s.TongHop(dtTu.Value, dtDen.Value);
            dgvThuoc.DataSource = s.ThuocDaKe(dtTu.Value, dtDen.Value);
            dgvBacSi.DataSource = s.KhamTheoBacSi(dtTu.Value, dtDen.Value);
        }

        private void btnDong_Click(object a, EventArgs e) { Close(); }
    }
}
