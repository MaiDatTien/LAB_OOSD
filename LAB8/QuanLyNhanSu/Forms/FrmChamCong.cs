using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public class FrmChamCong : Form
    {
        readonly ChamCongService s = new ChamCongService();
        readonly DanhMucService dm = new DanhMucService();
        readonly BindingList<PhanCongItem> dsPC = new BindingList<PhanCongItem>();
        readonly BindingList<ChamCongItem> dsCC = new BindingList<ChamCongItem>();
        readonly BindingList<PhuTroiItem> dsPT = new BindingList<PhuTroiItem>();

        public FrmChamCong()
        {
            Ui.CauHinh(this, "Phân công, chấm công và phụ trội", 1150, 800);
            var tc = new TabControl { Dock = DockStyle.Fill };

            // ===== Tab 1: Kế hoạch phân công tuần (Trưởng phòng) =====
            var txtSoKH = Ui.Txt(); var cboPBKH = Ui.Cbo(); var cboTPKH = Ui.Cbo();
            var dtTuNgay = Ui.Dtp(); var dtDenNgay = Ui.Dtp(); dtDenNgay.Value = DateTime.Today.AddDays(6);
            var txtGhiChuKH = Ui.Txt();
            var cboNVKH = Ui.Cbo(); var cboCaKH = Ui.Cbo(); var dtNgayPC = Ui.Dtp(); var chkPT = new CheckBox { Text = "Có kế hoạch phụ trội", AutoSize = true, Margin = new Padding(6, 8, 6, 3) };
            var btnThemPC = Ui.Btn("Thêm dòng phân công"); var btnBoPC = Ui.Btn("Bỏ dòng chọn"); var btnLapKH = Ui.Btn("Lập kế hoạch");
            var dgvPCChon = Ui.Dgv(130); var dgvKH = Ui.Dgv(); var dgvCTKH = Ui.Dgv(120);
            var g1 = Ui.Luoi(3);
            Ui.Them(g1, "Số kế hoạch", txtSoKH); Ui.Them(g1, "Phòng ban", cboPBKH); Ui.Them(g1, "Trưởng phòng lập", cboTPKH);
            Ui.Them(g1, "Từ ngày", dtTuNgay); Ui.Them(g1, "Đến ngày", dtDenNgay); Ui.Them(g1, "Ghi chú", txtGhiChuKH);
            Ui.Them(g1, "Nhân viên", cboNVKH); Ui.Them(g1, "Ca làm việc", cboCaKH); Ui.Them(g1, "Ngày làm", dtNgayPC);
            Ui.Doc(Ui.Tab(tc, "1. Kế hoạch phân công"), g1, Ui.Hang(chkPT, btnThemPC, btnBoPC, btnLapKH),
                dgvPCChon, Ui.Lbl("Các kế hoạch đã lập (chọn dòng để xem chi tiết):"), dgvKH, dgvCTKH);

            // ===== Tab 2: Bảng chấm công (Ban chấm công) =====
            var txtSoBCC = Ui.Txt(); var cboPBCC = Ui.Cbo(); var cboLapCC = Ui.Cbo();
            var numThangCC = Ui.Num(12, 0, DateTime.Today.Month); numThangCC.Minimum = 1;
            var numNamCC = Ui.Num(2100, 0, DateTime.Today.Year); numNamCC.ThousandsSeparator = false; numNamCC.Minimum = 2000;
            var cboNVCC = Ui.Cbo(); var cboCaCC = Ui.Cbo(); var dtNgayCC = Ui.Dtp(); var numGioCC = Ui.Num(24, 2, 8);
            var btnThemCC = Ui.Btn("Thêm dòng chấm công"); var btnBoCC = Ui.Btn("Bỏ dòng chọn"); var btnLapCC = Ui.Btn("Lập bảng chấm công");
            var dgvCCChon = Ui.Dgv(130); var dgvBCC = Ui.Dgv(); var dgvCTCC = Ui.Dgv(120);
            var g2 = Ui.Luoi(3);
            Ui.Them(g2, "Số bảng chấm công", txtSoBCC); Ui.Them(g2, "Phòng ban", cboPBCC); Ui.Them(g2, "Ban chấm công lập", cboLapCC);
            Ui.Them(g2, "Tháng", numThangCC); Ui.Them(g2, "Năm", numNamCC);
            Ui.Them(g2, "Nhân viên", cboNVCC); Ui.Them(g2, "Ca làm việc", cboCaCC); Ui.Them(g2, "Ngày", dtNgayCC); Ui.Them(g2, "Số giờ làm", numGioCC);
            Ui.Doc(Ui.Tab(tc, "2. Bảng chấm công"), g2, Ui.Hang(btnThemCC, btnBoCC, btnLapCC),
                dgvCCChon, Ui.Lbl("Các bảng chấm công đã lập:"), dgvBCC, dgvCTCC);

            // ===== Tab 3: Phiếu ghi nhận phụ trội (Ban chấm công) =====
            var txtSoPT = Ui.Txt(); var dtNgayPT = Ui.Dtp(); var cboHTPT = Ui.CboList("Tăng ca", "Ngày lễ", "Ngày nghỉ");
            var cboPBPT = Ui.Cbo(); var cboLapPT = Ui.Cbo(); var txtGhiChuPT = Ui.Txt();
            var cboNVPT = Ui.Cbo(); var numGioPT = Ui.Num(12, 2, 2);
            var btnThemPT = Ui.Btn("Thêm nhân viên"); var btnBoPT = Ui.Btn("Bỏ dòng chọn"); var btnLapPT = Ui.Btn("Lập phiếu phụ trội");
            var dgvPTChon = Ui.Dgv(130); var dgvPT = Ui.Dgv(); var dgvCTPT = Ui.Dgv(120);
            var g3 = Ui.Luoi(3);
            Ui.Them(g3, "Số phiếu phụ trội", txtSoPT); Ui.Them(g3, "Ngày phụ trội", dtNgayPT); Ui.Them(g3, "Hình thức", cboHTPT);
            Ui.Them(g3, "Phòng ban", cboPBPT); Ui.Them(g3, "Ban chấm công lập", cboLapPT); Ui.Them(g3, "Ghi chú", txtGhiChuPT);
            Ui.Them(g3, "Nhân viên", cboNVPT); Ui.Them(g3, "Số giờ phụ trội", numGioPT);
            Ui.Doc(Ui.Tab(tc, "3. Phiếu phụ trội"), g3, Ui.Hang(Ui.Lbl("Giờ phụ trội được tính 1.5 lần giờ thường."), btnThemPT, btnBoPT, btnLapPT),
                dgvPTChon, Ui.Lbl("Các phiếu phụ trội đã lập:"), dgvPT, dgvCTPT);

            var btnDong = Ui.Btn("Đóng");
            Ui.Doc(this, tc, Ui.Hang(btnDong));

            dgvPCChon.DataSource = dsPC; dgvCCChon.DataSource = dsCC; dgvPTChon.DataSource = dsPT;

            // Nạp danh sách nhân viên theo phòng ban đang chọn
            Action napNVKH = () => Ui.Nap(cboNVKH, dm.LayNhanVienTheoPhongBan(Ui.V(cboPBKH)), "HienThi", "MaNV");
            Action napNVCC = () => Ui.Nap(cboNVCC, dm.LayNhanVienTheoPhongBan(Ui.V(cboPBCC)), "HienThi", "MaNV");
            Action napNVPT = () => Ui.Nap(cboNVPT, dm.LayNhanVienTheoPhongBan(Ui.V(cboPBPT)), "HienThi", "MaNV");
            cboPBKH.SelectionChangeCommitted += (o, ev) => { napNVKH(); dsPC.Clear(); };
            cboPBCC.SelectionChangeCommitted += (o, ev) => { napNVCC(); dsCC.Clear(); };
            cboPBPT.SelectionChangeCommitted += (o, ev) => { napNVPT(); dsPT.Clear(); };

            Action tai = () =>
            {
                Ui.Nap(cboPBKH, dm.LayPhongBan(), "TenPB", "MaPB");
                Ui.Nap(cboPBCC, dm.LayPhongBan(), "TenPB", "MaPB");
                Ui.Nap(cboPBPT, dm.LayPhongBan(), "TenPB", "MaPB");
                Ui.Nap(cboTPKH, dm.LayNhanVienTheoVaiTro("Trưởng phòng"), "HienThi", "MaNV");
                Ui.Nap(cboLapCC, dm.LayNhanVienTheoVaiTro("Ban chấm công"), "HienThi", "MaNV");
                Ui.Nap(cboLapPT, dm.LayNhanVienTheoVaiTro("Ban chấm công"), "HienThi", "MaNV");
                Ui.Nap(cboCaKH, dm.LayCaLamViec(), "HienThi", "MaCa");
                Ui.Nap(cboCaCC, dm.LayCaLamViec(), "HienThi", "MaCa");
                napNVKH(); napNVCC(); napNVPT();
                dgvKH.DataSource = s.LayKeHoach(); dgvBCC.DataSource = s.LayBangChamCong(); dgvPT.DataSource = s.LayPhieuPhuTroi();
            };

            // Xem chi tiết khi chọn dòng
            dgvKH.SelectionChanged += (o, ev) => { if (dgvKH.CurrentRow != null) dgvCTKH.DataSource = s.LayChiTietPhanCong(Convert.ToString(dgvKH.CurrentRow.Cells["SoKH"].Value)); };
            dgvBCC.SelectionChanged += (o, ev) => { if (dgvBCC.CurrentRow != null) dgvCTCC.DataSource = s.LayChiTietChamCong(Convert.ToString(dgvBCC.CurrentRow.Cells["SoBCC"].Value)); };
            dgvPT.SelectionChanged += (o, ev) => { if (dgvPT.CurrentRow != null) dgvCTPT.DataSource = s.LayChiTietPhuTroi(Convert.ToString(dgvPT.CurrentRow.Cells["SoPhieuPT"].Value)); };

            // --- Tab 1 ---
            btnThemPC.Click += (o, ev) =>
            {
                if (string.IsNullOrEmpty(Ui.V(cboNVKH)) || string.IsNullOrEmpty(Ui.V(cboCaKH))) { MessageBox.Show("Chọn nhân viên và ca làm việc."); return; }
                dsPC.Add(new PhanCongItem { MaNV = Ui.V(cboNVKH), Ngay = dtNgayPC.Value.Date, MaCa = Ui.V(cboCaKH), CoPhuTroi = chkPT.Checked });
            };
            btnBoPC.Click += (o, ev) => { if (dgvPCChon.CurrentRow != null) dsPC.RemoveAt(dgvPCChon.CurrentRow.Index); };
            btnLapKH.Click += (o, ev) =>
            {
                var k = s.LapKeHoach(txtSoKH.Text.Trim(), Ui.V(cboPBKH), dtTuNgay.Value, dtDenNgay.Value, Ui.V(cboTPKH),
                    txtGhiChuKH.Text.Trim(), new List<PhanCongItem>(dsPC));
                if (Ui.Bao(k)) { dsPC.Clear(); tai(); }
            };

            // --- Tab 2 ---
            btnThemCC.Click += (o, ev) =>
            {
                if (string.IsNullOrEmpty(Ui.V(cboNVCC)) || string.IsNullOrEmpty(Ui.V(cboCaCC))) { MessageBox.Show("Chọn nhân viên và ca làm việc."); return; }
                dsCC.Add(new ChamCongItem { MaNV = Ui.V(cboNVCC), Ngay = dtNgayCC.Value.Date, MaCa = Ui.V(cboCaCC), SoGioLam = numGioCC.Value });
            };
            btnBoCC.Click += (o, ev) => { if (dgvCCChon.CurrentRow != null) dsCC.RemoveAt(dgvCCChon.CurrentRow.Index); };
            btnLapCC.Click += (o, ev) =>
            {
                var k = s.LapBangChamCong(txtSoBCC.Text.Trim(), Ui.V(cboPBCC), (int)numThangCC.Value, (int)numNamCC.Value,
                    Ui.V(cboLapCC), new List<ChamCongItem>(dsCC));
                if (Ui.Bao(k)) { dsCC.Clear(); tai(); }
            };

            // --- Tab 3 ---
            btnThemPT.Click += (o, ev) =>
            {
                string ma = Ui.V(cboNVPT);
                if (string.IsNullOrEmpty(ma)) { MessageBox.Show("Chọn nhân viên."); return; }
                foreach (var x in dsPT) if (x.MaNV == ma) { MessageBox.Show("Nhân viên đã có trong phiếu."); return; }
                dsPT.Add(new PhuTroiItem { MaNV = ma, SoGioPhuTroi = numGioPT.Value });
            };
            btnBoPT.Click += (o, ev) => { if (dgvPTChon.CurrentRow != null) dsPT.RemoveAt(dgvPTChon.CurrentRow.Index); };
            btnLapPT.Click += (o, ev) =>
            {
                var k = s.LapPhieuPhuTroi(txtSoPT.Text.Trim(), dtNgayPT.Value, cboHTPT.Text, Ui.V(cboPBPT), Ui.V(cboLapPT),
                    txtGhiChuPT.Text.Trim(), new List<PhuTroiItem>(dsPT));
                if (Ui.Bao(k)) { dsPT.Clear(); tai(); }
            };

            btnDong.Click += (o, ev) => Close();
            Load += (o, ev) => tai();
        }
    }
}
