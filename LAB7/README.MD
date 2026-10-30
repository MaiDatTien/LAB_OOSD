LAB 7 - Quản Lý Nhân Sự (OOSD)

Dự án thực hành bài Lab 7 học phần Thiết kế Phần mềm Hướng đối tượng (Object-Oriented Software Design). Dự án tập trung vào việc phân tích, thiết kế kiến trúc và triển khai hệ thống phần mềm Quản lý Nhân sự.

1. Cấu trúc thư mục

QuanLyNhanSu/: Thư mục chứa toàn bộ mã nguồn của ứng dụng (Source code).

QuanLyNhanSu.sql: Script khởi tạo cơ sở dữ liệu, cấu trúc bảng và dữ liệu mẫu.

lab7.docx: Tài liệu báo cáo chi tiết (bao gồm đặc tả yêu cầu, các biểu đồ thiết kế UML và kết quả thực nghiệm).

README.MD: Tài liệu hướng dẫn cài đặt và tổng quan dự án.

2. Chức năng chính

Quản lý hồ sơ nhân viên: Xem danh sách, thêm mới, cập nhật thông tin và xóa hồ sơ nhân sự.

Quản lý phòng ban & chức vụ: Phân bổ và theo dõi nhân sự theo từng bộ phận, vị trí công tác.

Tra cứu & Thống kê: Tìm kiếm nhân viên theo mã, họ tên hoặc phòng ban làm việc.

3. Yêu cầu hệ thống

Ngôn ngữ & Nền tảng: C# (.NET) / Java (tùy thuộc cấu hình đồ án của bạn).

Hệ quản trị cơ sở dữ liệu: Microsoft SQL Server / MySQL.

Công cụ phát triển (IDE): Visual Studio / IntelliJ IDEA / NetBeans / Eclipse.

4. Hướng dẫn cài đặt và triển khai

Bước 1: Khởi tạo Cơ sở dữ liệu

Mở phần mềm quản trị CSDL (SQL Server Management Studio hoặc MySQL Workbench).

Mở file QuanLyNhanSu.sql và thực thi (Execute) toàn bộ script để tạo Database và dữ liệu mẫu.

Bước 2: Cấu hình kết nối

Mở IDE và chọn mở dự án từ thư mục QuanLyNhanSu.

Tìm đến file cấu hình kết nối CSDL (ví dụ: App.config, appsettings.json hoặc lớp DBConnection).

Cập nhật lại chuỗi kết nối (Connection String) bao gồm Server Name, User ID và Password sao cho khớp với cấu hình máy cá nhân của bạn.

Bước 3: Biên dịch và chạy chương trình

Thực hiện Clean và Build (hoặc Rebuild) lại toàn bộ Solution/Project để nạp các thư viện cần thiết.

Nhấn Start (hoặc Run) để khởi chạy ứng dụng.

5. Tài liệu thiết kế (Báo cáo)

Toàn bộ phần lý thuyết và thiết kế kiến trúc hướng đối tượng được trình bày chi tiết trong file lab7.docx, bao gồm:

Sơ đồ ca sử dụng (Use Case Diagram) và đặc tả chi tiết.

Sơ đồ lớp (Class Diagram) mức phân tích và thiết kế.

Sơ đồ tuần tự (Sequence Diagram) cho các chức năng cốt lõi.

Thiết kế cơ sở dữ liệu quan hệ và giao diện người dùng (UI).

6. Thông tin tác giả

Sinh viên thực hiện: Mai Đạt Tiến

Tài khoản GitHub: MaiDatTien

Học phần: Thiết kế Phần mềm Hướng đối tượng (LAB_OOSD)
