namespace QuanLyBenhAn.Forms
{
    partial class FrmThongKe
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
            this.c1 = new System.Windows.Forms.Label();
            this.dtTu = new System.Windows.Forms.DateTimePicker();
            this.c2 = new System.Windows.Forms.Label();
            this.dtDen = new System.Windows.Forms.DateTimePicker();
            this.btnTK = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.c3 = new System.Windows.Forms.Label();
            this.dgvTongHop = new System.Windows.Forms.DataGridView();
            this.c4 = new System.Windows.Forms.Label();
            this.dgvThuoc = new System.Windows.Forms.DataGridView();
            this.c5 = new System.Windows.Forms.Label();
            this.dgvBacSi = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // c1
            // 
            this.c1.Location = new System.Drawing.Point(20, 24);
            this.c1.Name = "c1";
            this.c1.AutoSize = true;
            this.c1.Text = "Từ ngày";
            this.c1.TabIndex = 0;
            // 
            // dtTu
            // 
            this.dtTu.Location = new System.Drawing.Point(80, 20);
            this.dtTu.Name = "dtTu";
            this.dtTu.Size = new System.Drawing.Size(120, 20);
            this.dtTu.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTu.CustomFormat = "dd/MM/yyyy";
            this.dtTu.TabIndex = 1;
            // 
            // c2
            // 
            this.c2.Location = new System.Drawing.Point(220, 24);
            this.c2.Name = "c2";
            this.c2.AutoSize = true;
            this.c2.Text = "Đến ngày";
            this.c2.TabIndex = 2;
            // 
            // dtDen
            // 
            this.dtDen.Location = new System.Drawing.Point(285, 20);
            this.dtDen.Name = "dtDen";
            this.dtDen.Size = new System.Drawing.Size(120, 20);
            this.dtDen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDen.CustomFormat = "dd/MM/yyyy";
            this.dtDen.TabIndex = 3;
            // 
            // btnTK
            // 
            this.btnTK.Location = new System.Drawing.Point(430, 16);
            this.btnTK.Name = "btnTK";
            this.btnTK.Size = new System.Drawing.Size(100, 30);
            this.btnTK.Text = "Thống kê";
            this.btnTK.UseVisualStyleBackColor = true;
            this.btnTK.TabIndex = 4;
            this.btnTK.Click += new System.EventHandler(this.btnTK_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(545, 16);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 30);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 5;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // c3
            // 
            this.c3.Location = new System.Drawing.Point(20, 62);
            this.c3.Name = "c3";
            this.c3.AutoSize = true;
            this.c3.Text = "Tổng hợp";
            this.c3.TabIndex = 6;
            // 
            // dgvTongHop
            // 
            this.dgvTongHop.Location = new System.Drawing.Point(20, 82);
            this.dgvTongHop.Name = "dgvTongHop";
            this.dgvTongHop.Size = new System.Drawing.Size(850, 90);
            this.dgvTongHop.AllowUserToAddRows = false;
            this.dgvTongHop.AllowUserToDeleteRows = false;
            this.dgvTongHop.ReadOnly = true;
            this.dgvTongHop.MultiSelect = false;
            this.dgvTongHop.RowHeadersVisible = false;
            this.dgvTongHop.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTongHop.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTongHop.BackgroundColor = System.Drawing.Color.White;
            this.dgvTongHop.TabIndex = 7;
            // 
            // c4
            // 
            this.c4.Location = new System.Drawing.Point(20, 188);
            this.c4.Name = "c4";
            this.c4.AutoSize = true;
            this.c4.Text = "Thuốc đã kê";
            this.c4.TabIndex = 8;
            // 
            // dgvThuoc
            // 
            this.dgvThuoc.Location = new System.Drawing.Point(20, 208);
            this.dgvThuoc.Name = "dgvThuoc";
            this.dgvThuoc.Size = new System.Drawing.Size(420, 360);
            this.dgvThuoc.AllowUserToAddRows = false;
            this.dgvThuoc.AllowUserToDeleteRows = false;
            this.dgvThuoc.ReadOnly = true;
            this.dgvThuoc.MultiSelect = false;
            this.dgvThuoc.RowHeadersVisible = false;
            this.dgvThuoc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvThuoc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvThuoc.BackgroundColor = System.Drawing.Color.White;
            this.dgvThuoc.TabIndex = 9;
            // 
            // c5
            // 
            this.c5.Location = new System.Drawing.Point(460, 188);
            this.c5.Name = "c5";
            this.c5.AutoSize = true;
            this.c5.Text = "Số phiếu theo bác sĩ";
            this.c5.TabIndex = 10;
            // 
            // dgvBacSi
            // 
            this.dgvBacSi.Location = new System.Drawing.Point(460, 208);
            this.dgvBacSi.Name = "dgvBacSi";
            this.dgvBacSi.Size = new System.Drawing.Size(410, 360);
            this.dgvBacSi.AllowUserToAddRows = false;
            this.dgvBacSi.AllowUserToDeleteRows = false;
            this.dgvBacSi.ReadOnly = true;
            this.dgvBacSi.MultiSelect = false;
            this.dgvBacSi.RowHeadersVisible = false;
            this.dgvBacSi.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBacSi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBacSi.BackgroundColor = System.Drawing.Color.White;
            this.dgvBacSi.TabIndex = 11;
            // 
            // FrmThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Name = "FrmThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Controls.Add(this.c1);
            this.Controls.Add(this.dtTu);
            this.Controls.Add(this.c2);
            this.Controls.Add(this.dtDen);
            this.Controls.Add(this.btnTK);
            this.Controls.Add(this.btnDong);
            this.Controls.Add(this.c3);
            this.Controls.Add(this.dgvTongHop);
            this.Controls.Add(this.c4);
            this.Controls.Add(this.dgvThuoc);
            this.Controls.Add(this.c5);
            this.Controls.Add(this.dgvBacSi);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label c1;
        private System.Windows.Forms.DateTimePicker dtTu;
        private System.Windows.Forms.Label c2;
        private System.Windows.Forms.DateTimePicker dtDen;
        private System.Windows.Forms.Button btnTK;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label c3;
        private System.Windows.Forms.DataGridView dgvTongHop;
        private System.Windows.Forms.Label c4;
        private System.Windows.Forms.DataGridView dgvThuoc;
        private System.Windows.Forms.Label c5;
        private System.Windows.Forms.DataGridView dgvBacSi;
    }
}
