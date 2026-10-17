namespace QuanLyBenhAn.Forms
{
    partial class FrmKetQuaXN
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
            this.a0 = new System.Windows.Forms.Label();
            this.dgvChoKQ = new System.Windows.Forms.DataGridView();
            this.a1 = new System.Windows.Forms.Label();
            this.txtKetQua = new System.Windows.Forms.TextBox();
            this.a2 = new System.Windows.Forms.Label();
            this.cboKTV = new System.Windows.Forms.ComboBox();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // a0
            // 
            this.a0.Location = new System.Drawing.Point(20, 8);
            this.a0.Name = "a0";
            this.a0.AutoSize = true;
            this.a0.Text = "Xét nghiệm đang chờ kết quả";
            this.a0.TabIndex = 0;
            // 
            // dgvChoKQ
            // 
            this.dgvChoKQ.Location = new System.Drawing.Point(20, 28);
            this.dgvChoKQ.Name = "dgvChoKQ";
            this.dgvChoKQ.Size = new System.Drawing.Size(740, 290);
            this.dgvChoKQ.AllowUserToAddRows = false;
            this.dgvChoKQ.AllowUserToDeleteRows = false;
            this.dgvChoKQ.ReadOnly = true;
            this.dgvChoKQ.MultiSelect = false;
            this.dgvChoKQ.RowHeadersVisible = false;
            this.dgvChoKQ.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChoKQ.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvChoKQ.BackgroundColor = System.Drawing.Color.White;
            this.dgvChoKQ.TabIndex = 1;
            // 
            // a1
            // 
            this.a1.Location = new System.Drawing.Point(20, 342);
            this.a1.Name = "a1";
            this.a1.AutoSize = true;
            this.a1.Text = "Kết quả";
            this.a1.TabIndex = 2;
            // 
            // txtKetQua
            // 
            this.txtKetQua.Location = new System.Drawing.Point(90, 338);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(670, 60);
            this.txtKetQua.Multiline = true;
            this.txtKetQua.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtKetQua.TabIndex = 3;
            // 
            // a2
            // 
            this.a2.Location = new System.Drawing.Point(20, 424);
            this.a2.Name = "a2";
            this.a2.AutoSize = true;
            this.a2.Text = "KTV";
            this.a2.TabIndex = 4;
            // 
            // cboKTV
            // 
            this.cboKTV.Location = new System.Drawing.Point(60, 420);
            this.cboKTV.Name = "cboKTV";
            this.cboKTV.Size = new System.Drawing.Size(200, 21);
            this.cboKTV.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboKTV.FormattingEnabled = true;
            this.cboKTV.TabIndex = 5;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(290, 416);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(120, 30);
            this.btnLuu.Text = "Lưu kết quả";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.TabIndex = 6;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Location = new System.Drawing.Point(420, 416);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.Text = "Tải lại";
            this.btnLamMoi.UseVisualStyleBackColor = true;
            this.btnLamMoi.TabIndex = 7;
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // FrmKetQuaXN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Name = "FrmKetQuaXN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nhập kết quả xét nghiệm";
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Load += new System.EventHandler(this.Frm_Load);
            this.Controls.Add(this.a0);
            this.Controls.Add(this.dgvChoKQ);
            this.Controls.Add(this.a1);
            this.Controls.Add(this.txtKetQua);
            this.Controls.Add(this.a2);
            this.Controls.Add(this.cboKTV);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnLamMoi);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label a0;
        private System.Windows.Forms.DataGridView dgvChoKQ;
        private System.Windows.Forms.Label a1;
        private System.Windows.Forms.TextBox txtKetQua;
        private System.Windows.Forms.Label a2;
        private System.Windows.Forms.ComboBox cboKTV;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnLamMoi;
    }
}
