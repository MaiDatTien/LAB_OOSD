namespace QuanLyBenhAn.Forms
{
    partial class FrmDanhMuc
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
            this.tabKhoa = new System.Windows.Forms.TabPage();
            this.lbl_txtKhoaMa = new System.Windows.Forms.Label();
            this.txtKhoaMa = new System.Windows.Forms.TextBox();
            this.lbl_txtKhoaTen = new System.Windows.Forms.Label();
            this.txtKhoaTen = new System.Windows.Forms.TextBox();
            this.lbl_numKhoaPhi = new System.Windows.Forms.Label();
            this.numKhoaPhi = new System.Windows.Forms.NumericUpDown();
            this.btnThemKhoa = new System.Windows.Forms.Button();
            this.dgvKhoa = new System.Windows.Forms.DataGridView();
            this.tabBS = new System.Windows.Forms.TabPage();
            this.lbl_txtBSMa = new System.Windows.Forms.Label();
            this.txtBSMa = new System.Windows.Forms.TextBox();
            this.lbl_txtBSTen = new System.Windows.Forms.Label();
            this.txtBSTen = new System.Windows.Forms.TextBox();
            this.lbl_txtBSChuyenMon = new System.Windows.Forms.Label();
            this.txtBSChuyenMon = new System.Windows.Forms.TextBox();
            this.lbl_cboBSKhoa = new System.Windows.Forms.Label();
            this.cboBSKhoa = new System.Windows.Forms.ComboBox();
            this.btnThemBS = new System.Windows.Forms.Button();
            this.dgvBS = new System.Windows.Forms.DataGridView();
            this.tabNV = new System.Windows.Forms.TabPage();
            this.lbl_txtNVMa = new System.Windows.Forms.Label();
            this.txtNVMa = new System.Windows.Forms.TextBox();
            this.lbl_txtNVTen = new System.Windows.Forms.Label();
            this.txtNVTen = new System.Windows.Forms.TextBox();
            this.lbl_cboNVVaiTro = new System.Windows.Forms.Label();
            this.cboNVVaiTro = new System.Windows.Forms.ComboBox();
            this.btnThemNV = new System.Windows.Forms.Button();
            this.dgvNV = new System.Windows.Forms.DataGridView();
            this.tabTC = new System.Windows.Forms.TabPage();
            this.lbl_txtTCMa = new System.Windows.Forms.Label();
            this.txtTCMa = new System.Windows.Forms.TextBox();
            this.lbl_txtTCTen = new System.Windows.Forms.Label();
            this.txtTCTen = new System.Windows.Forms.TextBox();
            this.lbl_txtTCDonVi = new System.Windows.Forms.Label();
            this.txtTCDonVi = new System.Windows.Forms.TextBox();
            this.btnThemTC = new System.Windows.Forms.Button();
            this.dgvTC = new System.Windows.Forms.DataGridView();
            this.tabXNDM = new System.Windows.Forms.TabPage();
            this.lbl_txtXNMa = new System.Windows.Forms.Label();
            this.txtXNMa = new System.Windows.Forms.TextBox();
            this.lbl_txtXNTen = new System.Windows.Forms.Label();
            this.txtXNTen = new System.Windows.Forms.TextBox();
            this.lbl_numXNGia = new System.Windows.Forms.Label();
            this.numXNGia = new System.Windows.Forms.NumericUpDown();
            this.btnThemXN = new System.Windows.Forms.Button();
            this.dgvXN = new System.Windows.Forms.DataGridView();
            this.tabThuoc = new System.Windows.Forms.TabPage();
            this.lbl_txtThuocMa = new System.Windows.Forms.Label();
            this.txtThuocMa = new System.Windows.Forms.TextBox();
            this.lbl_txtThuocTen = new System.Windows.Forms.Label();
            this.txtThuocTen = new System.Windows.Forms.TextBox();
            this.lbl_txtThuocDVT = new System.Windows.Forms.Label();
            this.txtThuocDVT = new System.Windows.Forms.TextBox();
            this.lbl_txtThuocHC = new System.Windows.Forms.Label();
            this.txtThuocHC = new System.Windows.Forms.TextBox();
            this.lbl_txtThuocCCD = new System.Windows.Forms.Label();
            this.txtThuocCCD = new System.Windows.Forms.TextBox();
            this.lbl_numThuocGia = new System.Windows.Forms.Label();
            this.numThuocGia = new System.Windows.Forms.NumericUpDown();
            this.btnThemThuoc = new System.Windows.Forms.Button();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            this.tabMain.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(10, 10);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(880, 520);
            this.tabMain.TabIndex = 0;
            // 
            // tabKhoa
            // 
            this.tabKhoa.Name = "tabKhoa";
            this.tabKhoa.Text = "Khoa";
            this.tabKhoa.UseVisualStyleBackColor = true;
            this.tabKhoa.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lbl_txtKhoaMa
            // 
            this.lbl_txtKhoaMa.Location = new System.Drawing.Point(15, 19);
            this.lbl_txtKhoaMa.Name = "lbl_txtKhoaMa";
            this.lbl_txtKhoaMa.AutoSize = true;
            this.lbl_txtKhoaMa.Text = "Mã khoa";
            this.lbl_txtKhoaMa.TabIndex = 1;
            // 
            // txtKhoaMa
            // 
            this.txtKhoaMa.Location = new System.Drawing.Point(73, 15);
            this.txtKhoaMa.Name = "txtKhoaMa";
            this.txtKhoaMa.Size = new System.Drawing.Size(90, 20);
            this.txtKhoaMa.TabIndex = 2;
            // 
            // lbl_txtKhoaTen
            // 
            this.lbl_txtKhoaTen.Location = new System.Drawing.Point(188, 19);
            this.lbl_txtKhoaTen.Name = "lbl_txtKhoaTen";
            this.lbl_txtKhoaTen.AutoSize = true;
            this.lbl_txtKhoaTen.Text = "Tên khoa";
            this.lbl_txtKhoaTen.TabIndex = 3;
            // 
            // txtKhoaTen
            // 
            this.txtKhoaTen.Location = new System.Drawing.Point(252, 15);
            this.txtKhoaTen.Name = "txtKhoaTen";
            this.txtKhoaTen.Size = new System.Drawing.Size(200, 20);
            this.txtKhoaTen.TabIndex = 4;
            // 
            // lbl_numKhoaPhi
            // 
            this.lbl_numKhoaPhi.Location = new System.Drawing.Point(477, 19);
            this.lbl_numKhoaPhi.Name = "lbl_numKhoaPhi";
            this.lbl_numKhoaPhi.AutoSize = true;
            this.lbl_numKhoaPhi.Text = "Phí khám";
            this.lbl_numKhoaPhi.TabIndex = 5;
            // 
            // numKhoaPhi
            // 
            this.numKhoaPhi.Location = new System.Drawing.Point(541, 15);
            this.numKhoaPhi.Name = "numKhoaPhi";
            this.numKhoaPhi.Size = new System.Drawing.Size(110, 20);
            this.numKhoaPhi.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numKhoaPhi.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numKhoaPhi.ThousandsSeparator = true;
            this.numKhoaPhi.TabIndex = 6;
            // 
            // btnThemKhoa
            // 
            this.btnThemKhoa.Location = new System.Drawing.Point(15, 55);
            this.btnThemKhoa.Name = "btnThemKhoa";
            this.btnThemKhoa.Size = new System.Drawing.Size(110, 28);
            this.btnThemKhoa.Text = "Thêm";
            this.btnThemKhoa.UseVisualStyleBackColor = true;
            this.btnThemKhoa.TabIndex = 7;
            this.btnThemKhoa.Click += new System.EventHandler(this.btnThemKhoa_Click);
            // 
            // dgvKhoa
            // 
            this.dgvKhoa.Location = new System.Drawing.Point(15, 100);
            this.dgvKhoa.Name = "dgvKhoa";
            this.dgvKhoa.Size = new System.Drawing.Size(842, 380);
            this.dgvKhoa.AllowUserToAddRows = false;
            this.dgvKhoa.AllowUserToDeleteRows = false;
            this.dgvKhoa.ReadOnly = true;
            this.dgvKhoa.MultiSelect = false;
            this.dgvKhoa.RowHeadersVisible = false;
            this.dgvKhoa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhoa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhoa.BackgroundColor = System.Drawing.Color.White;
            this.dgvKhoa.TabIndex = 8;
            // 
            // tabBS
            // 
            this.tabBS.Name = "tabBS";
            this.tabBS.Text = "Bác sĩ";
            this.tabBS.UseVisualStyleBackColor = true;
            this.tabBS.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lbl_txtBSMa
            // 
            this.lbl_txtBSMa.Location = new System.Drawing.Point(15, 19);
            this.lbl_txtBSMa.Name = "lbl_txtBSMa";
            this.lbl_txtBSMa.AutoSize = true;
            this.lbl_txtBSMa.Text = "Mã BS";
            this.lbl_txtBSMa.TabIndex = 9;
            // 
            // txtBSMa
            // 
            this.txtBSMa.Location = new System.Drawing.Point(60, 15);
            this.txtBSMa.Name = "txtBSMa";
            this.txtBSMa.Size = new System.Drawing.Size(90, 20);
            this.txtBSMa.TabIndex = 10;
            // 
            // lbl_txtBSTen
            // 
            this.lbl_txtBSTen.Location = new System.Drawing.Point(175, 19);
            this.lbl_txtBSTen.Name = "lbl_txtBSTen";
            this.lbl_txtBSTen.AutoSize = true;
            this.lbl_txtBSTen.Text = "Họ tên";
            this.lbl_txtBSTen.TabIndex = 11;
            // 
            // txtBSTen
            // 
            this.txtBSTen.Location = new System.Drawing.Point(226, 15);
            this.txtBSTen.Name = "txtBSTen";
            this.txtBSTen.Size = new System.Drawing.Size(200, 20);
            this.txtBSTen.TabIndex = 12;
            // 
            // lbl_txtBSChuyenMon
            // 
            this.lbl_txtBSChuyenMon.Location = new System.Drawing.Point(451, 19);
            this.lbl_txtBSChuyenMon.Name = "lbl_txtBSChuyenMon";
            this.lbl_txtBSChuyenMon.AutoSize = true;
            this.lbl_txtBSChuyenMon.Text = "Chuyên môn";
            this.lbl_txtBSChuyenMon.TabIndex = 13;
            // 
            // txtBSChuyenMon
            // 
            this.txtBSChuyenMon.Location = new System.Drawing.Point(529, 15);
            this.txtBSChuyenMon.Name = "txtBSChuyenMon";
            this.txtBSChuyenMon.Size = new System.Drawing.Size(180, 20);
            this.txtBSChuyenMon.TabIndex = 14;
            // 
            // lbl_cboBSKhoa
            // 
            this.lbl_cboBSKhoa.Location = new System.Drawing.Point(15, 59);
            this.lbl_cboBSKhoa.Name = "lbl_cboBSKhoa";
            this.lbl_cboBSKhoa.AutoSize = true;
            this.lbl_cboBSKhoa.Text = "Khoa";
            this.lbl_cboBSKhoa.TabIndex = 15;
            // 
            // cboBSKhoa
            // 
            this.cboBSKhoa.Location = new System.Drawing.Point(53, 55);
            this.cboBSKhoa.Name = "cboBSKhoa";
            this.cboBSKhoa.Size = new System.Drawing.Size(220, 21);
            this.cboBSKhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBSKhoa.FormattingEnabled = true;
            this.cboBSKhoa.TabIndex = 16;
            // 
            // btnThemBS
            // 
            this.btnThemBS.Location = new System.Drawing.Point(330, 53);
            this.btnThemBS.Name = "btnThemBS";
            this.btnThemBS.Size = new System.Drawing.Size(110, 28);
            this.btnThemBS.Text = "Thêm";
            this.btnThemBS.UseVisualStyleBackColor = true;
            this.btnThemBS.TabIndex = 17;
            this.btnThemBS.Click += new System.EventHandler(this.btnThemBS_Click);
            // 
            // dgvBS
            // 
            this.dgvBS.Location = new System.Drawing.Point(15, 100);
            this.dgvBS.Name = "dgvBS";
            this.dgvBS.Size = new System.Drawing.Size(842, 380);
            this.dgvBS.AllowUserToAddRows = false;
            this.dgvBS.AllowUserToDeleteRows = false;
            this.dgvBS.ReadOnly = true;
            this.dgvBS.MultiSelect = false;
            this.dgvBS.RowHeadersVisible = false;
            this.dgvBS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBS.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBS.BackgroundColor = System.Drawing.Color.White;
            this.dgvBS.TabIndex = 18;
            // 
            // tabNV
            // 
            this.tabNV.Name = "tabNV";
            this.tabNV.Text = "Nhân viên";
            this.tabNV.UseVisualStyleBackColor = true;
            this.tabNV.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lbl_txtNVMa
            // 
            this.lbl_txtNVMa.Location = new System.Drawing.Point(15, 19);
            this.lbl_txtNVMa.Name = "lbl_txtNVMa";
            this.lbl_txtNVMa.AutoSize = true;
            this.lbl_txtNVMa.Text = "Mã NV";
            this.lbl_txtNVMa.TabIndex = 19;
            // 
            // txtNVMa
            // 
            this.txtNVMa.Location = new System.Drawing.Point(60, 15);
            this.txtNVMa.Name = "txtNVMa";
            this.txtNVMa.Size = new System.Drawing.Size(90, 20);
            this.txtNVMa.TabIndex = 20;
            // 
            // lbl_txtNVTen
            // 
            this.lbl_txtNVTen.Location = new System.Drawing.Point(175, 19);
            this.lbl_txtNVTen.Name = "lbl_txtNVTen";
            this.lbl_txtNVTen.AutoSize = true;
            this.lbl_txtNVTen.Text = "Họ tên";
            this.lbl_txtNVTen.TabIndex = 21;
            // 
            // txtNVTen
            // 
            this.txtNVTen.Location = new System.Drawing.Point(226, 15);
            this.txtNVTen.Name = "txtNVTen";
            this.txtNVTen.Size = new System.Drawing.Size(200, 20);
            this.txtNVTen.TabIndex = 22;
            // 
            // lbl_cboNVVaiTro
            // 
            this.lbl_cboNVVaiTro.Location = new System.Drawing.Point(451, 19);
            this.lbl_cboNVVaiTro.Name = "lbl_cboNVVaiTro";
            this.lbl_cboNVVaiTro.AutoSize = true;
            this.lbl_cboNVVaiTro.Text = "Vai trò";
            this.lbl_cboNVVaiTro.TabIndex = 23;
            // 
            // cboNVVaiTro
            // 
            this.cboNVVaiTro.Location = new System.Drawing.Point(509, 15);
            this.cboNVVaiTro.Name = "cboNVVaiTro";
            this.cboNVVaiTro.Size = new System.Drawing.Size(150, 21);
            this.cboNVVaiTro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNVVaiTro.FormattingEnabled = true;
            this.cboNVVaiTro.TabIndex = 24;
            // 
            // btnThemNV
            // 
            this.btnThemNV.Location = new System.Drawing.Point(15, 55);
            this.btnThemNV.Name = "btnThemNV";
            this.btnThemNV.Size = new System.Drawing.Size(110, 28);
            this.btnThemNV.Text = "Thêm";
            this.btnThemNV.UseVisualStyleBackColor = true;
            this.btnThemNV.TabIndex = 25;
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            // 
            // dgvNV
            // 
            this.dgvNV.Location = new System.Drawing.Point(15, 100);
            this.dgvNV.Name = "dgvNV";
            this.dgvNV.Size = new System.Drawing.Size(842, 380);
            this.dgvNV.AllowUserToAddRows = false;
            this.dgvNV.AllowUserToDeleteRows = false;
            this.dgvNV.ReadOnly = true;
            this.dgvNV.MultiSelect = false;
            this.dgvNV.RowHeadersVisible = false;
            this.dgvNV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNV.BackgroundColor = System.Drawing.Color.White;
            this.dgvNV.TabIndex = 26;
            // 
            // tabTC
            // 
            this.tabTC.Name = "tabTC";
            this.tabTC.Text = "Triệu chứng";
            this.tabTC.UseVisualStyleBackColor = true;
            this.tabTC.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lbl_txtTCMa
            // 
            this.lbl_txtTCMa.Location = new System.Drawing.Point(15, 19);
            this.lbl_txtTCMa.Name = "lbl_txtTCMa";
            this.lbl_txtTCMa.AutoSize = true;
            this.lbl_txtTCMa.Text = "Mã TC";
            this.lbl_txtTCMa.TabIndex = 27;
            // 
            // txtTCMa
            // 
            this.txtTCMa.Location = new System.Drawing.Point(60, 15);
            this.txtTCMa.Name = "txtTCMa";
            this.txtTCMa.Size = new System.Drawing.Size(90, 20);
            this.txtTCMa.TabIndex = 28;
            // 
            // lbl_txtTCTen
            // 
            this.lbl_txtTCTen.Location = new System.Drawing.Point(175, 19);
            this.lbl_txtTCTen.Name = "lbl_txtTCTen";
            this.lbl_txtTCTen.AutoSize = true;
            this.lbl_txtTCTen.Text = "Tên triệu chứng";
            this.lbl_txtTCTen.TabIndex = 29;
            // 
            // txtTCTen
            // 
            this.txtTCTen.Location = new System.Drawing.Point(286, 15);
            this.txtTCTen.Name = "txtTCTen";
            this.txtTCTen.Size = new System.Drawing.Size(200, 20);
            this.txtTCTen.TabIndex = 30;
            // 
            // lbl_txtTCDonVi
            // 
            this.lbl_txtTCDonVi.Location = new System.Drawing.Point(511, 19);
            this.lbl_txtTCDonVi.Name = "lbl_txtTCDonVi";
            this.lbl_txtTCDonVi.AutoSize = true;
            this.lbl_txtTCDonVi.Text = "Đơn vị";
            this.lbl_txtTCDonVi.TabIndex = 31;
            // 
            // txtTCDonVi
            // 
            this.txtTCDonVi.Location = new System.Drawing.Point(562, 15);
            this.txtTCDonVi.Name = "txtTCDonVi";
            this.txtTCDonVi.Size = new System.Drawing.Size(90, 20);
            this.txtTCDonVi.TabIndex = 32;
            // 
            // btnThemTC
            // 
            this.btnThemTC.Location = new System.Drawing.Point(15, 55);
            this.btnThemTC.Name = "btnThemTC";
            this.btnThemTC.Size = new System.Drawing.Size(110, 28);
            this.btnThemTC.Text = "Thêm";
            this.btnThemTC.UseVisualStyleBackColor = true;
            this.btnThemTC.TabIndex = 33;
            this.btnThemTC.Click += new System.EventHandler(this.btnThemTC_Click);
            // 
            // dgvTC
            // 
            this.dgvTC.Location = new System.Drawing.Point(15, 100);
            this.dgvTC.Name = "dgvTC";
            this.dgvTC.Size = new System.Drawing.Size(842, 380);
            this.dgvTC.AllowUserToAddRows = false;
            this.dgvTC.AllowUserToDeleteRows = false;
            this.dgvTC.ReadOnly = true;
            this.dgvTC.MultiSelect = false;
            this.dgvTC.RowHeadersVisible = false;
            this.dgvTC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTC.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTC.BackgroundColor = System.Drawing.Color.White;
            this.dgvTC.TabIndex = 34;
            // 
            // tabXNDM
            // 
            this.tabXNDM.Name = "tabXNDM";
            this.tabXNDM.Text = "Loại xét nghiệm";
            this.tabXNDM.UseVisualStyleBackColor = true;
            this.tabXNDM.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lbl_txtXNMa
            // 
            this.lbl_txtXNMa.Location = new System.Drawing.Point(15, 19);
            this.lbl_txtXNMa.Name = "lbl_txtXNMa";
            this.lbl_txtXNMa.AutoSize = true;
            this.lbl_txtXNMa.Text = "Mã XN";
            this.lbl_txtXNMa.TabIndex = 35;
            // 
            // txtXNMa
            // 
            this.txtXNMa.Location = new System.Drawing.Point(60, 15);
            this.txtXNMa.Name = "txtXNMa";
            this.txtXNMa.Size = new System.Drawing.Size(90, 20);
            this.txtXNMa.TabIndex = 36;
            // 
            // lbl_txtXNTen
            // 
            this.lbl_txtXNTen.Location = new System.Drawing.Point(175, 19);
            this.lbl_txtXNTen.Name = "lbl_txtXNTen";
            this.lbl_txtXNTen.AutoSize = true;
            this.lbl_txtXNTen.Text = "Tên xét nghiệm";
            this.lbl_txtXNTen.TabIndex = 37;
            // 
            // txtXNTen
            // 
            this.txtXNTen.Location = new System.Drawing.Point(279, 15);
            this.txtXNTen.Name = "txtXNTen";
            this.txtXNTen.Size = new System.Drawing.Size(200, 20);
            this.txtXNTen.TabIndex = 38;
            // 
            // lbl_numXNGia
            // 
            this.lbl_numXNGia.Location = new System.Drawing.Point(504, 19);
            this.lbl_numXNGia.Name = "lbl_numXNGia";
            this.lbl_numXNGia.AutoSize = true;
            this.lbl_numXNGia.Text = "Đơn giá";
            this.lbl_numXNGia.TabIndex = 39;
            // 
            // numXNGia
            // 
            this.numXNGia.Location = new System.Drawing.Point(562, 15);
            this.numXNGia.Name = "numXNGia";
            this.numXNGia.Size = new System.Drawing.Size(110, 20);
            this.numXNGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numXNGia.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numXNGia.ThousandsSeparator = true;
            this.numXNGia.TabIndex = 40;
            // 
            // btnThemXN
            // 
            this.btnThemXN.Location = new System.Drawing.Point(15, 55);
            this.btnThemXN.Name = "btnThemXN";
            this.btnThemXN.Size = new System.Drawing.Size(110, 28);
            this.btnThemXN.Text = "Thêm";
            this.btnThemXN.UseVisualStyleBackColor = true;
            this.btnThemXN.TabIndex = 41;
            this.btnThemXN.Click += new System.EventHandler(this.btnThemXN_Click);
            // 
            // dgvXN
            // 
            this.dgvXN.Location = new System.Drawing.Point(15, 100);
            this.dgvXN.Name = "dgvXN";
            this.dgvXN.Size = new System.Drawing.Size(842, 380);
            this.dgvXN.AllowUserToAddRows = false;
            this.dgvXN.AllowUserToDeleteRows = false;
            this.dgvXN.ReadOnly = true;
            this.dgvXN.MultiSelect = false;
            this.dgvXN.RowHeadersVisible = false;
            this.dgvXN.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXN.BackgroundColor = System.Drawing.Color.White;
            this.dgvXN.TabIndex = 42;
            // 
            // tabThuoc
            // 
            this.tabThuoc.Name = "tabThuoc";
            this.tabThuoc.Text = "Thuốc";
            this.tabThuoc.UseVisualStyleBackColor = true;
            this.tabThuoc.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lbl_txtThuocMa
            // 
            this.lbl_txtThuocMa.Location = new System.Drawing.Point(15, 16);
            this.lbl_txtThuocMa.Name = "lbl_txtThuocMa";
            this.lbl_txtThuocMa.AutoSize = true;
            this.lbl_txtThuocMa.Text = "Mã thuốc";
            this.lbl_txtThuocMa.TabIndex = 43;
            // 
            // txtThuocMa
            // 
            this.txtThuocMa.Location = new System.Drawing.Point(79, 12);
            this.txtThuocMa.Name = "txtThuocMa";
            this.txtThuocMa.Size = new System.Drawing.Size(80, 20);
            this.txtThuocMa.TabIndex = 44;
            // 
            // lbl_txtThuocTen
            // 
            this.lbl_txtThuocTen.Location = new System.Drawing.Point(184, 16);
            this.lbl_txtThuocTen.Name = "lbl_txtThuocTen";
            this.lbl_txtThuocTen.AutoSize = true;
            this.lbl_txtThuocTen.Text = "Tên thuốc";
            this.lbl_txtThuocTen.TabIndex = 45;
            // 
            // txtThuocTen
            // 
            this.txtThuocTen.Location = new System.Drawing.Point(255, 12);
            this.txtThuocTen.Name = "txtThuocTen";
            this.txtThuocTen.Size = new System.Drawing.Size(200, 20);
            this.txtThuocTen.TabIndex = 46;
            // 
            // lbl_txtThuocDVT
            // 
            this.lbl_txtThuocDVT.Location = new System.Drawing.Point(480, 16);
            this.lbl_txtThuocDVT.Name = "lbl_txtThuocDVT";
            this.lbl_txtThuocDVT.AutoSize = true;
            this.lbl_txtThuocDVT.Text = "Đơn vị tính";
            this.lbl_txtThuocDVT.TabIndex = 47;
            // 
            // txtThuocDVT
            // 
            this.txtThuocDVT.Location = new System.Drawing.Point(564, 12);
            this.txtThuocDVT.Name = "txtThuocDVT";
            this.txtThuocDVT.Size = new System.Drawing.Size(80, 20);
            this.txtThuocDVT.TabIndex = 48;
            // 
            // lbl_txtThuocHC
            // 
            this.lbl_txtThuocHC.Location = new System.Drawing.Point(15, 48);
            this.lbl_txtThuocHC.Name = "lbl_txtThuocHC";
            this.lbl_txtThuocHC.AutoSize = true;
            this.lbl_txtThuocHC.Text = "Hoạt chất";
            this.lbl_txtThuocHC.TabIndex = 49;
            // 
            // txtThuocHC
            // 
            this.txtThuocHC.Location = new System.Drawing.Point(86, 44);
            this.txtThuocHC.Name = "txtThuocHC";
            this.txtThuocHC.Size = new System.Drawing.Size(170, 20);
            this.txtThuocHC.TabIndex = 50;
            // 
            // lbl_txtThuocCCD
            // 
            this.lbl_txtThuocCCD.Location = new System.Drawing.Point(281, 48);
            this.lbl_txtThuocCCD.Name = "lbl_txtThuocCCD";
            this.lbl_txtThuocCCD.AutoSize = true;
            this.lbl_txtThuocCCD.Text = "Chống chỉ định";
            this.lbl_txtThuocCCD.TabIndex = 51;
            // 
            // txtThuocCCD
            // 
            this.txtThuocCCD.Location = new System.Drawing.Point(385, 44);
            this.txtThuocCCD.Name = "txtThuocCCD";
            this.txtThuocCCD.Size = new System.Drawing.Size(190, 20);
            this.txtThuocCCD.TabIndex = 52;
            // 
            // lbl_numThuocGia
            // 
            this.lbl_numThuocGia.Location = new System.Drawing.Point(600, 48);
            this.lbl_numThuocGia.Name = "lbl_numThuocGia";
            this.lbl_numThuocGia.AutoSize = true;
            this.lbl_numThuocGia.Text = "Đơn giá";
            this.lbl_numThuocGia.TabIndex = 53;
            // 
            // numThuocGia
            // 
            this.numThuocGia.Location = new System.Drawing.Point(658, 44);
            this.numThuocGia.Name = "numThuocGia";
            this.numThuocGia.Size = new System.Drawing.Size(100, 20);
            this.numThuocGia.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numThuocGia.Increment = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numThuocGia.ThousandsSeparator = true;
            this.numThuocGia.TabIndex = 54;
            // 
            // btnThemThuoc
            // 
            this.btnThemThuoc.Location = new System.Drawing.Point(740, 70);
            this.btnThemThuoc.Name = "btnThemThuoc";
            this.btnThemThuoc.Size = new System.Drawing.Size(110, 24);
            this.btnThemThuoc.Text = "Thêm";
            this.btnThemThuoc.UseVisualStyleBackColor = true;
            this.btnThemThuoc.TabIndex = 55;
            this.btnThemThuoc.Click += new System.EventHandler(this.btnThemThuoc_Click);
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.Location = new System.Drawing.Point(15, 100);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.Size = new System.Drawing.Size(842, 380);
            this.dgvThuoc.AllowUserToAddRows = false;
            this.dgvThuoc.AllowUserToDeleteRows = false;
            this.dgvThuoc.ReadOnly = true;
            this.dgvThuoc.MultiSelect = false;
            this.dgvThuoc.RowHeadersVisible = false;
            this.dgvThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuoc.TabIndex = 56;
            // 
            // FrmDanhMuc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Name = "FrmDanhMuc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục bệnh viện";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.Add(this.tabMain);
            this.tabMain.TabPages.Add(this.tabKhoa);
            this.tabKhoa.Controls.Add(this.lbl_txtKhoaMa);
            this.tabKhoa.Controls.Add(this.txtKhoaMa);
            this.tabKhoa.Controls.Add(this.lbl_txtKhoaTen);
            this.tabKhoa.Controls.Add(this.txtKhoaTen);
            this.tabKhoa.Controls.Add(this.lbl_numKhoaPhi);
            this.tabKhoa.Controls.Add(this.numKhoaPhi);
            this.tabKhoa.Controls.Add(this.btnThemKhoa);
            this.tabKhoa.Controls.Add(this.dgvKhoa);
            this.tabMain.TabPages.Add(this.tabBS);
            this.tabBS.Controls.Add(this.lbl_txtBSMa);
            this.tabBS.Controls.Add(this.txtBSMa);
            this.tabBS.Controls.Add(this.lbl_txtBSTen);
            this.tabBS.Controls.Add(this.txtBSTen);
            this.tabBS.Controls.Add(this.lbl_txtBSChuyenMon);
            this.tabBS.Controls.Add(this.txtBSChuyenMon);
            this.tabBS.Controls.Add(this.lbl_cboBSKhoa);
            this.tabBS.Controls.Add(this.cboBSKhoa);
            this.tabBS.Controls.Add(this.btnThemBS);
            this.tabBS.Controls.Add(this.dgvBS);
            this.tabMain.TabPages.Add(this.tabNV);
            this.tabNV.Controls.Add(this.lbl_txtNVMa);
            this.tabNV.Controls.Add(this.txtNVMa);
            this.tabNV.Controls.Add(this.lbl_txtNVTen);
            this.tabNV.Controls.Add(this.txtNVTen);
            this.tabNV.Controls.Add(this.lbl_cboNVVaiTro);
            this.tabNV.Controls.Add(this.cboNVVaiTro);
            this.tabNV.Controls.Add(this.btnThemNV);
            this.tabNV.Controls.Add(this.dgvNV);
            this.tabMain.TabPages.Add(this.tabTC);
            this.tabTC.Controls.Add(this.lbl_txtTCMa);
            this.tabTC.Controls.Add(this.txtTCMa);
            this.tabTC.Controls.Add(this.lbl_txtTCTen);
            this.tabTC.Controls.Add(this.txtTCTen);
            this.tabTC.Controls.Add(this.lbl_txtTCDonVi);
            this.tabTC.Controls.Add(this.txtTCDonVi);
            this.tabTC.Controls.Add(this.btnThemTC);
            this.tabTC.Controls.Add(this.dgvTC);
            this.tabMain.TabPages.Add(this.tabXNDM);
            this.tabXNDM.Controls.Add(this.lbl_txtXNMa);
            this.tabXNDM.Controls.Add(this.txtXNMa);
            this.tabXNDM.Controls.Add(this.lbl_txtXNTen);
            this.tabXNDM.Controls.Add(this.txtXNTen);
            this.tabXNDM.Controls.Add(this.lbl_numXNGia);
            this.tabXNDM.Controls.Add(this.numXNGia);
            this.tabXNDM.Controls.Add(this.btnThemXN);
            this.tabXNDM.Controls.Add(this.dgvXN);
            this.tabMain.TabPages.Add(this.tabThuoc);
            this.tabThuoc.Controls.Add(this.lbl_txtThuocMa);
            this.tabThuoc.Controls.Add(this.txtThuocMa);
            this.tabThuoc.Controls.Add(this.lbl_txtThuocTen);
            this.tabThuoc.Controls.Add(this.txtThuocTen);
            this.tabThuoc.Controls.Add(this.lbl_txtThuocDVT);
            this.tabThuoc.Controls.Add(this.txtThuocDVT);
            this.tabThuoc.Controls.Add(this.lbl_txtThuocHC);
            this.tabThuoc.Controls.Add(this.txtThuocHC);
            this.tabThuoc.Controls.Add(this.lbl_txtThuocCCD);
            this.tabThuoc.Controls.Add(this.txtThuocCCD);
            this.tabThuoc.Controls.Add(this.lbl_numThuocGia);
            this.tabThuoc.Controls.Add(this.numThuocGia);
            this.tabThuoc.Controls.Add(this.btnThemThuoc);
            this.tabThuoc.Controls.Add(this.dgvThuoc);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabKhoa;
        private System.Windows.Forms.Label lbl_txtKhoaMa;
        private System.Windows.Forms.TextBox txtKhoaMa;
        private System.Windows.Forms.Label lbl_txtKhoaTen;
        private System.Windows.Forms.TextBox txtKhoaTen;
        private System.Windows.Forms.Label lbl_numKhoaPhi;
        private System.Windows.Forms.NumericUpDown numKhoaPhi;
        private System.Windows.Forms.Button btnThemKhoa;
        private System.Windows.Forms.DataGridView dgvKhoa;
        private System.Windows.Forms.TabPage tabBS;
        private System.Windows.Forms.Label lbl_txtBSMa;
        private System.Windows.Forms.TextBox txtBSMa;
        private System.Windows.Forms.Label lbl_txtBSTen;
        private System.Windows.Forms.TextBox txtBSTen;
        private System.Windows.Forms.Label lbl_txtBSChuyenMon;
        private System.Windows.Forms.TextBox txtBSChuyenMon;
        private System.Windows.Forms.Label lbl_cboBSKhoa;
        private System.Windows.Forms.ComboBox cboBSKhoa;
        private System.Windows.Forms.Button btnThemBS;
        private System.Windows.Forms.DataGridView dgvBS;
        private System.Windows.Forms.TabPage tabNV;
        private System.Windows.Forms.Label lbl_txtNVMa;
        private System.Windows.Forms.TextBox txtNVMa;
        private System.Windows.Forms.Label lbl_txtNVTen;
        private System.Windows.Forms.TextBox txtNVTen;
        private System.Windows.Forms.Label lbl_cboNVVaiTro;
        private System.Windows.Forms.ComboBox cboNVVaiTro;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.DataGridView dgvNV;
        private System.Windows.Forms.TabPage tabTC;
        private System.Windows.Forms.Label lbl_txtTCMa;
        private System.Windows.Forms.TextBox txtTCMa;
        private System.Windows.Forms.Label lbl_txtTCTen;
        private System.Windows.Forms.TextBox txtTCTen;
        private System.Windows.Forms.Label lbl_txtTCDonVi;
        private System.Windows.Forms.TextBox txtTCDonVi;
        private System.Windows.Forms.Button btnThemTC;
        private System.Windows.Forms.DataGridView dgvTC;
        private System.Windows.Forms.TabPage tabXNDM;
        private System.Windows.Forms.Label lbl_txtXNMa;
        private System.Windows.Forms.TextBox txtXNMa;
        private System.Windows.Forms.Label lbl_txtXNTen;
        private System.Windows.Forms.TextBox txtXNTen;
        private System.Windows.Forms.Label lbl_numXNGia;
        private System.Windows.Forms.NumericUpDown numXNGia;
        private System.Windows.Forms.Button btnThemXN;
        private System.Windows.Forms.DataGridView dgvXN;
        private System.Windows.Forms.TabPage tabThuoc;
        private System.Windows.Forms.Label lbl_txtThuocMa;
        private System.Windows.Forms.TextBox txtThuocMa;
        private System.Windows.Forms.Label lbl_txtThuocTen;
        private System.Windows.Forms.TextBox txtThuocTen;
        private System.Windows.Forms.Label lbl_txtThuocDVT;
        private System.Windows.Forms.TextBox txtThuocDVT;
        private System.Windows.Forms.Label lbl_txtThuocHC;
        private System.Windows.Forms.TextBox txtThuocHC;
        private System.Windows.Forms.Label lbl_txtThuocCCD;
        private System.Windows.Forms.TextBox txtThuocCCD;
        private System.Windows.Forms.Label lbl_numThuocGia;
        private System.Windows.Forms.NumericUpDown numThuocGia;
        private System.Windows.Forms.Button btnThemThuoc;
        private System.Windows.Forms.DataGridView dgvThuoc;
    }
}
