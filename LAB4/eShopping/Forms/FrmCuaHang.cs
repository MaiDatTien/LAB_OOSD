using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using eShopping.Adapters;
using eShopping.Models;

namespace eShopping.Forms
{
    public class FrmCuaHang : Form
    {
        readonly IProductSystem heThongSanPham = DichVuNgoai.SanPham;
        ComboBox cboNhom;
        DataGridView dgvSanPham, dgvGio;
        NumericUpDown numSoLuong, numSoLuongMoi;
        Label lblTong;

        public FrmCuaHang()
        {
            Text = "Chọn sản phẩm - Giỏ hàng";
            Width = 980;
            Height = 640;
            StartPosition = FormStartPosition.CenterParent;

            Ui.Nhan(this, "Nhóm sản phẩm:", 15, 15);
            cboNhom = Ui.OChon(this, 130, 15, 260);
            cboNhom.DataSource = heThongSanPham.LayNhom().ToList();
            cboNhom.DisplayMember = "TenNhom";
            cboNhom.ValueMember = "MaNhom";
            cboNhom.SelectedIndexChanged += (o, e) => TaiSanPham();

            dgvSanPham = Ui.Luoi(this, 15, 55, 930, 190);
            Ui.Nhan(this, "Số lượng:", 15, 255, 60);
            numSoLuong = Ui.OSo(this, 80, 255, 60, 1, 99, 1);
            var btnChiTiet = Ui.Nut(this, "Xem chi tiết", 160, 252);
            var btnThem = Ui.Nut(this, "Thêm vào giỏ", 285, 252);
            btnChiTiet.Click += BtnChiTiet_Click;
            btnThem.Click += BtnThem_Click;

            Ui.Nhan(this, "GIỎ HÀNG", 15, 295);
            dgvGio = Ui.Luoi(this, 15, 320, 930, 170);
            dgvGio.DataSource = PhienLamViec.Gio.Dong;

            Ui.Nhan(this, "SL mới:", 15, 505, 55);
            numSoLuongMoi = Ui.OSo(this, 75, 505, 60, 1, 99, 1);
            var btnCapNhat = Ui.Nut(this, "Cập nhật SL", 150, 502);
            var btnXoa = Ui.Nut(this, "Xóa khỏi giỏ", 275, 502);
            btnCapNhat.Click += BtnCapNhat_Click;
            btnXoa.Click += BtnXoa_Click;

            lblTong = new Label { Left = 420, Top = 507, Width = 260 };
            lblTong.Font = new Font(Font, FontStyle.Bold);
            Controls.Add(lblTong);

            var btnTinhTien = Ui.Nut(this, "Tính tiền / Đặt hàng", 760, 498, 185);
            btnTinhTien.Height = 36;
            btnTinhTien.Click += (o, e) => { LuongDatHang.TinhTien(this); CapNhatTong(); };

            PhienLamViec.Gio.Dong.ListChanged += (o, e) => CapNhatTong();
            TaiSanPham();
            CapNhatTong();
        }

        void TaiSanPham()
        {
            if (cboNhom.SelectedValue == null) return;
            try
            {
                dgvSanPham.DataSource = heThongSanPham.LaySanPham(cboNhom.SelectedValue.ToString())
                    .Select(x => new
                    {
                        x.MaSP,
                        x.TenSP,
                        x.NhaSanXuat,
                        x.GiaBan,
                        TinhTrang = x.ConHang ? "Còn hàng" : "Hết hàng"
                    }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không lấy được dữ liệu từ hệ thống quản lý sản phẩm: " + ex.Message);
            }
        }

        string MaSanPhamChon()
        {
            return dgvSanPham.CurrentRow == null ? null : Convert.ToString(dgvSanPham.CurrentRow.Cells["MaSP"].Value);
        }

        string MaTrongGioChon()
        {
            return dgvGio.CurrentRow == null ? null : Convert.ToString(dgvGio.CurrentRow.Cells["MaSP"].Value);
        }

        void ThemVaoGio(SanPham sp)
        {
            var kq = PhienLamViec.Gio.Them(sp, (int)numSoLuong.Value);
            MessageBox.Show(kq.ThongBao);
            CapNhatTong();
        }

        void BtnThem_Click(object sender, EventArgs e)
        {
            string ma = MaSanPhamChon();
            if (ma == null) return;
            ThemVaoGio(heThongSanPham.LayChiTiet(ma));
        }

        void BtnChiTiet_Click(object sender, EventArgs e)
        {
            string ma = MaSanPhamChon();
            if (ma == null) return;
            var sp = heThongSanPham.LayChiTiet(ma);
            if (sp == null)
            {
                MessageBox.Show("Không tìm thấy sản phẩm.");
                return;
            }
            using (var f = new FrmChiTiet(sp, ThemVaoGio)) f.ShowDialog(this);
        }

        void BtnCapNhat_Click(object sender, EventArgs e)
        {
            string ma = MaTrongGioChon();
            if (ma == null) return;
            MessageBox.Show(PhienLamViec.Gio.CapNhatSoLuong(ma, (int)numSoLuongMoi.Value).ThongBao);
            CapNhatTong();
        }

        void BtnXoa_Click(object sender, EventArgs e)
        {
            string ma = MaTrongGioChon();
            if (ma == null) return;
            MessageBox.Show(PhienLamViec.Gio.Xoa(ma).ThongBao);
            CapNhatTong();
        }

        void CapNhatTong()
        {
            lblTong.Text = "Tiền hàng: " + PhienLamViec.Gio.TongTienHang.ToString("N0") + " đ";
        }
    }
}
