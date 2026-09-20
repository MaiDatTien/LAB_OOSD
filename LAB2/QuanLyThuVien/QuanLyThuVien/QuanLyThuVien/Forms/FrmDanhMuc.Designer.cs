namespace QuanLyThuVien.Forms
{
    partial class FrmDanhMuc
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
            this.tabNV = new System.Windows.Forms.TabPage();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.txtNVHo = new System.Windows.Forms.TextBox();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.cboNVPhai = new System.Windows.Forms.ComboBox();
            this.dtNVNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.txtNVChucVu = new System.Windows.Forms.TextBox();
            this.txtNVSDT = new System.Windows.Forms.TextBox();
            this.btnNVThem = new System.Windows.Forms.Button();
            this.btnNVCapNhat = new System.Windows.Forms.Button();
            this.btnNVXoa = new System.Windows.Forms.Button();
            this.btnNVMoi = new System.Windows.Forms.Button();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.lblNV1 = new System.Windows.Forms.Label();
            this.lblNV2 = new System.Windows.Forms.Label();
            this.lblNV3 = new System.Windows.Forms.Label();
            this.lblNV4 = new System.Windows.Forms.Label();
            this.lblNV5 = new System.Windows.Forms.Label();
            this.lblNV6 = new System.Windows.Forms.Label();
            this.lblNV7 = new System.Windows.Forms.Label();
            this.tabTL = new System.Windows.Forms.TabPage();
            this.txtTLMa = new System.Windows.Forms.TextBox();
            this.txtTLTen = new System.Windows.Forms.TextBox();
            this.btnTLThem = new System.Windows.Forms.Button();
            this.btnTLCapNhat = new System.Windows.Forms.Button();
            this.btnTLXoa = new System.Windows.Forms.Button();
            this.btnTLMoi = new System.Windows.Forms.Button();
            this.dgvTL = new System.Windows.Forms.DataGridView();
            this.lblTL1 = new System.Windows.Forms.Label();
            this.lblTL2 = new System.Windows.Forms.Label();
            this.tabNXB = new System.Windows.Forms.TabPage();
            this.txtNXBMa = new System.Windows.Forms.TextBox();
            this.txtNXBDiaChi = new System.Windows.Forms.TextBox();
            this.txtNXBSDT = new System.Windows.Forms.TextBox();
            this.btnNXBThem = new System.Windows.Forms.Button();
            this.btnNXBCapNhat = new System.Windows.Forms.Button();
            this.btnNXBXoa = new System.Windows.Forms.Button();
            this.btnNXBMoi = new System.Windows.Forms.Button();
            this.dgvNXB = new System.Windows.Forms.DataGridView();
            this.lblNXB1 = new System.Windows.Forms.Label();
            this.lblNXB2 = new System.Windows.Forms.Label();
            this.lblNXB3 = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabNV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).BeginInit();
            this.tabTL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).BeginInit();
            this.tabNXB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).BeginInit();
            this.SuspendLayout();
         
            this.tabs.Controls.Add(this.tabNV);
            this.tabs.Controls.Add(this.tabTL);
            this.tabs.Controls.Add(this.tabNXB);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(1020, 615);
            this.tabs.TabIndex = 0;
     
            this.tabNV.Controls.Add(this.lblNV7);
            this.tabNV.Controls.Add(this.lblNV6);
            this.tabNV.Controls.Add(this.lblNV5);
            this.tabNV.Controls.Add(this.lblNV4);
            this.tabNV.Controls.Add(this.lblNV3);
            this.tabNV.Controls.Add(this.lblNV2);
            this.tabNV.Controls.Add(this.lblNV1);
            this.tabNV.Controls.Add(this.dgvNV);
            this.tabNV.Controls.Add(this.btnNVMoi);
            this.tabNV.Controls.Add(this.btnNVXoa);
            this.tabNV.Controls.Add(this.btnNVCapNhat);
            this.tabNV.Controls.Add(this.btnNVThem);
            this.tabNV.Controls.Add(this.txtNVSDT);
            this.tabNV.Controls.Add(this.txtNVChucVu);
            this.tabNV.Controls.Add(this.dtNVNgaySinh);
            this.tabNV.Controls.Add(this.cboNVPhai);
            this.tabNV.Controls.Add(this.txtNVTen);
            this.tabNV.Controls.Add(this.txtNVHo);
            this.tabNV.Controls.Add(this.txtNVMa);
            this.tabNV.Location = new System.Drawing.Point(4, 30);
            this.tabNV.Name = "tabNV";
            this.tabNV.Padding = new System.Windows.Forms.Padding(3);
            this.tabNV.Size = new System.Drawing.Size(1012, 581);
            this.tabNV.TabIndex = 0;
            this.tabNV.Text = "Nhân viên";
            this.tabNV.UseVisualStyleBackColor = true;
        
            this.txtNVMa.Location = new System.Drawing.Point(130, 25);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(200, 29);
            this.txtNVMa.TabIndex = 0;
        
            this.txtNVHo.Location = new System.Drawing.Point(130, 65);
            this.txtNVHo.Name = "txtNVHo";
            this.txtNVHo.Size = new System.Drawing.Size(200, 29);
            this.txtNVHo.TabIndex = 1;
        
            this.txtNVTen.Location = new System.Drawing.Point(130, 105);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(200, 29);
            this.txtNVTen.TabIndex = 2;
        
            this.cboNVPhai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNVPhai.FormattingEnabled = true;
            this.cboNVPhai.Location = new System.Drawing.Point(480, 25);
            this.cboNVPhai.Name = "cboNVPhai";
            this.cboNVPhai.Size = new System.Drawing.Size(200, 29);
            this.cboNVPhai.TabIndex = 3;
       
            this.dtNVNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtNVNgaySinh.Location = new System.Drawing.Point(480, 65);
            this.dtNVNgaySinh.Name = "dtNVNgaySinh";
            this.dtNVNgaySinh.Size = new System.Drawing.Size(200, 29);
            this.dtNVNgaySinh.TabIndex = 4;
       
            this.txtNVChucVu.Location = new System.Drawing.Point(480, 105);
            this.txtNVChucVu.Name = "txtNVChucVu";
            this.txtNVChucVu.Size = new System.Drawing.Size(200, 29);
            this.txtNVChucVu.TabIndex = 5;
    
            this.txtNVSDT.Location = new System.Drawing.Point(480, 145);
            this.txtNVSDT.Name = "txtNVSDT";
            this.txtNVSDT.Size = new System.Drawing.Size(200, 29);
            this.txtNVSDT.TabIndex = 6;
         
            this.btnNVThem.Location = new System.Drawing.Point(740, 25);
            this.btnNVThem.Name = "btnNVThem";
            this.btnNVThem.Size = new System.Drawing.Size(120, 35);
            this.btnNVThem.TabIndex = 7;
            this.btnNVThem.Text = "Thêm";
            this.btnNVThem.UseVisualStyleBackColor = true;
            this.btnNVThem.Click += new System.EventHandler(this.btnNVThem_Click);
     
            this.btnNVCapNhat.Location = new System.Drawing.Point(870, 25);
            this.btnNVCapNhat.Name = "btnNVCapNhat";
            this.btnNVCapNhat.Size = new System.Drawing.Size(120, 35);
            this.btnNVCapNhat.TabIndex = 8;
            this.btnNVCapNhat.Text = "Cập nhật";
            this.btnNVCapNhat.UseVisualStyleBackColor = true;
            this.btnNVCapNhat.Click += new System.EventHandler(this.btnNVCapNhat_Click);
    
            this.btnNVXoa.Location = new System.Drawing.Point(740, 75);
            this.btnNVXoa.Name = "btnNVXoa";
            this.btnNVXoa.Size = new System.Drawing.Size(120, 35);
            this.btnNVXoa.TabIndex = 9;
            this.btnNVXoa.Text = "Xóa";
            this.btnNVXoa.UseVisualStyleBackColor = true;
            this.btnNVXoa.Click += new System.EventHandler(this.btnNVXoa_Click);
        
            this.btnNVMoi.Location = new System.Drawing.Point(870, 75);
            this.btnNVMoi.Name = "btnNVMoi";
            this.btnNVMoi.Size = new System.Drawing.Size(120, 35);
            this.btnNVMoi.TabIndex = 10;
            this.btnNVMoi.Text = "Làm mới";
            this.btnNVMoi.UseVisualStyleBackColor = true;
            this.btnNVMoi.Click += new System.EventHandler(this.btnNVMoi_Click);
       
            this.dgvNV.AllowUserToAddRows = false;
            this.dgvNV.AllowUserToDeleteRows = false;
            this.dgvNV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNV.Location = new System.Drawing.Point(20, 200);
            this.dgvNV.MultiSelect = false;
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.ReadOnly = true;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNV.Size = new System.Drawing.Size(970, 360);
            this.dgvNV.TabIndex = 11;
            this.dgvNV.SelectionChanged += new System.EventHandler(this.dgvNV_SelectionChanged);
            this.lblNV1.AutoSize = true;
            this.lblNV1.Location = new System.Drawing.Point(20, 28);
            this.lblNV1.Name = "lblNV1";
            this.lblNV1.Size = new System.Drawing.Size(107, 21);
            this.lblNV1.Text = "Mã nhân viên:";
      
            this.lblNV2.AutoSize = true;
            this.lblNV2.Location = new System.Drawing.Point(20, 68);
            this.lblNV2.Name = "lblNV2";
            this.lblNV2.Size = new System.Drawing.Size(33, 21);
            this.lblNV2.Text = "Họ:";
      
            this.lblNV3.AutoSize = true;
            this.lblNV3.Location = new System.Drawing.Point(20, 108);
            this.lblNV3.Name = "lblNV3";
            this.lblNV3.Size = new System.Drawing.Size(36, 21);
            this.lblNV3.Text = "Tên:";
     
            this.lblNV4.AutoSize = true;
            this.lblNV4.Location = new System.Drawing.Point(380, 28);
            this.lblNV4.Name = "lblNV4";
            this.lblNV4.Size = new System.Drawing.Size(42, 21);
            this.lblNV4.Text = "Phái:";
     
            this.lblNV5.AutoSize = true;
            this.lblNV5.Location = new System.Drawing.Point(380, 68);
            this.lblNV5.Name = "lblNV5";
            this.lblNV5.Size = new System.Drawing.Size(83, 21);
            this.lblNV5.Text = "Ngày sinh:";
     
            this.lblNV6.AutoSize = true;
            this.lblNV6.Location = new System.Drawing.Point(380, 108);
            this.lblNV6.Name = "lblNV6";
            this.lblNV6.Size = new System.Drawing.Size(69, 21);
            this.lblNV6.Text = "Chức vụ:";
            this.lblNV7.AutoSize = true;
            this.lblNV7.Location = new System.Drawing.Point(380, 148);
            this.lblNV7.Name = "lblNV7";
            this.lblNV7.Size = new System.Drawing.Size(83, 21);
            this.lblNV7.Text = "Điện thoại:";
    
            this.tabTL.Controls.Add(this.lblTL2);
            this.tabTL.Controls.Add(this.lblTL1);
            this.tabTL.Controls.Add(this.dgvTL);
            this.tabTL.Controls.Add(this.btnTLMoi);
            this.tabTL.Controls.Add(this.btnTLXoa);
            this.tabTL.Controls.Add(this.btnTLCapNhat);
            this.tabTL.Controls.Add(this.btnTLThem);
            this.tabTL.Controls.Add(this.txtTLTen);
            this.tabTL.Controls.Add(this.txtTLMa);
            this.tabTL.Location = new System.Drawing.Point(4, 30);
            this.tabTL.Name = "tabTL";
            this.tabTL.Padding = new System.Windows.Forms.Padding(3);
            this.tabTL.Size = new System.Drawing.Size(1012, 581);
            this.tabTL.TabIndex = 1;
            this.tabTL.Text = "Thể loại";
            this.tabTL.UseVisualStyleBackColor = true;
       
            this.txtTLMa.Location = new System.Drawing.Point(140, 25);
            this.txtTLMa.Name = "txtTLMa";
            this.txtTLMa.Size = new System.Drawing.Size(300, 29);
            this.txtTLMa.TabIndex = 0;
      
            this.txtTLTen.Location = new System.Drawing.Point(140, 65);
            this.txtTLTen.Name = "txtTLTen";
            this.txtTLTen.Size = new System.Drawing.Size(300, 29);
            this.txtTLTen.TabIndex = 1;
     
            this.btnTLThem.Location = new System.Drawing.Point(500, 25);
            this.btnTLThem.Name = "btnTLThem";
            this.btnTLThem.Size = new System.Drawing.Size(110, 35);
            this.btnTLThem.TabIndex = 2;
            this.btnTLThem.Text = "Thêm";
            this.btnTLThem.UseVisualStyleBackColor = true;
            this.btnTLThem.Click += new System.EventHandler(this.btnTLThem_Click);
      
            this.btnTLCapNhat.Location = new System.Drawing.Point(620, 25);
            this.btnTLCapNhat.Name = "btnTLCapNhat";
            this.btnTLCapNhat.Size = new System.Drawing.Size(110, 35);
            this.btnTLCapNhat.TabIndex = 3;
            this.btnTLCapNhat.Text = "Cập nhật";
            this.btnTLCapNhat.UseVisualStyleBackColor = true;
            this.btnTLCapNhat.Click += new System.EventHandler(this.btnTLCapNhat_Click);
   
            this.btnTLXoa.Location = new System.Drawing.Point(740, 25);
            this.btnTLXoa.Name = "btnTLXoa";
            this.btnTLXoa.Size = new System.Drawing.Size(110, 35);
            this.btnTLXoa.TabIndex = 4;
            this.btnTLXoa.Text = "Xóa";
            this.btnTLXoa.UseVisualStyleBackColor = true;
            this.btnTLXoa.Click += new System.EventHandler(this.btnTLXoa_Click);
      
            this.btnTLMoi.Location = new System.Drawing.Point(860, 25);
            this.btnTLMoi.Name = "btnTLMoi";
            this.btnTLMoi.Size = new System.Drawing.Size(110, 35);
            this.btnTLMoi.TabIndex = 5;
            this.btnTLMoi.Text = "Làm mới";
            this.btnTLMoi.UseVisualStyleBackColor = true;
            this.btnTLMoi.Click += new System.EventHandler(this.btnTLMoi_Click);
       
            this.dgvTL.AllowUserToAddRows = false;
            this.dgvTL.AllowUserToDeleteRows = false;
            this.dgvTL.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTL.Location = new System.Drawing.Point(20, 120);
            this.dgvTL.MultiSelect = false;
            this.dgvTL.Name = "dgvTL";
            this.dgvTL.ReadOnly = true;
            this.dgvTL.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTL.Size = new System.Drawing.Size(950, 440);
            this.dgvTL.TabIndex = 6;
            this.dgvTL.SelectionChanged += new System.EventHandler(this.dgvTL_SelectionChanged);
        
            this.lblTL1.AutoSize = true;
            this.lblTL1.Location = new System.Drawing.Point(20, 28);
            this.lblTL1.Name = "lblTL1";
            this.lblTL1.Size = new System.Drawing.Size(89, 21);
            this.lblTL1.Text = "Mã thể loại:";
         
            this.lblTL2.AutoSize = true;
            this.lblTL2.Location = new System.Drawing.Point(20, 68);
            this.lblTL2.Name = "lblTL2";
            this.lblTL2.Size = new System.Drawing.Size(92, 21);
            this.lblTL2.Text = "Tên thể loại:";
            this.tabNXB.Controls.Add(this.lblNXB3);
            this.tabNXB.Controls.Add(this.lblNXB2);
            this.tabNXB.Controls.Add(this.lblNXB1);
            this.tabNXB.Controls.Add(this.dgvNXB);
            this.tabNXB.Controls.Add(this.btnNXBMoi);
            this.tabNXB.Controls.Add(this.btnNXBXoa);
            this.tabNXB.Controls.Add(this.btnNXBCapNhat);
            this.tabNXB.Controls.Add(this.btnNXBThem);
            this.tabNXB.Controls.Add(this.txtNXBSDT);
            this.tabNXB.Controls.Add(this.txtNXBDiaChi);
            this.tabNXB.Controls.Add(this.txtNXBMa);
            this.tabNXB.Location = new System.Drawing.Point(4, 30);
            this.tabNXB.Name = "tabNXB";
            this.tabNXB.Size = new System.Drawing.Size(1012, 581);
            this.tabNXB.TabIndex = 2;
            this.tabNXB.Text = "Nhà xuất bản";
            this.tabNXB.UseVisualStyleBackColor = true;
        
            this.txtNXBMa.Location = new System.Drawing.Point(150, 25);
            this.txtNXBMa.Name = "txtNXBMa";
            this.txtNXBMa.Size = new System.Drawing.Size(300, 29);
            this.txtNXBMa.TabIndex = 0;
      
            this.txtNXBDiaChi.Location = new System.Drawing.Point(150, 65);
            this.txtNXBDiaChi.Name = "txtNXBDiaChi";
            this.txtNXBDiaChi.Size = new System.Drawing.Size(300, 29);
            this.txtNXBDiaChi.TabIndex = 1;
        
            this.txtNXBSDT.Location = new System.Drawing.Point(150, 105);
            this.txtNXBSDT.Name = "txtNXBSDT";
            this.txtNXBSDT.Size = new System.Drawing.Size(300, 29);
            this.txtNXBSDT.TabIndex = 2;
      
            this.btnNXBThem.Location = new System.Drawing.Point(500, 25);
            this.btnNXBThem.Name = "btnNXBThem";
            this.btnNXBThem.Size = new System.Drawing.Size(110, 35);
            this.btnNXBThem.TabIndex = 3;
            this.btnNXBThem.Text = "Thêm";
            this.btnNXBThem.UseVisualStyleBackColor = true;
            this.btnNXBThem.Click += new System.EventHandler(this.btnNXBThem_Click);
        
            this.btnNXBCapNhat.Location = new System.Drawing.Point(620, 25);
            this.btnNXBCapNhat.Name = "btnNXBCapNhat";
            this.btnNXBCapNhat.Size = new System.Drawing.Size(110, 35);
            this.btnNXBCapNhat.TabIndex = 4;
            this.btnNXBCapNhat.Text = "Cập nhật";
            this.btnNXBCapNhat.UseVisualStyleBackColor = true;
            this.btnNXBCapNhat.Click += new System.EventHandler(this.btnNXBCapNhat_Click);
      
            this.btnNXBXoa.Location = new System.Drawing.Point(740, 25);
            this.btnNXBXoa.Name = "btnNXBXoa";
            this.btnNXBXoa.Size = new System.Drawing.Size(110, 35);
            this.btnNXBXoa.TabIndex = 5;
            this.btnNXBXoa.Text = "Xóa";
            this.btnNXBXoa.UseVisualStyleBackColor = true;
            this.btnNXBXoa.Click += new System.EventHandler(this.btnNXBXoa_Click);
       
            this.btnNXBMoi.Location = new System.Drawing.Point(860, 25);
            this.btnNXBMoi.Name = "btnNXBMoi";
            this.btnNXBMoi.Size = new System.Drawing.Size(110, 35);
            this.btnNXBMoi.TabIndex = 6;
            this.btnNXBMoi.Text = "Làm mới";
            this.btnNXBMoi.UseVisualStyleBackColor = true;
            this.btnNXBMoi.Click += new System.EventHandler(this.btnNXBMoi_Click);
        
            this.dgvNXB.AllowUserToAddRows = false;
            this.dgvNXB.AllowUserToDeleteRows = false;
            this.dgvNXB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNXB.Location = new System.Drawing.Point(20, 160);
            this.dgvNXB.MultiSelect = false;
            this.dgvNXB.Name = "dgvNXB";
            this.dgvNXB.ReadOnly = true;
            this.dgvNXB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNXB.Size = new System.Drawing.Size(950, 400);
            this.dgvNXB.TabIndex = 7;
            this.dgvNXB.SelectionChanged += new System.EventHandler(this.dgvNXB_SelectionChanged);
     
            this.lblNXB1.AutoSize = true;
            this.lblNXB1.Location = new System.Drawing.Point(20, 28);
            this.lblNXB1.Name = "lblNXB1";
            this.lblNXB1.Size = new System.Drawing.Size(130, 21);
            this.lblNXB1.Text = "Mã nhà xuất bản:";
       
            this.lblNXB2.AutoSize = true;
            this.lblNXB2.Location = new System.Drawing.Point(20, 68);
            this.lblNXB2.Name = "lblNXB2";
            this.lblNXB2.Size = new System.Drawing.Size(60, 21);
            this.lblNXB2.Text = "Địa chỉ:";
     
            this.lblNXB3.AutoSize = true;
            this.lblNXB3.Location = new System.Drawing.Point(20, 108);
            this.lblNXB3.Name = "lblNXB3";
            this.lblNXB3.Size = new System.Drawing.Size(83, 21);
            this.lblNXB3.Text = "Điện thoại:";
     
            this.btnDong.Location = new System.Drawing.Point(912, 633);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(120, 35);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
    
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1044, 680);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Danh mục và nhân viên";
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
            this.tabs.ResumeLayout(false);
            this.tabNV.ResumeLayout(false);
            this.tabNV.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNV)).EndInit();
            this.tabTL.ResumeLayout(false);
            this.tabTL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTL)).EndInit();
            this.tabNXB.ResumeLayout(false);
            this.tabNXB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNXB)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabNV;
        private System.Windows.Forms.TabPage tabTL;
        private System.Windows.Forms.TabPage tabNXB;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.TextBox txtNVHo;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.ComboBox cboNVPhai;
        private System.Windows.Forms.DateTimePicker dtNVNgaySinh;
        private System.Windows.Forms.TextBox txtNVChucVu;
        private System.Windows.Forms.TextBox txtNVSDT;
        private System.Windows.Forms.Button btnNVThem;
        private System.Windows.Forms.Button btnNVCapNhat;
        private System.Windows.Forms.Button btnNVXoa;
        private System.Windows.Forms.Button btnNVMoi;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.Label lblNV1;
        private System.Windows.Forms.Label lblNV2;
        private System.Windows.Forms.Label lblNV3;
        private System.Windows.Forms.Label lblNV4;
        private System.Windows.Forms.Label lblNV5;
        private System.Windows.Forms.Label lblNV6;
        private System.Windows.Forms.Label lblNV7;
        private System.Windows.Forms.TextBox txtTLMa;
        private System.Windows.Forms.TextBox txtTLTen;
        private System.Windows.Forms.Button btnTLThem;
        private System.Windows.Forms.Button btnTLCapNhat;
        private System.Windows.Forms.Button btnTLXoa;
        private System.Windows.Forms.Button btnTLMoi;
        private System.Windows.Forms.DataGridView dgvTL;
        private System.Windows.Forms.Label lblTL1;
        private System.Windows.Forms.Label lblTL2;
        private System.Windows.Forms.TextBox txtNXBMa;
        private System.Windows.Forms.TextBox txtNXBDiaChi;
        private System.Windows.Forms.TextBox txtNXBSDT;
        private System.Windows.Forms.Button btnNXBThem;
        private System.Windows.Forms.Button btnNXBCapNhat;
        private System.Windows.Forms.Button btnNXBXoa;
        private System.Windows.Forms.Button btnNXBMoi;
        private System.Windows.Forms.DataGridView dgvNXB;
        private System.Windows.Forms.Label lblNXB1;
        private System.Windows.Forms.Label lblNXB2;
        private System.Windows.Forms.Label lblNXB3;
        private System.Windows.Forms.Button btnDong;
    }
}