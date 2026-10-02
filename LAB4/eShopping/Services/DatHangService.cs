using System;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using eShopping.Adapters;
using eShopping.Data;
using eShopping.Models;

namespace eShopping.Services
{
    public class DatHangService
    {
        readonly CauHinhService cauHinh = new CauHinhService();
        readonly IProductSystem heThongSanPham;
        readonly IPaymentGateway thanhToan;
        readonly IEmailService email;

        public DatHangService() : this(DichVuNgoai.SanPham, DichVuNgoai.ThanhToan, DichVuNgoai.Email)
        {
        }

        public DatHangService(IProductSystem heThongSanPham, IPaymentGateway thanhToan, IEmailService email)
        {
            this.heThongSanPham = heThongSanPham;
            this.thanhToan = thanhToan;
            this.email = email;
        }

        public KetQuaXuLy TinhGia(GioHang gio, string maLoaiPhieu, string maKhuVuc, string maLoaiThe)
        {
            if (gio == null || gio.Rong) return KetQuaXuLy.Fail("Giỏ hàng trống.");
            var phiTheoBang = cauHinh.LayPhiGiaoTheoBang(maKhuVuc, maLoaiPhieu);
            if (phiTheoBang == null) return KetQuaXuLy.Fail("Chưa cấu hình phí giao hàng cho khu vực và loại phiếu đã chọn.");
            var loaiThe = cauHinh.LayLoaiThe(maLoaiThe);
            if (loaiThe == null) return KetQuaXuLy.Fail("Chưa chọn loại thẻ.");
            var bang = new BangGia
            {
                TienHang = gio.TongTienHang,
                MienPhiGiao = QuyTac.MienPhiGiao(gio.TongTienHang, maLoaiPhieu),
                PhiGiao = QuyTac.PhiGiao(gio.TongTienHang, maLoaiPhieu, phiTheoBang.Value),
                PhiThe = loaiThe.LePhi
            };
            return KetQuaXuLy.Ok("OK", bang);
        }

        public KetQuaXuLy DatHang(KhachHang kh, GioHang gio, string maLoaiPhieu, NguoiNhan nguoiNhan, ThongTinThe the, DateTime now)
        {
            if (kh == null) return KetQuaXuLy.Fail("Bạn cần đăng nhập trước khi đặt hàng.");
            if (gio == null || gio.Rong) return KetQuaXuLy.Fail("Giỏ hàng trống.");
            if (string.IsNullOrWhiteSpace(maLoaiPhieu)) return KetQuaXuLy.Fail("Chưa chọn loại phiếu đặt hàng.");
            if (nguoiNhan == null || string.IsNullOrWhiteSpace(nguoiNhan.HoTen) || string.IsNullOrWhiteSpace(nguoiNhan.DiaChi)
                || string.IsNullOrWhiteSpace(nguoiNhan.DienThoai) || string.IsNullOrWhiteSpace(nguoiNhan.MaKhuVuc))
                return KetQuaXuLy.Fail("Nhập đủ họ tên, địa chỉ, điện thoại và khu vực của người nhận.");
            if (the == null) return KetQuaXuLy.Fail("Chưa nhập thông tin thẻ.");

            bool doiGia = false;
            foreach (var dong in gio.Dong.ToList())
            {
                var sp = heThongSanPham.LayChiTiet(dong.MaSP);
                if (sp == null) return KetQuaXuLy.Fail("Sản phẩm \"" + dong.TenSP + "\" không còn trong hệ thống.");
                if (!sp.ConHang) return KetQuaXuLy.Fail("Sản phẩm \"" + dong.TenSP + "\" đã hết hàng. Hãy bỏ khỏi giỏ.");
                if (sp.GiaBan != dong.DonGia)
                {
                    dong.DonGia = sp.GiaBan;
                    doiGia = true;
                }
            }
            if (doiGia)
            {
                gio.Dong.ResetBindings();
                return KetQuaXuLy.Fail("Giá một số sản phẩm đã thay đổi. Giỏ hàng đã được cập nhật, vui lòng kiểm tra và đặt lại.");
            }

            var ketQuaGia = TinhGia(gio, maLoaiPhieu, nguoiNhan.MaKhuVuc, the.MaLoaiThe);
            if (!ketQuaGia.ThanhCong) return ketQuaGia;
            var bang = (BangGia)ketQuaGia.DuLieu;

            var loaiThe = cauHinh.LayLoaiThe(the.MaLoaiThe);
            var ketQuaThe = QuyTac.KiemTraThe(the, loaiThe, now);
            if (!ketQuaThe.ThanhCong) return ketQuaThe;

            KetQuaKiemTraThe ketQuaTT;
            try
            {
                ketQuaTT = thanhToan.KiemTra(the, bang.Tong);
            }
            catch (Exception ex)
            {
                return KetQuaXuLy.Fail("Không kết nối được dịch vụ thanh toán: " + ex.Message);
            }
            if (!ketQuaTT.ThanhCong)
            {
                GhiNhatKyThe(kh.MaKhach, the, bang.Tong, "Từ chối", ketQuaTT.LyDo, null);
                return KetQuaXuLy.Fail("Thanh toán bị từ chối: " + ketQuaTT.LyDo + " Đơn hàng chưa được ghi nhận.");
            }

            string soDon;
            using (var cn = Db.OpenConnection())
            using (var tx = cn.BeginTransaction())
            {
                try
                {
                    var lenhGD = new SqlCommand(@"INSERT INTO GiaoDichThe(MaKhach,MaLoaiThe,Last4,TenChuThe,SoTien,KetQua,LyDo,MaThamChieu)
                        OUTPUT INSERTED.MaGiaoDich
                        VALUES(@mk,@lt,@l4,@tc,@st,N'Thành công',NULL,@tc2)", cn, tx);
                    lenhGD.Parameters.AddWithValue("@mk", kh.MaKhach);
                    lenhGD.Parameters.AddWithValue("@lt", the.MaLoaiThe);
                    lenhGD.Parameters.AddWithValue("@l4", the.Last4);
                    lenhGD.Parameters.AddWithValue("@tc", the.TenChuThe.Trim());
                    lenhGD.Parameters.AddWithValue("@st", bang.Tong);
                    lenhGD.Parameters.AddWithValue("@tc2", (object)ketQuaTT.MaThamChieu ?? DBNull.Value);
                    int maGiaoDich = Convert.ToInt32(lenhGD.ExecuteScalar());

                    var lenhSo = new SqlCommand("SELECT NEXT VALUE FOR SeqSoDon", cn, tx);
                    soDon = "DH" + Convert.ToInt64(lenhSo.ExecuteScalar()).ToString("D6");

                    var lenhDon = new SqlCommand(@"INSERT INTO DonDatHang(SoDon,MaKhach,MaLoaiPhieu,NgayDat,NguoiNhan,DiaChiNhan,DienThoaiNhan,MaKhuVuc,TienHang,PhiGiao,PhiThe,MaGiaoDich)
                        VALUES(@so,@mk,@lp,@nd,@nn,@dc,@dt,@kv,@th,@pg,@pt,@gd)", cn, tx);
                    lenhDon.Parameters.AddWithValue("@so", soDon);
                    lenhDon.Parameters.AddWithValue("@mk", kh.MaKhach);
                    lenhDon.Parameters.AddWithValue("@lp", maLoaiPhieu);
                    lenhDon.Parameters.AddWithValue("@nd", now);
                    lenhDon.Parameters.AddWithValue("@nn", nguoiNhan.HoTen.Trim());
                    lenhDon.Parameters.AddWithValue("@dc", nguoiNhan.DiaChi.Trim());
                    lenhDon.Parameters.AddWithValue("@dt", nguoiNhan.DienThoai.Trim());
                    lenhDon.Parameters.AddWithValue("@kv", nguoiNhan.MaKhuVuc);
                    lenhDon.Parameters.AddWithValue("@th", bang.TienHang);
                    lenhDon.Parameters.AddWithValue("@pg", bang.PhiGiao);
                    lenhDon.Parameters.AddWithValue("@pt", bang.PhiThe);
                    lenhDon.Parameters.AddWithValue("@gd", maGiaoDich);
                    lenhDon.ExecuteNonQuery();

                    foreach (var dong in gio.Dong)
                    {
                        var lenhCT = new SqlCommand("INSERT INTO ChiTietDonDat(SoDon,MaSP,TenSP,DonGia,SoLuong) VALUES(@so,@ma,@ten,@gia,@sl)", cn, tx);
                        lenhCT.Parameters.AddWithValue("@so", soDon);
                        lenhCT.Parameters.AddWithValue("@ma", dong.MaSP);
                        lenhCT.Parameters.AddWithValue("@ten", dong.TenSP);
                        lenhCT.Parameters.AddWithValue("@gia", dong.DonGia);
                        lenhCT.Parameters.AddWithValue("@sl", dong.SoLuong);
                        lenhCT.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    return KetQuaXuLy.Fail("Không ghi nhận được đơn hàng: " + ex.Message);
                }
            }

            string thongBaoEmail;
            if (string.IsNullOrWhiteSpace(kh.Email))
            {
                CapNhatTrangThaiEmail(soDon, "Không có email");
                thongBaoEmail = "Khách hàng không cung cấp email nên không gửi xác nhận.";
            }
            else
            {
                string loi;
                string noiDung = SoanEmail(soDon, kh, gio, maLoaiPhieu, nguoiNhan, bang, now);
                bool daGui = email.Gui(kh.Email.Trim(), "Xác nhận đơn đặt hàng " + soDon, noiDung, out loi);
                CapNhatTrangThaiEmail(soDon, daGui ? "Đã gửi" : "Lỗi gửi");
                thongBaoEmail = daGui
                    ? "Đã gửi email xác nhận tới " + kh.Email + "."
                    : "Đơn đã ghi nhận nhưng gửi email thất bại (" + loi + ").";
            }

            gio.LamRong();
            return KetQuaXuLy.Ok("Đặt hàng thành công. Số đơn: " + soDon + ". Tổng thanh toán: " + bang.Tong.ToString("N0") + " đ. " + thongBaoEmail, soDon);
        }

        void GhiNhatKyThe(int maKhach, ThongTinThe the, decimal soTien, string ketQua, string lyDo, string maThamChieu)
        {
            try
            {
                Db.Execute(@"INSERT INTO GiaoDichThe(MaKhach,MaLoaiThe,Last4,TenChuThe,SoTien,KetQua,LyDo,MaThamChieu)
                             VALUES(@mk,@lt,@l4,@tc,@st,@kq,@ld,@tc2)",
                    new SqlParameter("@mk", maKhach),
                    new SqlParameter("@lt", the.MaLoaiThe),
                    new SqlParameter("@l4", the.Last4),
                    new SqlParameter("@tc", the.TenChuThe.Trim()),
                    new SqlParameter("@st", soTien),
                    new SqlParameter("@kq", ketQua),
                    new SqlParameter("@ld", (object)lyDo ?? DBNull.Value),
                    new SqlParameter("@tc2", (object)maThamChieu ?? DBNull.Value));
            }
            catch
            {
            }
        }

        void CapNhatTrangThaiEmail(string soDon, string trangThai)
        {
            try
            {
                Db.Execute("UPDATE DonDatHang SET TrangThaiEmail=@t WHERE SoDon=@s",
                    new SqlParameter("@t", trangThai), new SqlParameter("@s", soDon));
            }
            catch
            {
            }
        }

        static string SoanEmail(string soDon, KhachHang kh, GioHang gio, string maLoaiPhieu, NguoiNhan nn, BangGia bang, DateTime now)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Cảm ơn " + kh.HoTen + " đã mua hàng tại e-Shopping.");
            sb.AppendLine("Số đơn: " + soDon + " - Thời điểm đặt: " + now.ToString("dd/MM/yyyy HH:mm"));
            sb.AppendLine("Hình thức giao: " + maLoaiPhieu);
            sb.AppendLine("Người nhận: " + nn.HoTen + " - " + nn.DienThoai);
            sb.AppendLine("Địa chỉ nhận: " + nn.DiaChi);
            sb.AppendLine("--- Sản phẩm ---");
            foreach (var d in gio.Dong)
                sb.AppendLine(d.TenSP + " | SL " + d.SoLuong + " x " + d.DonGia.ToString("N0") + " = " + d.ThanhTien.ToString("N0"));
            sb.AppendLine("Tiền hàng: " + bang.TienHang.ToString("N0"));
            sb.AppendLine("Phí giao hàng: " + bang.PhiGiao.ToString("N0") + (bang.MienPhiGiao ? " (miễn phí)" : ""));
            sb.AppendLine("Phí thanh toán: " + bang.PhiThe.ToString("N0"));
            sb.AppendLine("TỔNG CỘNG: " + bang.Tong.ToString("N0") + " đ");
            return sb.ToString();
        }
    }
}
