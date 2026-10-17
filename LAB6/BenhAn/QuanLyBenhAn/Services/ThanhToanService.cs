using System;
using System.Data;
using QuanLyBenhAn.Data;
using static QuanLyBenhAn.Data.KetQuaXuLy;

namespace QuanLyBenhAn.Services
{
    public class ThanhToanService
    {
        static readonly string[] HinhThucHopLe = { "Tiền mặt", "Chuyển khoản", "Thẻ", "Ví điện tử" };

        public DataTable LayPhieuChoThanhToan()
        {
            return Db.Query(@"SELECT p.SoPhieuKham, b.HoTen, p.LoaiKham, p.NgayGioKham
                FROM PhieuKham p JOIN HoSoBenhAn h ON p.MaHS=h.MaHS JOIN BenhNhan b ON h.MaBN=b.MaBN
                WHERE p.TrangThai=N'Chờ thanh toán' ORDER BY p.NgayGioKham");
        }

        public DataTable LayHoaDon()
        {
            return Db.Query(@"SELECT h.SoHoaDon, h.SoPhieuKham, h.TienKham, h.TienXetNghiem, h.TienThuoc, h.TongTien,
                ISNULL((SELECT SUM(t.SoTien) FROM ThanhToan t WHERE t.SoHoaDon=h.SoHoaDon),0) AS DaTra, h.TrangThai
                FROM HoaDon h ORDER BY h.NgayLap DESC");
        }

        // BR11: hóa đơn gồm tiền khám + xét nghiệm + thuốc; định kỳ miễn tiền khám
        public KetQuaXuLy LapHoaDon(string pk, string maNV)
        {
            if (Db.Rong(pk, maNV)) return Fail("Phải chọn phiếu khám và nhân viên lập hóa đơn.");
            return Db.InTx((cn, tx) =>
            {
                decimal tienKham = 0, tienXN = 0, tienThuoc = 0; string tt = null;
                using (var rd = Db.Cmd(cn, tx, @"SELECT
                    CASE WHEN p.LoaiKham=N'Định kỳ' THEN 0 ELSE k.PhiKham END,
                    ISNULL((SELECT SUM(l.DonGia) FROM ChiTietXetNghiem x JOIN LoaiXetNghiem l ON x.MaLoaiXN=l.MaLoaiXN
                            WHERE x.SoPhieuKham=p.SoPhieuKham),0),
                    ISNULL((SELECT SUM(c.SoLuong*t.DonGia) FROM ToaThuoc a JOIN ChiTietToa c ON a.SoToa=c.SoToa
                            JOIN Thuoc t ON c.MaThuoc=t.MaThuoc WHERE a.SoPhieuKham=p.SoPhieuKham),0),
                    p.TrangThai
                    FROM PhieuKham AS p WITH (UPDLOCK) JOIN Khoa k ON p.MaKhoa=k.MaKhoa WHERE p.SoPhieuKham=@p", "@p", pk).ExecuteReader())
                {
                    if (!rd.Read()) return Fail("Không tìm thấy phiếu khám.");
                    tienKham = Convert.ToDecimal(rd[0]); tienXN = Convert.ToDecimal(rd[1]);
                    tienThuoc = Convert.ToDecimal(rd[2]); tt = Convert.ToString(rd[3]);
                }
                if (tt != "Chờ thanh toán") return Fail("Chỉ lập hóa đơn cho phiếu ở trạng thái Chờ thanh toán.");
                int daCo = Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM HoaDon WHERE SoPhieuKham=@p", "@p", pk).ExecuteScalar());
                if (daCo > 0) return Fail("Phiếu khám này đã có hóa đơn.");
                int chua = Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM ChiTietXetNghiem WHERE SoPhieuKham=@p AND KetQua IS NULL", "@p", pk).ExecuteScalar());
                if (chua > 0) return Fail("Còn xét nghiệm chưa có kết quả, chưa thể lập hóa đơn.");

                decimal tong = tienKham + tienXN + tienThuoc;
                string hd = Db.NextCode(cn, tx, "HD", "HoaDon", "SoHoaDon", 6);
                Db.Cmd(cn, tx, "INSERT INTO HoaDon(SoHoaDon,SoPhieuKham,MaNV,TienKham,TienXetNghiem,TienThuoc,TrangThai) VALUES(@h,@p,@nv,@k,@x,@t,@tt)",
                    "@h", hd, "@p", pk, "@nv", maNV, "@k", tienKham, "@x", tienXN, "@t", tienThuoc,
                    "@tt", tong == 0 ? "Đã thanh toán" : "Chưa thanh toán").ExecuteNonQuery();
                return Ok("Đã lập hóa đơn " + hd + ", tổng " + tong.ToString("N0") + (tong == 0 ? " (miễn phí, đã thanh toán)." : "."), hd);
            });
        }

        // BR12: nhiều giao dịch, nhiều hình thức, không vượt tổng hóa đơn
        public KetQuaXuLy ThanhToan(string soHD, string hinhThuc, decimal tien)
        {
            if (Db.Rong(soHD, hinhThuc)) return Fail("Phải chọn hóa đơn và hình thức thanh toán.");
            if (Array.IndexOf(HinhThucHopLe, hinhThuc) < 0) return Fail("Hình thức thanh toán không hợp lệ.");
            if (tien <= 0) return Fail("Số tiền phải lớn hơn 0.");
            return Db.InTx((cn, tx) =>
            {
                decimal tong = 0; string tt = null;
                using (var rd = Db.Cmd(cn, tx, "SELECT TongTien, TrangThai FROM HoaDon WITH (UPDLOCK) WHERE SoHoaDon=@h", "@h", soHD).ExecuteReader())
                {
                    if (!rd.Read()) return Fail("Không tìm thấy hóa đơn.");
                    tong = Convert.ToDecimal(rd[0]); tt = Convert.ToString(rd[1]);
                }
                if (tt == "Đã thanh toán") return Fail("Hóa đơn đã thanh toán đủ.");
                decimal da = Convert.ToDecimal(Db.Cmd(cn, tx, "SELECT ISNULL(SUM(SoTien),0) FROM ThanhToan WHERE SoHoaDon=@h", "@h", soHD).ExecuteScalar());
                if (da + tien > tong) return Fail("Số tiền vượt số còn phải trả (" + (tong - da).ToString("N0") + ").");
                string ma = Db.NextCode(cn, tx, "TT", "ThanhToan", "MaThanhToan", 6);
                Db.Cmd(cn, tx, "INSERT INTO ThanhToan(MaThanhToan,SoHoaDon,HinhThuc,SoTien) VALUES(@m,@h,@ht,@t)",
                    "@m", ma, "@h", soHD, "@ht", hinhThuc, "@t", tien).ExecuteNonQuery();
                if (da + tien == tong)
                    Db.Cmd(cn, tx, "UPDATE HoaDon SET TrangThai=N'Đã thanh toán' WHERE SoHoaDon=@h", "@h", soHD).ExecuteNonQuery();
                return Ok("Đã ghi thanh toán bằng " + hinhThuc + (da + tien == tong ? ". Hóa đơn đã thanh toán đủ." : ". Còn lại " + (tong - da - tien).ToString("N0") + "."));
            });
        }

        // BR11: chỉ hoàn tất khi hóa đơn đã thanh toán đủ; sau đó phiếu bị khóa
        public KetQuaXuLy HoanTat(string pk)
        {
            if (Db.Rong(pk)) return Fail("Chưa chọn phiếu khám.");
            return Db.InTx((cn, tx) =>
            {
                object o = Db.Cmd(cn, tx, "SELECT TrangThai FROM HoaDon WHERE SoPhieuKham=@p", "@p", pk).ExecuteScalar();
                if (o == null) return Fail("Chưa lập hóa đơn cho phiếu khám.");
                if (Convert.ToString(o) != "Đã thanh toán") return Fail("Hóa đơn chưa thanh toán đủ.");
                int n = Db.Cmd(cn, tx, "UPDATE PhieuKham SET TrangThai=N'Hoàn tất' WHERE SoPhieuKham=@p AND TrangThai=N'Chờ thanh toán'", "@p", pk).ExecuteNonQuery();
                return n == 0 ? Fail("Phiếu không ở trạng thái Chờ thanh toán.") : Ok("Đã hoàn tất phiếu khám, dữ liệu được khóa.");
            });
        }
    }
}
