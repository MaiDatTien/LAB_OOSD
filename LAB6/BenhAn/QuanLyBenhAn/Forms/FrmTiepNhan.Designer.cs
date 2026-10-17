namespace QuanLyBenhAn.Forms
{
    partial class FrmTiepNhan
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
            this.tabDangKy = new System.Windows.Forms.TabPage();
            this.tabGiaHan = new System.Windows.Forms.TabPage();
            this.tabTraCuu = new System.Windows.Forms.TabPage();
            this.lbl_txtTen = new System.Windows.Forms.Label();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.lbl_txtDiaChi = new System.Windows.Forms.Label();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.lbl_dtNgaySinh = new System.Windows.Forms.Label();
            this.dtNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lbl_txtSDT = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.lbl_numLePhi = new System.Windows.Forms.Label();
            this.numLePhi = new System.Windows.Forms.NumericUpDown();
            this.lbl_cboHT = new System.Windows.Forms.Label();
            this.cboHT = new System.Windows.Forms.ComboBox();
            this.lbl_cboNV = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnDangKy = new System.Windows.Forms.Button();
            this.lblMaHS = new System.Windows.Forms.Label();
            this.picAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.lbl_hsgh = new System.Windows.Forms.Label();
            this.txtHSGiaHan = new System.Windows.Forms.TextBox();
            this.lbl_lpgh = new System.Windows.Forms.Label();
            this.numLePhiGH = new System.Windows.Forms.NumericUpDown();
            this.lbl_htgh = new System.Windows.Forms.Label();
            this.cboHTGH = new System.Windows.Forms.ComboBox();
            this.btnGiaHan = new System.Windows.Forms.Button();
            this.lbl_ghnv = new System.Windows.Forms.Label();
            this.lbl_tk = new System.Windows.Forms.Label();
            this.txtTuKhoa = new System.Windows.Forms.TextBox();
            this.btnTim = new System.Windows.Forms.Button();
            this.dgvHoSo = new System.Windows.Forms.DataGridView();
            this.picAnhHS = new System.Windows.Forms.PictureBox();
            this.lbl_ls = new System.Windows.Forms.Label();
            this.dgvLichSu = new System.Windows.Forms.DataGridView();
            this.lbl_tc = new System.Windows.Forms.Label();
            this.dgvTrieuChung = new System.Windows.Forms.DataGridView();
            this.lbl_xn = new System.Windows.Forms.Label();
            this.dgvXNChon = new System.Windows.Forms.DataGridView();
            this.lbl_toa = new System.Windows.Forms.Label();
            this.dgvToa = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            this.tabMain.SuspendLayout();
            // 
            // tabMain
            // 
            this.tabMain.Location = new System.Drawing.Point(10, 10);
            this.tabMain.Name = "tabMain";
            this.tabMain.Size = new System.Drawing.Size(980, 680);
            this.tabMain.TabIndex = 0;
            // 
            // tabDangKy
            // 
            this.tabDangKy.Name = "tabDangKy";
            this.tabDangKy.Text = "Đăng ký lần đầu";
            this.tabDangKy.UseVisualStyleBackColor = true;
            this.tabDangKy.Padding = new System.Windows.Forms.Padding(3);
            // 
            // tabGiaHan
            // 
            this.tabGiaHan.Name = "tabGiaHan";
            this.tabGiaHan.Text = "Gia hạn lệ phí";
            this.tabGiaHan.UseVisualStyleBackColor = true;
            this.tabGiaHan.Padding = new System.Windows.Forms.Padding(3);
            // 
            // tabTraCuu
            // 
            this.tabTraCuu.Name = "tabTraCuu";
            this.tabTraCuu.Text = "Tra cứu và lịch sử";
            this.tabTraCuu.UseVisualStyleBackColor = true;
            this.tabTraCuu.Padding = new System.Windows.Forms.Padding(3);
            // 
            // lbl_txtTen
            // 
            this.lbl_txtTen.Location = new System.Drawing.Point(20, 28);
            this.lbl_txtTen.Name = "lbl_txtTen";
            this.lbl_txtTen.AutoSize = true;
            this.lbl_txtTen.Text = "Họ tên";
            this.lbl_txtTen.TabIndex = 1;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(130, 24);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(280, 20);
            this.txtTen.TabIndex = 2;
            // 
            // lbl_txtDiaChi
            // 
            this.lbl_txtDiaChi.Location = new System.Drawing.Point(20, 68);
            this.lbl_txtDiaChi.Name = "lbl_txtDiaChi";
            this.lbl_txtDiaChi.AutoSize = true;
            this.lbl_txtDiaChi.Text = "Địa chỉ";
            this.lbl_txtDiaChi.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(130, 64);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(280, 20);
            this.txtDiaChi.TabIndex = 4;
            // 
            // lbl_dtNgaySinh
            // 
            this.lbl_dtNgaySinh.Location = new System.Drawing.Point(20, 108);
            this.lbl_dtNgaySinh.Name = "lbl_dtNgaySinh";
            this.lbl_dtNgaySinh.AutoSize = true;
            this.lbl_dtNgaySinh.Text = "Ngày sinh";
            this.lbl_dtNgaySinh.TabIndex = 5;
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.Location = new System.Drawing.Point(130, 104);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Size = new System.Drawing.Size(130, 20);
            this.dtNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtNgaySinh.CustomFormat = "dd/MM/yyyy";
            this.dtNgaySinh.TabIndex = 6;
            // 
            // lbl_txtSDT
            // 
            this.lbl_txtSDT.Location = new System.Drawing.Point(20, 148);
            this.lbl_txtSDT.Name = "lbl_txtSDT";
            this.lbl_txtSDT.AutoSize = true;
            this.lbl_txtSDT.Text = "Điện thoại";
            this.lbl_txtSDT.TabIndex = 7;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(130, 144);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(160, 20);
            this.txtSDT.TabIndex = 8;
            // 
            // lbl_numLePhi
            // 
            this.lbl_numLePhi.Location = new System.Drawing.Point(20, 188);
            this.lbl_numLePhi.Name = "lbl_numLePhi";
            this.lbl_numLePhi.AutoSize = true;
            this.lbl_numLePhi.Text = "Lệ phí năm";
            this.lbl_numLePhi.TabIndex = 9;
            // 
            // numLePhi
            // 
            this.numLePhi.Location = new System.Drawing.Point(130, 184);
            this.numLePhi.Name = "numLePhi";
            this.numLePhi.Size = new System.Drawing.Size(130, 20);
            this.numLePhi.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numLePhi.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numLePhi.ThousandsSeparator = true;
            this.numLePhi.TabIndex = 10;
            // 
            // lbl_cboHT
            // 
            this.lbl_cboHT.Location = new System.Drawing.Point(20, 228);
            this.lbl_cboHT.Name = "lbl_cboHT";
            this.lbl_cboHT.AutoSize = true;
            this.lbl_cboHT.Text = "Hình thức";
            this.lbl_cboHT.TabIndex = 11;
            // 
            // cboHT
            // 
            this.cboHT.Location = new System.Drawing.Point(130, 224);
            this.cboHT.Name = "cboHT";
            this.cboHT.Size = new System.Drawing.Size(160, 21);
            this.cboHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHT.FormattingEnabled = true;
            this.cboHT.TabIndex = 12;
            // 
            // lbl_cboNV
            // 
            this.lbl_cboNV.Location = new System.Drawing.Point(20, 268);
            this.lbl_cboNV.Name = "lbl_cboNV";
            this.lbl_cboNV.AutoSize = true;
            this.lbl_cboNV.Text = "Nhân viên";
            this.lbl_cboNV.TabIndex = 13;
            // 
            // cboNV
            // 
            this.cboNV.Location = new System.Drawing.Point(130, 264);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(200, 21);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.TabIndex = 14;
            // 
            // btnDangKy
            // 
            this.btnDangKy.Location = new System.Drawing.Point(130, 314);
            this.btnDangKy.Name = "btnDangKy";
            this.btnDangKy.Size = new System.Drawing.Size(130, 34);
            this.btnDangKy.Text = "Đăng ký";
            this.btnDangKy.UseVisualStyleBackColor = true;
            this.btnDangKy.TabIndex = 15;
            this.btnDangKy.Click += new System.EventHandler(this.btnDangKy_Click);
            // 
            // lblMaHS
            // 
            this.lblMaHS.Location = new System.Drawing.Point(130, 366);
            this.lblMaHS.Name = "lblMaHS";
            this.lblMaHS.AutoSize = true;
            this.lblMaHS.Text = "Mã hồ sơ: ";
            this.lblMaHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMaHS.TabIndex = 16;
            // 
            // picAnh
            // 
            this.picAnh.Location = new System.Drawing.Point(560, 24);
            this.picAnh.Name = "picAnh";
            this.picAnh.Size = new System.Drawing.Size(180, 240);
            this.picAnh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnh.TabStop = false;
            this.picAnh.TabIndex = 17;
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(560, 274);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(180, 30);
            this.btnChonAnh.Text = "Chọn ảnh 3x4";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.TabIndex = 18;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // lbl_hsgh
            // 
            this.lbl_hsgh.Location = new System.Drawing.Point(20, 28);
            this.lbl_hsgh.Name = "lbl_hsgh";
            this.lbl_hsgh.AutoSize = true;
            this.lbl_hsgh.Text = "Mã hồ sơ";
            this.lbl_hsgh.TabIndex = 19;
            // 
            // txtHSGiaHan
            // 
            this.txtHSGiaHan.Location = new System.Drawing.Point(130, 24);
            this.txtHSGiaHan.Name = "txtHSGiaHan";
            this.txtHSGiaHan.Size = new System.Drawing.Size(160, 20);
            this.txtHSGiaHan.TabIndex = 20;
            // 
            // lbl_lpgh
            // 
            this.lbl_lpgh.Location = new System.Drawing.Point(20, 68);
            this.lbl_lpgh.Name = "lbl_lpgh";
            this.lbl_lpgh.AutoSize = true;
            this.lbl_lpgh.Text = "Lệ phí năm";
            this.lbl_lpgh.TabIndex = 21;
            // 
            // numLePhiGH
            // 
            this.numLePhiGH.Location = new System.Drawing.Point(130, 64);
            this.numLePhiGH.Name = "numLePhiGH";
            this.numLePhiGH.Size = new System.Drawing.Size(130, 20);
            this.numLePhiGH.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numLePhiGH.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numLePhiGH.ThousandsSeparator = true;
            this.numLePhiGH.TabIndex = 22;
            // 
            // lbl_htgh
            // 
            this.lbl_htgh.Location = new System.Drawing.Point(20, 108);
            this.lbl_htgh.Name = "lbl_htgh";
            this.lbl_htgh.AutoSize = true;
            this.lbl_htgh.Text = "Hình thức";
            this.lbl_htgh.TabIndex = 23;
            // 
            // cboHTGH
            // 
            this.cboHTGH.Location = new System.Drawing.Point(130, 104);
            this.cboHTGH.Name = "cboHTGH";
            this.cboHTGH.Size = new System.Drawing.Size(160, 21);
            this.cboHTGH.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHTGH.FormattingEnabled = true;
            this.cboHTGH.TabIndex = 24;
            // 
            // btnGiaHan
            // 
            this.btnGiaHan.Location = new System.Drawing.Point(130, 150);
            this.btnGiaHan.Name = "btnGiaHan";
            this.btnGiaHan.Size = new System.Drawing.Size(130, 34);
            this.btnGiaHan.Text = "Gia hạn";
            this.btnGiaHan.UseVisualStyleBackColor = true;
            this.btnGiaHan.TabIndex = 25;
            this.btnGiaHan.Click += new System.EventHandler(this.btnGiaHan_Click);
            // 
            // lbl_ghnv
            // 
            this.lbl_ghnv.Location = new System.Drawing.Point(130, 200);
            this.lbl_ghnv.Name = "lbl_ghnv";
            this.lbl_ghnv.AutoSize = true;
            this.lbl_ghnv.Text = "Nhân viên thực hiện được chọn ở ô Nhân viên của tab Đăng ký lần đầu.";
            this.lbl_ghnv.TabIndex = 26;
            // 
            // lbl_tk
            // 
            this.lbl_tk.Location = new System.Drawing.Point(20, 24);
            this.lbl_tk.Name = "lbl_tk";
            this.lbl_tk.AutoSize = true;
            this.lbl_tk.Text = "Từ khóa (mã hồ sơ, họ tên, SĐT, ngày sinh dd/MM/yyyy)";
            this.lbl_tk.TabIndex = 27;
            // 
            // txtTuKhoa
            // 
            this.txtTuKhoa.Location = new System.Drawing.Point(340, 20);
            this.txtTuKhoa.Name = "txtTuKhoa";
            this.txtTuKhoa.Size = new System.Drawing.Size(280, 20);
            this.txtTuKhoa.TabIndex = 28;
            // 
            // btnTim
            // 
            this.btnTim.Location = new System.Drawing.Point(640, 17);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(90, 28);
            this.btnTim.Text = "Tìm";
            this.btnTim.UseVisualStyleBackColor = true;
            this.btnTim.TabIndex = 29;
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // dgvHoSo
            // 
            this.dgvHoSo.Location = new System.Drawing.Point(20, 55);
            this.dgvHoSo.Name = "dgvHoSo";
            this.dgvHoSo.Size = new System.Drawing.Size(700, 140);
            this.dgvHoSo.AllowUserToAddRows = false;
            this.dgvHoSo.AllowUserToDeleteRows = false;
            this.dgvHoSo.ReadOnly = true;
            this.dgvHoSo.MultiSelect = false;
            this.dgvHoSo.RowHeadersVisible = false;
            this.dgvHoSo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHoSo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHoSo.BackgroundColor = System.Drawing.Color.White;
            this.dgvHoSo.TabIndex = 30;
            this.dgvHoSo.SelectionChanged += new System.EventHandler(this.dgvHoSo_SelectionChanged);
            // 
            // picAnhHS
            // 
            this.picAnhHS.Location = new System.Drawing.Point(740, 55);
            this.picAnhHS.Name = "picAnhHS";
            this.picAnhHS.Size = new System.Drawing.Size(120, 150);
            this.picAnhHS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAnhHS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picAnhHS.TabStop = false;
            this.picAnhHS.TabIndex = 31;
            // 
            // lbl_ls
            // 
            this.lbl_ls.Location = new System.Drawing.Point(20, 208);
            this.lbl_ls.Name = "lbl_ls";
            this.lbl_ls.AutoSize = true;
            this.lbl_ls.Text = "Lịch sử khám (mới đến cũ)";
            this.lbl_ls.TabIndex = 32;
            // 
            // dgvLichSu
            // 
            this.dgvLichSu.Location = new System.Drawing.Point(20, 228);
            this.dgvLichSu.Name = "dgvLichSu";
            this.dgvLichSu.Size = new System.Drawing.Size(930, 170);
            this.dgvLichSu.AllowUserToAddRows = false;
            this.dgvLichSu.AllowUserToDeleteRows = false;
            this.dgvLichSu.ReadOnly = true;
            this.dgvLichSu.MultiSelect = false;
            this.dgvLichSu.RowHeadersVisible = false;
            this.dgvLichSu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLichSu.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLichSu.BackgroundColor = System.Drawing.Color.White;
            this.dgvLichSu.TabIndex = 33;
            this.dgvLichSu.SelectionChanged += new System.EventHandler(this.dgvLichSu_SelectionChanged);
            // 
            // lbl_tc
            // 
            this.lbl_tc.Location = new System.Drawing.Point(20, 408);
            this.lbl_tc.Name = "lbl_tc";
            this.lbl_tc.AutoSize = true;
            this.lbl_tc.Text = "Triệu chứng của phiếu";
            this.lbl_tc.TabIndex = 34;
            // 
            // dgvTrieuChung
            // 
            this.dgvTrieuChung.Location = new System.Drawing.Point(20, 428);
            this.dgvTrieuChung.Name = "dgvTrieuChung";
            this.dgvTrieuChung.Size = new System.Drawing.Size(300, 210);
            this.dgvTrieuChung.AllowUserToAddRows = false;
            this.dgvTrieuChung.AllowUserToDeleteRows = false;
            this.dgvTrieuChung.ReadOnly = true;
            this.dgvTrieuChung.MultiSelect = false;
            this.dgvTrieuChung.RowHeadersVisible = false;
            this.dgvTrieuChung.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrieuChung.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTrieuChung.BackgroundColor = System.Drawing.Color.White;
            this.dgvTrieuChung.TabIndex = 35;
            // 
            // lbl_xn
            // 
            this.lbl_xn.Location = new System.Drawing.Point(335, 408);
            this.lbl_xn.Name = "lbl_xn";
            this.lbl_xn.AutoSize = true;
            this.lbl_xn.Text = "Xét nghiệm của phiếu";
            this.lbl_xn.TabIndex = 36;
            // 
            // dgvXNChon
            // 
            this.dgvXNChon.Location = new System.Drawing.Point(335, 428);
            this.dgvXNChon.Name = "dgvXNChon";
            this.dgvXNChon.Size = new System.Drawing.Size(320, 210);
            this.dgvXNChon.AllowUserToAddRows = false;
            this.dgvXNChon.AllowUserToDeleteRows = false;
            this.dgvXNChon.ReadOnly = true;
            this.dgvXNChon.MultiSelect = false;
            this.dgvXNChon.RowHeadersVisible = false;
            this.dgvXNChon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvXNChon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvXNChon.BackgroundColor = System.Drawing.Color.White;
            this.dgvXNChon.TabIndex = 37;
            // 
            // lbl_toa
            // 
            this.lbl_toa.Location = new System.Drawing.Point(670, 408);
            this.lbl_toa.Name = "lbl_toa";
            this.lbl_toa.AutoSize = true;
            this.lbl_toa.Text = "Toa thuốc của phiếu";
            this.lbl_toa.TabIndex = 38;
            // 
            // dgvToa
            // 
            this.dgvToa.Location = new System.Drawing.Point(670, 428);
            this.dgvToa.Name = "dgvToa";
            this.dgvToa.Size = new System.Drawing.Size(280, 210);
            this.dgvToa.AllowUserToAddRows = false;
            this.dgvToa.AllowUserToDeleteRows = false;
            this.dgvToa.ReadOnly = true;
            this.dgvToa.MultiSelect = false;
            this.dgvToa.RowHeadersVisible = false;
            this.dgvToa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvToa.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvToa.BackgroundColor = System.Drawing.Color.White;
            this.dgvToa.TabIndex = 39;
            // 
            // FrmTiepNhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Name = "FrmTiepNhan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tiếp nhận – Hồ sơ bệnh án";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.Add(this.tabMain);
            this.tabMain.TabPages.Add(this.tabDangKy);
            this.tabMain.TabPages.Add(this.tabGiaHan);
            this.tabMain.TabPages.Add(this.tabTraCuu);
            this.tabDangKy.Controls.Add(this.lbl_txtTen);
            this.tabDangKy.Controls.Add(this.txtTen);
            this.tabDangKy.Controls.Add(this.lbl_txtDiaChi);
            this.tabDangKy.Controls.Add(this.txtDiaChi);
            this.tabDangKy.Controls.Add(this.lbl_dtNgaySinh);
            this.tabDangKy.Controls.Add(this.dtNgaySinh);
            this.tabDangKy.Controls.Add(this.lbl_txtSDT);
            this.tabDangKy.Controls.Add(this.txtSDT);
            this.tabDangKy.Controls.Add(this.lbl_numLePhi);
            this.tabDangKy.Controls.Add(this.numLePhi);
            this.tabDangKy.Controls.Add(this.lbl_cboHT);
            this.tabDangKy.Controls.Add(this.cboHT);
            this.tabDangKy.Controls.Add(this.lbl_cboNV);
            this.tabDangKy.Controls.Add(this.cboNV);
            this.tabDangKy.Controls.Add(this.btnDangKy);
            this.tabDangKy.Controls.Add(this.lblMaHS);
            this.tabDangKy.Controls.Add(this.picAnh);
            this.tabDangKy.Controls.Add(this.btnChonAnh);
            this.tabGiaHan.Controls.Add(this.lbl_hsgh);
            this.tabGiaHan.Controls.Add(this.txtHSGiaHan);
            this.tabGiaHan.Controls.Add(this.lbl_lpgh);
            this.tabGiaHan.Controls.Add(this.numLePhiGH);
            this.tabGiaHan.Controls.Add(this.lbl_htgh);
            this.tabGiaHan.Controls.Add(this.cboHTGH);
            this.tabGiaHan.Controls.Add(this.btnGiaHan);
            this.tabGiaHan.Controls.Add(this.lbl_ghnv);
            this.tabTraCuu.Controls.Add(this.lbl_tk);
            this.tabTraCuu.Controls.Add(this.txtTuKhoa);
            this.tabTraCuu.Controls.Add(this.btnTim);
            this.tabTraCuu.Controls.Add(this.dgvHoSo);
            this.tabTraCuu.Controls.Add(this.picAnhHS);
            this.tabTraCuu.Controls.Add(this.lbl_ls);
            this.tabTraCuu.Controls.Add(this.dgvLichSu);
            this.tabTraCuu.Controls.Add(this.lbl_tc);
            this.tabTraCuu.Controls.Add(this.dgvTrieuChung);
            this.tabTraCuu.Controls.Add(this.lbl_xn);
            this.tabTraCuu.Controls.Add(this.dgvXNChon);
            this.tabTraCuu.Controls.Add(this.lbl_toa);
            this.tabTraCuu.Controls.Add(this.dgvToa);
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabDangKy;
        private System.Windows.Forms.TabPage tabGiaHan;
        private System.Windows.Forms.TabPage tabTraCuu;
        private System.Windows.Forms.Label lbl_txtTen;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.Label lbl_txtDiaChi;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.Label lbl_dtNgaySinh;
        private System.Windows.Forms.DateTimePicker dtNgaySinh;
        private System.Windows.Forms.Label lbl_txtSDT;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label lbl_numLePhi;
        private System.Windows.Forms.NumericUpDown numLePhi;
        private System.Windows.Forms.Label lbl_cboHT;
        private System.Windows.Forms.ComboBox cboHT;
        private System.Windows.Forms.Label lbl_cboNV;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnDangKy;
        private System.Windows.Forms.Label lblMaHS;
        private System.Windows.Forms.PictureBox picAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.Label lbl_hsgh;
        private System.Windows.Forms.TextBox txtHSGiaHan;
        private System.Windows.Forms.Label lbl_lpgh;
        private System.Windows.Forms.NumericUpDown numLePhiGH;
        private System.Windows.Forms.Label lbl_htgh;
        private System.Windows.Forms.ComboBox cboHTGH;
        private System.Windows.Forms.Button btnGiaHan;
        private System.Windows.Forms.Label lbl_ghnv;
        private System.Windows.Forms.Label lbl_tk;
        private System.Windows.Forms.TextBox txtTuKhoa;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.DataGridView dgvHoSo;
        private System.Windows.Forms.PictureBox picAnhHS;
        private System.Windows.Forms.Label lbl_ls;
        private System.Windows.Forms.DataGridView dgvLichSu;
        private System.Windows.Forms.Label lbl_tc;
        private System.Windows.Forms.DataGridView dgvTrieuChung;
        private System.Windows.Forms.Label lbl_xn;
        private System.Windows.Forms.DataGridView dgvXNChon;
        private System.Windows.Forms.Label lbl_toa;
        private System.Windows.Forms.DataGridView dgvToa;
    }
}
