namespace QuanLyKhachSan.Forms
{
    partial class FrmDatPhong
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKhach, tabDat, tabNhan;

        // Tab Khách hàng
        private System.Windows.Forms.Label lblMaKH, lblTenKH, lblCMND, lblQT, lblSDT;
        private System.Windows.Forms.TextBox txtMaKH, txtTenKH, txtCMND, txtQT, txtSDT;
        private System.Windows.Forms.Button btnThemKhach;
        private System.Windows.Forms.DataGridView dgvKhach;

        // Tab Đặt phòng
        private System.Windows.Forms.Label lblSoPhieu, lblKhach, lblNV, lblKenh, lblLap, lblNhan, lblTra, lblCoc, lblSoNguoi;
        private System.Windows.Forms.TextBox txtSoPhieu;
        private System.Windows.Forms.ComboBox cboKhach, cboNV, cboKenh;
        private System.Windows.Forms.DateTimePicker dtLap, dtNhan, dtTra;
        private System.Windows.Forms.NumericUpDown numCoc, numSoNguoi;
        private System.Windows.Forms.DataGridView dgvPhong, dgvChon, dgvPhieu;
        private System.Windows.Forms.Button btnThemPhong, btnBoPhong, btnLapPhieu;

        // Tab Nhận phòng / Người lưu trú
        private System.Windows.Forms.Label lblPhieuChon, lblNguoiPhong, lblNguoiTen, lblNguoiCMND, lblNguoiQT;
        private System.Windows.Forms.TextBox txtPhieuChon, txtNguoiPhong, txtNguoiTen, txtNguoiCMND, txtNguoiQT;
        private System.Windows.Forms.DataGridView dgvCT, dgvNguoi;
        private System.Windows.Forms.Button btnThemNguoi, btnNhanPhong, btnNoShow;

        private System.Windows.Forms.Button btnDong;

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabKhach = new System.Windows.Forms.TabPage();
            this.tabDat = new System.Windows.Forms.TabPage();
            this.tabNhan = new System.Windows.Forms.TabPage();

            // ===== Tab Khách hàng =====
            this.lblMaKH = new System.Windows.Forms.Label() { Text = "Mã KH:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtMaKH = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 100 };
            this.lblTenKH = new System.Windows.Forms.Label() { Text = "Họ tên:", Location = new System.Drawing.Point(210, 20), AutoSize = true };
            this.txtTenKH = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(270, 17), Width = 180 };
            this.lblCMND = new System.Windows.Forms.Label() { Text = "CCCD/CMND:", Location = new System.Drawing.Point(470, 20), AutoSize = true };
            this.txtCMND = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(570, 17), Width = 130 };
            this.lblQT = new System.Windows.Forms.Label() { Text = "Quốc tịch:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            this.txtQT = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 57), Width = 150 };
            this.lblSDT = new System.Windows.Forms.Label() { Text = "SĐT:", Location = new System.Drawing.Point(260, 60), AutoSize = true };
            this.txtSDT = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(300, 57), Width = 130 };
            this.btnThemKhach = new System.Windows.Forms.Button() { Text = "Thêm khách", Location = new System.Drawing.Point(710, 55), Size = new System.Drawing.Size(120, 25) };
            this.dgvKhach = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 100), Size = new System.Drawing.Size(840, 280), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemKhach.Click += new System.EventHandler(this.btnThemKhach_Click);
            this.tabKhach.Text = "Khách hàng";
            this.tabKhach.Controls.AddRange(new System.Windows.Forms.Control[] { lblMaKH, txtMaKH, lblTenKH, txtTenKH, lblCMND, txtCMND, lblQT, txtQT, lblSDT, txtSDT, btnThemKhach, dgvKhach });

            // ===== Tab Đặt phòng =====
            this.lblSoPhieu = new System.Windows.Forms.Label() { Text = "Số phiếu:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtSoPhieu = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 100 };
            this.lblKhach = new System.Windows.Forms.Label() { Text = "Khách:", Location = new System.Drawing.Point(210, 20), AutoSize = true };
            this.cboKhach = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(260, 17), Width = 160, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblNV = new System.Windows.Forms.Label() { Text = "Lễ tân:", Location = new System.Drawing.Point(440, 20), AutoSize = true };
            this.cboNV = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(490, 17), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblKenh = new System.Windows.Forms.Label() { Text = "Kênh đặt:", Location = new System.Drawing.Point(660, 20), AutoSize = true };
            this.cboKenh = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(730, 17), Width = 130, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            this.lblLap = new System.Windows.Forms.Label() { Text = "Ngày lập:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            this.dtLap = new System.Windows.Forms.DateTimePicker() { Location = new System.Drawing.Point(90, 57), Width = 140 };
            this.lblNhan = new System.Windows.Forms.Label() { Text = "Ngày nhận:", Location = new System.Drawing.Point(250, 60), AutoSize = true };
            this.dtNhan = new System.Windows.Forms.DateTimePicker() { Location = new System.Drawing.Point(330, 57), Width = 140 };
            this.lblTra = new System.Windows.Forms.Label() { Text = "Ngày trả DK:", Location = new System.Drawing.Point(490, 60), AutoSize = true };
            this.dtTra = new System.Windows.Forms.DateTimePicker() { Location = new System.Drawing.Point(580, 57), Width = 140 };
            this.lblCoc = new System.Windows.Forms.Label() { Text = "Tiền cọc:", Location = new System.Drawing.Point(740, 60), AutoSize = true };
            this.numCoc = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(810, 57), Width = 90, Maximum = 100000000, DecimalPlaces = 0 };

            this.dgvPhong = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 100), Size = new System.Drawing.Size(400, 150), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.lblSoNguoi = new System.Windows.Forms.Label() { Text = "Số người:", Location = new System.Drawing.Point(440, 100), AutoSize = true };
            this.numSoNguoi = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(440, 120), Width = 70, Minimum = 1, Maximum = 20, Value = 1 };
            this.btnThemPhong = new System.Windows.Forms.Button() { Text = "Thêm phòng >>", Location = new System.Drawing.Point(440, 150), Size = new System.Drawing.Size(120, 30) };
            this.btnBoPhong = new System.Windows.Forms.Button() { Text = "<< Bỏ phòng", Location = new System.Drawing.Point(440, 190), Size = new System.Drawing.Size(120, 30) };
            this.dgvChon = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(580, 100), Size = new System.Drawing.Size(280, 150), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };

            this.btnLapPhieu = new System.Windows.Forms.Button() { Text = "Lập phiếu đặt", Location = new System.Drawing.Point(760, 260), Size = new System.Drawing.Size(100, 30) };

            this.dgvPhieu = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 300), Size = new System.Drawing.Size(840, 150), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.dgvPhieu.SelectionChanged += new System.EventHandler(this.dgvPhieu_SelectionChanged);

            this.tabDat.Text = "Đặt phòng";
            this.tabDat.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblSoPhieu, txtSoPhieu, lblKhach, cboKhach, lblNV, cboNV, lblKenh, cboKenh,
                lblLap, dtLap, lblNhan, dtNhan, lblTra, dtTra, lblCoc, numCoc,
                dgvPhong, lblSoNguoi, numSoNguoi, btnThemPhong, btnBoPhong, dgvChon,
                btnLapPhieu, dgvPhieu
            });

            // ===== Tab Nhận phòng / Người lưu trú =====
            this.lblPhieuChon = new System.Windows.Forms.Label() { Text = "Phiếu đặt:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtPhieuChon = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 120, ReadOnly = true };
            this.dgvCT = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(400, 150), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.dgvNguoi = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(440, 60), Size = new System.Drawing.Size(420, 150), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };

            this.lblNguoiPhong = new System.Windows.Forms.Label() { Text = "Phòng:", Location = new System.Drawing.Point(20, 230), AutoSize = true };
            this.txtNguoiPhong = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(80, 227), Width = 100 };
            this.lblNguoiTen = new System.Windows.Forms.Label() { Text = "Họ tên:", Location = new System.Drawing.Point(200, 230), AutoSize = true };
            this.txtNguoiTen = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(260, 227), Width = 180 };
            this.lblNguoiCMND = new System.Windows.Forms.Label() { Text = "CCCD:", Location = new System.Drawing.Point(460, 230), AutoSize = true };
            this.txtNguoiCMND = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(510, 227), Width = 130 };
            this.lblNguoiQT = new System.Windows.Forms.Label() { Text = "Quốc tịch:", Location = new System.Drawing.Point(660, 230), AutoSize = true };
            this.txtNguoiQT = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(730, 227), Width = 100 };
            this.btnThemNguoi = new System.Windows.Forms.Button() { Text = "Thêm người lưu trú", Location = new System.Drawing.Point(20, 265), Size = new System.Drawing.Size(150, 30) };
            this.btnNhanPhong = new System.Windows.Forms.Button() { Text = "Nhận phòng", Location = new System.Drawing.Point(190, 265), Size = new System.Drawing.Size(120, 30) };
            this.btnNoShow = new System.Windows.Forms.Button() { Text = "Đánh dấu No-show", Location = new System.Drawing.Point(320, 265), Size = new System.Drawing.Size(150, 30) };

            this.btnThemNguoi.Click += new System.EventHandler(this.btnThemNguoi_Click);
            this.btnNhanPhong.Click += new System.EventHandler(this.btnNhanPhong_Click);
            this.btnNoShow.Click += new System.EventHandler(this.btnNoShow_Click);

            this.tabNhan.Text = "Nhận phòng / Người lưu trú";
            this.tabNhan.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblPhieuChon, txtPhieuChon, dgvCT, dgvNguoi,
                lblNguoiPhong, txtNguoiPhong, lblNguoiTen, txtNguoiTen, lblNguoiCMND, txtNguoiCMND, lblNguoiQT, txtNguoiQT,
                btnThemNguoi, btnNhanPhong, btnNoShow
            });

            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            this.btnBoPhong.Click += new System.EventHandler(this.btnBoPhong_Click);
            this.btnLapPhieu.Click += new System.EventHandler(this.btnLapPhieu_Click);

            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(880, 470);
            this.tabControl.TabPages.AddRange(new System.Windows.Forms.TabPage[] { tabKhach, tabDat, tabNhan });

            this.btnDong = new System.Windows.Forms.Button() { Text = "Đóng", Location = new System.Drawing.Point(790, 490), Size = new System.Drawing.Size(100, 30) };
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.ClientSize = new System.Drawing.Size(900, 530);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnDong);
            this.Text = "Khách hàng - Đặt phòng - Nhận phòng";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_Load);
        }
    }
}