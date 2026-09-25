namespace QuanLyKhachSan.Forms
{
    partial class FrmTraPhong
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private System.Windows.Forms.Label lblDat;
        private System.Windows.Forms.ComboBox cboDat;
        private System.Windows.Forms.DataGridView dgvPhong, dgvTN, dgvDBChon, dgvHD;
        private System.Windows.Forms.Label lblPhong;
        private System.Windows.Forms.TextBox txtPhong;

        private System.Windows.Forms.Label lblSoDB, lblMucDo, lblSoTienDB, lblNVDB;
        private System.Windows.Forms.TextBox txtSoDB, txtMucDo;
        private System.Windows.Forms.NumericUpDown numDenBu;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnThemDB, btnLapDB;

        private System.Windows.Forms.Label lblSoHD, lblSoNgay, lblNVHD;
        private System.Windows.Forms.TextBox txtSoHD;
        private System.Windows.Forms.NumericUpDown numSoNgay;
        private System.Windows.Forms.ComboBox cboNV2;
        private System.Windows.Forms.Button btnLapHD;

        private System.Windows.Forms.Label lblHDChon, lblHT, lblTienTT, lblMaTT;
        private System.Windows.Forms.TextBox txtHDChon, txtMaTT;
        private System.Windows.Forms.ComboBox cboHT;
        private System.Windows.Forms.NumericUpDown numTienTT;
        private System.Windows.Forms.Button btnThanhToan, btnTraPhong;

        private System.Windows.Forms.Button btnDong;

        private void InitializeComponent()
        {
            this.lblDat = new System.Windows.Forms.Label() { Text = "Phiếu đang ở:", Location = new System.Drawing.Point(20, 15), AutoSize = true };
            this.cboDat = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(120, 12), Width = 180, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            this.dgvPhong = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 50), Size = new System.Drawing.Size(260, 130), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.dgvTN = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(300, 50), Size = new System.Drawing.Size(280, 130), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.dgvDBChon = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(600, 50), Size = new System.Drawing.Size(280, 130), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.dgvPhong.SelectionChanged += new System.EventHandler(this.dgvPhong_SelectionChanged);

            this.lblPhong = new System.Windows.Forms.Label() { Text = "Phòng chọn:", Location = new System.Drawing.Point(20, 190), AutoSize = true };
            this.txtPhong = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(100, 187), Width = 100, ReadOnly = true };

            this.lblSoDB = new System.Windows.Forms.Label() { Text = "Số phiếu đền bù:", Location = new System.Drawing.Point(20, 220), AutoSize = true };
            this.txtSoDB = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(130, 217), Width = 100 };
            this.lblMucDo = new System.Windows.Forms.Label() { Text = "Mức độ:", Location = new System.Drawing.Point(250, 220), AutoSize = true };
            this.txtMucDo = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(310, 217), Width = 150 };
            this.lblSoTienDB = new System.Windows.Forms.Label() { Text = "Số tiền:", Location = new System.Drawing.Point(480, 220), AutoSize = true };
            this.numDenBu = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(540, 217), Width = 100, Maximum = 100000000, DecimalPlaces = 0 };
            this.lblNVDB = new System.Windows.Forms.Label() { Text = "Nhân viên:", Location = new System.Drawing.Point(660, 220), AutoSize = true };
            this.cboNV = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(730, 217), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.btnThemDB = new System.Windows.Forms.Button() { Text = "Thêm TN đền bù", Location = new System.Drawing.Point(20, 250), Size = new System.Drawing.Size(150, 25) };
            this.btnLapDB = new System.Windows.Forms.Button() { Text = "Lập phiếu đền bù", Location = new System.Drawing.Point(730, 250), Size = new System.Drawing.Size(150, 25) };
            this.btnThemDB.Click += new System.EventHandler(this.btnThemDB_Click);
            this.btnLapDB.Click += new System.EventHandler(this.btnLapDB_Click);

            this.lblSoHD = new System.Windows.Forms.Label() { Text = "Số hóa đơn:", Location = new System.Drawing.Point(20, 290), AutoSize = true };
            this.txtSoHD = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(100, 287), Width = 100 };
            this.lblSoNgay = new System.Windows.Forms.Label() { Text = "Số ngày tính tiền:", Location = new System.Drawing.Point(220, 290), AutoSize = true };
            this.numSoNgay = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(340, 287), Width = 60, Minimum = 1, Maximum = 365, Value = 1 };
            this.lblNVHD = new System.Windows.Forms.Label() { Text = "Nhân viên TT:", Location = new System.Drawing.Point(420, 290), AutoSize = true };
            this.cboNV2 = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(510, 287), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.btnLapHD = new System.Windows.Forms.Button() { Text = "Lập hóa đơn", Location = new System.Drawing.Point(730, 285), Size = new System.Drawing.Size(150, 25) };
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);

            this.dgvHD = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 320), Size = new System.Drawing.Size(860, 150), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.dgvHD.SelectionChanged += new System.EventHandler(this.dgvHD_SelectionChanged);

            this.lblHDChon = new System.Windows.Forms.Label() { Text = "Hóa đơn chọn:", Location = new System.Drawing.Point(20, 480), AutoSize = true };
            this.txtHDChon = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(120, 477), Width = 100, ReadOnly = true };
            this.lblMaTT = new System.Windows.Forms.Label() { Text = "Mã TT:", Location = new System.Drawing.Point(240, 480), AutoSize = true };
            this.txtMaTT = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(290, 477), Width = 100 };
            this.lblHT = new System.Windows.Forms.Label() { Text = "Hình thức:", Location = new System.Drawing.Point(410, 480), AutoSize = true };
            this.cboHT = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(480, 477), Width = 130, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblTienTT = new System.Windows.Forms.Label() { Text = "Số tiền:", Location = new System.Drawing.Point(630, 480), AutoSize = true };
            this.numTienTT = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(690, 477), Width = 100, Maximum = 100000000, DecimalPlaces = 0 };
            this.btnThanhToan = new System.Windows.Forms.Button() { Text = "Thanh toán", Location = new System.Drawing.Point(20, 510), Size = new System.Drawing.Size(120, 30) };
            this.btnTraPhong = new System.Windows.Forms.Button() { Text = "Hoàn tất trả phòng", Location = new System.Drawing.Point(160, 510), Size = new System.Drawing.Size(150, 30) };
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            this.btnTraPhong.Click += new System.EventHandler(this.btnTraPhong_Click);

            this.btnDong = new System.Windows.Forms.Button() { Text = "Đóng", Location = new System.Drawing.Point(790, 510), Size = new System.Drawing.Size(90, 30) };
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                lblDat, cboDat, dgvPhong, dgvTN, dgvDBChon, lblPhong, txtPhong,
                lblSoDB, txtSoDB, lblMucDo, txtMucDo, lblSoTienDB, numDenBu, lblNVDB, cboNV, btnThemDB, btnLapDB,
                lblSoHD, txtSoHD, lblSoNgay, numSoNgay, lblNVHD, cboNV2, btnLapHD, dgvHD,
                lblHDChon, txtHDChon, lblMaTT, txtMaTT, lblHT, cboHT, lblTienTT, numTienTT, btnThanhToan, btnTraPhong,
                btnDong
            });
            this.Text = "Trả phòng - Đền bù - Hóa đơn - Thanh toán";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Frm_Load);
        }
    }
}