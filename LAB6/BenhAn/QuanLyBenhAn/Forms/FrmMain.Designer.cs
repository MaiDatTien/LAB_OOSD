namespace QuanLyBenhAn.Forms
{
    partial class FrmMain
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.btnDanhMuc = new System.Windows.Forms.Button();
            this.btnTiepNhan = new System.Windows.Forms.Button();
            this.btnLichHen = new System.Windows.Forms.Button();
            this.btnKhamBenh = new System.Windows.Forms.Button();
            this.btnXetNghiem = new System.Windows.Forms.Button();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnThongKe = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.Location = new System.Drawing.Point(95, 28);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Text = "HỆ THỐNG QUẢN LÝ HỒ SƠ BỆNH ÁN";
            this.lblTieuDe.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTieuDe.TabIndex = 0;
            // 
            // btnDanhMuc
            // 
            this.btnDanhMuc.Location = new System.Drawing.Point(40, 105);
            this.btnDanhMuc.Name = "btnDanhMuc";
            this.btnDanhMuc.Size = new System.Drawing.Size(220, 55);
            this.btnDanhMuc.Text = "Danh mục";
            this.btnDanhMuc.UseVisualStyleBackColor = true;
            this.btnDanhMuc.TabIndex = 1;
            this.btnDanhMuc.Click += new System.EventHandler(this.btnDanhMuc_Click);
            // 
            // btnTiepNhan
            // 
            this.btnTiepNhan.Location = new System.Drawing.Point(290, 105);
            this.btnTiepNhan.Name = "btnTiepNhan";
            this.btnTiepNhan.Size = new System.Drawing.Size(220, 55);
            this.btnTiepNhan.Text = "Tiếp nhận – Hồ sơ";
            this.btnTiepNhan.UseVisualStyleBackColor = true;
            this.btnTiepNhan.TabIndex = 2;
            this.btnTiepNhan.Click += new System.EventHandler(this.btnTiepNhan_Click);
            // 
            // btnLichHen
            // 
            this.btnLichHen.Location = new System.Drawing.Point(540, 105);
            this.btnLichHen.Name = "btnLichHen";
            this.btnLichHen.Size = new System.Drawing.Size(220, 55);
            this.btnLichHen.Text = "Lịch khám định kỳ";
            this.btnLichHen.UseVisualStyleBackColor = true;
            this.btnLichHen.TabIndex = 3;
            this.btnLichHen.Click += new System.EventHandler(this.btnLichHen_Click);
            // 
            // btnKhamBenh
            // 
            this.btnKhamBenh.Location = new System.Drawing.Point(40, 185);
            this.btnKhamBenh.Name = "btnKhamBenh";
            this.btnKhamBenh.Size = new System.Drawing.Size(220, 55);
            this.btnKhamBenh.Text = "Khám bệnh – Toa thuốc";
            this.btnKhamBenh.UseVisualStyleBackColor = true;
            this.btnKhamBenh.TabIndex = 4;
            this.btnKhamBenh.Click += new System.EventHandler(this.btnKhamBenh_Click);
            // 
            // btnXetNghiem
            // 
            this.btnXetNghiem.Location = new System.Drawing.Point(290, 185);
            this.btnXetNghiem.Name = "btnXetNghiem";
            this.btnXetNghiem.Size = new System.Drawing.Size(220, 55);
            this.btnXetNghiem.Text = "Kết quả xét nghiệm";
            this.btnXetNghiem.UseVisualStyleBackColor = true;
            this.btnXetNghiem.TabIndex = 5;
            this.btnXetNghiem.Click += new System.EventHandler(this.btnXetNghiem_Click);
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(540, 185);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(220, 55);
            this.btnThanhToan.Text = "Thanh toán – Hoàn tất";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnThongKe
            // 
            this.btnThongKe.Location = new System.Drawing.Point(165, 265);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(220, 55);
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = true;
            this.btnThongKe.TabIndex = 7;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(415, 265);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(220, 55);
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.TabIndex = 8;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 380);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý hồ sơ bệnh án";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.Add(this.lblTieuDe);
            this.Controls.Add(this.btnDanhMuc);
            this.Controls.Add(this.btnTiepNhan);
            this.Controls.Add(this.btnLichHen);
            this.Controls.Add(this.btnKhamBenh);
            this.Controls.Add(this.btnXetNghiem);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.btnThoat);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Button btnDanhMuc;
        private System.Windows.Forms.Button btnTiepNhan;
        private System.Windows.Forms.Button btnLichHen;
        private System.Windows.Forms.Button btnKhamBenh;
        private System.Windows.Forms.Button btnXetNghiem;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnThongKe;
        private System.Windows.Forms.Button btnThoat;
    }
}
