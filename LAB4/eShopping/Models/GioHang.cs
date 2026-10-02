using System.ComponentModel;
using System.Linq;

namespace eShopping.Models
{
    public class GioHang
    {
        readonly BindingList<DongGioHang> ds = new BindingList<DongGioHang>();

        public BindingList<DongGioHang> Dong { get { return ds; } }
        public decimal TongTienHang { get { return ds.Sum(x => x.ThanhTien); } }
        public bool Rong { get { return ds.Count == 0; } }

        public KetQuaXuLy Them(SanPham sp, int soLuong)
        {
            if (sp == null) return KetQuaXuLy.Fail("Không tìm thấy sản phẩm.");
            if (!sp.ConHang) return KetQuaXuLy.Fail("Sản phẩm \"" + sp.TenSP + "\" đã hết hàng.");
            if (soLuong <= 0) return KetQuaXuLy.Fail("Số lượng phải lớn hơn 0.");
            var d = ds.FirstOrDefault(x => x.MaSP == sp.MaSP);
            if (d != null)
            {
                d.SoLuong += soLuong;
                d.DonGia = sp.GiaBan;
                ds.ResetBindings();
            }
            else
            {
                ds.Add(new DongGioHang { MaSP = sp.MaSP, TenSP = sp.TenSP, DonGia = sp.GiaBan, SoLuong = soLuong });
            }
            return KetQuaXuLy.Ok("Đã thêm vào giỏ hàng.");
        }

        public KetQuaXuLy CapNhatSoLuong(string maSP, int soLuong)
        {
            var d = ds.FirstOrDefault(x => x.MaSP == maSP);
            if (d == null) return KetQuaXuLy.Fail("Sản phẩm không có trong giỏ.");
            if (soLuong <= 0) return KetQuaXuLy.Fail("Số lượng phải lớn hơn 0. Muốn bỏ sản phẩm hãy dùng Xóa.");
            d.SoLuong = soLuong;
            ds.ResetBindings();
            return KetQuaXuLy.Ok("Đã cập nhật số lượng.");
        }

        public KetQuaXuLy Xoa(string maSP)
        {
            var d = ds.FirstOrDefault(x => x.MaSP == maSP);
            if (d == null) return KetQuaXuLy.Fail("Sản phẩm không có trong giỏ.");
            ds.Remove(d);
            return KetQuaXuLy.Ok("Đã bỏ sản phẩm khỏi giỏ.");
        }

        public void LamRong()
        {
            ds.Clear();
        }
    }
}
