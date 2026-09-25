namespace QuanLyKhachSan.Forms
{
    partial class FrmDichVu
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private System.Windows.Forms.Label lblLuot, lblPhong, lblDV, lblNV, lblNgay, lblSL;
        private System.Windows.Forms.ComboBox cboLuot, cboDV, cboNV;
        private System.Windows.Forms.TextBox txtPhong;
        private System.Windows.Forms.DateTimePicker dtNgay;
        private System.Windows.Forms.NumericUpDown numSL;
        private System.Windows.Forms.Button btnGhi, btnDong;
        private System.Windows.Forms.DataGridView dgvLichSu;

        private void InitializeComponent()
        {
            this.lblLuot = new System.Windows.Forms.Label() { Text = "Phiếu lưu trú:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.cboLuot = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(120, 17), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };
            this.lblPhong = new System.Windows.Forms.Label() { Text = "Phòng:", Location = new System.Drawing.Point(290, 20), AutoSize = true };
            this.txtPhong = new System.Windows.Forms.TextBox() { Location = new System.Drawing.Point(340, 17), Width = 100, ReadOnly = true };
            this.lblDV = new System.Windows.Forms.Label() { Text = "Dịch vụ:", Location = new System.Drawing.Point(460, 20), AutoSize = true };
            this.cboDV = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(520, 17), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            this.lblNgay = new System.Windows.Forms.Label() { Text = "Ngày sử dụng:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            this.dtNgay = new System.Windows.Forms.DateTimePicker() { Location = new System.Drawing.Point(120, 57), Width = 150 };
            this.lblSL = new System.Windows.Forms.Label() { Text = "Số lượng:", Location = new System.Drawing.Point(290, 60), AutoSize = true };
            this.numSL = new System.Windows.Forms.NumericUpDown() { Location = new System.Drawing.Point(360, 57), Width = 70, Minimum = 1, Maximum = 1000, Value = 1 };
            this.lblNV = new System.Windows.Forms.Label() { Text = "Nhân viên:", Location = new System.Drawing.Point(460, 60), AutoSize = true };
            this.cboNV = new System.Windows.Forms.ComboBox() { Location = new System.Drawing.Point(530, 57), Width = 150, DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList };

            this.btnGhi = new System.Windows.Forms.Button() { Text = "Ghi nhận", Location = new System.Drawing.Point(700, 55), Size = new System.Drawing.Size(120, 25) };
            this.btnGhi.Click += new System.EventHandler(this.btnGhi_Click);

            this.dgvLichSu = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 100), Size = new System.Drawing.Size(800, 300), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };

            this.btnDong = new System.Windows.Forms.Button() { Text = "Đóng", Location = new System.Drawing.Point(740, 420), Size = new System.Drawing.Size(80, 30) };
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.cboLuot.SelectedIndexChanged += new System.EventHandler(this.cboLuot_SelectedIndexChanged);

            this.ClientSize = new System.Drawing.Size(840, 470);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { lblLuot, cboLuot, lblPhong, txtPhong, lblDV, cboDV, lblNgay, dtNgay, lblSL, numSL, lblNV, cboNV, btnGhi, dgvLichSu, btnDong });
            this.Text = "Sử dụng dịch vụ";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FrmDichVu_Load);
        }
    }
}