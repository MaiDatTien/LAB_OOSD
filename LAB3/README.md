# README - Bài 3: Hệ thống Quản lý khách sạn

## Thông tin
- Họ tên: Mai Tiến Đạt
- MSSV: 1250080030
- Bài: Bài 3 - Hệ thống Quản lý khách sạn

## Môi trường
- Visual Studio 2022, C#, .NET Framework
- Windows Forms App, ADO.NET (SqlClient)
- SQL Server LocalDB (MSSQLLocalDB)

## Đã làm
- Phân tích use case (tổng quát + phân rã 4 module), đặc tả 6 use case chính
- Vẽ biểu đồ lớp phân tích/chi tiết, biểu đồ trạng thái, 6 biểu đồ tuần tự, biểu đồ hoạt động
- Thiết kế CSDL SQL Server: 17 bảng, đầy đủ PK/FK/CHECK/UNIQUE
- Code 7 Form (FrmMain, FrmDanhMuc, FrmPhongTienNghi, FrmDatPhong, FrmDichVu, FrmTraPhong, FrmThongKe) theo kiến trúc UI - Service - Data, không viết SQL trong Form
- Dùng transaction cho các nghiệp vụ nhiều bảng: đặt phòng, ghi dịch vụ, đền bù, thanh toán, trả phòng
- Viết test case và test thử trên ứng dụng

## Kết quả
- App chạy được, kết nối CSDL LocalDB bình thường
- 15/15 test case tổng thể (TC01-TC15) chạy đúng
- Các quy tắc chính đều đúng: không đặt trùng lịch/vượt sức chứa, 1 thiết bị/1 phòng/1 ngày, dịch vụ cùng ngày cộng dồn, hóa đơn chỉ "Đã thanh toán" khi trả đủ tiền, chỉ trả phòng được khi hóa đơn đã thanh toán đủ

## Lỗi gặp phải & cách xử lý

/ Lỗi / Nguyên nhân / Xử lý /
Không kết nối được DB lúc chạy lần đầu | Chuỗi kết nối trong App.config trỏ sai instance / chưa chạy script SQL | Kiểm tra `sqllocaldb info`, chạy lại `Database/QuanLyKhachSan.sql` |
Lập phiếu lắp đặt 2 lần cùng thiết bị/cùng ngày bị lỗi SqlException | Vi phạm UNIQUE(MaTienNghi, NgayLap) | Bắt lỗi SQL 2627/2601 trong Service, trả thông báo dễ hiểu thay vì show lỗi gốc |
Đặt phòng trùng lịch mà vẫn lưu được (lần test đầu) | Chỉ check TrangThai, chưa check khoảng ngày chồng lấn | Thêm hàm kiểm tra trùng lịch theo NgayNhan/NgayTraDuKien trước khi insert |
Dùng cùng dịch vụ nhiều lần trong ngày bị tạo thành nhiều phiếu thay vì gộp | Tìm phiếu theo kiểu không khớp chính xác ngày | Thêm UNIQUE(SoPhieuDat, SoPhong, NgaySuDung), sửa lại cách tìm/tạo phiếu dịch vụ |
Thanh toán từng phần nhưng hóa đơn đổi trạng thái "Đã thanh toán" ngay | Chưa cộng dồn các lần thanh toán trước đó | Tính tổng đã trả từ bảng ThanhToan rồi mới so sánh với TongTien |
Form lỗi khi bấm nút lúc DataGridView chưa có dòng nào | Không check null CurrentRow | Thêm check `if (CurrentRow == null) return;` |
Update dở dang khi có lỗi giữa chừng | Thiếu try/catch quanh transaction | Bọc các thao tác nhiều bảng trong try/catch + rollback |

## Hướng dẫn chạy lại

1. **Tạo DB**: mở SQL Server Object Explorer (hoặc SSMS), chạy file `Database/QuanLyKhachSan.sql`.
2. **Kiểm tra kết nối**: mở `App.config`, xem connection string `QuanLyKhachSanDB` có đúng instance đang dùng không (mặc định `(localdb)\MSSQLLocalDB`).
3. **Build & chạy**: mở `QuanLyKhachSan.sln` bằng Visual Studio 2022 → Rebuild Solution → F5.
4. **Test nhanh theo luồng**:
   - Danh mục: thêm khu vực, NV, loại tiện nghi, dịch vụ, quy định đền bù
   - Phòng - Tiện nghi: thêm phòng, tiện nghi, lập phiếu lắp đặt
   - Đặt/Nhận phòng: thêm khách, đặt phòng, ghi người lưu trú, nhận phòng
   - Sử dụng dịch vụ: ghi 1-2 lần cùng dịch vụ/cùng ngày để thấy cộng dồn
   - Trả phòng - Thanh toán: đền bù (nếu có), lập hóa đơn, thanh toán, hoàn tất trả phòng
   - Thống kê: chọn khoảng ngày, xem số liệu

Test case chi tiết (TC01-TC15) nằm trong báo cáo Word, mục 9.

## Cấu trúc nộp bài
QuanLyKhachSan/
├── QuanLyKhachSan.sln
├── App.config
├── Data/Db.cs
├── Services/ (6 file .cs)
├── Forms/ (7 Form .cs + .Designer.cs)
├── Database/QuanLyKhachSan.sql
├── MaiTienDat_LAB3/ (báo cáo Word, workbook Excel, UML, hình giao diện)
└── README.md
