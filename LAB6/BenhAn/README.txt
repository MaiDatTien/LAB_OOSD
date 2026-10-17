QUẢN LÝ HỒ SƠ BỆNH ÁN - HUTECH OOAD Bài 5
1. Mở SSMS (hoặc SQL Server Object Explorer), chạy QuanLyBenhAn\Database\QuanLyBenhAn.sql.
2. Mở QuanLyBenhAn.sln bằng Visual Studio 2022 (workload .NET desktop development, .NET Framework 4.7.2).
3. Nếu không dùng LocalDB, sửa Data Source trong QuanLyBenhAn\App.config.
4. Nhấn F5. Màn hình chính FrmMain mở 7 Form: Danh mục, Tiếp nhận, Lịch hẹn, Khám bệnh, Kết quả xét nghiệm, Thanh toán, Thống kê.
Thứ tự thử nhanh: Tiếp nhận (đăng ký lần đầu) -> Khám bệnh (tạo phiếu, triệu chứng, xét nghiệm) -> Kết quả xét nghiệm -> Khám bệnh (lập toa, kết luận) -> Thanh toán (lập hóa đơn, thanh toán, hoàn tất).
