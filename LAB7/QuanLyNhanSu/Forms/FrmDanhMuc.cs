using System;
using System.Windows.Forms;
using QuanLyNhanSu.Models;
using QuanLyNhanSu.Services;

namespace QuanLyNhanSu.Forms
{
    public class FrmDanhMuc : Form
    {
        readonly DanhMucService s = new DanhMucService();

        public FrmDanhMuc()
        {
            Ui.CauHinh(this, "Danh mục: phòng ban, chức vụ, ca làm việc, nhân viên", 1050, 660);
            var tc = new TabControl { Dock = DockStyle.Fill };

            // ===== Phòng ban =====
            var txtPBMa = Ui.Txt(); var txtPBTen = Ui.Txt(); var txtPBMoTa = Ui.Txt();
            var btnThemPB = Ui.Btn("Thêm phòng ban"); var dgvPB = Ui.Dgv();
            var g1 = Ui.Luoi(3);
            Ui.Them(g1, "Mã PB", txtPBMa); Ui.Them(g1, "Tên phòng ban", txtPBTen); Ui.Them(g1, "Mô tả", txtPBMoTa);
            Ui.Doc(Ui.Tab(tc, "Phòng ban"), g1, Ui.Hang(btnThemPB), dgvPB);

            // ===== Chức vụ =====
            var txtCVMa = Ui.Txt(); var txtCVTen = Ui.Txt();
            var btnThemCV = Ui.Btn("Thêm chức vụ"); var dgvCV = Ui.Dgv();
            var g2 = Ui.Luoi(2);
            Ui.Them(g2, "Mã chức vụ", txtCVMa); Ui.Them(g2, "Tên chức vụ", txtCVTen);
            Ui.Doc(Ui.Tab(tc, "Chức vụ"), g2, Ui.Hang(btnThemCV), dgvCV);

            // ===== Ca làm việc =====
            var txtCaMa = Ui.Txt(); var txtCaTen = Ui.Txt();
            var dtCaBD = Ui.Gio(); var dtCaKT = Ui.Gio(); var numCaGio = Ui.Num(24, 2, 8);
            var btnThemCa = Ui.Btn("Thêm ca"); var dgvCa = Ui.Dgv();
            var g3 = Ui.Luoi(3);
            Ui.Them(g3, "Mã ca", txtCaMa); Ui.Them(g3, "Tên ca", txtCaTen); Ui.Them(g3, "Số giờ làm", numCaGio);
            Ui.Them(g3, "Giờ bắt đầu", dtCaBD); Ui.Them(g3, "Giờ kết thúc", dtCaKT);
            Ui.Doc(Ui.Tab(tc, "Ca làm việc"), g3, Ui.Hang(btnThemCa), dgvCa);

            // ===== Nhân viên =====
            var txtNVMa = Ui.Txt(); var txtNVTen = Ui.Txt();
            var dtNVNgaySinh = Ui.Dtp(); dtNVNgaySinh.Value = new DateTime(1995, 1, 1);
            var cboNVGioiTinh = Ui.CboList("Nam", "Nữ");
            var txtNVCCCD = Ui.Txt(); var txtNVSDT = Ui.Txt(); var txtNVDiaChi = Ui.Txt();
            var cboNVVaiTro = Ui.CboList("Nhân viên", "Nhân sự", "Trưởng phòng", "Ban chấm công", "Kế toán", "Giám đốc");
            var btnThemNV = Ui.Btn("Thêm hồ sơ nhân viên"); var dgvNV = Ui.Dgv();
            var g4 = Ui.Luoi(3);
            Ui.Them(g4, "Mã NV", txtNVMa); Ui.Them(g4, "Họ tên", txtNVTen); Ui.Them(g4, "Ngày sinh", dtNVNgaySinh);
            Ui.Them(g4, "Giới tính", cboNVGioiTinh); Ui.Them(g4, "Số CCCD", txtNVCCCD); Ui.Them(g4, "Điện thoại", txtNVSDT);
            Ui.Them(g4, "Địa chỉ", txtNVDiaChi, 2); Ui.Them(g4, "Vai trò", cboNVVaiTro);
            Ui.Doc(Ui.Tab(tc, "Nhân viên"), g4, Ui.Hang(btnThemNV), dgvNV);

            var btnDong = Ui.Btn("Đóng");
            Ui.Doc(this, tc, Ui.Hang(btnDong));

            Action tai = () =>
            {
                dgvPB.DataSource = s.LayPhongBan(); dgvCV.DataSource = s.LayChucVu();
                dgvCa.DataSource = s.LayCaLamViec(); dgvNV.DataSource = s.LayNhanVien();
            };
            Action<KetQuaXuLy> h = k => { if (Ui.Bao(k)) tai(); };

            btnThemPB.Click += (o, ev) => h(s.ThemPhongBan(txtPBMa.Text.Trim(), txtPBTen.Text.Trim(), txtPBMoTa.Text.Trim()));
            btnThemCV.Click += (o, ev) => h(s.ThemChucVu(txtCVMa.Text.Trim(), txtCVTen.Text.Trim()));
            btnThemCa.Click += (o, ev) => h(s.ThemCaLamViec(txtCaMa.Text.Trim(), txtCaTen.Text.Trim(),
                dtCaBD.Value.TimeOfDay, dtCaKT.Value.TimeOfDay, numCaGio.Value));
            btnThemNV.Click += (o, ev) => h(s.ThemNhanVien(txtNVMa.Text.Trim(), txtNVTen.Text.Trim(), dtNVNgaySinh.Value,
                cboNVGioiTinh.Text, txtNVCCCD.Text.Trim(), txtNVDiaChi.Text.Trim(), txtNVSDT.Text.Trim(), cboNVVaiTro.Text));
            btnDong.Click += (o, ev) => Close();
            Load += (o, ev) => tai();
        }
    }
}
