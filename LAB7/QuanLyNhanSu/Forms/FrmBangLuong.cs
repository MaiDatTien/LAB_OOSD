using System;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public class FrmBangLuong : Form
    {
        readonly BangLuongService s = new BangLuongService();
        readonly DanhMucService dm = new DanhMucService();

        public FrmBangLuong()
        {
            Ui.CauHinh(this, "Bảng lương tháng", 1250, 680);
            var txtSoBL = Ui.Txt();
            var numThang = Ui.Num(12, 0, DateTime.Today.Month); numThang.Minimum = 1;
            var numNam = Ui.Num(2100, 0, DateTime.Today.Year); numNam.ThousandsSeparator = false; numNam.Minimum = 2000;
            var cboKT = Ui.Cbo();
            var btnTinh = Ui.Btn("Tính bảng lương"); var btnChot = Ui.Btn("Chốt bảng lương"); var btnDong = Ui.Btn("Đóng");
            var dgvBL = Ui.Dgv(160); var dgvCT = Ui.Dgv();

            var g = Ui.Luoi(4);
            Ui.Them(g, "Số bảng lương", txtSoBL); Ui.Them(g, "Tháng", numThang); Ui.Them(g, "Năm", numNam); Ui.Them(g, "Kế toán lập", cboKT);
            var ghiChu = Ui.Lbl("Lương = lương cơ bản x giờ làm / 208 + phụ cấp + giờ phụ trội x 1.5 - BHXH - BHYT - tiền phạt trừ lương.");
            Ui.Doc(this, g, Ui.Hang(btnTinh, btnChot, btnDong), ghiChu, dgvBL, dgvCT);

            Action tai = () =>
            {
                Ui.Nap(cboKT, dm.LayNhanVienTheoVaiTro("Kế toán"), "HienThi", "MaNV");
                dgvBL.DataSource = s.LayBangLuong();
            };
            dgvBL.SelectionChanged += (o, ev) =>
            {
                if (dgvBL.CurrentRow == null) return;
                dgvCT.DataSource = s.LayChiTiet(Convert.ToString(dgvBL.CurrentRow.Cells["SoBangLuong"].Value));
            };
            btnTinh.Click += (o, ev) =>
            {
                if (Ui.Bao(s.TinhBangLuong(txtSoBL.Text.Trim(), (int)numThang.Value, (int)numNam.Value, Ui.V(cboKT)))) tai();
            };
            btnChot.Click += (o, ev) =>
            {
                if (dgvBL.CurrentRow == null) { MessageBox.Show("Chọn bảng lương cần chốt."); return; }
                if (Ui.Bao(s.ChotBangLuong(Convert.ToString(dgvBL.CurrentRow.Cells["SoBangLuong"].Value)))) tai();
            };
            btnDong.Click += (o, ev) => Close();
            Load += (o, ev) => tai();
        }
    }
}
