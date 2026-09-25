namespace QuanLyKhachSan.Forms
{
    partial class FrmThongKe
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing) { if (disposing && (components != null)) components.Dispose(); base.Dispose(disposing); }

        private System.Windows.Forms.Label lblTu, lblDen;
        private System.Windows.Forms.DateTimePicker dtTu, dtDen;
        private System.Windows.Forms.Button btnTK, btnDong;
        private System.Windows.Forms.DataGridView dgvTongHop, dgvDV;
        private System.Windows.Forms.Label lblTongHop, lblDV;

        private void InitializeComponent()
        {
            this.lblTu = new System.Windows.Forms.Label() { Text = "Từ ngày:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            this.dtTu = new System.Windows.Forms.DateTimePicker() { Location = new System.Drawing.Point(90, 17), Width = 150, Format = System.Windows.Forms.DateTimePickerFormat.Short };
            this.lblDen = new System.Windows.Forms.Label() { Text = "Đến ngày:", Location = new System.Drawing.Point(260, 20), AutoSize = true };
            this.dtDen = new System.Windows.Forms.DateTimePicker() { Location = new System.Drawing.Point(340, 17), Width = 150, Format = System.Windows.Forms.DateTimePickerFormat.Short };
            this.btnTK = new System.Windows.Forms.Button() { Text = "Thống kê", Location = new System.Drawing.Point(520, 15), Size = new System.Drawing.Size(120, 30) };
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);

            this.lblTongHop = new System.Windows.Forms.Label() { Text = "Tổng hợp:", Location = new System.Drawing.Point(20, 70), AutoSize = true, Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold) };
            this.dgvTongHop = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 95), Size = new System.Drawing.Size(810, 100), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };

            this.lblDV = new System.Windows.Forms.Label() { Text = "Dịch vụ sử dụng:", Location = new System.Drawing.Point(20, 210), AutoSize = true };
            this.dgvDV = new System.Windows.Forms.DataGridView() { Location = new System.Drawing.Point(20, 230), Size = new System.Drawing.Size(810, 250), BackgroundColor = System.Drawing.Color.White, AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill, AllowUserToAddRows = false };

            this.btnDong = new System.Windows.Forms.Button() { Text = "Đóng", Location = new System.Drawing.Point(750, 500), Size = new System.Drawing.Size(80, 30) };
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);

            this.ClientSize = new System.Drawing.Size(850, 550);
            this.Controls.AddRange(new System.Windows.Forms.Control[] { lblTu, dtTu, lblDen, dtDen, btnTK, lblTongHop, dgvTongHop, lblDV, dgvDV, btnDong });
            this.Text = "Thống kê khách sạn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        }
    }
}