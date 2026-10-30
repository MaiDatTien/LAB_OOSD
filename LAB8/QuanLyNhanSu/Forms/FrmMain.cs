using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyNhanSu.Forms
{
    public class FrmMain : Form
    {
        public FrmMain()
        {
            Ui.CauHinh(this, "Quản lý nhân sự - Công ty sơn Đông Á", 760, 440);
            StartPosition = FormStartPosition.CenterScreen;

            var tieuDe = new Label
            {
                Text = "HỆ THỐNG QUẢN LÝ NHÂN SỰ", AutoSize = false, Height = 80, TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 20, FontStyle.Bold), ForeColor = Color.FromArgb(0, 51, 102)
            };
            var luoi = new TableLayoutPanel { ColumnCount = 3, RowCount = 3, Padding = new Padding(20), Tag = "fill" };
            for (int i = 0; i < 3; i++)
            {
                luoi.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33f));
                luoi.RowStyles.Add(new RowStyle(SizeType.Percent, 33.33f));
            }
            luoi.Controls.Add(Nut("Danh mục", () => new FrmDanhMuc()));
            luoi.Controls.Add(Nut("Tuyển dụng - Hợp đồng", () => new FrmTuyenDung()));
            luoi.Controls.Add(Nut("QĐ chức vụ - lương", () => new FrmQuyetDinh()));
            luoi.Controls.Add(Nut("Chấm công - Phụ trội", () => new FrmChamCong()));
            luoi.Controls.Add(Nut("Bảng lương", () => new FrmBangLuong()));
            luoi.Controls.Add(Nut("Khen thưởng - Kỷ luật", () => new FrmKhenThuongKyLuat()));
            var thoat = new Button { Text = "Thoát", Dock = DockStyle.Fill, Margin = new Padding(10), Font = new Font("Segoe UI", 11) };
            thoat.Click += (o, ev) =>
            {
                if (MessageBox.Show("Bạn có thực sự muốn thoát?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
            };
            luoi.Controls.Add(thoat, 1, 2);
            Ui.Doc(this, tieuDe, luoi);
        }

        Button Nut(string text, Func<Form> tao)
        {
            var b = new Button { Text = text, Dock = DockStyle.Fill, Margin = new Padding(10), Font = new Font("Segoe UI", 11) };
            b.Click += (o, ev) => { using (var f = tao()) f.ShowDialog(this); };
            return b;
        }
    }
}
