# QuanLyNhanSu – Bài 7 Quản lý nhân sự (công ty sơn Đông Á)

WinForms C# (.NET Framework 4.7.2) + ADO.NET + SQL Server. Giao diện dựng bằng code (không cần Designer).

## Chạy
1. Mở SSMS, chạy `Database/QuanLyNhanSu.sql` (tạo DB, bảng, dữ liệu mẫu).
2. Không dùng LocalDB: sửa `Data Source` trong `App.config` (ví dụ `.\SQLEXPRESS`).
3. Mở `QuanLyNhanSu.sln` bằng Visual Studio 2022, nhấn F5.

## Kiến trúc
Forms (UI) → Services (nghiệp vụ, transaction) → Data/Db → SQL Server. Form không viết SQL.

| Form | Actor | Chức năng |
|---|---|---|
| FrmDanhMuc | Nhân sự | Phòng ban, chức vụ, ca, hồ sơ nhân viên |
| FrmTuyenDung | Nhân sự, Giám đốc | QĐ tuyển dụng, đánh giá thử việc, ký hợp đồng (+QĐ lương, QĐ chức vụ, BHXH/BHYT) |
| FrmQuyetDinh | Nhân sự, Giám đốc | QĐ chức vụ, QĐ lương (tăng lương) |
| FrmChamCong | Trưởng phòng, Ban chấm công | Kế hoạch phân công, bảng chấm công, phiếu phụ trội |
| FrmBangLuong | Kế toán | Tính/chốt bảng lương |
| FrmKhenThuongKyLuat | Nhân sự, Giám đốc, Kế toán | QĐ khen thưởng + phiếu chi; QĐ kỷ luật + phiếu thu/trừ lương |

Dữ liệu mẫu: NV01 Giám đốc, NV02 Nhân sự, NV03 Kế toán, NV04 Ban chấm công, NV05 Trưởng phòng SX, NV06 Trưởng phòng KT, NV07-08 nhân viên, NV09 chờ tuyển dụng.

## Giả định (đề không quy định)
Công chuẩn 208 giờ/tháng; BHXH 8%, BHYT 1.5% lương cơ bản (sửa được theo hồ sơ); phụ trội = 1.5 × giờ thường (cột HeSo); phụ cấp tính đủ tháng.

## Kịch bản test nhanh
| TC | Thao tác | Kết quả |
|---|---|---|
| T01 | Tuyển dụng: NV09, phòng SX, thử việc 01/07/2026–31/08/2026, lương 6.000.000, người lập NV02, ký NV01 | Thành công, NV09 → Thử việc |
| T02 | Ký QĐ bằng người không phải Giám đốc | Từ chối |
| T03 | Ký hợp đồng khi chưa đánh giá Đạt | Từ chối |
| T04 | Đánh giá NV09 = Đạt (đã hết hạn thử việc) rồi ký HĐ Dài hạn, bỏ trống số BHXH | Từ chối; nhập đủ BH → thành công, NV09 → Chính thức |
| T05 | Hợp đồng Ngắn hạn không có ngày kết thúc | Từ chối |
| T06 | Tăng lương với lương mới ≤ lương hiện hành | Từ chối |
| T07 | Kế hoạch phân công do người không phải Trưởng phòng của phòng đó lập | Từ chối |
| T08 | Bảng chấm công/phiếu phụ trội do người không thuộc Ban chấm công lập | Từ chối |
| T09 | Phiếu phụ trội 2 giờ cho NV07, rồi tính lương tháng | Tiền phụ trội = lương/208 × 2 × 1.5 |
| T10 | Tính lương NV05 (có BH) | Khấu trừ BHXH 8%, BHYT 1.5% |
| T11 | Tính lại bảng lương nháp / sau khi chốt | Nháp: tính lại được; đã chốt: từ chối |
| T12 | Khen thưởng cá nhân + tập thể trong một QĐ | Tạo QĐ, chi tiết, phiếu chi = tổng tiền |
| T13 | Dòng khen thưởng có số tiền 0 hoặc người ký không phải Giám đốc | Từ chối, rollback |
| T14 | Kỷ luật Phạt tiền, NV07, 'Trừ lương' | Tháng thu tiền, bảng lương trừ TruPhat |
| T15 | Kỷ luật tập thể chọn 'Trừ lương' | Từ chối (tập thể phải nộp tiền mặt) |
