using System;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public class FrmQuyetDinh : Form
    {
        readonly QuyetDinhService s = new QuyetDinhService();
        readonly DanhMucService dm = new DanhMucService();

        public FrmQuyetDinh()
        {
            Ui.CauHinh(this, "Quyết định chức vụ và quyết định lương", 1050, 640);
            var tc = new TabControl { Dock = DockStyle.Fill };

            // ===== QĐ chức vụ =====
            var txtSoQDCV = Ui.Txt(); var cboNVCV = Ui.Cbo(); var cboCV = Ui.Cbo();
            var dtHLCV = Ui.Dtp(); var numPCCV = Ui.Num(); var cboKyCV = Ui.Cbo(); var txtGhiChuCV = Ui.Txt();
            var btnLapCV = Ui.Btn("Lập quyết định chức vụ"); var dgvCV = Ui.Dgv();
            var g1 = Ui.Luoi(3);
            Ui.Them(g1, "Số QĐ chức vụ", txtSoQDCV); Ui.Them(g1, "Nhân viên", cboNVCV); Ui.Them(g1, "Chức vụ", cboCV);
            Ui.Them(g1, "Ngày hiệu lực", dtHLCV); Ui.Them(g1, "Phụ cấp chức vụ", numPCCV); Ui.Them(g1, "Giám đốc ký", cboKyCV);
            Ui.Them(g1, "Ghi chú", txtGhiChuCV, 3);
            Ui.Doc(Ui.Tab(tc, "Quyết định chức vụ"), g1, Ui.Hang(btnLapCV), dgvCV);

            // ===== QĐ lương =====
            var txtSoQDL = Ui.Txt(); var cboNVL = Ui.Cbo(); var dtHLL = Ui.Dtp();
            var numLuongCB = Ui.Num(); var numPCL = Ui.Num(); var numPCDH = Ui.Num();
            var cboLyDo = Ui.CboList("Tăng lương", "Điều chỉnh"); var cboKyL = Ui.Cbo();
            var btnLapL = Ui.Btn("Lập quyết định lương"); var dgvL = Ui.Dgv();
            var g2 = Ui.Luoi(3);
            Ui.Them(g2, "Số QĐ lương", txtSoQDL); Ui.Them(g2, "Nhân viên", cboNVL); Ui.Them(g2, "Ngày hiệu lực", dtHLL);
            Ui.Them(g2, "Lương cơ bản", numLuongCB); Ui.Them(g2, "Phụ cấp lương", numPCL); Ui.Them(g2, "Phụ cấp độc hại", numPCDH);
            Ui.Them(g2, "Lý do", cboLyDo); Ui.Them(g2, "Giám đốc ký", cboKyL);
            Ui.Doc(Ui.Tab(tc, "Quyết định lương"), g2, Ui.Hang(btnLapL), dgvL);

            var btnDong = Ui.Btn("Đóng");
            Ui.Doc(this, tc, Ui.Hang(btnDong));

            Action tai = () =>
            {
                Ui.Nap(cboNVCV, dm.LayNhanVienTheoTrangThai("Chính thức"), "HienThi", "MaNV");
                Ui.Nap(cboNVL, dm.LayNhanVienTheoTrangThai("Chính thức"), "HienThi", "MaNV");
                Ui.Nap(cboCV, dm.LayChucVu(), "TenCV", "MaCV");
                Ui.Nap(cboKyCV, dm.LayNhanVienTheoVaiTro("Giám đốc"), "HienThi", "MaNV");
                Ui.Nap(cboKyL, dm.LayNhanVienTheoVaiTro("Giám đốc"), "HienThi", "MaNV");
                dgvCV.DataSource = s.LayQDChucVu(); dgvL.DataSource = s.LayQDLuong();
            };
            Action<KetQuaXuLy> h = k => { if (Ui.Bao(k)) tai(); };

            btnLapCV.Click += (o, ev) => h(s.LapQDChucVu(txtSoQDCV.Text.Trim(), Ui.V(cboNVCV), Ui.V(cboCV),
                dtHLCV.Value, numPCCV.Value, txtGhiChuCV.Text.Trim(), Ui.V(cboKyCV)));
            btnLapL.Click += (o, ev) => h(s.LapQDLuong(txtSoQDL.Text.Trim(), Ui.V(cboNVL), dtHLL.Value,
                numLuongCB.Value, numPCL.Value, numPCDH.Value, cboLyDo.Text, Ui.V(cboKyL)));
            btnDong.Click += (o, ev) => Close();
            Load += (o, ev) => tai();
        }
    }
}
