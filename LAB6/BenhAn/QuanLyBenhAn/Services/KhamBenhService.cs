using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using QuanLyBenhAn.Data;
using QuanLyBenhAn.Models;
using static QuanLyBenhAn.Data.KetQuaXuLy;

namespace QuanLyBenhAn.Services
{
    public class KhamBenhService
    {
        // ---------- truy vấn ----------
        public DataTable LayPhieuDangKham()
        {
            return Db.Query(@"SELECT p.SoPhieuKham, p.MaHS, b.HoTen, p.LoaiKham, p.NgayGioKham, p.MaBS
                FROM PhieuKham p JOIN HoSoBenhAn h ON p.MaHS=h.MaHS JOIN BenhNhan b ON h.MaBN=b.MaBN
                WHERE p.TrangThai=N'Đang khám' ORDER BY p.NgayGioKham");
        }
        public DataTable LayLichDaDat(string maHS)
        {
            return Db.Query(@"SELECT MaLich, NgayGioHen FROM LichHen WHERE MaHS=@h AND TrangThai=N'Đã đặt'
                AND Quy=DATEPART(QUARTER,GETDATE()) AND Nam=YEAR(GETDATE())", "@h", maHS);
        }
        public DataTable LayTrieuChung(string pk)
        {
            return Db.Query(@"SELECT t.TenTC, c.GiaTri, t.DonVi FROM ChiTietTrieuChung c
                JOIN TrieuChung t ON c.MaTC=t.MaTC WHERE c.SoPhieuKham=@p ORDER BY t.TenTC", "@p", pk);
        }
        public DataTable LayXetNghiem(string pk)
        {
            return Db.Query(@"SELECT x.MaLoaiXN, l.TenXN, x.NgayYeuCau, x.KetQua, x.NgayTraKQ
                FROM ChiTietXetNghiem x JOIN LoaiXetNghiem l ON x.MaLoaiXN=l.MaLoaiXN
                WHERE x.SoPhieuKham=@p ORDER BY x.NgayYeuCau", "@p", pk);
        }
        public DataTable LayToa(string pk)
        {
            return Db.Query(@"SELECT a.SoToa, th.TenThuoc, c.SoLuong, c.LieuDung, c.CachDung, c.PhanUngPhu
                FROM ToaThuoc a JOIN ChiTietToa c ON a.SoToa=c.SoToa JOIN Thuoc th ON c.MaThuoc=th.MaThuoc
                WHERE a.SoPhieuKham=@p ORDER BY th.TenThuoc", "@p", pk);
        }
        public DataTable LayXNChoKetQua()
        {
            return Db.Query(@"SELECT x.SoPhieuKham, x.MaLoaiXN, l.TenXN, b.HoTen, x.NgayYeuCau
                FROM ChiTietXetNghiem x JOIN LoaiXetNghiem l ON x.MaLoaiXN=l.MaLoaiXN
                JOIN PhieuKham p ON x.SoPhieuKham=p.SoPhieuKham JOIN HoSoBenhAn h ON p.MaHS=h.MaHS
                JOIN BenhNhan b ON h.MaBN=b.MaBN
                WHERE x.KetQua IS NULL AND p.TrangThai<>N'Hoàn tất' ORDER BY x.NgayYeuCau");
        }

        // ---------- tiện ích ----------
        static string TrangThai(SqlConnection cn, SqlTransaction tx, string pk)
        {
            object o = Db.Cmd(cn, tx, "SELECT TrangThai FROM PhieuKham WITH (UPDLOCK) WHERE SoPhieuKham=@p", "@p", pk).ExecuteScalar();
            return o == null ? null : Convert.ToString(o);
        }
        static bool DangKham(SqlConnection cn, SqlTransaction tx, string pk) { return TrangThai(cn, tx, pk) == "Đang khám"; }

        // ---------- BR04, BR06, BR09 ----------
        public KetQuaXuLy TaoPhieuKham(string maHS, string maBS, string maKhoa, string loai, string maLich)
        {
            if (Db.Rong(maHS, maBS, maKhoa, loai)) return Fail("Hồ sơ, bác sĩ, khoa và loại khám không được để trống.");
            bool dinhKy = loai == "Định kỳ";
            if (dinhKy && Db.Rong(maLich)) return Fail("Khám định kỳ phải chọn lịch hẹn.");
            return Db.InTx((cn, tx) =>
            {
                var hh = Db.Cmd(cn, tx, "SELECT NgayHetHan FROM HoSoBenhAn WHERE MaHS=@h", "@h", maHS).ExecuteScalar();
                if (hh == null) return Fail("Không tìm thấy hồ sơ.");
                if (Convert.ToDateTime(hh) < DateTime.Today) return Fail("Hồ sơ đã hết hạn, cần gia hạn lệ phí trước khi khám.");
                int ok = Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM BacSi WHERE MaBS=@b AND MaKhoa=@k", "@b", maBS, "@k", maKhoa).ExecuteScalar());
                if (ok == 0) return Fail("Bác sĩ không thuộc khoa đã chọn.");
                string lich = null;
                if (dinhKy)
                {
                    int l = Convert.ToInt32(Db.Cmd(cn, tx,
                        @"SELECT COUNT(*) FROM LichHen WITH (UPDLOCK) WHERE MaLich=@l AND MaHS=@h AND TrangThai=N'Đã đặt'
                          AND Quy=DATEPART(QUARTER,GETDATE()) AND Nam=YEAR(GETDATE())", "@l", maLich, "@h", maHS).ExecuteScalar());
                    if (l == 0) return Fail("Lịch hẹn không hợp lệ: phải là lịch Đã đặt của hồ sơ này, trong quý hiện tại.");
                    lich = maLich;
                }
                string pk = Db.NextCode(cn, tx, "PK", "PhieuKham", "SoPhieuKham", 6);
                Db.Cmd(cn, tx, "INSERT INTO PhieuKham(SoPhieuKham,MaHS,MaBS,MaKhoa,MaLich,LoaiKham) VALUES(@p,@h,@b,@k,@l,@t)",
                    "@p", pk, "@h", maHS, "@b", maBS, "@k", maKhoa, "@l", lich, "@t", loai).ExecuteNonQuery();
                if (lich != null) Db.Cmd(cn, tx, "UPDATE LichHen SET TrangThai=N'Đã khám' WHERE MaLich=@l", "@l", lich).ExecuteNonQuery();
                return Ok("Đã tạo phiếu khám " + pk + ".", pk);
            });
        }

        public KetQuaXuLy GhiTrieuChung(string pk, string maTC, string giaTri)
        {
            if (Db.Rong(pk, maTC, giaTri)) return Fail("Phải chọn phiếu, triệu chứng và nhập giá trị.");
            return Db.InTx((cn, tx) =>
            {
                if (!DangKham(cn, tx, pk)) return Fail("Phiếu khám không tồn tại hoặc đã khóa.");
                int n = Db.Cmd(cn, tx, "UPDATE ChiTietTrieuChung SET GiaTri=@g WHERE SoPhieuKham=@p AND MaTC=@t", "@g", giaTri, "@p", pk, "@t", maTC).ExecuteNonQuery();
                if (n == 0) Db.Cmd(cn, tx, "INSERT INTO ChiTietTrieuChung VALUES(@p,@t,@g)", "@p", pk, "@t", maTC, "@g", giaTri).ExecuteNonQuery();
                return Ok("Đã ghi triệu chứng.");
            });
        }

        // BR05: xét nghiệm gắn đúng một phiếu, mỗi loại tối đa một lần
        public KetQuaXuLy YeuCauXetNghiem(string pk, string maLoaiXN)
        {
            if (Db.Rong(pk, maLoaiXN)) return Fail("Phải chọn phiếu và loại xét nghiệm.");
            return Db.InTx((cn, tx) =>
            {
                if (!DangKham(cn, tx, pk)) return Fail("Phiếu khám không tồn tại hoặc đã khóa.");
                int co = Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM ChiTietXetNghiem WHERE SoPhieuKham=@p AND MaLoaiXN=@l", "@p", pk, "@l", maLoaiXN).ExecuteScalar());
                if (co > 0) return Fail("Xét nghiệm này đã được yêu cầu trong phiếu.");
                Db.Cmd(cn, tx, "INSERT INTO ChiTietXetNghiem(SoPhieuKham,MaLoaiXN) VALUES(@p,@l)", "@p", pk, "@l", maLoaiXN).ExecuteNonQuery();
                return Ok("Đã yêu cầu xét nghiệm.");
            });
        }

        public KetQuaXuLy NhapKetQuaXN(string pk, string maLoaiXN, string ketQua, string maKTV)
        {
            if (Db.Rong(pk, maLoaiXN, ketQua, maKTV)) return Fail("Thiếu thông tin kết quả xét nghiệm.");
            return Db.InTx((cn, tx) =>
            {
                string tt = TrangThai(cn, tx, pk);
                if (tt == null) return Fail("Không tìm thấy phiếu khám.");
                if (tt == "Hoàn tất") return Fail("Phiếu đã Hoàn tất, không được sửa.");
                int n = Db.Cmd(cn, tx, "UPDATE ChiTietXetNghiem SET KetQua=@k, NgayTraKQ=GETDATE(), MaKTV=@v WHERE SoPhieuKham=@p AND MaLoaiXN=@l",
                    "@k", ketQua, "@v", maKTV, "@p", pk, "@l", maLoaiXN).ExecuteNonQuery();
                return n == 0 ? Fail("Phiếu này chưa yêu cầu xét nghiệm đó.") : Ok("Đã lưu kết quả xét nghiệm.");
            });
        }

        // BR05, BR10: toa gắn đúng một phiếu, chỉ bác sĩ phụ trách được lập
        public KetQuaXuLy LapToa(string pk, string maBS, string loiDan, List<ThuocItem> ds)
        {
            if (Db.Rong(pk, maBS)) return Fail("Thiếu phiếu khám hoặc bác sĩ.");
            if (ds == null || ds.Count == 0) return Fail("Toa thuốc phải có ít nhất một thuốc.");
            var daCo = new HashSet<string>();
            foreach (var x in ds)
            {
                if (x.SoLuong <= 0 || Db.Rong(x.MaThuoc, x.LieuDung)) return Fail("Thuốc " + x.TenThuoc + " thiếu số lượng hoặc liều dùng.");
                if (!daCo.Add(x.MaThuoc)) return Fail("Thuốc " + x.TenThuoc + " bị lặp trong toa.");
            }
            return Db.InTx((cn, tx) =>
            {
                if (!DangKham(cn, tx, pk)) return Fail("Phiếu khám không tồn tại hoặc đã khóa.");
                string phuTrach = Convert.ToString(Db.Cmd(cn, tx, "SELECT MaBS FROM PhieuKham WHERE SoPhieuKham=@p", "@p", pk).ExecuteScalar());
                if (phuTrach != maBS) return Fail("Chỉ bác sĩ phụ trách phiếu mới được lập toa.");
                int co = Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM ToaThuoc WHERE SoPhieuKham=@p", "@p", pk).ExecuteScalar());
                if (co > 0) return Fail("Phiếu khám này đã có toa thuốc.");
                string toa = Db.NextCode(cn, tx, "TOA", "ToaThuoc", "SoToa", 6);
                Db.Cmd(cn, tx, "INSERT INTO ToaThuoc(SoToa,SoPhieuKham,MaBS,LoiDan) VALUES(@t,@p,@b,@d)",
                    "@t", toa, "@p", pk, "@b", maBS, "@d", loiDan).ExecuteNonQuery();
                foreach (var x in ds)
                    Db.Cmd(cn, tx, "INSERT INTO ChiTietToa VALUES(@t,@m,@sl,@ld,@cd,@pu)",
                        "@t", toa, "@m", x.MaThuoc, "@sl", x.SoLuong, "@ld", x.LieuDung, "@cd", x.CachDung, "@pu", x.PhanUngPhu).ExecuteNonQuery();
                return Ok("Đã lập toa " + toa + " với " + ds.Count + " thuốc.", toa);
            });
        }

        // Kết luận: chuyển sang Chờ thanh toán
        public KetQuaXuLy KetLuan(string pk, string ketLuan)
        {
            if (Db.Rong(pk, ketLuan)) return Fail("Cần chọn phiếu và nhập kết luận.");
            return Db.InTx((cn, tx) =>
            {
                if (!DangKham(cn, tx, pk)) return Fail("Phiếu khám không ở trạng thái Đang khám.");
                string loai = Convert.ToString(Db.Cmd(cn, tx, "SELECT LoaiKham FROM PhieuKham WHERE SoPhieuKham=@p", "@p", pk).ExecuteScalar());
                int tc = Convert.ToInt32(Db.Cmd(cn, tx, "SELECT COUNT(*) FROM ChiTietTrieuChung WHERE SoPhieuKham=@p", "@p", pk).ExecuteScalar());
                if (loai == "Điều trị" && tc == 0) return Fail("Phiếu điều trị phải ghi ít nhất một triệu chứng.");
                Db.Cmd(cn, tx, "UPDATE PhieuKham SET KetLuan=@k, TrangThai=N'Chờ thanh toán' WHERE SoPhieuKham=@p", "@k", ketLuan, "@p", pk).ExecuteNonQuery();
                return Ok("Đã kết luận, phiếu chuyển sang Chờ thanh toán.");
            });
        }
    }
}
