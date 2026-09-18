using System;
using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien.Forms
{
    public partial class FrmMain : Form
    {
        // 1. Tự khai báo các control bằng code (Thay thế cho file .Designer.cs)
        private Label lblTitle;
        private Button btnDanhMuc;
        private Button btnSach;
        private Button btnDocGia;
        private Button btnMuonTra;
        private Button btnThongKe;
        private Button btnThoat;

        public FrmMain()
        {
            InitializeComponent(); // Gọi hàm tự vẽ giao diện bên dưới
        }

        // 2. Tự viết hàm vẽ giao diện và định vị tọa độ
        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.btnDanhMuc = new Button();
            this.btnSach = new Button();
            this.btnDocGia = new Button();
            this.btnMuonTra = new Button();
            this.btnThongKe = new Button();
            this.btnThoat = new Button();
            
            // Cấu hình Form chính
            this.Text = "Quản lý thư viện";
            this.ClientSize = new Size(780, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            // Cấu hình Tiêu đề
            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ THƯ VIỆN";
            this.lblTitle.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            this.lblTitle.Size = new Size(500, 50);
            this.lblTitle.Location = new Point(140, 30);

            // Cấu hình các nút bấm (giống hệt thiết kế tài liệu)
            this.btnDanhMuc.Text = "Danh mục / Nhân viên";
            this.btnDanhMuc.Size = new Size(240, 60);
            this.btnDanhMuc.Location = new Point(100, 120);
            this.btnDanhMuc.Click += new EventHandler(this.btnDanhMuc_Click);

            this.btnSach.Text = "Quản lý đầu sách";
            this.btnSach.Size = new Size(240, 60);
            this.btnSach.Location = new Point(440, 120);
            this.btnSach.Click += new EventHandler(this.btnSach_Click);

            this.btnDocGia.Text = "Độc giả và thẻ";
            this.btnDocGia.Size = new Size(240, 60);
            this.btnDocGia.Location = new Point(100, 210);
            this.btnDocGia.Click += new EventHandler(this.btnDocGia_Click);

            this.btnMuonTra.Text = "Mượn - Trả sách";
            this.btnMuonTra.Size = new Size(240, 60);
            this.btnMuonTra.Location = new Point(440, 210);
            this.btnMuonTra.Click += new EventHandler(this.btnMuonTra_Click);

            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.Size = new Size(240, 60);
            this.btnThongKe.Location = new Point(100, 300);
            this.btnThongKe.Click += new EventHandler(this.btnThongKe_Click);

            this.btnThoat.Text = "Thoát";
            this.btnThoat.Size = new Size(240, 60);
            this.btnThoat.Location = new Point(440, 300);
            this.btnThoat.Click += new EventHandler(this.btnThoat_Click);

            // Gắn các control vào màn hình
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.btnSach);
            this.Controls.Add(this.btnDocGia);
            this.Controls.Add(this.btnMuonTra);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnThoat);
        }

        // 3. Logic xử lý khi click nút
        private void btnDanhMuc_Click(object sender, EventArgs e) { MessageBox.Show("Đang dùng VS Code: Cần tự code giao diện cho FrmDanhMuc bằng tay giống file này!"); }
        private void btnSach_Click(object sender, EventArgs e) { MessageBox.Show("Đang dùng VS Code: Cần tự code giao diện cho FrmSach bằng tay!"); }
        private void btnDocGia_Click(object sender, EventArgs e) { MessageBox.Show("Đang dùng VS Code: Cần tự code giao diện cho FrmDocGia bằng tay!"); }
        private void btnMuonTra_Click(object sender, EventArgs e) { MessageBox.Show("Đang dùng VS Code: Cần tự code giao diện cho FrmMuonTra bằng tay!"); }
        private void btnThongKe_Click(object sender, EventArgs e) { MessageBox.Show("Đang dùng VS Code: Cần tự code giao diện cho FrmThongKe bằng tay!"); }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) Close();
        }
    }
}