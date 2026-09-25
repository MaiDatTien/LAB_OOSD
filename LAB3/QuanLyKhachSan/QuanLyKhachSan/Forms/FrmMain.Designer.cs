namespace QuanLyKhachSan.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }
        private void InitializeComponent()
        {
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnPhong = new System.Windows.Forms.Button();
            this.btnDatPhong = new System.Windows.Forms.Button();
            this.btnDichVu = new System.Windows.Forms.Button();
            this.btnTraPhong = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.lblTitle.Text = "HỆ THỐNG QUẢN LÝ KHÁCH SẠN";
            this.lblTitle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(0, 51, 102);
            this.lblTitle.Location = new System.Drawing.Point(200, 30);
            this.lblTitle.Size = new System.Drawing.Size(450, 40);
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            System.Drawing.Size btnSize = new System.Drawing.Size(220, 60);
            System.Drawing.Font btnFont = new System.Drawing.Font("Arial", 11F);

            void StyleButton(System.Windows.Forms.Button b, System.Drawing.Image icon)
            {
                b.Size = btnSize;
                b.Font = btnFont;
                b.Image = icon;
                b.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                b.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
                b.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
                b.Padding = new System.Windows.Forms.Padding(15, 0, 10, 0);
            }

            this.btnDanhMuc.Text = "Danh mục"; this.btnDanhMuc.Location = new System.Drawing.Point(50, 100);
            this.btnPhong.Text = "Phòng - Tiện nghi"; this.btnPhong.Location = new System.Drawing.Point(300, 100);
            this.btnDatPhong.Text = "Đặt / Nhận phòng"; this.btnDatPhong.Location = new System.Drawing.Point(550, 100);
            this.btnDichVu.Text = "Sử dụng dịch vụ"; this.btnDichVu.Location = new System.Drawing.Point(50, 190);
            this.btnTraPhong.Text = "Trả phòng - Thanh toán"; this.btnTraPhong.Location = new System.Drawing.Point(300, 190);
            this.btnThongKe.Text = "Thống kê"; this.btnThongKe.Location = new System.Drawing.Point(550, 190);
            this.btnThoat.Text = "Thoát"; this.btnThoat.Location = new System.Drawing.Point(300, 280);

            StyleButton(this.btnDanhMuc, IconHelper.DanhMuc());
            StyleButton(this.btnPhong, IconHelper.Phong());
            StyleButton(this.btnDatPhong, IconHelper.DatPhong());
            StyleButton(this.btnDichVu, IconHelper.DichVu());
            StyleButton(this.btnTraPhong, IconHelper.TraPhong());
            StyleButton(this.btnThongKe, IconHelper.ThongKe());
            StyleButton(this.btnThoat, IconHelper.Thoat());

            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            this.btnPhong.Click += new System.EventHandler(this.btnPhong_Click);
            this.btnDatPhong.Click += new System.EventHandler(this.btnDatPhong_Click);
            this.btnDichVu.Click += new System.EventHandler(this.btnDichVu_Click);
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);

            this.ClientSize = new System.Drawing.Size(820, 380);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { this.lblTitle, this.btnDanhMuc, this.btnPhong, this.btnDatPhong, this.btnDichVu, this.btnTraPhong, this.btnThongKe, this.btnThoat });
            this.Text = "Quản lý khách sạn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnDanhMuc, btnPhong, btnDatPhong, btnDichVu, btnTraPhong, btnThongKe, btnThoat;
    }
}