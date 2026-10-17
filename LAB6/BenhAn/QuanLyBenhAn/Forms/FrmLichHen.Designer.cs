namespace QuanLyBenhAn.Forms
{
    partial class FrmLichHen
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
            this.l1 = new System.Windows.Forms.Label();
            this.txtMaHS = new System.Windows.Forms.TextBox();
            this.l2 = new System.Windows.Forms.Label();
            this.dtHen = new System.Windows.Forms.DateTimePicker();
            this.lblQuy = new System.Windows.Forms.Label();
            this.l3 = new System.Windows.Forms.Label();
            this.cboNV = new System.Windows.Forms.ComboBox();
            this.btnDat = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.dgvLich = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            // 
            // l1
            // 
            this.l1.Location = new System.Drawing.Point(20, 24);
            this.l1.Name = "l1";
            this.l1.AutoSize = true;
            this.l1.Text = "Mã hồ sơ";
            this.l1.TabIndex = 0;
            // 
            // txtMaHS
            // 
            this.txtMaHS.Location = new System.Drawing.Point(95, 20);
            this.txtMaHS.Name = "txtMaHS";
            this.txtMaHS.Size = new System.Drawing.Size(130, 20);
            this.txtMaHS.TabIndex = 1;
            this.txtMaHS.Leave += new System.EventHandler(this.txtMaHS_Leave);
            // 
            // l2
            // 
            this.l2.Location = new System.Drawing.Point(245, 24);
            this.l2.Name = "l2";
            this.l2.AutoSize = true;
            this.l2.Text = "Ngày giờ hẹn";
            this.l2.TabIndex = 2;
            // 
            // dtHen
            // 
            this.dtHen.Location = new System.Drawing.Point(335, 20);
            this.dtHen.Name = "dtHen";
            this.dtHen.Size = new System.Drawing.Size(170, 20);
            this.dtHen.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHen.CustomFormat = "dd/MM/yyyy HH:mm";
            this.dtHen.TabIndex = 3;
            this.dtHen.ValueChanged += new System.EventHandler(this.dtHen_ValueChanged);
            // 
            // lblQuy
            // 
            this.lblQuy.Location = new System.Drawing.Point(525, 24);
            this.lblQuy.Name = "lblQuy";
            this.lblQuy.AutoSize = true;
            this.lblQuy.Text = "Quý";
            this.lblQuy.TabIndex = 4;
            // 
            // l3
            // 
            this.l3.Location = new System.Drawing.Point(20, 66);
            this.l3.Name = "l3";
            this.l3.AutoSize = true;
            this.l3.Text = "Nhân viên";
            this.l3.TabIndex = 5;
            // 
            // cboNV
            // 
            this.cboNV.Location = new System.Drawing.Point(95, 62);
            this.cboNV.Name = "cboNV";
            this.cboNV.Size = new System.Drawing.Size(200, 21);
            this.cboNV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNV.FormattingEnabled = true;
            this.cboNV.TabIndex = 6;
            // 
            // btnDat
            // 
            this.btnDat.Location = new System.Drawing.Point(320, 58);
            this.btnDat.Name = "btnDat";
            this.btnDat.Size = new System.Drawing.Size(110, 30);
            this.btnDat.Text = "Đặt lịch";
            this.btnDat.UseVisualStyleBackColor = true;
            this.btnDat.TabIndex = 7;
            this.btnDat.Click += new System.EventHandler(this.btnDat_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(440, 58);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(110, 30);
            this.btnHuy.Text = "Hủy lịch";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // dgvLich
            // 
            this.dgvLich.Location = new System.Drawing.Point(20, 110);
            this.dgvLich.Name = "dgvLich";
            this.dgvLich.Size = new System.Drawing.Size(740, 380);
            this.dgvLich.AllowUserToAddRows = false;
            this.dgvLich.AllowUserToDeleteRows = false;
            this.dgvLich.ReadOnly = true;
            this.dgvLich.MultiSelect = false;
            this.dgvLich.RowHeadersVisible = false;
            this.dgvLich.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLich.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvLich.BackgroundColor = System.Drawing.Color.White;
            this.dgvLich.TabIndex = 9;
            // 
            // FrmLichHen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Name = "FrmLichHen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lịch khám sức khỏe định kỳ theo quý";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.Add(this.l1);
            this.Controls.Add(this.txtMaHS);
            this.Controls.Add(this.l2);
            this.Controls.Add(this.dtHen);
            this.Controls.Add(this.lblQuy);
            this.Controls.Add(this.l3);
            this.Controls.Add(this.cboNV);
            this.Controls.Add(this.btnDat);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.dgvLich);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label l1;
        private System.Windows.Forms.TextBox txtMaHS;
        private System.Windows.Forms.Label l2;
        private System.Windows.Forms.DateTimePicker dtHen;
        private System.Windows.Forms.Label lblQuy;
        private System.Windows.Forms.Label l3;
        private System.Windows.Forms.ComboBox cboNV;
        private System.Windows.Forms.Button btnDat;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.DataGridView dgvLich;
    }
}
