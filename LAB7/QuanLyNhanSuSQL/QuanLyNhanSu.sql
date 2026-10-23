-- =============================================================================
-- ĐẠI HỌC CÔNG NGHỆ TP.HCM (HUTECH)
-- BÀI THỰC HÀNH SỐ 7: PHÂN TÍCH THIẾT KẾ HƯỚNG ĐỐI TƯỢNG
-- HỆ THỐNG QUẢN LÝ NHÂN SỰ - CÔNG TY SƠN ĐÔNG Á
-- SCRIPT T-SQL TẠO CƠ SỞ DỮ LIỆU, RÀNG BUỘC VÀ DỮ LIỆU KIỂM THỬ MẪU
-- =============================================================================

IF DB_ID(N'QuanLyNhanSu') IS NULL 
    CREATE DATABASE QuanLyNhanSu;
GO

USE QuanLyNhanSu;
GO

-- Xóa bảng cũ theo thứ tự ràng buộc khóa ngoại (nếu có)
IF OBJECT_ID('PhieuThuNopPhat','U') IS NOT NULL DROP TABLE PhieuThuNopPhat;
IF OBJECT_ID('ChiTietKyLuat','U') IS NOT NULL DROP TABLE ChiTietKyLuat;
IF OBJECT_ID('QuyetDinhKyLuat','U') IS NOT NULL DROP TABLE QuyetDinhKyLuat;
IF OBJECT_ID('PhieuChiKhenThuong','U') IS NOT NULL DROP TABLE PhieuChiKhenThuong;
IF OBJECT_ID('ChiTietKhenThuong','U') IS NOT NULL DROP TABLE ChiTietKhenThuong;
IF OBJECT_ID('QuyetDinhKhenThuong','U') IS NOT NULL DROP TABLE QuyetDinhKhenThuong;
IF OBJECT_ID('ChiTietBangLuong','U') IS NOT NULL DROP TABLE ChiTietBangLuong;
IF OBJECT_ID('BangLuong','U') IS NOT NULL DROP TABLE BangLuong;
IF OBJECT_ID('ChiTietPhieuPhuTroi','U') IS NOT NULL DROP TABLE ChiTietPhieuPhuTroi;
IF OBJECT_ID('PhieuPhuTroi','U') IS NOT NULL DROP TABLE PhieuPhuTroi;
IF OBJECT_ID('ChiTietChamCong','U') IS NOT NULL DROP TABLE ChiTietChamCong;
IF OBJECT_ID('BangChamCong','U') IS NOT NULL DROP TABLE BangChamCong;
IF OBJECT_ID('ChiTietPhanCong','U') IS NOT NULL DROP TABLE ChiTietPhanCong;
IF OBJECT_ID('KeHoachPhanCong','U') IS NOT NULL DROP TABLE KeHoachPhanCong;
IF OBJECT_ID('HoSoBaoHiem','U') IS NOT NULL DROP TABLE HoSoBaoHiem;
IF OBJECT_ID('QuyetDinhLuong','U') IS NOT NULL DROP TABLE QuyetDinhLuong;
IF OBJECT_ID('QuyetDinhChucVu','U') IS NOT NULL DROP TABLE QuyetDinhChucVu;
IF OBJECT_ID('HopDong','U') IS NOT NULL DROP TABLE HopDong;
IF OBJECT_ID('QuyetDinhTuyenDung','U') IS NOT NULL DROP TABLE QuyetDinhTuyenDung;
IF OBJECT_ID('NhanVien','U') IS NOT NULL DROP TABLE NhanVien;
IF OBJECT_ID('CaLamViec','U') IS NOT NULL DROP TABLE CaLamViec;
IF OBJECT_ID('ChucVu','U') IS NOT NULL DROP TABLE ChucVu;
IF OBJECT_ID('PhongBan','U') IS NOT NULL DROP TABLE PhongBan;
GO

-- =============================================================================
-- PHẦN 1: BẢNG DANH MỤC CƠ SỞ
-- =============================================================================

CREATE TABLE PhongBan(
    MaPB varchar(20) NOT NULL PRIMARY KEY,
    TenPB nvarchar(100) NOT NULL UNIQUE,
    MoTa nvarchar(250) NULL
);

CREATE TABLE ChucVu(
    MaCV varchar(20) NOT NULL PRIMARY KEY,
    TenCV nvarchar(100) NOT NULL UNIQUE
);

CREATE TABLE CaLamViec(
    MaCa varchar(10) NOT NULL PRIMARY KEY,
    TenCa nvarchar(50) NOT NULL UNIQUE,
    GioBatDau time(0) NOT NULL,
    GioKetThuc time(0) NOT NULL,
    SoGio decimal(4,2) NOT NULL CHECK(SoGio > 0 AND SoGio <= 24)
);

CREATE TABLE NhanVien(
    MaNV varchar(20) NOT NULL PRIMARY KEY,
    HoTen nvarchar(120) NOT NULL,
    NgaySinh date NOT NULL,
    GioiTinh nvarchar(10) NOT NULL,
    SoCCCD varchar(20) NOT NULL UNIQUE,
    DiaChi nvarchar(250) NULL,
    SoDienThoai varchar(20) NULL,
    MaPB varchar(20) NULL,
    VaiTro nvarchar(30) NOT NULL DEFAULT N'Nhân viên',
    TrangThai nvarchar(30) NOT NULL DEFAULT N'Chờ tuyển dụng',
    CONSTRAINT CK_NV_GioiTinh CHECK(GioiTinh IN (N'Nam', N'Nữ')),
    CONSTRAINT CK_NV_VaiTro CHECK(VaiTro IN (N'Nhân viên', N'Nhân sự', N'Trưởng phòng', N'Ban chấm công', N'Kế toán', N'Giám đốc')),
    CONSTRAINT CK_NV_TrangThai CHECK(TrangThai IN (N'Chờ tuyển dụng', N'Thử việc', N'Chính thức', N'Nghỉ việc')),
    CONSTRAINT FK_NV_PB FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB)
);

-- =============================================================================
-- PHẦN 2: TUYỂN DỤNG, HỢP ĐỒNG, BẢO HIỂM
-- =============================================================================

CREATE TABLE QuyetDinhTuyenDung(
    SoQDTD varchar(30) NOT NULL PRIMARY KEY,
    MaNV varchar(20) NOT NULL,
    MaPB varchar(20) NOT NULL,
    NgayQuyetDinh date NOT NULL,
    NgayBatDauThuViec date NOT NULL,
    NgayKetThucThuViec date NOT NULL,
    LuongThuViec decimal(18,2) NOT NULL CHECK(LuongThuViec > 0),
    NoiDungDieuKhoan nvarchar(max) NOT NULL,
    KetQuaThuViec nvarchar(20) NULL,
    MaNVLap varchar(20) NOT NULL,
    MaNVKy varchar(20) NOT NULL,
    CONSTRAINT CK_QDTD_ThuViec CHECK(NgayKetThucThuViec >= NgayBatDauThuViec),
    CONSTRAINT CK_QDTD_KetQua CHECK(KetQuaThuViec IS NULL OR KetQuaThuViec IN (N'Đạt', N'Không đạt')),
    CONSTRAINT FK_QDTD_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_QDTD_PB FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB),
    CONSTRAINT FK_QDTD_Lap FOREIGN KEY(MaNVLap) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_QDTD_Ky FOREIGN KEY(MaNVKy) REFERENCES NhanVien(MaNV)
);

CREATE TABLE HopDong(
    SoHopDong varchar(30) NOT NULL PRIMARY KEY,
    MaNV varchar(20) NOT NULL,
    SoQDTD varchar(30) NULL,
    LoaiHopDong nvarchar(20) NOT NULL,
    NgayKy date NOT NULL,
    NgayBatDau date NOT NULL,
    NgayKetThuc date NULL,
    NoiDung nvarchar(max) NULL,
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Hiệu lực',
    MaNVKy varchar(20) NOT NULL,
    CONSTRAINT CK_HD_Loai CHECK(LoaiHopDong IN (N'Dài hạn', N'Ngắn hạn')),
    CONSTRAINT CK_HD_TrangThai CHECK(TrangThai IN (N'Hiệu lực', N'Hết hạn', N'Chấm dứt')),
    CONSTRAINT CK_HD_NgayKT CHECK(NgayKetThuc IS NULL OR NgayKetThuc >= NgayBatDau),
    CONSTRAINT CK_HD_NganHan CHECK(LoaiHopDong = N'Dài hạn' OR NgayKetThuc IS NOT NULL),
    CONSTRAINT FK_HD_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_HD_QDTD FOREIGN KEY(SoQDTD) REFERENCES QuyetDinhTuyenDung(SoQDTD),
    CONSTRAINT FK_HD_Ky FOREIGN KEY(MaNVKy) REFERENCES NhanVien(MaNV)
);
CREATE UNIQUE INDEX UX_HopDong_HieuLuc ON HopDong(MaNV) WHERE TrangThai = N'Hiệu lực';

CREATE TABLE HoSoBaoHiem(
    MaHoSoBH varchar(40) NOT NULL PRIMARY KEY,
    MaNV varchar(20) NOT NULL UNIQUE,
    SoHopDong varchar(30) NOT NULL UNIQUE,
    SoSoBHXH varchar(20) NOT NULL UNIQUE,
    SoTheBHYT varchar(20) NOT NULL UNIQUE,
    NgayThamGia date NOT NULL,
    MucDongBHXH decimal(5,2) NOT NULL DEFAULT 8 CHECK(MucDongBHXH BETWEEN 0 AND 100),
    MucDongBHYT decimal(5,2) NOT NULL DEFAULT 1.5 CHECK(MucDongBHYT BETWEEN 0 AND 100),
    CONSTRAINT FK_BH_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_BH_HD FOREIGN KEY(SoHopDong) REFERENCES HopDong(SoHopDong)
);

-- =============================================================================
-- PHẦN 3: QUYẾT ĐỊNH CHỨC VỤ VÀ QUYẾT ĐỊNH LƯƠNG
-- =============================================================================

CREATE TABLE QuyetDinhChucVu(
    SoQDCV varchar(30) NOT NULL PRIMARY KEY,
    MaNV varchar(20) NOT NULL,
    MaCV varchar(20) NOT NULL,
    NgayHieuLuc date NOT NULL,
    PhuCapChucVu decimal(18,2) NOT NULL DEFAULT 0 CHECK(PhuCapChucVu >= 0),
    GhiChu nvarchar(250) NULL,
    MaNVKy varchar(20) NOT NULL,
    CONSTRAINT UQ_QDCV_NV_Ngay UNIQUE(MaNV, NgayHieuLuc),
    CONSTRAINT FK_QDCV_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_QDCV_CV FOREIGN KEY(MaCV) REFERENCES ChucVu(MaCV),
    CONSTRAINT FK_QDCV_Ky FOREIGN KEY(MaNVKy) REFERENCES NhanVien(MaNV)
);

CREATE TABLE QuyetDinhLuong(
    SoQDL varchar(30) NOT NULL PRIMARY KEY,
    MaNV varchar(20) NOT NULL,
    NgayHieuLuc date NOT NULL,
    LuongCoBan decimal(18,2) NOT NULL CHECK(LuongCoBan > 0),
    PhuCapLuong decimal(18,2) NOT NULL DEFAULT 0 CHECK(PhuCapLuong >= 0),
    PhuCapDocHai decimal(18,2) NOT NULL DEFAULT 0 CHECK(PhuCapDocHai >= 0),
    LyDo nvarchar(20) NOT NULL,
    MaNVKy varchar(20) NOT NULL,
    CONSTRAINT CK_QDL_LyDo CHECK(LyDo IN (N'Ký chính thức', N'Tăng lương', N'Điều chỉnh')),
    CONSTRAINT UQ_QDL_NV_Ngay UNIQUE(MaNV, NgayHieuLuc),
    CONSTRAINT FK_QDL_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_QDL_Ky FOREIGN KEY(MaNVKy) REFERENCES NhanVien(MaNV)
);

-- =============================================================================
-- PHẦN 4: PHÂN CÔNG, CHẤM CÔNG, PHỤ TRỘI
-- =============================================================================

CREATE TABLE KeHoachPhanCong(
    SoKH varchar(30) NOT NULL PRIMARY KEY,
    MaPB varchar(20) NOT NULL,
    TuNgay date NOT NULL,
    DenNgay date NOT NULL,
    NgayLap date NOT NULL,
    MaNVLap varchar(20) NOT NULL,
    GhiChu nvarchar(250) NULL,
    CONSTRAINT CK_KH_Ngay CHECK(DenNgay >= TuNgay),
    CONSTRAINT FK_KH_PB FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB),
    CONSTRAINT FK_KH_NV FOREIGN KEY(MaNVLap) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietPhanCong(
    SoKH varchar(30) NOT NULL,
    MaNV varchar(20) NOT NULL,
    Ngay date NOT NULL,
    MaCa varchar(10) NOT NULL,
    CoPhuTroi bit NOT NULL DEFAULT 0,
    PRIMARY KEY(SoKH, MaNV, Ngay, MaCa),
    CONSTRAINT FK_CTPC_KH FOREIGN KEY(SoKH) REFERENCES KeHoachPhanCong(SoKH),
    CONSTRAINT FK_CTPC_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_CTPC_Ca FOREIGN KEY(MaCa) REFERENCES CaLamViec(MaCa)
);

CREATE TABLE BangChamCong(
    SoBCC varchar(30) NOT NULL PRIMARY KEY,
    MaPB varchar(20) NOT NULL,
    Thang int NOT NULL CHECK(Thang BETWEEN 1 AND 12),
    Nam int NOT NULL CHECK(Nam >= 2000),
    NgayLap datetime NOT NULL,
    MaNVLap varchar(20) NOT NULL,
    CONSTRAINT UQ_BCC_PB_Thang UNIQUE(MaPB, Thang, Nam),
    CONSTRAINT FK_BCC_PB FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB),
    CONSTRAINT FK_BCC_NV FOREIGN KEY(MaNVLap) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietChamCong(
    SoBCC varchar(30) NOT NULL,
    MaNV varchar(20) NOT NULL,
    Ngay date NOT NULL,
    MaCa varchar(10) NOT NULL,
    SoGioLam decimal(4,2) NOT NULL CHECK(SoGioLam >= 0 AND SoGioLam <= 24),
    PRIMARY KEY(SoBCC, MaNV, Ngay, MaCa),
    CONSTRAINT FK_CTCC_BCC FOREIGN KEY(SoBCC) REFERENCES BangChamCong(SoBCC),
    CONSTRAINT FK_CTCC_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_CTCC_Ca FOREIGN KEY(MaCa) REFERENCES CaLamViec(MaCa)
);

CREATE TABLE PhieuPhuTroi(
    SoPhieuPT varchar(30) NOT NULL PRIMARY KEY,
    NgayPhuTroi date NOT NULL,
    HinhThuc nvarchar(20) NOT NULL,
    MaPB varchar(20) NOT NULL,
    MaNVLap varchar(20) NOT NULL,
    HeSo decimal(3,2) NOT NULL DEFAULT 1.5 CHECK(HeSo >= 1),
    GhiChu nvarchar(250) NULL,
    CONSTRAINT CK_PT_HinhThuc CHECK(HinhThuc IN (N'Tăng ca', N'Ngày lễ', N'Ngày nghỉ')),
    CONSTRAINT FK_PT_PB FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB),
    CONSTRAINT FK_PT_NV FOREIGN KEY(MaNVLap) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietPhieuPhuTroi(
    SoPhieuPT varchar(30) NOT NULL,
    MaNV varchar(20) NOT NULL,
    SoGioPhuTroi decimal(4,2) NOT NULL CHECK(SoGioPhuTroi > 0 AND SoGioPhuTroi <= 12),
    PRIMARY KEY(SoPhieuPT, MaNV),
    CONSTRAINT FK_CTPT_Phieu FOREIGN KEY(SoPhieuPT) REFERENCES PhieuPhuTroi(SoPhieuPT),
    CONSTRAINT FK_CTPT_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

-- =============================================================================
-- PHẦN 5: BẢNG LƯƠNG HẰNG THÁNG
-- =============================================================================

CREATE TABLE BangLuong(
    SoBangLuong varchar(30) NOT NULL PRIMARY KEY,
    Thang int NOT NULL CHECK(Thang BETWEEN 1 AND 12),
    Nam int NOT NULL CHECK(Nam >= 2000),
    NgayLap datetime NOT NULL,
    MaNVLap varchar(20) NOT NULL,
    TrangThai nvarchar(20) NOT NULL DEFAULT N'Nháp',
    CONSTRAINT CK_BL_TrangThai CHECK(TrangThai IN (N'Nháp', N'Đã chốt')),
    CONSTRAINT UQ_BL_Thang UNIQUE(Thang, Nam),
    CONSTRAINT FK_BL_NV FOREIGN KEY(MaNVLap) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietBangLuong(
    SoBangLuong varchar(30) NOT NULL,
    MaNV varchar(20) NOT NULL,
    LuongCoBan decimal(18,2) NOT NULL,
    PhuCapLuong decimal(18,2) NOT NULL,
    PhuCapDocHai decimal(18,2) NOT NULL,
    PhuCapChucVu decimal(18,2) NOT NULL,
    TongGioLam decimal(8,2) NOT NULL,
    TongGioPhuTroi decimal(8,2) NOT NULL,
    TienLuongLam decimal(18,2) NOT NULL,
    TienPhuTroi decimal(18,2) NOT NULL,
    KhauTruBHXH decimal(18,2) NOT NULL,
    KhauTruBHYT decimal(18,2) NOT NULL,
    TruPhat decimal(18,2) NOT NULL,
    ThucLanh AS (CONVERT(decimal(18,2), TienLuongLam + PhuCapLuong + PhuCapDocHai + PhuCapChucVu + TienPhuTroi - KhauTruBHXH - KhauTruBHYT - TruPhat)) PERSISTED,
    PRIMARY KEY(SoBangLuong, MaNV),
    CONSTRAINT FK_CTBL_BL FOREIGN KEY(SoBangLuong) REFERENCES BangLuong(SoBangLuong),
    CONSTRAINT FK_CTBL_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV)
);

-- =============================================================================
-- PHẦN 6: KHEN THƯỞNG VÀ KỶ LUẬT
-- =============================================================================

CREATE TABLE QuyetDinhKhenThuong(
    SoQDKT varchar(30) NOT NULL PRIMARY KEY,
    NgayQuyetDinh date NOT NULL,
    LoaiKhenThuong nvarchar(30) NOT NULL,
    LyDo nvarchar(250) NOT NULL,
    MaNVKy varchar(20) NOT NULL,
    CONSTRAINT CK_QDKT_Loai CHECK(LoaiKhenThuong IN (N'Thành tích', N'Ngày lễ', N'Thưởng cuối năm', N'Lương tháng 13')),
    CONSTRAINT FK_QDKT_Ky FOREIGN KEY(MaNVKy) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietKhenThuong(
    MaCTKT int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    SoQDKT varchar(30) NOT NULL,
    MaNV varchar(20) NULL,
    MaPB varchar(20) NULL,
    SoTien decimal(18,2) NOT NULL CHECK(SoTien > 0),
    CONSTRAINT CK_CTKT_DoiTuong CHECK((MaNV IS NOT NULL AND MaPB IS NULL) OR (MaNV IS NULL AND MaPB IS NOT NULL)),
    CONSTRAINT FK_CTKT_QD FOREIGN KEY(SoQDKT) REFERENCES QuyetDinhKhenThuong(SoQDKT),
    CONSTRAINT FK_CTKT_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_CTKT_PB FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB)
);
CREATE UNIQUE INDEX UX_CTKT_NV ON ChiTietKhenThuong(SoQDKT, MaNV) WHERE MaNV IS NOT NULL;
CREATE UNIQUE INDEX UX_CTKT_PB ON ChiTietKhenThuong(SoQDKT, MaPB) WHERE MaPB IS NOT NULL;

CREATE TABLE PhieuChiKhenThuong(
    SoPhieuChi varchar(30) NOT NULL PRIMARY KEY,
    SoQDKT varchar(30) NOT NULL UNIQUE,
    NgayChi datetime NOT NULL,
    TongTien decimal(18,2) NOT NULL CHECK(TongTien > 0),
    MaNVLap varchar(20) NOT NULL,
    CONSTRAINT FK_PCKT_QD FOREIGN KEY(SoQDKT) REFERENCES QuyetDinhKhenThuong(SoQDKT),
    CONSTRAINT FK_PCKT_NV FOREIGN KEY(MaNVLap) REFERENCES NhanVien(MaNV)
);

CREATE TABLE QuyetDinhKyLuat(
    SoQDKL varchar(30) NOT NULL PRIMARY KEY,
    NgayQuyetDinh date NOT NULL,
    HinhThucKyLuat nvarchar(30) NOT NULL,
    LyDo nvarchar(250) NOT NULL,
    MaNVKy varchar(20) NOT NULL,
    CONSTRAINT CK_QDKL_HinhThuc CHECK(HinhThucKyLuat IN (N'Khiển trách', N'Cảnh cáo', N'Phạt tiền')),
    CONSTRAINT FK_QDKL_Ky FOREIGN KEY(MaNVKy) REFERENCES NhanVien(MaNV)
);

CREATE TABLE ChiTietKyLuat(
    MaCTKL int IDENTITY(1,1) NOT NULL PRIMARY KEY,
    SoQDKL varchar(30) NOT NULL,
    MaNV varchar(20) NULL,
    MaPB varchar(20) NULL,
    SoTienPhat decimal(18,2) NOT NULL DEFAULT 0 CHECK(SoTienPhat >= 0),
    CONSTRAINT CK_CTKL_DoiTuong CHECK((MaNV IS NOT NULL AND MaPB IS NULL) OR (MaNV IS NULL AND MaPB IS NOT NULL)),
    CONSTRAINT FK_CTKL_QD FOREIGN KEY(SoQDKL) REFERENCES QuyetDinhKyLuat(SoQDKL),
    CONSTRAINT FK_CTKL_NV FOREIGN KEY(MaNV) REFERENCES NhanVien(MaNV),
    CONSTRAINT FK_CTKL_PB FOREIGN KEY(MaPB) REFERENCES PhongBan(MaPB)
);
CREATE UNIQUE INDEX UX_CTKL_NV ON ChiTietKyLuat(SoQDKL, MaNV) WHERE MaNV IS NOT NULL;
CREATE UNIQUE INDEX UX_CTKL_PB ON ChiTietKyLuat(SoQDKL, MaPB) WHERE MaPB IS NOT NULL;

CREATE TABLE PhieuThuNopPhat(
    SoPhieuThu varchar(30) NOT NULL PRIMARY KEY,
    MaCTKL int NOT NULL UNIQUE,
    NgayThu datetime NOT NULL,
    SoTien decimal(18,2) NOT NULL CHECK(SoTien > 0),
    HinhThucThu nvarchar(20) NOT NULL,
    MaNVLap varchar(20) NOT NULL,
    CONSTRAINT CK_PTNP_HinhThuc CHECK(HinhThucThu IN (N'Nộp tiền mặt', N'Trừ lương')),
    CONSTRAINT FK_PTNP_CT FOREIGN KEY(MaCTKL) REFERENCES ChiTietKyLuat(MaCTKL),
    CONSTRAINT FK_PTNP_NV FOREIGN KEY(MaNVLap) REFERENCES NhanVien(MaNV)
);
GO

-- =============================================================================
-- PHẦN 7: DỮ LIỆU KIỂM THỬ MẪU (TEST DATA)
-- =============================================================================

INSERT INTO PhongBan(MaPB, TenPB, MoTa) VALUES
('BGD', N'Ban giám đốc', N'Ban lãnh đạo điều hành'),
('NS', N'Phòng nhân sự', N'Tổ chức tuyển dụng & hợp đồng'),
('TCKT', N'Phòng tài chính kế toán', N'Quản lý tiền lương & thu chi'),
('KT', N'Phòng kỹ thuật', N'Nghiên cứu công thức sơn'),
('SX', N'Phòng sản xuất', N'Phân xưởng sản xuất sơn Đông Á');

INSERT INTO ChucVu(MaCV, TenCV) VALUES 
('GD', N'Giám đốc'),
('TP', N'Trưởng phòng'),
('PP', N'Phó phòng'),
('NV', N'Nhân viên');

INSERT INTO CaLamViec(MaCa, TenCa, GioBatDau, GioKetThuc, SoGio) VALUES
('CA1', N'Ca sáng', '06:00', '14:00', 8),
('CA2', N'Ca chiều', '14:00', '22:00', 8),
('HC', N'Hành chính', '08:00', '17:00', 8);

INSERT INTO NhanVien(MaNV, HoTen, NgaySinh, GioiTinh, SoCCCD, DiaChi, SoDienThoai, MaPB, VaiTro, TrangThai) VALUES
('NV01', N'Nguyễn Văn Đông', '1975-03-12', N'Nam', '079075000001', N'TP.HCM', '0901000001', 'BGD', N'Giám đốc', N'Chính thức'),
('NV02', N'Trần Thị Hạnh', '1988-07-21', N'Nữ', '079088000002', N'TP.HCM', '0901000002', 'NS', N'Nhân sự', N'Chính thức'),
('NV03', N'Lê Minh Tâm', '1986-11-05', N'Nam', '079086000003', N'TP.HCM', '0901000003', 'TCKT', N'Kế toán', N'Chính thức'),
('NV04', N'Phạm Thu Hà', '1991-01-30', N'Nữ', '079091000004', N'TP.HCM', '0901000004', 'NS', N'Ban chấm công', N'Chính thức'),
('NV05', N'Võ Quốc Bảo', '1983-09-14', N'Nam', '079083000005', N'Bình Dương', '0901000005', 'SX', N'Trưởng phòng', N'Chính thức'),
('NV06', N'Đặng Hoàng Long', '1985-05-09', N'Nam', '079085000006', N'TP.HCM', '0901000006', 'KT', N'Trưởng phòng', N'Chính thức'),
('NV07', N'Bùi Anh Khoa', '1996-12-02', N'Nam', '079096000007', N'Đồng Nai', '0901000007', 'SX', N'Nhân viên', N'Chính thức'),
('NV08', N'Ngô Thanh Mai', '1997-04-18', N'Nữ', '079097000008', N'TP.HCM', '0901000008', 'KT', N'Nhân viên', N'Chính thức'),
('NV09', N'Hồ Gia Huy', '2000-08-25', N'Nam', '079000000009', N'Long An', '0901000009', NULL, N'Nhân viên', N'Chờ tuyển dụng');

INSERT INTO QuyetDinhLuong(SoQDL, MaNV, NgayHieuLuc, LuongCoBan, PhuCapLuong, PhuCapDocHai, LyDo, MaNVKy) VALUES
('QDL01', 'NV01', '2025-01-01', 40000000, 0, 0, N'Ký chính thức', 'NV01'),
('QDL02', 'NV02', '2025-01-01', 15000000, 500000, 0, N'Ký chính thức', 'NV01'),
('QDL03', 'NV03', '2025-01-01', 18000000, 500000, 0, N'Ký chính thức', 'NV01'),
('QDL04', 'NV04', '2025-01-01', 12000000, 300000, 0, N'Ký chính thức', 'NV01'),
('QDL05', 'NV05', '2025-01-01', 20000000, 500000, 800000, N'Ký chính thức', 'NV01'),
('QDL06', 'NV06', '2025-01-01', 20000000, 500000, 0, N'Ký chính thức', 'NV01'),
('QDL07', 'NV07', '2025-01-01', 9000000, 300000, 800000, N'Ký chính thức', 'NV01'),
('QDL08', 'NV08', '2025-01-01', 10000000, 300000, 0, N'Ký chính thức', 'NV01');

INSERT INTO QuyetDinhChucVu(SoQDCV, MaNV, MaCV, NgayHieuLuc, PhuCapChucVu, GhiChu, MaNVKy) VALUES
('QDCV01', 'NV01', 'GD', '2025-01-01', 5000000, NULL, 'NV01'),
('QDCV02', 'NV05', 'TP', '2025-01-01', 1500000, NULL, 'NV01'),
('QDCV03', 'NV06', 'TP', '2025-01-01', 1500000, NULL, 'NV01');

INSERT INTO HopDong(SoHopDong, MaNV, SoQDTD, LoaiHopDong, NgayKy, NgayBatDau, NgayKetThuc, NoiDung, TrangThai, MaNVKy) VALUES
('HD001', 'NV05', NULL, N'Dài hạn', '2025-01-01', '2025-01-01', NULL, N'Hợp đồng không xác định thời hạn', N'Hiệu lực', 'NV01'),
('HD002', 'NV07', NULL, N'Ngắn hạn', '2025-01-01', '2025-01-01', '2026-12-31', N'Hợp đồng 24 tháng', N'Hiệu lực', 'NV01');

INSERT INTO HoSoBaoHiem(MaHoSoBH, MaNV, SoHopDong, SoSoBHXH, SoTheBHYT, NgayThamGia, MucDongBHXH, MucDongBHYT) VALUES
('BH_HD001', 'NV05', 'HD001', '0123456789', 'DN4797912345678', '2025-01-01', 8, 1.5);
GO

PRINT N'Cơ sở dữ liệu QuanLyNhanSu đã được tạo và nạp dữ liệu mẫu thành công!';
