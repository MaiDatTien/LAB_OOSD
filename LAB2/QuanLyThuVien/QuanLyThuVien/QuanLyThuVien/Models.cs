using System;

namespace QuanLyThuVien.Models
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public string Phai { get; set; }
        public DateTime NgaySinh { get; set; }
        public string ChucVu { get; set; }
        public string SoDienThoai { get; set; }
    }

    public class TheLoai
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
    }

    public class NhaXuatBan
    {
        public string MaNhaXuatBan { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
    }

    public class DauSach
    {
        public string MaDauSach { get; set; }
        public string TenSach { get; set; }
        public int NamXuatBan { get; set; }
        public int SoLuongHienCo { get; set; }
        public string MaTheLoai { get; set; }
        public string MaNhaXuatBan { get; set; }
    }

    public class DocGia
    {
        public string MaDocGia { get; set; }
        public string Ho { get; set; }
        public string Ten { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Phai { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public string Anh3x4 { get; set; }
    }

    public class KetQuaXuLy
    {
        public bool ThanhCong { get; set; }
        public string ThongBao { get; set; }
        public static KetQuaXuLy Ok(string msg) => new KetQuaXuLy { ThanhCong = true, ThongBao = msg };
        public static KetQuaXuLy Loi(string msg) => new KetQuaXuLy { ThanhCong = false, ThongBao = msg };
    }

    public class ThongKeTongHop
    {
        public int LuotSachMuon { get; set; }
        public int SachQuaHan { get; set; }
        public int SachMat { get; set; }
        public int SachHuHong { get; set; }
        public decimal TongPhiPhat { get; set; }
    }
}