using System;
using System.Data;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public class FrmTuyenDung : Form
    {
        readonly TuyenDungService s = new TuyenDungService();
        readonly DanhMucService dm = new DanhMucService();

        public FrmTuyenDung()
        {
            Ui.CauHinh(this, "Tuyển dụng, thử việc, hợp đồng và bảo hiểm", 1150, 760);
            var tc = new TabControl { Dock = DockStyle.Fill };

            // ===== Tab 1: QĐ tuyển dụng + đánh giá thử việc =====
            var txtSoQDTD = Ui.Txt(); var cboNVChoTD = Ui.Cbo(); var cboPBTD = Ui.Cbo();
            var dtNgayQD = Ui.Dtp(); var dtBatDauTV = Ui.Dtp(); var dtKetThucTV = Ui.Dtp();
            var numLuongTV = Ui.Num(); var cboLapTD = Ui.Cbo(); var cboKyTD = Ui.Cbo();
            var txtDieuKhoan = Ui.Txt(true);
            var btnLapQDTD = Ui.Btn("Lập quyết định tuyển dụng");
            var dgvQDTD = Ui.Dgv();
            var dgvThuViec = Ui.Dgv(110);
            var cboKetQua = Ui.CboList("Đạt", "Không đạt"); var btnDanhGia = Ui.Btn("Ghi nhận đánh giá thử việc");
            var g1 = Ui.Luoi(3);
            Ui.Them(g1, "Số QĐ tuyển dụng", txtSoQDTD); Ui.Them(g1, "Nhân viên (chờ tuyển dụng)", cboNVChoTD); Ui.Them(g1, "Phòng ban cần tuyển", cboPBTD);
            Ui.Them(g1, "Ngày quyết định", dtNgayQD); Ui.Them(g1, "Bắt đầu thử việc", dtBatDauTV); Ui.Them(g1, "Kết thúc thử việc", dtKetThucTV);
            Ui.Them(g1, "Lương thử việc", numLuongTV); Ui.Them(g1, "Người lập (Nhân sự)", cboLapTD); Ui.Them(g1, "Giám đốc ký", cboKyTD);
            Ui.Them(g1, "Điều khoản hai bên", txtDieuKhoan, 3);
            var lbTV = Ui.Lbl("Nhân viên đang thử việc (chọn dòng để đánh giá sau khi hết thời gian thử việc):");
            Ui.Doc(Ui.Tab(tc, "1. Tuyển dụng - Thử việc"), g1, Ui.Hang(btnLapQDTD), dgvQDTD, lbTV, dgvThuViec,
                Ui.Hang(Ui.Lbl("Kết quả:"), cboKetQua, btnDanhGia));

            // ===== Tab 2: Ký hợp đồng chính thức =====
            var cboNVKy = Ui.Cbo(); var txtSoHD = Ui.Txt(); var cboLoaiHD = Ui.CboList("Dài hạn", "Ngắn hạn");
            var dtNgayKy = Ui.Dtp(); var dtBatDauHD = Ui.Dtp();
            var dtKetThucHD = Ui.Dtp(); dtKetThucHD.ShowCheckBox = true; dtKetThucHD.Checked = false;
            var cboKyHD = Ui.Cbo(); var txtNoiDungHD = Ui.Txt();
            var txtSoQDL = Ui.Txt(); var numLuongCB = Ui.Num(); var numPCL = Ui.Num(); var numPCDH = Ui.Num();
            var cboCV = Ui.Cbo(); var txtSoQDCV = Ui.Txt(); var numPCCV = Ui.Num();
            var txtBHXH = Ui.Txt(); var txtBHYT = Ui.Txt(); var numMucXH = Ui.Num(100, 2, 8); var numMucYT = Ui.Num(100, 2, 1.5m);
            var btnKyHD = Ui.Btn("Ký hợp đồng chính thức"); var dgvHD = Ui.Dgv();
            var g2 = Ui.Luoi(3);
            Ui.Them(g2, "Nhân viên (đạt thử việc)", cboNVKy); Ui.Them(g2, "Số hợp đồng", txtSoHD); Ui.Them(g2, "Loại hợp đồng", cboLoaiHD);
            Ui.Them(g2, "Ngày ký", dtNgayKy); Ui.Them(g2, "Ngày bắt đầu", dtBatDauHD); Ui.Them(g2, "Ngày kết thúc (ngắn hạn)", dtKetThucHD);
            Ui.Them(g2, "Giám đốc ký", cboKyHD); Ui.Them(g2, "Nội dung", txtNoiDungHD, 2);
            Ui.Them(g2, "Số QĐ lương", txtSoQDL); Ui.Them(g2, "Lương cơ bản", numLuongCB); Ui.Them(g2, "Phụ cấp lương", numPCL);
            Ui.Them(g2, "Phụ cấp độc hại", numPCDH); Ui.Them(g2, "Chức vụ (nếu có)", cboCV); Ui.Them(g2, "Số QĐ chức vụ", txtSoQDCV);
            Ui.Them(g2, "Phụ cấp chức vụ", numPCCV); Ui.Them(g2, "Số sổ BHXH (dài hạn)", txtBHXH); Ui.Them(g2, "Số thẻ BHYT (dài hạn)", txtBHYT);
            Ui.Them(g2, "Mức đóng BHXH (%)", numMucXH); Ui.Them(g2, "Mức đóng BHYT (%)", numMucYT);
            Ui.Doc(Ui.Tab(tc, "2. Ký hợp đồng chính thức"), g2, Ui.Hang(btnKyHD), dgvHD);

            var btnDong = Ui.Btn("Đóng");
            Ui.Doc(this, tc, Ui.Hang(btnDong));

            // Bật/tắt ô theo loại hợp đồng và chức vụ
            Action capNhatLoai = () =>
            {
                bool dai = cboLoaiHD.Text == "Dài hạn";
                txtBHXH.Enabled = txtBHYT.Enabled = numMucXH.Enabled = numMucYT.Enabled = dai;
                dtKetThucHD.Enabled = !dai;
                if (dai) dtKetThucHD.Checked = false; else dtKetThucHD.Checked = true;
            };
            Action capNhatCV = () =>
            {
                bool co = !string.IsNullOrEmpty(Ui.V(cboCV));
                txtSoQDCV.Enabled = numPCCV.Enabled = co;
            };
            cboLoaiHD.SelectedIndexChanged += (o, ev) => capNhatLoai();
            cboCV.SelectedIndexChanged += (o, ev) => capNhatCV();

            Action tai = () =>
            {
                Ui.Nap(cboNVChoTD, dm.LayNhanVienTheoTrangThai("Chờ tuyển dụng"), "HienThi", "MaNV");
                Ui.Nap(cboPBTD, dm.LayPhongBan(), "TenPB", "MaPB");
                Ui.Nap(cboLapTD, dm.LayNhanVienTheoVaiTro("Nhân sự"), "HienThi", "MaNV");
                Ui.Nap(cboKyTD, dm.LayNhanVienTheoVaiTro("Giám đốc"), "HienThi", "MaNV");
                Ui.Nap(cboKyHD, dm.LayNhanVienTheoVaiTro("Giám đốc"), "HienThi", "MaNV");
                Ui.Nap(cboNVKy, s.LayNhanVienDatThuViec(), "HienThi", "MaNV");
                DataTable cv = dm.LayChucVu();
                DataRow r = cv.NewRow(); r["MaCV"] = ""; r["TenCV"] = "(Không có chức vụ)"; cv.Rows.InsertAt(r, 0);
                Ui.Nap(cboCV, cv, "TenCV", "MaCV");
                dgvQDTD.DataSource = s.LayQDTuyenDung();
                dgvThuViec.DataSource = s.LayNhanVienThuViec();
                dgvHD.DataSource = s.LayHopDong();
                capNhatLoai(); capNhatCV();
            };
            Action<KetQuaXuLy> h = k => { if (Ui.Bao(k)) tai(); };

            btnLapQDTD.Click += (o, ev) => h(s.LapQDTuyenDung(txtSoQDTD.Text.Trim(), Ui.V(cboNVChoTD), Ui.V(cboPBTD),
                dtNgayQD.Value, dtBatDauTV.Value, dtKetThucTV.Value, numLuongTV.Value, txtDieuKhoan.Text.Trim(),
                Ui.V(cboLapTD), Ui.V(cboKyTD)));

            btnDanhGia.Click += (o, ev) =>
            {
                if (dgvThuViec.CurrentRow == null) { MessageBox.Show("Chọn một nhân viên đang thử việc."); return; }
                h(s.DanhGiaThuViec(Convert.ToString(dgvThuViec.CurrentRow.Cells["SoQDTD"].Value), cboKetQua.Text));
            };

            btnKyHD.Click += (o, ev) =>
            {
                var x = new KyHopDongInput
                {
                    SoHopDong = txtSoHD.Text.Trim(), MaNV = Ui.V(cboNVKy), LoaiHopDong = cboLoaiHD.Text,
                    NgayKy = dtNgayKy.Value, NgayBatDau = dtBatDauHD.Value,
                    NgayKetThuc = dtKetThucHD.Checked ? (DateTime?)dtKetThucHD.Value : null,
                    NoiDung = txtNoiDungHD.Text.Trim(), MaNVKy = Ui.V(cboKyHD),
                    SoQDLuong = txtSoQDL.Text.Trim(), LuongCoBan = numLuongCB.Value, PhuCapLuong = numPCL.Value, PhuCapDocHai = numPCDH.Value,
                    MaCV = Ui.V(cboCV), SoQDChucVu = txtSoQDCV.Text.Trim(), PhuCapChucVu = numPCCV.Value,
                    SoSoBHXH = txtBHXH.Text.Trim(), SoTheBHYT = txtBHYT.Text.Trim(), MucBHXH = numMucXH.Value, MucBHYT = numMucYT.Value
                };
                h(s.KyHopDong(x));
            };
            btnDong.Click += (o, ev) => Close();
            Load += (o, ev) => tai();
        }
    }
}
