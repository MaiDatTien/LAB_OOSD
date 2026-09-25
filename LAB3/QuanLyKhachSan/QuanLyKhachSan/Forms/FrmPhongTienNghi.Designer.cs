namespace QuanLyKhachSan.Forms
{
    partial class FrmPhongTienNghi
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPhong, tabTienNghi, tabLapDat;

        // Tab Phòng
        private System.Windows.Forms.Label lblPhong, lblKhu, lblMax, lblGia;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.ComboBox cboKhu;
        private System.Windows.Forms.NumericUpDown numMax, numGia;
        private System.Windows.Forms.Button btnThemPhong;
        private System.Windows.Forms.DataGridView dgvPhong;

        // Tab Tiện nghi
        private System.Windows.Forms.Label lblMaTN, lblLoai, lblSTT, lblTinhTrang;
        private System.Windows.Forms.TextBox txtMaTN, txtTinhTrang;
        private System.Windows.Forms.ComboBox cboLoai;
        private System.Windows.Forms.NumericUpDown numSTT;
        private System.Windows.Forms.Button btnThemTN;
        private System.Windows.Forms.DataGridView dgvTN;

        // Tab Lắp đặt
        private System.Windows.Forms.Label lblSoLD, lblTN, lblPhongLD, lblNgay, lblTTLD, lblNVLD, lblGhiChu;
        private System.Windows.Forms.TextBox txtSoLD, txtTTLD, txtGhiChu;
        private System.Windows.Forms.ComboBox cboTN, cboPhong, cboNV;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.Button btnLapDat;
        private System.Windows.Forms.DataGridView dgvLD;

        private System.Windows.Forms.Button btnDong;

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPhong = new System.Windows.Forms.TabPage();
            this.tabTienNghi = new System.Windows.Forms.TabPage();
            this.tabLapDat = new System.Windows.Forms.TabPage();

            // ===== Tab Phòng =====
            this.lblPhong = new System.Windows.Forms.Label() { Text = "Số phòng:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtPhong = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 100 };
            this.lblKhu = new System.Windows.Forms.Label() { Text = "Khu vực:", Location = new System.Drawing.Point(210, 20), AutoSize = true };
            this.cboKhu = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(280, 17), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblMax = new System.Windows.Forms.Label() { Text = "Số người tối đa:", Location = new System.Drawing.Point(450, 20), AutoSize = true };
            this.numMax = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(560, 17), Width = 60, Minimum = 1, Maximum = 20, Value = 2 };
            this.lblGia = new System.Windows.Forms.Label() { Text = "Đơn giá/ngày:", Location = new System.Drawing.Point(640, 20), AutoSize = true };
            this.numGia = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(740, 17), Width = 90, Maximum = 100000000, DecimalPlaces = 0 };
            this.btnThemPhong = new System.Windows.Forms.Button() { Text = "Thêm phòng", Location = new System.Drawing.Point(20, 55), Size = new System.Drawing.Size(120, 25) };
            this.dgvPhong = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(830, 290), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemPhong.Click += new System.EventHandler(this.btnThemPhong_Click);
            this.tabPhong.Text = "Phòng";
            this.tabPhong.Controls.AddRange(new System.Windows.Forms.Control[] { lblPhong, txtPhong, lblKhu, cboKhu, lblMax, numMax, lblGia, numGia, btnThemPhong, dgvPhong });

            // ===== Tab Tiện nghi =====
            this.lblMaTN = new System.Windows.Forms.Label() { Text = "Mã tiện nghi:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtMaTN = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(110, 17), Width = 100 };
            this.lblLoai = new System.Windows.Forms.Label() { Text = "Loại:", Location = new System.Drawing.Point(230, 20), AutoSize = true };
            this.cboLoai = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(270, 17), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblSTT = new System.Windows.Forms.Label() { Text = "Số thứ tự:", Location = new System.Drawing.Point(440, 20), AutoSize = true };
            this.numSTT = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(510, 17), Width = 60, Minimum = 1, Maximum = 1000, Value = 1 };
            this.lblTinhTrang = new System.Windows.Forms.Label() { Text = "Tình trạng:", Location = new System.Drawing.Point(590, 20), AutoSize = true };
            this.txtTinhTrang = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(670, 17), Width = 150 };
            this.btnThemTN = new System.Windows.Forms.Button() { Text = "Thêm tiện nghi", Location = new System.Drawing.Point(20, 55), Size = new System.Drawing.Size(130, 25) };
            this.dgvTN = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(830, 290), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemTN.Click += new System.EventHandler(this.btnThemTN_Click);
            this.tabTienNghi.Text = "Tiện nghi";
            this.tabTienNghi.Controls.AddRange(new System.Windows.Forms.Control[] { lblMaTN, txtMaTN, lblLoai, cboLoai, lblSTT, numSTT, lblTinhTrang, txtTinhTrang, btnThemTN, dgvTN });

            // ===== Tab Lắp đặt =====
            this.lblSoLD = new System.Windows.Forms.Label() { Text = "Phiếu lắp đặt:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtSoLD = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(110, 17), Width = 100 };
            this.lblTN = new System.Windows.Forms.Label() { Text = "Tiện nghi:", Location = new System.Drawing.Point(230, 20), AutoSize = true };
            this.cboTN = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(300, 17), Width = 120, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblPhongLD = new System.Windows.Forms.Label() { Text = "Phòng:", Location = new System.Drawing.Point(440, 20), AutoSize = true };
            this.cboPhong = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(490, 17), Width = 120, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblNgay = new System.Windows.Forms.Label() { Text = "Ngày:", Location = new System.Drawing.Point(630, 20), AutoSize = true };
            this.dtNgay = new System.Windows.Forms.DateTimePicker() { Location = new System.Drawing.Point(670, 17), Width = 140 };

            this.lblTTLD = new System.Windows.Forms.Label() { Text = "Tình trạng:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            this.txtTTLD = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(100, 57), Width = 150 };
            this.lblNVLD = new System.Windows.Forms.Label() { Text = "Nhân viên:", Location = new System.Drawing.Point(270, 60), AutoSize = true };
            this.cboNV = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(340, 57), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblGhiChu = new System.Windows.Forms.Label() { Text = "Ghi chú:", Location = new System.Drawing.Point(510, 60), AutoSize = true };
            this.txtGhiChu = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(570, 57), Width = 240 };

            this.btnLapDat = new System.Windows.Forms.Button() { Text = "Lập phiếu", Location = new System.Drawing.Point(730, 90), Size = new System.Drawing.Size(100, 30) };
            this.dgvLD = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 130), Size = new System.Drawing.Size(830, 250), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnLapDat.Click += new System.EventHandler(this.btnLapDat_Click);

            this.tabLapDat.Text = "Lắp đặt / luân chuyển";
            this.tabLapDat.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblSoLD, txtSoLD, lblTN, cboTN, lblPhongLD, cboPhong, lblNgay, dtNgay,
                lblTTLD, txtTTLD, lblNVLD, cboNV, lblGhiChu, txtGhiChu,
                btnLapDat, dgvLD
            });

            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(870, 420);
            this.tabControl.TabPages.AddRange(new System.Windows.Forms.TabPage[] { tabPhong, tabTienNghi, tabLapDat });

            this.btnDong = new System.Windows.Forms.Button() { Text = "Đóng", Location = new System.Drawing.Point(780, 440), Size = new System.Drawing.Size(100, 30) };
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.ClientSize = new System.Drawing.Size(890, 480);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnDong);
            this.Text = "Phòng - Tiện nghi - Phiếu lắp đặt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_Load);
        }
    }
}