using System;
using System.Data;
using QuanLyBenhAn.Data;
using static QuanLyBenhAn.Data.KetQuaXuLy;

namespace QuanLyBenhAn.Services
{
    public class DanhMucService
    {
        static readonly string[] BangHopLe = { "Khoa", "BacSi", "NhanVien", "TrieuChung", "LoaiXetNghiem", "Thuoc" };

        public DataTable Lay(string bang)
        {
            if (Array.IndexOf(BangHopLe, bang) < 0) throw new ArgumentException("Bảng không hợp lệ");
            return Db.Query("SELECT * FROM " + bang + " ORDER BY 1");
        }

        public KetQuaXuLy ThemKhoa(string ma, string ten, decimal phi)
        {
            if (Db.Rong(ma, ten) || phi < 0) return Fail("Thông tin khoa không hợp lệ.");
            return Db.Insert1("INSERT INTO Khoa VALUES(@m,@t,@p)", "Đã thêm khoa.", "@m", ma, "@t", ten, "@p", phi);
        }
        public KetQuaXuLy ThemBacSi(string ma, string ten, string cm, string khoa)
        {
            if (Db.Rong(ma, ten, khoa)) return Fail("Thông tin bác sĩ chưa đủ.");
            return Db.Insert1("INSERT INTO BacSi VALUES(@m,@t,@c,@k)", "Đã thêm bác sĩ.", "@m", ma, "@t", ten, "@c", cm, "@k", khoa);
        }
        public KetQuaXuLy ThemNhanVien(string ma, string ten, string vaiTro)
        {
            if (Db.Rong(ma, ten, vaiTro)) return Fail("Thông tin nhân viên chưa đủ.");
            return Db.Insert1("INSERT INTO NhanVien VALUES(@m,@t,@v)", "Đã thêm nhân viên.", "@m", ma, "@t", ten, "@v", vaiTro);
        }
        public KetQuaXuLy ThemTrieuChung(string ma, string ten, string donVi)
        {
            if (Db.Rong(ma, ten)) return Fail("Thông tin triệu chứng chưa đủ.");
            return Db.Insert1("INSERT INTO TrieuChung VALUES(@m,@t,@d)", "Đã thêm triệu chứng.", "@m", ma, "@t", ten, "@d", donVi);
        }
        public KetQuaXuLy ThemLoaiXN(string ma, string ten, decimal gia)
        {
            if (Db.Rong(ma, ten) || gia < 0) return Fail("Thông tin xét nghiệm không hợp lệ.");
            return Db.Insert1("INSERT INTO LoaiXetNghiem VALUES(@m,@t,@g)", "Đã thêm loại xét nghiệm.", "@m", ma, "@t", ten, "@g", gia);
        }
        public KetQuaXuLy ThemThuoc(string ma, string ten, string dvt, string hc, string ccd, decimal gia)
        {
            if (Db.Rong(ma, ten, dvt) || gia < 0) return Fail("Thông tin thuốc không hợp lệ.");
            return Db.Insert1("INSERT INTO Thuoc VALUES(@m,@t,@d,@h,@c,@g)", "Đã thêm thuốc.",
                "@m", ma, "@t", ten, "@d", dvt, "@h", hc, "@c", ccd, "@g", gia);
        }
    }
}
