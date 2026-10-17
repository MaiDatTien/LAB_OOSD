namespace QuanLyBenhAn.Forms
{
    partial class FrmKhamBenh
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
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPhieu = new System.Windows.Forms.TabPage();
            this.tabXN = new System.Windows.Forms.TabPage();
            this.tabToa = new System.Windows.Forms.TabPage();
            this.k1 = new System.Windows.Forms.Label();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.k2 = new System.Windows.Forms.Label();
            this.cboKhoa = new System.Windows.Forms.ComboBox();
            this.k3 = new System.Windows.Forms.Label();
            this.cboBS = new System.Windows.Forms.ComboBox();
            this.k4 = new System.Windows.Forms.Label();
            this.cboLoai = new System.Windows.Forms.ComboBox();
            this.k5 = new System.Windows.Forms.Label();
            this.cboLich = new System.Windows.Forms.ComboBox();
            this.btnTaoPhieu = new System.Windows.Forms.Button();
            this.k6 = new System.Windows.Forms.Label();
            this.cboPhieu = new System.Windows.Forms.ComboBox();
            this.k7 = new System.Windows.Forms.Label();
            this.cboTC = new System.Windows.Forms.ComboBox();
            this.k8 = new System.Windows.Forms.Label();
            this.txtGiaTri = new System.Windows.Forms.TextBox();
            this.btnGhiTC = new System.Windows.Forms.Button();
            this.dgvTC = new System.Windows.Forms.DataGridView();
            this.k9 = new System.Windows.Forms.Label();
            this.txtKetLuan = new System.Windows.Forms.TextBox();
            this.btnKetLuan = new System.Windows.Forms.Button();
            this.x1 = new System.Windows.Forms.Label();
            this.cboXN = new System.Windows.Forms.ComboBox();
            this.btnYeuCauXN = new System.Windows.Forms.Button();
            this.dgvXNPhieu = new System.Windows.Forms.DataGridView();
            this.t1 = new System.Windows.Forms.Label();
            this.cboBSToa = new System.Windows.Forms.ComboBox();
            this.t2 = new System.Windows.Forms.Label();
            this.cboThuoc = new System.Windows.Forms.ComboBox();
            this.t3 = new System.Windows.Forms.Label();
            this.numSL = new System.Windows.Forms.NumericUpDown();
            this.t4 = new System.Windows.Forms.Label();
            this.txtLieu = new System.Windows.Forms.TextBox();
            this.t5 = new System.Windows.Forms.Label();
            this.txtCach = new System.Windows.Forms.TextBox();
            this.t6 = new System.Windows.Forms.Label();
            this.txtPhanUng = new System.Windows.Forms.TextBox();
            this.btnThemThuoc = new System.Windows.Forms.Button();
            this.btnBoThuoc = new System.Windows.Forms.Button();
            this.dgvToaChon = new System.Windows.Forms.DataGridView();
            this.t7 = new System.Windows.Forms.Label();
            this.txtLoiDan = new System.Windows.Forms.TextBox();
            this.btnLapToa = new System.Windows.Forms.Button();
            this.t8 = new System.Windows.Forms.Label();
            this.dgvToaDaLap = new System.Windows.Forms.DataGridView();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            this.tabMain.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(10, 10);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(980, 620);
            this.tabMain.TabIndex = 0;
            // 
            // tabPhieu
            // 
            this.tabPhieu.Name = "tabPhieu";
            this.tabPhieu.Text = "Phiếu khám và triệu chứng";
            this.tabPhieu.UseVisualStyleBackColor = true;
            this.tabPhieu.Padding = new System.Windows.Forms.Padding(3);
            // 
            // tabXN
            // 
            this.tabXN.Name = "tabXN";
            this.tabXN.Text = "Yêu cầu xét nghiệm";
            this.tabXN.UseVisualStyleBackColor = true;
            this.tabXN.Padding = new System.Windows.Forms.Padding(3);
            // 
            // tabToa
            // 
            this.tabToa.Name = "tabToa";
            this.tabToa.Text = "Toa thuốc";
            this.tabToa.UseVisualStyleBackColor = true;
            this.tabToa.Padding = new System.Windows.Forms.Padding(3);
            // 
            // k1
            // 
            this.k1.Location = new System.Drawing.Point(20, 28);
            this.k1.Name = "k1";
            this.k1.AutoSize = true;
            this.k1.Text = "Mã hồ sơ";
            this.k1.TabIndex = 1;
            // 
            // txtMaHS
            // 
            this.txtMaHS.Location = new System.Drawing.Point(90, 24);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.Size = new System.Drawing.Size(120, 20);
            this.txtMaHS.TabIndex = 2;
            // 
            // k2
            // 
            this.k2.Location = new System.Drawing.Point(230, 28);
            this.k2.Name = "k2";
            this.k2.AutoSize = true;
            this.k2.Text = "Khoa";
            this.k2.TabIndex = 3;
            // 
            // cboKhoa
            // 
            this.cboKhoa.Location = new System.Drawing.Point(270, 24);
            this.cboKhoa.Name = "cboKhoa";
            this.cboKhoa.Size = new System.Drawing.Size(170, 21);
            this.cboKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKhoa.FormattingEnabled = true;
            this.cboKhoa.TabIndex = 4;
            this.cboKhoa.SelectedIndexChanged += new System.EventHandler(this.cboKhoa_SelectedIndexChanged);
            // 
            // k3
            // 
            this.k3.Location = new System.Drawing.Point(460, 28);
            this.k3.Name = "k3";
            this.k3.AutoSize = true;
            this.k3.Text = "Bác sĩ";
            this.k3.TabIndex = 5;
            // 
            // cboBS
            // 
            this.cboBS.Location = new System.Drawing.Point(505, 24);
            this.cboBS.Name = "cboBS";
            this.cboBS.Size = new System.Drawing.Size(190, 21);
            this.cboBS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBS.FormattingEnabled = true;
            this.cboBS.TabIndex = 6;
            // 
            // k4
            // 
            this.k4.Location = new System.Drawing.Point(715, 28);
            this.k4.Name = "k4";
            this.k4.AutoSize = true;
            this.k4.Text = "Loại khám";
            this.k4.TabIndex = 7;
            // 
            // cboLoai
            // 
            this.cboLoai.Location = new System.Drawing.Point(785, 24);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Size = new System.Drawing.Size(100, 21);
            this.cboLoai.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLoai.FormattingEnabled = true;
            this.cboLoai.TabIndex = 8;
            this.cboLoai.SelectedIndexChanged += new System.EventHandler(this.cboLoai_SelectedIndexChanged);
            // 
            // k5
            // 
            this.k5.Location = new System.Drawing.Point(20, 68);
            this.k5.Name = "k5";
            this.k5.AutoSize = true;
            this.k5.Text = "Lịch hẹn";
            this.k5.TabIndex = 9;
            // 
            // cboLich
            // 
            this.cboLich.Location = new System.Drawing.Point(90, 64);
            this.cboLich.Name = "cboLich";
            this.cboLich.Size = new System.Drawing.Size(120, 21);
            this.cboLich.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLich.FormattingEnabled = true;
            this.cboLich.TabIndex = 10;
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Location = new System.Drawing.Point(230, 60);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(130, 30);
            this.btnTaoPhieu.Text = "Tạo phiếu khám";
            this.btnTaoPhieu.UseVisualStyleBackColor = true;
            this.btnTaoPhieu.TabIndex = 11;
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // k6
            // 
            this.k6.Location = new System.Drawing.Point(20, 118);
            this.k6.Name = "k6";
            this.k6.AutoSize = true;
            this.k6.Text = "Phiếu đang khám";
            this.k6.TabIndex = 12;
            // 
            // cboPhieu
            // 
            this.cboPhieu.Location = new System.Drawing.Point(130, 114);
            this.cboPhieu.Name = "cboPhieu";
            this.cboPhieu.Size = new System.Drawing.Size(150, 21);
            this.cboPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieu.FormattingEnabled = true;
            this.cboPhieu.TabIndex = 13;
            this.cboPhieu.SelectedIndexChanged += new System.EventHandler(this.cboPhieu_SelectedIndexChanged);
            // 
            // k7
            // 
            this.k7.Location = new System.Drawing.Point(300, 118);
            this.k7.Name = "k7";
            this.k7.AutoSize = true;
            this.k7.Text = "Triệu chứng";
            this.k7.TabIndex = 14;
            // 
            // cboTC
            // 
            this.cboTC.Location = new System.Drawing.Point(375, 114);
            this.cboTC.Name = "cboTC";
            this.cboTC.Size = new System.Drawing.Size(160, 21);
            this.cboTC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTC.FormattingEnabled = true;
            this.cboTC.TabIndex = 15;
            // 
            // k8
            // 
            this.k8.Location = new System.Drawing.Point(555, 118);
            this.k8.Name = "k8";
            this.k8.AutoSize = true;
            this.k8.Text = "Giá trị";
            this.k8.TabIndex = 16;
            // 
            // txtGiaTri
            // 
            this.txtGiaTri.Location = new System.Drawing.Point(600, 114);
            this.txtGiaTri.Name = "txtGiaTri";
            this.txtGiaTri.Size = new System.Drawing.Size(120, 20);
            this.txtGiaTri.TabIndex = 17;
            // 
            // btnGhiTC
            // 
            this.btnGhiTC.Location = new System.Drawing.Point(740, 110);
            this.btnGhiTC.Name = "btnGhiTC";
            this.btnGhiTC.Size = new System.Drawing.Size(140, 30);
            this.btnGhiTC.Text = "Ghi triệu chứng";
            this.btnGhiTC.UseVisualStyleBackColor = true;
            this.btnGhiTC.TabIndex = 18;
            this.btnGhiTC.Click += new System.EventHandler(this.btnGhiTC_Click);
            // 
            // dgvTC
            // 
            this.dgvTC.Location = new System.Drawing.Point(20, 150);
            this.dgvTC.Name = "dgvTC";
            this.dgvTC.Size = new System.Drawing.Size(860, 200);
            this.dgvTC.AllowUserToAddRows = false;
            this.dgvTC.AllowUserToDeleteRows = false;
            this.dgvTC.ReadOnly = true;
            this.dgvTC.MultiSelect = false;
            this.dgvTC.RowHeadersVisible = false;
            this.dgvTC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTC.BackgroundColor = System.Drawing.Color.White;
            this.dgvTC.TabIndex = 19;
            // 
            // k9
            // 
            this.k9.Location = new System.Drawing.Point(20, 370);
            this.k9.Name = "k9";
            this.k9.AutoSize = true;
            this.k9.Text = "Kết luận";
            this.k9.TabIndex = 20;
            // 
            // txtKetLuan
            // 
            this.txtKetLuan.Location = new System.Drawing.Point(90, 365);
            this.txtKetLuan.Name = "txtKetLuan";
            this.txtKetLuan.Size = new System.Drawing.Size(790, 80);
            this.txtKetLuan.Multiline = true;
            this.txtKetLuan.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKetLuan.TabIndex = 21;
            // 
            // btnKetLuan
            // 
            this.btnKetLuan.Location = new System.Drawing.Point(90, 455);
            this.btnKetLuan.Name = "btnKetLuan";
            this.btnKetLuan.Size = new System.Drawing.Size(250, 32);
            this.btnKetLuan.Text = "Kết luận (chuyển Chờ thanh toán)";
            this.btnKetLuan.UseVisualStyleBackColor = true;
            this.btnKetLuan.TabIndex = 22;
            this.btnKetLuan.Click += new System.EventHandler(this.btnKetLuan_Click);
            // 
            // x1
            // 
            this.x1.Location = new System.Drawing.Point(20, 28);
            this.x1.Name = "x1";
            this.x1.AutoSize = true;
            this.x1.Text = "Loại xét nghiệm";
            this.x1.TabIndex = 23;
            // 
            // cboXN
            // 
            this.cboXN.Location = new System.Drawing.Point(125, 24);
            this.cboXN.Name = "cboXN";
            this.cboXN.Size = new System.Drawing.Size(220, 21);
            this.cboXN.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboXN.FormattingEnabled = true;
            this.cboXN.TabIndex = 24;
            // 
            // btnYeuCauXN
            // 
            this.btnYeuCauXN.Location = new System.Drawing.Point(365, 20);
            this.btnYeuCauXN.Name = "btnYeuCauXN";
            this.btnYeuCauXN.Size = new System.Drawing.Size(130, 30);
            this.btnYeuCauXN.Text = "Yêu cầu";
            this.btnYeuCauXN.UseVisualStyleBackColor = true;
            this.btnYeuCauXN.TabIndex = 25;
            this.btnYeuCauXN.Click += new System.EventHandler(this.btnYeuCauXN_Click);
            // 
            // dgvXNPhieu
            // 
            this.dgvXNPhieu.Location = new System.Drawing.Point(20, 70);
            this.dgvXNPhieu.Name = "dgvXNPhieu";
            this.dgvXNPhieu.Size = new System.Drawing.Size(930, 450);
            this.dgvXNPhieu.AllowUserToAddRows = false;
            this.dgvXNPhieu.AllowUserToDeleteRows = false;
            this.dgvXNPhieu.ReadOnly = true;
            this.dgvXNPhieu.MultiSelect = false;
            this.dgvXNPhieu.RowHeadersVisible = false;
            this.dgvXNPhieu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXNPhieu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXNPhieu.BackgroundColor = System.Drawing.Color.White;
            this.dgvXNPhieu.TabIndex = 26;
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(20, 28);
            this.t1.Name = "t1";
            this.t1.AutoSize = true;
            this.t1.Text = "Bác sĩ lập toa";
            this.t1.TabIndex = 27;
            // 
            // cboBSToa
            // 
            this.cboBSToa.Location = new System.Drawing.Point(110, 24);
            this.cboBSToa.Name = "cboBSToa";
            this.cboBSToa.Size = new System.Drawing.Size(200, 21);
            this.cboBSToa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBSToa.FormattingEnabled = true;
            this.cboBSToa.TabIndex = 28;
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(330, 28);
            this.t2.Name = "t2";
            this.t2.AutoSize = true;
            this.t2.Text = "Thuốc";
            this.t2.TabIndex = 29;
            // 
            // cboThuoc
            // 
            this.cboThuoc.Location = new System.Drawing.Point(375, 24);
            this.cboThuoc.Name = "cboThuoc";
            this.cboThuoc.Size = new System.Drawing.Size(230, 21);
            this.cboThuoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboThuoc.FormattingEnabled = true;
            this.cboThuoc.TabIndex = 30;
            // 
            // t3
            // 
            this.t3.Location = new System.Drawing.Point(625, 28);
            this.t3.Name = "t3";
            this.t3.AutoSize = true;
            this.t3.Text = "Số lượng";
            this.t3.TabIndex = 31;
            // 
            // numSL
            // 
            this.numSL.Location = new System.Drawing.Point(690, 24);
            this.numSL.Name = "numSL";
            this.numSL.Size = new System.Drawing.Size(70, 20);
            this.numSL.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numSL.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.Value = new decimal(new int[] { 1, 0, 0, 0 });
            this.numSL.TabIndex = 32;
            // 
            // t4
            // 
            this.t4.Location = new System.Drawing.Point(20, 68);
            this.t4.Name = "t4";
            this.t4.AutoSize = true;
            this.t4.Text = "Liều dùng";
            this.t4.TabIndex = 33;
            // 
            // txtLieu
            // 
            this.txtLieu.Location = new System.Drawing.Point(85, 64);
            this.txtLieu.Name = "txtLieu";
            this.txtLieu.Size = new System.Drawing.Size(200, 20);
            this.txtLieu.TabIndex = 34;
            // 
            // t5
            // 
            this.t5.Location = new System.Drawing.Point(305, 68);
            this.t5.Name = "t5";
            this.t5.AutoSize = true;
            this.t5.Text = "Cách dùng";
            this.t5.TabIndex = 35;
            // 
            // txtCach
            // 
            this.txtCach.Location = new System.Drawing.Point(375, 64);
            this.txtCach.Name = "txtCach";
            this.txtCach.Size = new System.Drawing.Size(230, 20);
            this.txtCach.TabIndex = 36;
            // 
            // t6
            // 
            this.t6.Location = new System.Drawing.Point(20, 108);
            this.t6.Name = "t6";
            this.t6.AutoSize = true;
            this.t6.Text = "Phản ứng phụ";
            this.t6.TabIndex = 37;
            // 
            // txtPhanUng
            // 
            this.txtPhanUng.Location = new System.Drawing.Point(105, 104);
            this.txtPhanUng.Name = "txtPhanUng";
            this.txtPhanUng.Size = new System.Drawing.Size(400, 20);
            this.txtPhanUng.TabIndex = 38;
            // 
            // btnThemThuoc
            // 
            this.btnThemThuoc.Location = new System.Drawing.Point(525, 99);
            this.btnThemThuoc.Name = "btnThemThuoc";
            this.btnThemThuoc.Size = new System.Drawing.Size(100, 30);
            this.btnThemThuoc.Text = "Thêm thuốc";
            this.btnThemThuoc.UseVisualStyleBackColor = true;
            this.btnThemThuoc.TabIndex = 39;
            this.btnThemThuoc.Click += new System.EventHandler(this.btnThemThuoc_Click);
            // 
            // btnBoThuoc
            // 
            this.btnBoThuoc.Location = new System.Drawing.Point(635, 99);
            this.btnBoThuoc.Name = "btnBoThuoc";
            this.btnBoThuoc.Size = new System.Drawing.Size(100, 30);
            this.btnBoThuoc.Text = "Bỏ thuốc";
            this.btnBoThuoc.UseVisualStyleBackColor = true;
            this.btnBoThuoc.TabIndex = 40;
            this.btnBoThuoc.Click += new System.EventHandler(this.btnBoThuoc_Click);
            // 
            // dgvToaChon
            // 
            this.dgvToaChon.Location = new System.Drawing.Point(20, 140);
            this.dgvToaChon.Name = "dgvToaChon";
            this.dgvToaChon.Size = new System.Drawing.Size(930, 170);
            this.dgvToaChon.AllowUserToAddRows = false;
            this.dgvToaChon.AllowUserToDeleteRows = false;
            this.dgvToaChon.ReadOnly = true;
            this.dgvToaChon.MultiSelect = false;
            this.dgvToaChon.RowHeadersVisible = false;
            this.dgvToaChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToaChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToaChon.BackgroundColor = System.Drawing.Color.White;
            this.dgvToaChon.TabIndex = 41;
            // 
            // t7
            // 
            this.t7.Location = new System.Drawing.Point(20, 328);
            this.t7.Name = "t7";
            this.t7.AutoSize = true;
            this.t7.Text = "Lời dặn";
            this.t7.TabIndex = 42;
            // 
            // txtLoiDan
            // 
            this.txtLoiDan.Location = new System.Drawing.Point(75, 324);
            this.txtLoiDan.Name = "txtLoiDan";
            this.txtLoiDan.Size = new System.Drawing.Size(600, 20);
            this.txtLoiDan.TabIndex = 43;
            // 
            // btnLapToa
            // 
            this.btnLapToa.Location = new System.Drawing.Point(695, 320);
            this.btnLapToa.Name = "btnLapToa";
            this.btnLapToa.Size = new System.Drawing.Size(120, 30);
            this.btnLapToa.Text = "Lập toa";
            this.btnLapToa.UseVisualStyleBackColor = true;
            this.btnLapToa.TabIndex = 44;
            this.btnLapToa.Click += new System.EventHandler(this.btnLapToa_Click);
            // 
            // t8
            // 
            this.t8.Location = new System.Drawing.Point(20, 368);
            this.t8.Name = "t8";
            this.t8.AutoSize = true;
            this.t8.Text = "Toa đã lập của phiếu đang chọn";
            this.t8.TabIndex = 45;
            // 
            // dgvToaDaLap
            // 
            this.dgvToaDaLap.Location = new System.Drawing.Point(20, 390);
            this.dgvToaDaLap.Name = "dgvToaDaLap";
            this.dgvToaDaLap.Size = new System.Drawing.Size(930, 170);
            this.dgvToaDaLap.AllowUserToAddRows = false;
            this.dgvToaDaLap.AllowUserToDeleteRows = false;
            this.dgvToaDaLap.ReadOnly = true;
            this.dgvToaDaLap.MultiSelect = false;
            this.dgvToaDaLap.RowHeadersVisible = false;
            this.dgvToaDaLap.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToaDaLap.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToaDaLap.BackgroundColor = System.Drawing.Color.White;
            this.dgvToaDaLap.TabIndex = 46;
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(890, 640);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 30);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 47;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmKhamBenh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 680);
            this.Name = "FrmKhamBenh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khám bệnh – Triệu chứng – Xét nghiệm – Toa thuốc";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.Add(this.tabMain);
            this.tabMain.TabPages.Add(this.tabPhieu);
            this.tabMain.TabPages.Add(this.tabXN);
            this.tabMain.TabPages.Add(this.tabToa);
            this.tabPhieu.Controls.Add(this.k1);
            this.tabPhieu.Controls.Add(this.txtMaHS);
            this.tabPhieu.Controls.Add(this.k2);
            this.tabPhieu.Controls.Add(this.cboKhoa);
            this.tabPhieu.Controls.Add(this.k3);
            this.tabPhieu.Controls.Add(this.cboBS);
            this.tabPhieu.Controls.Add(this.k4);
            this.tabPhieu.Controls.Add(this.cboLoai);
            this.tabPhieu.Controls.Add(this.k5);
            this.tabPhieu.Controls.Add(this.cboLich);
            this.tabPhieu.Controls.Add(this.btnTaoPhieu);
            this.tabPhieu.Controls.Add(this.k6);
            this.tabPhieu.Controls.Add(this.cboPhieu);
            this.tabPhieu.Controls.Add(this.k7);
            this.tabPhieu.Controls.Add(this.cboTC);
            this.tabPhieu.Controls.Add(this.k8);
            this.tabPhieu.Controls.Add(this.txtGiaTri);
            this.tabPhieu.Controls.Add(this.btnGhiTC);
            this.tabPhieu.Controls.Add(this.dgvTC);
            this.tabPhieu.Controls.Add(this.k9);
            this.tabPhieu.Controls.Add(this.txtKetLuan);
            this.tabPhieu.Controls.Add(this.btnKetLuan);
            this.tabXN.Controls.Add(this.x1);
            this.tabXN.Controls.Add(this.cboXN);
            this.tabXN.Controls.Add(this.btnYeuCauXN);
            this.tabXN.Controls.Add(this.dgvXNPhieu);
            this.tabToa.Controls.Add(this.t1);
            this.tabToa.Controls.Add(this.cboBSToa);
            this.tabToa.Controls.Add(this.t2);
            this.tabToa.Controls.Add(this.cboThuoc);
            this.tabToa.Controls.Add(this.t3);
            this.tabToa.Controls.Add(this.numSL);
            this.tabToa.Controls.Add(this.t4);
            this.tabToa.Controls.Add(this.txtLieu);
            this.tabToa.Controls.Add(this.t5);
            this.tabToa.Controls.Add(this.txtCach);
            this.tabToa.Controls.Add(this.t6);
            this.tabToa.Controls.Add(this.txtPhanUng);
            this.tabToa.Controls.Add(this.btnThemThuoc);
            this.tabToa.Controls.Add(this.btnBoThuoc);
            this.tabToa.Controls.Add(this.dgvToaChon);
            this.tabToa.Controls.Add(this.t7);
            this.tabToa.Controls.Add(this.txtLoiDan);
            this.tabToa.Controls.Add(this.btnLapToa);
            this.tabToa.Controls.Add(this.t8);
            this.tabToa.Controls.Add(this.dgvToaDaLap);
            this.Controls.Add(this.btnDong);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPhieu;
        private System.Windows.Forms.TabPage tabXN;
        private System.Windows.Forms.TabPage tabToa;
        private System.Windows.Forms.Label k1;
        private System.Windows.Forms.TextBox txtMaHS;
        private System.Windows.Forms.Label k2;
        private System.Windows.Forms.ComboBox cboKhoa;
        private System.Windows.Forms.Label k3;
        private System.Windows.Forms.ComboBox cboBS;
        private System.Windows.Forms.Label k4;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.Label k5;
        private System.Windows.Forms.ComboBox cboLich;
        private System.Windows.Forms.Button btnTaoPhieu;
        private System.Windows.Forms.Label k6;
        private System.Windows.Forms.ComboBox cboPhieu;
        private System.Windows.Forms.Label k7;
        private System.Windows.Forms.ComboBox cboTC;
        private System.Windows.Forms.Label k8;
        private System.Windows.Forms.TextBox txtGiaTri;
        private System.Windows.Forms.Button btnGhiTC;
        private System.Windows.Forms.DataGridView dgvTC;
        private System.Windows.Forms.Label k9;
        private System.Windows.Forms.TextBox txtKetLuan;
        private System.Windows.Forms.Button btnKetLuan;
        private System.Windows.Forms.Label x1;
        private System.Windows.Forms.ComboBox cboXN;
        private System.Windows.Forms.Button btnYeuCauXN;
        private System.Windows.Forms.DataGridView dgvXNPhieu;
        private System.Windows.Forms.Label t1;
        private System.Windows.Forms.ComboBox cboBSToa;
        private System.Windows.Forms.Label t2;
        private System.Windows.Forms.ComboBox cboThuoc;
        private System.Windows.Forms.Label t3;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Label t4;
        private System.Windows.Forms.TextBox txtLieu;
        private System.Windows.Forms.Label t5;
        private System.Windows.Forms.TextBox txtCach;
        private System.Windows.Forms.Label t6;
        private System.Windows.Forms.TextBox txtPhanUng;
        private System.Windows.Forms.Button btnThemThuoc;
        private System.Windows.Forms.Button btnBoThuoc;
        private System.Windows.Forms.DataGridView dgvToaChon;
        private System.Windows.Forms.Label t7;
        private System.Windows.Forms.TextBox txtLoiDan;
        private System.Windows.Forms.Button btnLapToa;
        private System.Windows.Forms.Label t8;
        private System.Windows.Forms.DataGridView dgvToaDaLap;
        private System.Windows.Forms.Button btnDong;
    }
}
