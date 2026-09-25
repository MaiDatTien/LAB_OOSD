namespace QuanLyKhachSan.Forms
{
    partial class FrmDanhMuc
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabKhuVuc, tabNhanVien, tabLoaiTN, tabDichVu, tabQuyDinh;

        private System.Windows.Forms.Label lblKhuMa, lblKhuTen;
        private System.Windows.Forms.TextBox txtKhuMa, txtKhuTen;
        private System.Windows.Forms.Button btnThemKhu;
        private System.Windows.Forms.DataGridView dgvKhu;

        private System.Windows.Forms.Label lblNVMa, lblNVTen, lblNVVaiTro, lblNVSDT;
        private System.Windows.Forms.TextBox txtNVMa, txtNVTen, txtNVVaiTro, txtNVSDT;
        private System.Windows.Forms.Button btnThemNV;
        private System.Windows.Forms.DataGridView dgvNV;

        private System.Windows.Forms.Label lblLoaiMa, lblLoaiTen;
        private System.Windows.Forms.TextBox txtLoaiMa, txtLoaiTen;
        private System.Windows.Forms.Button btnThemLoaiTN;
        private System.Windows.Forms.DataGridView dgvLoaiTN;

        private System.Windows.Forms.Label lblDVMa, lblDVTen, lblDVDVT, lblDVGia;
        private System.Windows.Forms.TextBox txtDVMa, txtDVTen, txtDVDVT;
        private System.Windows.Forms.NumericUpDown numDVGia;
        private System.Windows.Forms.Button btnThemDV;
        private System.Windows.Forms.DataGridView dgvDV;

        private System.Windows.Forms.Label lblQDMa, lblQDLoai, lblQDMucDo, lblQDTien;
        private System.Windows.Forms.TextBox txtQDMa, txtQDMucDo;
        private System.Windows.Forms.ComboBox cboQDLoai;
        private System.Windows.Forms.NumericUpDown numQDTien;
        private System.Windows.Forms.Button btnThemQD;
        private System.Windows.Forms.DataGridView dgvQD;

        private System.Windows.Forms.Button btnDong;

        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabKhuVuc = new System.Windows.Forms.TabPage();
            this.tabNhanVien = new System.Windows.Forms.TabPage();
            this.tabLoaiTN = new System.Windows.Forms.TabPage();
            this.tabDichVu = new System.Windows.Forms.TabPage();
            this.tabQuyDinh = new System.Windows.Forms.TabPage();

            // ===== Tab Khu vực =====
            this.lblKhuMa = new System.Windows.Forms.Label() { Text = "Mã khu vực:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtKhuMa = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(120, 17), Width = 150 };
            this.lblKhuTen = new System.Windows.Forms.Label() { Text = "Tên khu vực:", Location = new System.Drawing.Point(300, 20), AutoSize = true };
            this.txtKhuTen = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(400, 17), Width = 200 };
            this.btnThemKhu = new System.Windows.Forms.Button() { Text = "Thêm", Location = new System.Drawing.Point(650, 15), Size = new System.Drawing.Size(80, 25) };
            this.dgvKhu = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(850, 320), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemKhu.Click += new System.EventHandler(this.btnThemKhu_Click);
            this.tabKhuVuc.Text = "Khu vực";
            this.tabKhuVuc.Controls.AddRange(new System.Windows.Forms.Control[] { lblKhuMa, txtKhuMa, lblKhuTen, txtKhuTen, btnThemKhu, dgvKhu });

            // ===== Tab Nhân viên =====
            this.lblNVMa = new System.Windows.Forms.Label() { Text = "Mã NV:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtNVMa = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 100 };
            this.lblNVTen = new System.Windows.Forms.Label() { Text = "Họ tên:", Location = new System.Drawing.Point(210, 20), AutoSize = true };
            this.txtNVTen = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(270, 17), Width = 180 };
            this.lblNVVaiTro = new System.Windows.Forms.Label() { Text = "Vai trò:", Location = new System.Drawing.Point(470, 20), AutoSize = true };
            this.txtNVVaiTro = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(530, 17), Width = 150 };
            this.lblNVSDT = new System.Windows.Forms.Label() { Text = "SĐT:", Location = new System.Drawing.Point(700, 20), AutoSize = true };
            this.txtNVSDT = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(740, 17), Width = 100 };
            this.btnThemNV = new System.Windows.Forms.Button() { Text = "Thêm", Location = new System.Drawing.Point(20, 55), Size = new System.Drawing.Size(80, 25) };
            this.dgvNV = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(850, 290), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemNV.Click += new System.EventHandler(this.btnThemNV_Click);
            this.tabNhanVien.Text = "Nhân viên";
            this.tabNhanVien.Controls.AddRange(new System.Windows.Forms.Control[] { lblNVMa, txtNVMa, lblNVTen, txtNVTen, lblNVVaiTro, txtNVVaiTro, lblNVSDT, txtNVSDT, btnThemNV, dgvNV });

            // ===== Tab Loại tiện nghi =====
            this.lblLoaiMa = new System.Windows.Forms.Label() { Text = "Mã loại:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtLoaiMa = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 150 };
            this.lblLoaiTen = new System.Windows.Forms.Label() { Text = "Tên loại:", Location = new System.Drawing.Point(270, 20), AutoSize = true };
            this.txtLoaiTen = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(340, 17), Width = 200 };
            this.btnThemLoaiTN = new System.Windows.Forms.Button() { Text = "Thêm", Location = new System.Drawing.Point(570, 15), Size = new System.Drawing.Size(80, 25) };
            this.dgvLoaiTN = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 60), Size = new System.Drawing.Size(850, 320), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemLoaiTN.Click += new System.EventHandler(this.btnThemLoaiTN_Click);
            this.tabLoaiTN.Text = "Loại tiện nghi";
            this.tabLoaiTN.Controls.AddRange(new System.Windows.Forms.Control[] { lblLoaiMa, txtLoaiMa, lblLoaiTen, txtLoaiTen, btnThemLoaiTN, dgvLoaiTN });

            // ===== Tab Dịch vụ =====
            this.lblDVMa = new System.Windows.Forms.Label() { Text = "Mã DV:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtDVMa = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 100 };
            this.lblDVTen = new System.Windows.Forms.Label() { Text = "Tên DV:", Location = new System.Drawing.Point(210, 20), AutoSize = true };
            this.txtDVTen = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(280, 17), Width = 180 };
            this.lblDVDVT = new System.Windows.Forms.Label() { Text = "Đơn vị tính:", Location = new System.Drawing.Point(480, 20), AutoSize = true };
            this.txtDVDVT = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(560, 17), Width = 100 };
            this.lblDVGia = new System.Windows.Forms.Label() { Text = "Đơn giá:", Location = new System.Drawing.Point(680, 20), AutoSize = true };
            this.numDVGia = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(750, 17), Width = 100, Maximum = 100000000, DecimalPlaces = 0 };
            this.btnThemDV = new System.Windows.Forms.Button() { Text = "Thêm", Location = new System.Drawing.Point(20, 55), Size = new System.Drawing.Size(80, 25) };
            this.dgvDV = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(850, 290), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemDV.Click += new System.EventHandler(this.btnThemDV_Click);
            this.tabDichVu.Text = "Dịch vụ";
            this.tabDichVu.Controls.AddRange(new System.Windows.Forms.Control[] { lblDVMa, txtDVMa, lblDVTen, txtDVTen, lblDVDVT, txtDVDVT, lblDVGia, numDVGia, btnThemDV, dgvDV });

            // ===== Tab Quy định đền bù =====
            this.lblQDMa = new System.Windows.Forms.Label() { Text = "Mã QĐ:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.txtQDMa = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(90, 17), Width = 100 };
            this.lblQDLoai = new System.Windows.Forms.Label() { Text = "Loại TN:", Location = new System.Drawing.Point(210, 20), AutoSize = true };
            this.cboQDLoai = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(280, 17), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblQDMucDo = new System.Windows.Forms.Label() { Text = "Mức độ:", Location = new System.Drawing.Point(450, 20), AutoSize = true };
            this.txtQDMucDo = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(520, 17), Width = 150 };
            this.lblQDTien = new System.Windows.Forms.Label() { Text = "Số tiền:", Location = new System.Drawing.Point(690, 20), AutoSize = true };
            this.numQDTien = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(750, 17), Width = 100, Maximum = 100000000, DecimalPlaces = 0 };
            this.btnThemQD = new System.Windows.Forms.Button() { Text = "Thêm", Location = new System.Drawing.Point(20, 55), Size = new System.Drawing.Size(80, 25) };
            this.dgvQD = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 90), Size = new System.Drawing.Size(850, 290), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };
            this.btnThemQD.Click += new System.EventHandler(this.btnThemQD_Click);
            this.tabQuyDinh.Text = "Quy định đền bù";
            this.tabQuyDinh.Controls.AddRange(new System.Windows.Forms.Control[] { lblQDMa, txtQDMa, lblQDLoai, cboQDLoai, lblQDMucDo, txtQDMucDo, lblQDTien, numQDTien, btnThemQD, dgvQD });

            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Size = new System.Drawing.Size(900, 400);
            this.tabControl.TabPages.AddRange(new System.Windows.Forms.TabPage[] { tabKhuVuc, tabNhanVien, tabLoaiTN, tabDichVu, tabQuyDinh });

            this.btnDong = new System.Windows.Forms.Button() { Text = "Đóng", Location = new System.Drawing.Point(810, 420), Size = new System.Drawing.Size(100, 30) };
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.ClientSize = new System.Drawing.Size(930, 470);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btnDong);
            this.Text = "Danh mục khách sạn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmDanhMuc_Load);
        }
    }
}