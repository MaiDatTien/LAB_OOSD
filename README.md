# LAB_OOSD

Kho lưu trữ các bài thực hành môn Phân tích Thiết kế Hướng đối tượng (Object-Oriented Software Development).

## Thông tin

| Mục | Nội dung |
|---|---|
| Sinh viên | Mai Tiến Đạt |
| MSSV | 1250080030 |
| Lớp | K12_ĐH_CNPM1 |
| Khoa | Công nghệ thông tin |
| Trường | Đại học Tài nguyên và Môi trường TP. Hồ Chí Minh |
| Giảng viên hướng dẫn | Th.S Phạm Trọng Huynh |

## Giới thiệu

Kho này tổng hợp 8 bài thực hành, bao gồm toàn bộ quy trình phân tích và thiết kế hệ thống phần mềm theo hướng đối tượng: khảo sát nghiệp vụ, xác định yêu cầu, mô hình hóa bằng UML, thiết kế cơ sở dữ liệu, thiết kế giao diện và cài đặt chương trình.

## Danh sách bài thực hành

| Thư mục | Đề tài | Nội dung chính |
|---|---|---|
| LAB1 | Hệ thống thư viện trực tuyến | Đặc tả yêu cầu, Use Case, Activity Diagram |
| LAB2 | Hệ thống quản lý thư viện | Phân tích yêu cầu, UML, CSDL SQL Server, giao diện và cài đặt C# WinForms |
| LAB3 | Hệ thống quản lý khách sạn | Phân tích thiết kế chi tiết, CSDL, giao diện và cài đặt C# WinForms |
| LAB4 | Hệ thống cửa hàng trực tuyến e-Shopping | Phân tích nghiệp vụ, UML, cài đặt và kiểm thử prototype C# WinForms |
| LAB5 | Quản lý hồ sơ bệnh án của bệnh nhân | Class, Use Case, Activity Diagram, Sequence Diagram |
| LAB6 | Quản lý công ty du lịch Văn Hóa Việt | Phân tích thiết kế, UML, CSDL, giao diện và cài đặt C# WinForms |
| LAB7 | Quản lý nhân sự công ty Sơn Đông Á | Class, Use Case, Activity Diagram, Sequence Diagram, CSDL |
| LAB8 | Quản lý cho thuê văn phòng ở cao ốc | Class, Use Case, Activity Diagram, Sequence Diagram |

## Cấu trúc thư mục

```
LAB_OOSD/
├── IMAGES/        Hình ảnh sơ đồ UML và ảnh chụp giao diện dùng trong báo cáo
├── LAB1/
├── LAB2/
├── LAB3/
├── LAB4/
├── LAB5/
├── LAB6/
├── LAB7/
├── LAB8/
└── .gitignore
```

Mỗi thư mục LAB chứa mã nguồn, tài liệu và tệp README riêng mô tả chi tiết bài tương ứng.

## Công nghệ và công cụ

- Ngôn ngữ: C#, SQL
- Giao diện: Windows Forms
- Cơ sở dữ liệu: Microsoft SQL Server
- Mô hình hóa: UML (Use Case, Class, Activity, Sequence, State Machine), ERD
- Công cụ vẽ sơ đồ: draw.io
- Môi trường phát triển: Visual Studio

## Hướng dẫn chạy các bài có cài đặt

1. Cài đặt Visual Studio có workload phát triển ứng dụng Windows Forms (.NET) và Microsoft SQL Server.
2. Sao chép kho lưu trữ:

```
git clone https://github.com/MaiDatTien/LAB_OOSD.git
```

3. Mở thư mục của bài cần chạy, chạy tệp script SQL (nếu có) để tạo cơ sở dữ liệu và dữ liệu mẫu.
4. Cập nhật chuỗi kết nối trong tệp cấu hình của dự án cho phù hợp với máy cục bộ.
5. Mở tệp solution (.sln) bằng Visual Studio, build và chạy chương trình.

## Tài liệu

Báo cáo tổng hợp toàn bộ 8 bài, gồm mô tả đề bài, bảng đặc tả, sơ đồ UML, thiết kế cơ sở dữ liệu và hình ảnh giao diện, được lưu dưới dạng tệp Word đi kèm kho lưu trữ. Các hình ảnh minh họa nằm trong thư mục IMAGES.

## Ghi chú

Kho lưu trữ phục vụ mục đích học tập. Nội dung do sinh viên thực hiện theo yêu cầu của học phần.
