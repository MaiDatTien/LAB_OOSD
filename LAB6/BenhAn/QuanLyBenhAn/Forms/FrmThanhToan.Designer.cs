namespace QuanLyBenhAn.Forms
{
    partial class FrmThanhToan
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
            this.b1 = new System.Windows.Forms.Label();
            this.cboPhieu = new System.Windows.Forms.ComboBox();
            this.b2 = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnLapHD = new System.Windows.Forms.Button();
            this.dgvHD = new System.Windows.Forms.DataGridView();
            this.b3 = new System.Windows.Forms.Label();
            this.txtHDChon = new System.Windows.Forms.TextBox();
            this.b4 = new System.Windows.Forms.Label();
            this.txtPhieuChon = new System.Windows.Forms.TextBox();
            this.lblConLai = new System.Windows.Forms.Label();
            this.b5 = new System.Windows.Forms.Label();
            this.cboHT = new System.Windows.Forms.ComboBox();
            this.b6 = new System.Windows.Forms.Label();
            this.numTien = new System.Windows.Forms.NumericUpDown();
            this.btnThanhToan = new System.Windows.Forms.Button();
            this.btnHoanTat = new System.Windows.Forms.Button();
            this.btnDong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b1
            // 
            this.b1.Location = new System.Drawing.Point(20, 24);
            this.b1.Name = "b1";
            this.b1.AutoSize = true;
            this.b1.Text = "Phiếu chờ thanh toán";
            this.b1.TabIndex = 0;
            // 
            // cboPhieu
            // 
            this.cboPhieu.Location = new System.Drawing.Point(150, 20);
            this.cboPhieu.Name = "cboPhieu";
            this.cboPhieu.Size = new System.Drawing.Size(160, 21);
            this.cboPhieu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhieu.FormattingEnabled = true;
            this.cboPhieu.TabIndex = 1;
            // 
            // b2
            // 
            this.b2.Location = new System.Drawing.Point(335, 24);
            this.b2.Name = "b2";
            this.b2.AutoSize = true;
            this.b2.Text = "Thu ngân";
            this.b2.TabIndex = 2;
            // 
            // cboNV
            // 
            this.cboNV.Location = new System.Drawing.Point(395, 20);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(180, 21);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.TabIndex = 3;
            // 
            // btnLapHD
            // 
            this.btnLapHD.Location = new System.Drawing.Point(600, 16);
            this.btnLapHD.Name = "btnLapHD";
            this.btnLapHD.Size = new System.Drawing.Size(130, 30);
            this.btnLapHD.Text = "Lập hóa đơn";
            this.btnLapHD.UseVisualStyleBackColor = true;
            this.btnLapHD.TabIndex = 4;
            this.btnLapHD.Click += new System.EventHandler(this.btnLapHD_Click);
            // 
            // dgvHD
            // 
            this.dgvHD.Location = new System.Drawing.Point(20, 60);
            this.dgvHD.Name = "dgvHD";
            this.dgvHD.Size = new System.Drawing.Size(850, 300);
            this.dgvHD.AllowUserToAddRows = false;
            this.dgvHD.AllowUserToDeleteRows = false;
            this.dgvHD.ReadOnly = true;
            this.dgvHD.MultiSelect = false;
            this.dgvHD.RowHeadersVisible = false;
            this.dgvHD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHD.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHD.BackgroundColor = System.Drawing.Color.White;
            this.dgvHD.TabIndex = 5;
            this.dgvHD.SelectionChanged += new System.EventHandler(this.dgvHD_SelectionChanged);
            // 
            // b3
            // 
            this.b3.Location = new System.Drawing.Point(20, 384);
            this.b3.Name = "b3";
            this.b3.AutoSize = true;
            this.b3.Text = "Hóa đơn";
            this.b3.TabIndex = 6;
            // 
            // txtHDChon
            // 
            this.txtHDChon.Location = new System.Drawing.Point(75, 380);
            this.txtHDChon.Name = "txtHDChon";
            this.txtHDChon.Size = new System.Drawing.Size(110, 20);
            this.txtHDChon.ReadOnly = true;
            this.txtHDChon.TabIndex = 7;
            // 
            // b4
            // 
            this.b4.Location = new System.Drawing.Point(205, 384);
            this.b4.Name = "b4";
            this.b4.AutoSize = true;
            this.b4.Text = "Phiếu khám";
            this.b4.TabIndex = 8;
            // 
            // txtPhieuChon
            // 
            this.txtPhieuChon.Location = new System.Drawing.Point(275, 380);
            this.txtPhieuChon.Name = "txtPhieuChon";
            this.txtPhieuChon.Size = new System.Drawing.Size(110, 20);
            this.txtPhieuChon.ReadOnly = true;
            this.txtPhieuChon.TabIndex = 9;
            // 
            // lblConLai
            // 
            this.lblConLai.Location = new System.Drawing.Point(410, 384);
            this.lblConLai.Name = "lblConLai";
            this.lblConLai.AutoSize = true;
            this.lblConLai.Text = "Còn phải trả: 0";
            this.lblConLai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblConLai.TabIndex = 10;
            // 
            // b5
            // 
            this.b5.Location = new System.Drawing.Point(20, 432);
            this.b5.Name = "b5";
            this.b5.AutoSize = true;
            this.b5.Text = "Hình thức";
            this.b5.TabIndex = 11;
            // 
            // cboHT
            // 
            this.cboHT.Location = new System.Drawing.Point(85, 428);
            this.cboHT.Name = "cboHT";
            this.cboHT.Size = new System.Drawing.Size(140, 21);
            this.cboHT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboHT.FormattingEnabled = true;
            this.cboHT.TabIndex = 12;
            // 
            // b6
            // 
            this.b6.Location = new System.Drawing.Point(245, 432);
            this.b6.Name = "b6";
            this.b6.AutoSize = true;
            this.b6.Text = "Số tiền";
            this.b6.TabIndex = 13;
            // 
            // numTien
            // 
            this.numTien.Location = new System.Drawing.Point(295, 428);
            this.numTien.Name = "numTien";
            this.numTien.Size = new System.Drawing.Size(140, 20);
            this.numTien.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            this.numTien.Increment = new decimal(new int[] { 10000, 0, 0, 0 });
            this.numTien.ThousandsSeparator = true;
            this.numTien.TabIndex = 14;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Location = new System.Drawing.Point(460, 424);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(110, 30);
            this.btnThanhToan.Text = "Thanh toán";
            this.btnThanhToan.UseVisualStyleBackColor = true;
            this.btnThanhToan.TabIndex = 15;
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnHoanTat
            // 
            this.btnHoanTat.Location = new System.Drawing.Point(580, 424);
            this.btnHoanTat.Name = "btnHoanTat";
            this.btnHoanTat.Size = new System.Drawing.Size(140, 30);
            this.btnHoanTat.Text = "Hoàn tất phiếu";
            this.btnHoanTat.UseVisualStyleBackColor = true;
            this.btnHoanTat.TabIndex = 16;
            this.btnHoanTat.Click += new System.EventHandler(this.btnHoanTat_Click);
            // 
            // btnDong
            // 
            this.btnDong.Location = new System.Drawing.Point(740, 424);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(100, 30);
            this.btnDong.Text = "Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            this.btnDong.TabIndex = 17;
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // FrmThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 540);
            this.Name = "FrmThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanh toán viện phí – Hoàn tất phiếu khám";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.Add(this.b1);
            this.Controls.Add(this.cboPhieu);
            this.Controls.Add(this.b2);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.btnLapHD);
            this.Controls.Add(this.dgvHD);
            this.Controls.Add(this.b3);
            this.Controls.Add(this.txtHDChon);
            this.Controls.Add(this.b4);
            this.Controls.Add(this.txtPhieuChon);
            this.Controls.Add(this.lblConLai);
            this.Controls.Add(this.b5);
            this.Controls.Add(this.cboHT);
            this.Controls.Add(this.b6);
            this.Controls.Add(this.numTien);
            this.Controls.Add(this.btnThanhToan);
            this.Controls.Add(this.btnHoanTat);
            this.Controls.Add(this.btnDong);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label b1;
        private System.Windows.Forms.ComboBox cboPhieu;
        private System.Windows.Forms.Label b2;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnLapHD;
        private System.Windows.Forms.DataGridView dgvHD;
        private System.Windows.Forms.Label b3;
        private System.Windows.Forms.TextBox txtHDChon;
        private System.Windows.Forms.Label b4;
        private System.Windows.Forms.TextBox txtPhieuChon;
        private System.Windows.Forms.Label lblConLai;
        private System.Windows.Forms.Label b5;
        private System.Windows.Forms.ComboBox cboHT;
        private System.Windows.Forms.Label b6;
        private System.Windows.Forms.NumericUpDown numTien;
        private System.Windows.Forms.Button btnThanhToan;
        private System.Windows.Forms.Button btnHoanTat;
        private System.Windows.Forms.Button btnDong;
    }
}
