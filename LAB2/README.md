DỰ ÁN QUẢN LÝ THƯ VIỆN (LAB 2)
1. GIỚI THIỆU TỔNG QUAN
Dự án Quản lý Thư viện là ứng dụng Desktop được phát triển trên nền tảng C# Windows Forms và .NET Framework. Phần mềm giải quyết toàn bộ quy trình nghiệp vụ thư viện từ quản trị dữ liệu nền tảng, quản lý kho sách, cấp thẻ độc giả cho đến lập phiếu mượn trả và thống kê báo cáo vi phạm.

2. KIẾN TRÚC HỆ THỐNG
Dự án được tổ chức theo mô hình phân tầng chuẩn nhằm tách biệt giữa giao diện và logic xử lý dữ liệu:

QuanLyThuVien.Forms: Chứa toàn bộ giao diện người dùng (FrmMain, FrmDanhMuc, FrmSach, FrmDocGia, FrmMuonTra, FrmThongKe).

QuanLyThuVien.Models: Chứa các lớp đối tượng thực thể đại diện cho bảng dữ liệu.

QuanLyThuVien.Services: Chứa các lớp xử lý logic nghiệp vụ và truy xuất cơ sở dữ liệu.

3. CÁC MÀN HÌNH CHỨC NĂNG CHÍNH
FrmMain: Màn hình chính đóng vai trò điều khiển trung tâm, cung cấp điều hướng đến tất cả phân hệ.

FrmDanhMuc: Quản lý các danh mục nền tảng gồm Nhân viên, Thể loại và Nhà xuất bản trên giao diện TabControl, bắt lỗi khóa ngoại khi xóa.

FrmSach: Quản lý thông tin đầu sách, kiểm tra số lượng tồn kho hợp lệ, hỗ trợ tìm kiếm nhanh theo tên sách và tác giả.

FrmDocGia: Quản lý hồ sơ độc giả, lưu trữ ảnh chân dung, hỗ trợ tự động tính hạn thẻ và xử lý gia hạn thẻ.

FrmMuonTra: Phân hệ nghiệp vụ cốt lõi dùng để lập phiếu mượn (khóa tối đa 3 cuốn), kiểm tra hạn thẻ, xử lý trả sách, ghi nhận tình trạng hư hỏng/mất và tính phí phạt.

FrmThongKe: Báo cáo tổng hợp số liệu mượn/trả, lọc theo khoảng thời gian tùy chọn và hiển thị chi tiết danh sách phiếu phạt.

4. HƯỚNG DẪN CÀI ĐẶT VÀ CHẠY ỨNG DỤNG
Bước 1: Mở tệp giải pháp (.sln) bằng Visual Studio 2019 hoặc phiên bản cao hơn.
Bước 2: Cấu hình lại chuỗi kết nối cơ sở dữ liệu SQL Server trong tệp cấu hình ứng dụng.
Bước 3: Chạy kịch bản SQL đi kèm để khởi tạo cơ sở dữ liệu và dữ liệu mẫu.
Bước 4: Nhấn F5 (hoặc chọn Start) để biên dịch và chạy ứng dụng.
