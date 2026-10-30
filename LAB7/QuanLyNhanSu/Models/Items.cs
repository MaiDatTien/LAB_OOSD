using System;

namespace QuanLyNhanSu.Models
{
    public class PhanCongItem
    {
        public string MaNV { get; set; }
        public DateTime Ngay { get; set; }
        public string MaCa { get; set; }
        public bool CoPhuTroi { get; set; }
    }
    public class ChamCongItem
    {
        public string MaNV { get; set; }
        public DateTime Ngay { get; set; }
        public string MaCa { get; set; }
        public decimal SoGioLam { get; set; }
    }
    public class PhuTroiItem
    {
        public string MaNV { get; set; }
        public decimal SoGioPhuTroi { get; set; }
    }
    public class KhenThuongItem
    {
        public string MaNV { get; set; }
        public string MaPB { get; set; }
        public decimal SoTien { get; set; }
        public string DoiTuong { get { return MaNV ?? MaPB; } }
    }
    public class KyLuatItem
    {
        public string MaNV { get; set; }
        public string MaPB { get; set; }
        public decimal SoTienPhat { get; set; }
        public string HinhThucThu { get; set; }
        public string SoPhieuThu { get; set; }
        public string DoiTuong { get { return MaNV ?? MaPB; } }
    }
    public class KyHopDongInput
    {
        public string SoHopDong, MaNV, LoaiHopDong, NoiDung, MaNVKy;
        public DateTime NgayKy, NgayBatDau;
        public DateTime? NgayKetThuc;
        public string SoQDLuong;
        public decimal LuongCoBan, PhuCapLuong, PhuCapDocHai;
        public string MaCV, SoQDChucVu;
        public decimal PhuCapChucVu;
        public string SoSoBHXH, SoTheBHYT;
        public decimal MucBHXH = 8m, MucBHYT = 1.5m;
    }
}
