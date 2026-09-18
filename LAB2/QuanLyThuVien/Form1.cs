using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using QuanLyThuVien.Services;
using QuanLyThuVien.Services;

namespace QuanLyThuVien
{
    public partial class Form1 : Form
    {
        private DataGridView dgvNhanVien;
        private DanhMucService danhMucService;

        public Form1()
        {
            this.Text = "Danh sách Nhân viên thư viện";
            this.Size = new Size(700, 400);
            this.StartPosition = FormStartPosition.CenterScreen;

            danhMucService = new DanhMucService();
            dgvNhanVien = new DataGridView();
            dgvNhanVien.Dock = DockStyle.Fill;
            dgvNhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvNhanVien.ReadOnly = true;      
            dgvNhanVien.AllowUserToAddRows = false;

            try 
            {
                DataTable dtNhanVien = danhMucService.LayNhanVien();
                dgvNhanVien.DataSource = dtNhanVien;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lấy dữ liệu:\n" + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Controls.Add(dgvNhanVien);
        }
    }
}