using System.Collections.Generic;
using System.Linq;
using eShopping.Models;

namespace eShopping.Adapters
{
    public class MockProductSystem : IProductSystem
    {
        readonly List<NhomSanPham> nhom = new List<NhomSanPham>
        {
            new NhomSanPham { MaNhom = "CAM", TenNhom = "Máy chụp hình kỹ thuật số" },
            new NhomSanPham { MaNhom = "TOY", TenNhom = "Đồ chơi" },
            new NhomSanPham { MaNhom = "GD", TenNhom = "Thiết bị điện gia dụng" },
            new NhomSanPham { MaNhom = "PC", TenNhom = "Thiết bị máy tính" }
        };

        readonly List<SanPham> sp = new List<SanPham>
        {
            new SanPham { MaSP = "CAM01", TenSP = "Máy ảnh compact X100", NhaSanXuat = "Fuji", MaNhom = "CAM", GiaBan = 3200000, ConHang = true, MoTa = "Máy ảnh nhỏ gọn.", ThongSoKyThuat = "20MP, zoom 5x" },
            new SanPham { MaSP = "CAM02", TenSP = "Máy ảnh mirrorless Z5", NhaSanXuat = "Nikon", MaNhom = "CAM", GiaBan = 28500000, ConHang = true, MoTa = "Mirrorless full-frame.", ThongSoKyThuat = "24MP, 4K" },
            new SanPham { MaSP = "CAM03", TenSP = "Máy ảnh du lịch T7", NhaSanXuat = "Sony", MaNhom = "CAM", GiaBan = 6900000, ConHang = false, MoTa = "Đang hết hàng.", ThongSoKyThuat = "18MP" },
            new SanPham { MaSP = "TOY01", TenSP = "Bộ xếp hình 500 mảnh", NhaSanXuat = "BrickCo", MaNhom = "TOY", GiaBan = 450000, ConHang = true, MoTa = "Quà Giáng sinh.", ThongSoKyThuat = "500 mảnh" },
            new SanPham { MaSP = "TOY02", TenSP = "Robot điều khiển từ xa", NhaSanXuat = "RoboKid", MaNhom = "TOY", GiaBan = 780000, ConHang = true, MoTa = "Pin sạc.", ThongSoKyThuat = "2.4GHz" },
            new SanPham { MaSP = "GD01", TenSP = "Nồi chiên không dầu 5L", NhaSanXuat = "Philips", MaNhom = "GD", GiaBan = 2100000, ConHang = true, MoTa = "Công suất 1700W.", ThongSoKyThuat = "5L" },
            new SanPham { MaSP = "PC01", TenSP = "Chuột không dây", NhaSanXuat = "Logitech", MaNhom = "PC", GiaBan = 320000, ConHang = true, MoTa = "Bluetooth.", ThongSoKyThuat = "1600 DPI" },
            new SanPham { MaSP = "PC02", TenSP = "Bàn phím cơ", NhaSanXuat = "Keychron", MaNhom = "PC", GiaBan = 1850000, ConHang = true, MoTa = "Switch đỏ.", ThongSoKyThuat = "75%" }
        };

        public IList<NhomSanPham> LayNhom()
        {
            return nhom;
        }

        public IList<SanPham> LaySanPham(string maNhom)
        {
            return sp.Where(x => x.MaNhom == maNhom).ToList();
        }

        public SanPham LayChiTiet(string maSP)
        {
            return sp.FirstOrDefault(x => x.MaSP == maSP);
        }

        public void DatGia(string maSP, decimal gia)
        {
            sp.First(x => x.MaSP == maSP).GiaBan = gia;
        }

        public void DatConHang(string maSP, bool con)
        {
            sp.First(x => x.MaSP == maSP).ConHang = con;
        }
    }
}
