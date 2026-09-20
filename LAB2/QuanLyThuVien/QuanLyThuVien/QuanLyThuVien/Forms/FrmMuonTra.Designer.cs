namespace QuanLyThuVien.Forms
{
    partial class FrmMuonTra
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabMuon = new System.Windows.Forms.TabPage();
            this.btnLapPhieu = new System.Windows.Forms.Button();
            this.dgvSachChon = new System.Windows.Forms.DataGridView();
            this.btnBoSach = new System.Windows.Forms.Button();
            this.btnThemSach = new System.Windows.Forms.Button();
            this.dgvSachCon = new System.Windows.Forms.DataGridView();
            this.dtHenTra = new System.Windows.Forms.DateTimePicker();
            this.dtNgayMuon = new System.Windows.Forms.DateTimePicker();
            this.cboNhanVienMuon = new System.Windows.Forms.ComboBox();
            this.lblTrangThai = new System.Windows.Forms.Label();
            this.btnKiemTra = new System.Windows.Forms.Button();
            this.cboDocGia = new System.Windows.Forms.ComboBox();
            this.lblM6 = new System.Windows.Forms.Label();
            this.lblM5 = new System.Windows.Forms.Label();
            this.lblM4 = new System.Windows.Forms.Label();
            this.lblM3 = new System.Windows.Forms.Label();
            this.lblM2 = new System.Windows.Forms.Label();
            this.lblM1 = new System.Windows.Forms.Label();
            this.tabTra = new System.Windows.Forms.TabPage();
            this.btnTraSach = new System.Windows.Forms.Button();
            this.numPhiPhat = new System.Windows.Forms.NumericUpDown();
            this.cboTinhTrang = new System.Windows.Forms.ComboBox();
            this.dtNgayTra = new System.Windows.Forms.DateTimePicker();
            this.dgvDangMuon = new System.Windows.Forms.DataGridView();
            this.cboNhanVienTra = new System.Windows.Forms.ComboBox();
            this.btnTaiSachMuon = new System.Windows.Forms.Button();
            this.cboDocGiaTra = new System.Windows.Forms.ComboBox();
            this.lblT6 = new System.Windows.Forms.Label();
            this.lblT5 = new System.Windows.Forms.Label();
            this.lblT4 = new System.Windows.Forms.Label();
            this.lblT3 = new System.Windows.Forms.Label();
            this.lblT2 = new System.Windows.Forms.Label();
            this.lblT1 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabMuon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).BeginInit();
            this.tabTra.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).BeginInit();
            this.SuspendLayout();
          
            this.tabs.Controls.Add(this.tabMuon);
            this.tabs.Controls.Add(this.tabTra);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1160, 650);
            this.tabs.TabIndex = 0;
          
            this.tabMuon.Controls.Add(this.btnLapPhieu);
            this.tabMuon.Controls.Add(this.dgvSachChon);
            this.tabMuon.Controls.Add(this.btnBoSach);
            this.tabMuon.Controls.Add(this.btnThemSach);
            this.tabMuon.Controls.Add(this.dgvSachCon);
            this.tabMuon.Controls.Add(this.dtHenTra);
            this.tabMuon.Controls.Add(this.dtNgayMuon);
            this.tabMuon.Controls.Add(this.cboNhanVienMuon);
            this.tabMuon.Controls.Add(this.lblTrangThai);
            this.tabMuon.Controls.Add(this.btnKiemTra);
            this.tabMuon.Controls.Add(this.cboDocGia);
            this.tabMuon.Controls.Add(this.lblM6);
            this.tabMuon.Controls.Add(this.lblM5);
            this.tabMuon.Controls.Add(this.lblM4);
            this.tabMuon.Controls.Add(this.lblM3);
            this.tabMuon.Controls.Add(this.lblM2);
            this.tabMuon.Controls.Add(this.lblM1);
            this.tabMuon.Location = new System.Drawing.Point(4, 30);
            this.tabMuon.Name = "tabMuon";
            this.tabMuon.Padding = new System.Windows.Forms.Padding(3);
            this.tabMuon.Size = new System.Drawing.Size(1152, 616);
            this.tabMuon.TabIndex = 0;
            this.tabMuon.Text = "Mượn sách";
            this.tabMuon.UseVisualStyleBackColor = true;
          
            this.btnLapPhieu.Location = new System.Drawing.Point(950, 560);
            this.btnLapPhieu.Name = "btnLapPhieu";
            this.btnLapPhieu.Size = new System.Drawing.Size(180, 40);
            this.btnLapPhieu.TabIndex = 16;
            this.btnLapPhieu.Text = "Lập phiếu mượn";
            this.btnLapPhieu.UseVisualStyleBackColor = true;
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);
         
            this.dgvSachChon.AllowUserToAddRows = false;
            this.dgvSachChon.AllowUserToDeleteRows = false;
            this.dgvSachChon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachChon.Location = new System.Drawing.Point(640, 180);
            this.dgvSachChon.MultiSelect = false;
            this.dgvSachChon.Name = "dgvSachChon";
            this.dgvSachChon.ReadOnly = true;
            this.dgvSachChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachChon.Size = new System.Drawing.Size(490, 360);
            this.dgvSachChon.TabIndex = 15;
         
            this.btnBoSach.Location = new System.Drawing.Point(520, 360);
            this.btnBoSach.Name = "btnBoSach";
            this.btnBoSach.Size = new System.Drawing.Size(100, 40);
            this.btnBoSach.TabIndex = 14;
            this.btnBoSach.Text = "<< Bỏ";
            this.btnBoSach.UseVisualStyleBackColor = true;
            this.btnBoSach.Click += new System.EventHandler(this.btnBoSach_Click);
           
            this.btnThemSach.Location = new System.Drawing.Point(520, 300);
            this.btnThemSach.Name = "btnThemSach";
            this.btnThemSach.Size = new System.Drawing.Size(100, 40);
            this.btnThemSach.TabIndex = 13;
            this.btnThemSach.Text = "Thêm >>";
            this.btnThemSach.UseVisualStyleBackColor = true;
            this.btnThemSach.Click += new System.EventHandler(this.btnThemSach_Click);
         
            this.dgvSachCon.AllowUserToAddRows = false;
            this.dgvSachCon.AllowUserToDeleteRows = false;
            this.dgvSachCon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSachCon.Location = new System.Drawing.Point(20, 180);
            this.dgvSachCon.MultiSelect = false;
            this.dgvSachCon.Name = "dgvSachCon";
            this.dgvSachCon.ReadOnly = true;
            this.dgvSachCon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSachCon.Size = new System.Drawing.Size(480, 360);
            this.dgvSachCon.TabIndex = 12;
          
            this.dtHenTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHenTra.Location = new System.Drawing.Point(740, 72);
            this.dtHenTra.Name = "dtHenTra";
            this.dtHenTra.Size = new System.Drawing.Size(200, 29);
            this.dtHenTra.TabIndex = 11;
            
            this.dtNgayMuon.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayMuon.Location = new System.Drawing.Point(440, 72);
            this.dtNgayMuon.Name = "dtNgayMuon";
            this.dtNgayMuon.Size = new System.Drawing.Size(200, 29);
            this.dtNgayMuon.TabIndex = 10;
            
            this.cboNhanVienMuon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVienMuon.FormattingEnabled = true;
            this.cboNhanVienMuon.Location = new System.Drawing.Point(170, 72);
            this.cboNhanVienMuon.Name = "cboNhanVienMuon";
            this.cboNhanVienMuon.Size = new System.Drawing.Size(180, 29);
            this.cboNhanVienMuon.TabIndex = 9;
            
        
            this.lblTrangThai.AutoSize = true;
            this.lblTrangThai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTrangThai.Location = new System.Drawing.Point(520, 25);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(0, 21);
            this.lblTrangThai.TabIndex = 8;
         
            this.btnKiemTra.Location = new System.Drawing.Point(360, 20);
            this.btnKiemTra.Name = "btnKiemTra";
            this.btnKiemTra.Size = new System.Drawing.Size(140, 35);
            this.btnKiemTra.TabIndex = 7;
            this.btnKiemTra.Text = "Kiểm tra điều kiện";
            this.btnKiemTra.UseVisualStyleBackColor = true;
            this.btnKiemTra.Click += new System.EventHandler(this.btnKiemTra_Click);
          
            this.cboDocGia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGia.FormattingEnabled = true;
            this.cboDocGia.Location = new System.Drawing.Point(100, 22);
            this.cboDocGia.Name = "cboDocGia";
            this.cboDocGia.Size = new System.Drawing.Size(250, 29);
            this.cboDocGia.TabIndex = 6;
         
            this.lblM6.AutoSize = true;
            this.lblM6.Location = new System.Drawing.Point(640, 150);
            this.lblM6.Name = "lblM6";
            this.lblM6.Size = new System.Drawing.Size(176, 21);
            this.lblM6.Text = "Sách đã chọn (tối đa 3):";
         
            this.lblM5.AutoSize = true;
            this.lblM5.Location = new System.Drawing.Point(20, 150);
            this.lblM5.Name = "lblM5";
            this.lblM5.Size = new System.Drawing.Size(150, 21);
            this.lblM5.Text = "Sách còn trong kho:";
          
            this.lblM4.AutoSize = true;
            this.lblM4.Location = new System.Drawing.Point(660, 75);
            this.lblM4.Name = "lblM4";
            this.lblM4.Size = new System.Drawing.Size(64, 21);
            this.lblM4.Text = "Hẹn trả:";
            
            this.lblM3.AutoSize = true;
            this.lblM3.Location = new System.Drawing.Point(360, 75);
            this.lblM3.Name = "lblM3";
            this.lblM3.Size = new System.Drawing.Size(95, 21);
            this.lblM3.Text = "Ngày mượn:";
          
            this.lblM2.AutoSize = true;
            this.lblM2.Location = new System.Drawing.Point(20, 75);
            this.lblM2.Name = "lblM2";
            this.lblM2.Size = new System.Drawing.Size(147, 21);
            this.lblM2.Text = "Nhân viên lập phiếu:";
           
            this.lblM1.AutoSize = true;
            this.lblM1.Location = new System.Drawing.Point(20, 25);
            this.lblM1.Name = "lblM1";
            this.lblM1.Size = new System.Drawing.Size(65, 21);
            this.lblM1.Text = "Độc giả:";
         
            this.tabTra.Controls.Add(this.btnTraSach);
            this.tabTra.Controls.Add(this.numPhiPhat);
            this.tabTra.Controls.Add(this.cboTinhTrang);
            this.tabTra.Controls.Add(this.dtNgayTra);
            this.tabTra.Controls.Add(this.dgvDangMuon);
            this.tabTra.Controls.Add(this.cboNhanVienTra);
            this.tabTra.Controls.Add(this.btnTaiSachMuon);
            this.tabTra.Controls.Add(this.cboDocGiaTra);
            this.tabTra.Controls.Add(this.lblT6);
            this.tabTra.Controls.Add(this.lblT5);
            this.tabTra.Controls.Add(this.lblT4);
            this.tabTra.Controls.Add(this.lblT3);
            this.tabTra.Controls.Add(this.lblT2);
            this.tabTra.Controls.Add(this.lblT1);
            this.tabTra.Location = new System.Drawing.Point(4, 30);
            this.tabTra.Name = "tabTra";
            this.tabTra.Padding = new System.Windows.Forms.Padding(3);
            this.tabTra.Size = new System.Drawing.Size(1152, 616);
            this.tabTra.TabIndex = 1;
            this.tabTra.Text = "Trả sách";
            this.tabTra.UseVisualStyleBackColor = true;
        
            this.btnTraSach.Location = new System.Drawing.Point(950, 560);
            this.btnTraSach.Name = "btnTraSach";
            this.btnTraSach.Size = new System.Drawing.Size(180, 40);
            this.btnTraSach.TabIndex = 13;
            this.btnTraSach.Text = "Xác nhận trả sách";
            this.btnTraSach.UseVisualStyleBackColor = true;
            this.btnTraSach.Click += new System.EventHandler(this.btnTraSach_Click);
         
            this.numPhiPhat.Location = new System.Drawing.Point(620, 520);
            this.numPhiPhat.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            this.numPhiPhat.Name = "numPhiPhat";
            this.numPhiPhat.Size = new System.Drawing.Size(200, 29);
            this.numPhiPhat.TabIndex = 12;
          
            this.cboTinhTrang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTinhTrang.FormattingEnabled = true;
            this.cboTinhTrang.Location = new System.Drawing.Point(620, 475);
            this.cboTinhTrang.Name = "cboTinhTrang";
            this.cboTinhTrang.Size = new System.Drawing.Size(200, 29);
            this.cboTinhTrang.TabIndex = 11;
       
            this.dtNgayTra.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNgayTra.Location = new System.Drawing.Point(180, 520);
            this.dtNgayTra.Name = "dtNgayTra";
            this.dtNgayTra.Size = new System.Drawing.Size(200, 29);
            this.dtNgayTra.TabIndex = 10;
          
            this.dgvDangMuon.AllowUserToAddRows = false;
            this.dgvDangMuon.AllowUserToDeleteRows = false;
            this.dgvDangMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDangMuon.Location = new System.Drawing.Point(20, 130);
            this.dgvDangMuon.MultiSelect = false;
            this.dgvDangMuon.Name = "dgvDangMuon";
            this.dgvDangMuon.ReadOnly = true;
            this.dgvDangMuon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDangMuon.Size = new System.Drawing.Size(1110, 320);
            this.dgvDangMuon.TabIndex = 9;
         
            this.cboNhanVienTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNhanVienTra.FormattingEnabled = true;
            this.cboNhanVienTra.Location = new System.Drawing.Point(180, 475);
            this.cboNhanVienTra.Name = "cboNhanVienTra";
            this.cboNhanVienTra.Size = new System.Drawing.Size(200, 29);
            this.cboNhanVienTra.TabIndex = 8;
       
            this.btnTaiSachMuon.Location = new System.Drawing.Point(360, 20);
            this.btnTaiSachMuon.Name = "btnTaiSachMuon";
            this.btnTaiSachMuon.Size = new System.Drawing.Size(160, 35);
            this.btnTaiSachMuon.TabIndex = 7;
            this.btnTaiSachMuon.Text = "Tải sách đang mượn";
            this.btnTaiSachMuon.UseVisualStyleBackColor = true;
            this.btnTaiSachMuon.Click += new System.EventHandler(this.btnTaiSachMuon_Click);
         
            this.cboDocGiaTra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocGiaTra.FormattingEnabled = true;
            this.cboDocGiaTra.Location = new System.Drawing.Point(100, 22);
            this.cboDocGiaTra.Name = "cboDocGiaTra";
            this.cboDocGiaTra.Size = new System.Drawing.Size(250, 29);
            this.cboDocGiaTra.TabIndex = 6;
            this.cboDocGiaTra.SelectedIndexChanged += new System.EventHandler(this.cboDocGiaTra_SelectedIndexChanged);
        
            this.lblT6.AutoSize = true;
            this.lblT6.Location = new System.Drawing.Point(460, 523);
            this.lblT6.Name = "lblT6";
            this.lblT6.Size = new System.Drawing.Size(131, 21);
            this.lblT6.TabIndex = 5;
            this.lblT6.Text = "Phí phạt (nếu có):";
         
            this.lblT5.AutoSize = true;
            this.lblT5.Location = new System.Drawing.Point(460, 478);
            this.lblT5.Name = "lblT5";
            this.lblT5.Size = new System.Drawing.Size(117, 21);
            this.lblT5.TabIndex = 4;
            this.lblT5.Text = "Tình trạng sách:";
        
            this.lblT4.AutoSize = true;
            this.lblT4.Location = new System.Drawing.Point(20, 523);
            this.lblT4.Name = "lblT4";
            this.lblT4.Size = new System.Drawing.Size(73, 21);
            this.lblT4.TabIndex = 3;
            this.lblT4.Text = "Ngày trả:";
           
            this.lblT3.AutoSize = true;
            this.lblT3.Location = new System.Drawing.Point(20, 478);
            this.lblT3.Name = "lblT3";
            this.lblT3.Size = new System.Drawing.Size(155, 21);
            this.lblT3.TabIndex = 2;
            this.lblT3.Text = "Nhân viên nhận trả:";
        
            this.lblT2.AutoSize = true;
            this.lblT2.Location = new System.Drawing.Point(20, 95);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(206, 21);
            this.lblT2.TabIndex = 1;
            this.lblT2.Text = "Danh sách sách đang mượn:";
         
            this.lblT1.AutoSize = true;
            this.lblT1.Location = new System.Drawing.Point(20, 25);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(65, 21);
            this.lblT1.TabIndex = 0;
            this.lblT1.Text = "Độc giả:";
          
            this.btnDong.Location = new System.Drawing.Point(1052, 670);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 35);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
         
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 715);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmMuonTra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Mượn - Trả sách";
            this.Load += new System.EventHandler(this.FrmMuonTra_Load);
            this.tabs.ResumeLayout(false);
            this.tabMuon.ResumeLayout(false);
            this.tabMuon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachChon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSachCon)).EndInit();
            this.tabTra.ResumeLayout(false);
            this.tabTra.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numPhiPhat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDangMuon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabMuon;
        private System.Windows.Forms.TabPage tabTra;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblM1;
        private System.Windows.Forms.Label lblM2;
        private System.Windows.Forms.Label lblM3;
        private System.Windows.Forms.Label lblM4;
        private System.Windows.Forms.Label lblM5;
        private System.Windows.Forms.Label lblM6;
        private System.Windows.Forms.ComboBox cboDocGia;
        private System.Windows.Forms.Button btnKiemTra;
        private System.Windows.Forms.Label lblTrangThai;
        private System.Windows.Forms.ComboBox cboNhanVienMuon;
        private System.Windows.Forms.DateTimePicker dtNgayMuon;
        private System.Windows.Forms.DateTimePicker dtHenTra;
        private System.Windows.Forms.DataGridView dgvSachCon;
        private System.Windows.Forms.Button btnThemSach;
        private System.Windows.Forms.Button btnBoSach;
        private System.Windows.Forms.DataGridView dgvSachChon;
        private System.Windows.Forms.Button btnLapPhieu;
        private System.Windows.Forms.Label lblT1;
        private System.Windows.Forms.Label lblT2;
        private System.Windows.Forms.Label lblT3;
        private System.Windows.Forms.Label lblT4;
        private System.Windows.Forms.Label lblT5;
        private System.Windows.Forms.Label lblT6;
        private System.Windows.Forms.ComboBox cboDocGiaTra;
        private System.Windows.Forms.Button btnTaiSachMuon;
        private System.Windows.Forms.ComboBox cboNhanVienTra;
        private System.Windows.Forms.DataGridView dgvDangMuon;
        private System.Windows.Forms.DateTimePicker dtNgayTra;
        private System.Windows.Forms.ComboBox cboTinhTrang;
        private System.Windows.Forms.NumericUpDown numPhiPhat;
        private System.Windows.Forms.Button btnTraSach;
    }
}