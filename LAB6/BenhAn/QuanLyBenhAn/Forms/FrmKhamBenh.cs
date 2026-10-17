using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using QuanLyBenhAn.Data;
using QuanLyBenhAn.Models;
using QuanLyBenhAn.Services;

namespace QuanLyBenhAn.Forms
{
    public partial class FrmKhamBenh : Form
    {
        readonly KhamBenhService s = new KhamBenhService();
        readonly DanhMucService dm = new DanhMucService();
        readonly BindingList<ThuocItem> toa = new BindingList<ThuocItem>();
        DataTable bsAll;
        public FrmKhamBenh() { InitializeComponent(); }

        string V(ComboBox c) { return c.SelectedValue == null ? "" : c.SelectedValue.ToString(); }
        void Bind(ComboBox c, object ds, string hien, string ma) { c.DataSource = ds; c.DisplayMember = hien; c.ValueMember = ma; }

        private void Frm_Load(object a, EventArgs e)
        {
            bsAll = dm.Lay("BacSi");
            Bind(cboKhoa, dm.Lay("Khoa"), "TenKhoa", "MaKhoa");
            Bind(cboBSToa, dm.Lay("BacSi"), "HoTen", "MaBS");
            Bind(cboTC, dm.Lay("TrieuChung"), "TenTC", "MaTC");
            Bind(cboXN, dm.Lay("LoaiXetNghiem"), "TenXN", "MaLoaiXN");
            Bind(cboThuoc, dm.Lay("Thuoc"), "TenThuoc", "MaThuoc");
            cboLoai.Items.AddRange(new object[] { "Điều trị", "Định kỳ" }); cboLoai.SelectedIndex = 0;
            dgvToaChon.DataSource = toa;
            cboKhoa_SelectedIndexChanged(null, null);
            TaiPhieu();
        }

        void TaiPhieu() { Bind(cboPhieu, s.LayPhieuDangKham(), "SoPhieuKham", "SoPhieuKham"); TaiChiTiet(); }

        void TaiChiTiet()
        {
            string pk = V(cboPhieu);
            if (pk == "") { dgvTC.DataSource = null; dgvXNPhieu.DataSource = null; dgvToaDaLap.DataSource = null; return; }
            dgvTC.DataSource = s.LayTrieuChung(pk);
            dgvXNPhieu.DataSource = s.LayXetNghiem(pk);
            dgvToaDaLap.DataSource = s.LayToa(pk);
            // gợi ý bác sĩ phụ trách của phiếu cho tab Toa thuốc
            var r = cboPhieu.SelectedItem as DataRowView;
            if (r != null) cboBSToa.SelectedValue = Convert.ToString(r["MaBS"]);
        }

        void H(KetQuaXuLy k) { MessageBox.Show(k.ThongBao); if (k.ThanhCong) TaiPhieu(); }

        private void cboKhoa_SelectedIndexChanged(object a, EventArgs e)
        {
            if (bsAll == null) return;
            bsAll.DefaultView.RowFilter = "MaKhoa='" + V(cboKhoa).Replace("'", "''") + "'";
            Bind(cboBS, bsAll.DefaultView, "HoTen", "MaBS");
        }

        private void cboLoai_SelectedIndexChanged(object a, EventArgs e)
        {
            bool dk = cboLoai.Text == "Định kỳ";
            cboLich.Enabled = dk;
            if (dk) Bind(cboLich, s.LayLichDaDat(txtMaHS.Text.Trim()), "MaLich", "MaLich"); else cboLich.DataSource = null;
        }

        private void btnTaoPhieu_Click(object a, EventArgs e)
        {
            H(s.TaoPhieuKham(txtMaHS.Text.Trim(), V(cboBS), V(cboKhoa), cboLoai.Text, V(cboLich)));
        }

        private void cboPhieu_SelectedIndexChanged(object a, EventArgs e) { TaiChiTiet(); }

        private void btnGhiTC_Click(object a, EventArgs e)
        { var k = s.GhiTrieuChung(V(cboPhieu), V(cboTC), txtGiaTri.Text.Trim()); MessageBox.Show(k.ThongBao); TaiChiTiet(); }

        private void btnYeuCauXN_Click(object a, EventArgs e)
        { var k = s.YeuCauXetNghiem(V(cboPhieu), V(cboXN)); MessageBox.Show(k.ThongBao); TaiChiTiet(); }

        private void btnThemThuoc_Click(object a, EventArgs e)
        {
            string ma = V(cboThuoc);
            if (ma == "") return;
            foreach (var x in toa) if (x.MaThuoc == ma) { MessageBox.Show("Thuốc đã có trong toa."); return; }
            toa.Add(new ThuocItem
            {
                MaThuoc = ma, TenThuoc = cboThuoc.Text, SoLuong = (int)numSL.Value,
                LieuDung = txtLieu.Text.Trim(), CachDung = txtCach.Text.Trim(), PhanUngPhu = txtPhanUng.Text.Trim()
            });
        }

        private void btnBoThuoc_Click(object a, EventArgs e)
        {
            if (dgvToaChon.CurrentRow != null && dgvToaChon.CurrentRow.Index < toa.Count) toa.RemoveAt(dgvToaChon.CurrentRow.Index);
        }

        private void btnLapToa_Click(object a, EventArgs e)
        {
            var k = s.LapToa(V(cboPhieu), V(cboBSToa), txtLoiDan.Text.Trim(), new List<ThuocItem>(toa));
            MessageBox.Show(k.ThongBao);
            if (k.ThanhCong) { toa.Clear(); TaiChiTiet(); }
        }

        private void btnKetLuan_Click(object a, EventArgs e)
        { H(s.KetLuan(V(cboPhieu), txtKetLuan.Text.Trim())); }

        private void btnDong_Click(object a, EventArgs e) { Close(); }
    }
}
