using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public class FrmKhenThuongKyLuat : Form
    {
        readonly KhenThuongKyLuatService s = new KhenThuongKyLuatService();
        readonly DanhMucService dm = new DanhMucService();
        readonly BindingList<KhenThuongItem> dsKT = new BindingList<KhenThuongItem>();
        readonly BindingList<KyLuatItem> dsKL = new BindingList<KyLuatItem>();

        public FrmKhenThuongKyLuat()
        {
            Ui.CauHinh(this, "Khen thưởng và kỷ luật (cá nhân hoặc tập thể phòng ban)", 1150, 780);
            var tc = new TabControl { Dock = DockStyle.Fill };

            // ===== Tab 1: Quyết định khen thưởng + phiếu chi =====
            var txtSoQDKT = Ui.Txt(); var txtSoPhieuChi = Ui.Txt(); var dtNgayKT = Ui.Dtp();
            var cboLoaiKT = Ui.CboList("Thành tích", "Ngày lễ", "Thưởng cuối năm", "Lương tháng 13");
            var cboKyKT = Ui.Cbo(); var cboKTChi = Ui.Cbo(); var txtLyDoKT = Ui.Txt();
            var optCaNhanKT = new RadioButton { Text = "Cá nhân", Checked = true, AutoSize = true, Margin = new Padding(6, 8, 6, 3) };
            var optTapTheKT = new RadioButton { Text = "Tập thể phòng ban", AutoSize = true, Margin = new Padding(6, 8, 6, 3) };
            var cboNVKT = Ui.Cbo(); cboNVKT.Width = 200; cboNVKT.Dock = DockStyle.None;
            var cboPBKT = Ui.Cbo(); cboPBKT.Width = 180; cboPBKT.Dock = DockStyle.None;
            var numTienKT = Ui.Num(); numTienKT.Dock = DockStyle.None; numTienKT.Width = 130;
            var btnThemKT = Ui.Btn("Thêm đối tượng"); var btnBoKT = Ui.Btn("Bỏ dòng chọn"); var btnLapKT = Ui.Btn("Lập quyết định khen thưởng + phiếu chi");
            var dgvKTChon = Ui.Dgv(120); var dgvQDKT = Ui.Dgv(); var dgvCTKT = Ui.Dgv(120);
            var g1 = Ui.Luoi(3);
            Ui.Them(g1, "Số QĐ khen thưởng", txtSoQDKT); Ui.Them(g1, "Số phiếu chi", txtSoPhieuChi); Ui.Them(g1, "Ngày quyết định", dtNgayKT);
            Ui.Them(g1, "Loại khen thưởng", cboLoaiKT); Ui.Them(g1, "Giám đốc ký", cboKyKT); Ui.Them(g1, "Kế toán lập phiếu chi", cboKTChi);
            Ui.Them(g1, "Lý do", txtLyDoKT, 3);
            Ui.Doc(Ui.Tab(tc, "1. Khen thưởng"), g1,
                Ui.Hang(optCaNhanKT, cboNVKT, optTapTheKT, cboPBKT, Ui.Lbl("Số tiền:"), numTienKT, btnThemKT, btnBoKT),
                dgvKTChon, Ui.Hang(btnLapKT), dgvQDKT, dgvCTKT);

            // ===== Tab 2: Quyết định kỷ luật + phiếu thu nộp phạt =====
            var txtSoQDKL = Ui.Txt(); var dtNgayKL = Ui.Dtp(); var cboHinhThucKL = Ui.CboList("Khiển trách", "Cảnh cáo", "Phạt tiền");
            var cboKyKL = Ui.Cbo(); var cboKTThu = Ui.Cbo(); var txtLyDoKL = Ui.Txt();
            var optCaNhanKL = new RadioButton { Text = "Cá nhân", Checked = true, AutoSize = true, Margin = new Padding(6, 8, 6, 3) };
            var optTapTheKL = new RadioButton { Text = "Tập thể phòng ban", AutoSize = true, Margin = new Padding(6, 8, 6, 3) };
            var cboNVKL = Ui.Cbo(); cboNVKL.Width = 200; cboNVKL.Dock = DockStyle.None;
            var cboPBKL = Ui.Cbo(); cboPBKL.Width = 180; cboPBKL.Dock = DockStyle.None;
            var numTienKL = Ui.Num(); numTienKL.Dock = DockStyle.None; numTienKL.Width = 120;
            var cboHTThu = Ui.CboList("Nộp tiền mặt", "Trừ lương"); cboHTThu.Dock = DockStyle.None; cboHTThu.Width = 120;
            var txtSoPhieuThu = Ui.Txt(); txtSoPhieuThu.Dock = DockStyle.None; txtSoPhieuThu.Width = 110;
            var btnThemKL = Ui.Btn("Thêm đối tượng"); var btnBoKL = Ui.Btn("Bỏ dòng chọn"); var btnLapKL = Ui.Btn("Lập quyết định kỷ luật");
            var dgvKLChon = Ui.Dgv(120); var dgvQDKL = Ui.Dgv(); var dgvCTKL = Ui.Dgv(120);
            var g2 = Ui.Luoi(3);
            Ui.Them(g2, "Số QĐ kỷ luật", txtSoQDKL); Ui.Them(g2, "Ngày quyết định", dtNgayKL); Ui.Them(g2, "Hình thức kỷ luật", cboHinhThucKL);
            Ui.Them(g2, "Giám đốc ký", cboKyKL); Ui.Them(g2, "Kế toán lập phiếu thu", cboKTThu);
            Ui.Them(g2, "Lý do", txtLyDoKL, 3);
            Ui.Doc(Ui.Tab(tc, "2. Kỷ luật"), g2,
                Ui.Hang(optCaNhanKL, cboNVKL, optTapTheKL, cboPBKL),
                Ui.Hang(Ui.Lbl("Tiền phạt:"), numTienKL, Ui.Lbl("Hình thức thu:"), cboHTThu, Ui.Lbl("Số phiếu thu:"), txtSoPhieuThu, btnThemKL, btnBoKL),
                dgvKLChon, Ui.Hang(btnLapKL), dgvQDKL, dgvCTKL);

            var btnDong = Ui.Btn("Đóng");
            Ui.Doc(this, tc, Ui.Hang(btnDong));
            dgvKTChon.DataSource = dsKT; dgvKLChon.DataSource = dsKL;

            // Cá nhân hay tập thể: bật ô tương ứng
            Action doiKT = () => { cboNVKT.Enabled = optCaNhanKT.Checked; cboPBKT.Enabled = optTapTheKT.Checked; };
            Action doiKL = () => { cboNVKL.Enabled = optCaNhanKL.Checked; cboPBKL.Enabled = optTapTheKL.Checked; };
            optCaNhanKT.CheckedChanged += (o, ev) => doiKT();
            optCaNhanKL.CheckedChanged += (o, ev) => doiKL();
            doiKT(); doiKL();

            Action tai = () =>
            {
                Ui.Nap(cboKyKT, dm.LayNhanVienTheoVaiTro("Giám đốc"), "HienThi", "MaNV");
                Ui.Nap(cboKyKL, dm.LayNhanVienTheoVaiTro("Giám đốc"), "HienThi", "MaNV");
                Ui.Nap(cboKTChi, dm.LayNhanVienTheoVaiTro("Kế toán"), "HienThi", "MaNV");
                Ui.Nap(cboKTThu, dm.LayNhanVienTheoVaiTro("Kế toán"), "HienThi", "MaNV");
                Ui.Nap(cboNVKT, dm.LayNhanVienDangLamViec(), "HienThi", "MaNV");
                Ui.Nap(cboNVKL, dm.LayNhanVienDangLamViec(), "HienThi", "MaNV");
                Ui.Nap(cboPBKT, dm.LayPhongBan(), "TenPB", "MaPB");
                Ui.Nap(cboPBKL, dm.LayPhongBan(), "TenPB", "MaPB");
                dgvQDKT.DataSource = s.LayQDKhenThuong(); dgvQDKL.DataSource = s.LayQDKyLuat();
            };
            dgvQDKT.SelectionChanged += (o, ev) => { if (dgvQDKT.CurrentRow != null) dgvCTKT.DataSource = s.LayChiTietKhenThuong(Convert.ToString(dgvQDKT.CurrentRow.Cells["SoQDKT"].Value)); };
            dgvQDKL.SelectionChanged += (o, ev) => { if (dgvQDKL.CurrentRow != null) dgvCTKL.DataSource = s.LayChiTietKyLuat(Convert.ToString(dgvQDKL.CurrentRow.Cells["SoQDKL"].Value)); };

            // --- Khen thưởng ---
            btnThemKT.Click += (o, ev) =>
            {
                var x = new KhenThuongItem { SoTien = numTienKT.Value };
                if (optCaNhanKT.Checked) x.MaNV = Ui.V(cboNVKT); else x.MaPB = Ui.V(cboPBKT);
                if (string.IsNullOrEmpty(x.DoiTuong)) { MessageBox.Show("Chọn đối tượng."); return; }
                foreach (var d in dsKT) if (d.DoiTuong == x.DoiTuong) { MessageBox.Show("Đối tượng đã có trong danh sách."); return; }
                dsKT.Add(x);
            };
            btnBoKT.Click += (o, ev) => { if (dgvKTChon.CurrentRow != null) dsKT.RemoveAt(dgvKTChon.CurrentRow.Index); };
            btnLapKT.Click += (o, ev) =>
            {
                var k = s.LapQDKhenThuong(txtSoQDKT.Text.Trim(), txtSoPhieuChi.Text.Trim(), dtNgayKT.Value, cboLoaiKT.Text,
                    txtLyDoKT.Text.Trim(), Ui.V(cboKyKT), Ui.V(cboKTChi), new List<KhenThuongItem>(dsKT));
                if (Ui.Bao(k)) { dsKT.Clear(); tai(); }
            };

            // --- Kỷ luật ---
            btnThemKL.Click += (o, ev) =>
            {
                bool phat = cboHinhThucKL.Text == "Phạt tiền";
                var x = new KyLuatItem
                {
                    SoTienPhat = phat ? numTienKL.Value : 0,
                    HinhThucThu = phat ? cboHTThu.Text : null,
                    SoPhieuThu = phat ? txtSoPhieuThu.Text.Trim() : null
                };
                if (optCaNhanKL.Checked) x.MaNV = Ui.V(cboNVKL); else x.MaPB = Ui.V(cboPBKL);
                if (string.IsNullOrEmpty(x.DoiTuong)) { MessageBox.Show("Chọn đối tượng."); return; }
                foreach (var d in dsKL) if (d.DoiTuong == x.DoiTuong) { MessageBox.Show("Đối tượng đã có trong danh sách."); return; }
                dsKL.Add(x);
            };
            btnBoKL.Click += (o, ev) => { if (dgvKLChon.CurrentRow != null) dsKL.RemoveAt(dgvKLChon.CurrentRow.Index); };
            btnLapKL.Click += (o, ev) =>
            {
                var k = s.LapQDKyLuat(txtSoQDKL.Text.Trim(), dtNgayKL.Value, cboHinhThucKL.Text, txtLyDoKL.Text.Trim(),
                    Ui.V(cboKyKL), Ui.V(cboKTThu), new List<KyLuatItem>(dsKL));
                if (Ui.Bao(k)) { dsKL.Clear(); tai(); }
            };

            btnDong.Click += (o, ev) => Close();
            Load += (o, ev) => tai();
        }
    }
}
