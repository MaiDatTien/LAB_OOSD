Quản lý công ty du lịch

Tài liệu bài tập phân tích, thiết kế hướng đối tượng cho hệ thống quản lý công ty du lịch Văn Hóa Việt.

| Thông tin | Chi tiết |
|---|---|
| Sinh viên | Mai Tiến Đạt |
| MSSV | 1250080030 |
| Học phần | Thực hành Phân tích Thiết kế Hướng Đối tượng |
| Trường | Đại học Tài Nguyên và Môi Trường TP HCM(HCMUNRE) |
| Công nghệ định hướng | C# WinForms, .NET Framework 4.7.2, SQL Server |

## Trạng thái gói bài

Gói hiện tại gồm báo cáo Word và README. Chưa có mã nguồn C# (`.sln`, `.csproj`), file cấu hình kết nối hay script tạo CSDL (`.sql`), vì vậy hiện chưa thể biên dịch hoặc chạy ứng dụng. Phần cài đặt bên dưới chuẩn bị môi trường cho hướng hiện thực được mô tả trong báo cáo.

## Chức năng được mô hình hóa

- Quản lý danh mục, tour, hành trình, phương tiện theo chặng và điểm tham quan.
- Mở chuyến, đăng ký khách lẻ và thu tiền vé.
- Lập hoặc hủy đăng ký đoàn, nhận đặt cọc và quản lý danh sách thành viên khi mua bảo hiểm.
- Phân công hướng dẫn viên và kiểm tra trùng lịch.
- Thanh toán đoàn sau tour, gửi khảo sát và ghi nhận phản hồi.
- Tính lương hướng dẫn viên và thống kê.

## Yêu cầu cài đặt

### Để xem báo cáo

- Microsoft Word 2016 trở lên, hoặc ứng dụng tương thích với định dạng `.docx`.

### Để chuẩn bị môi trường phát triển ứng dụng

- Windows 10/11.
- Visual Studio 2022 với workload **.NET desktop development**.
- .NET Framework 4.7.2 Developer Pack/Targeting Pack để biên dịch đúng target framework.
- SQL Server Database Engine và SQL Server Management Studio (SSMS).

## Cài đặt và sử dụng

### Mở báo cáo hiện có

1. Mở [`outputs/Bai_6_Quan_ly_cong_ty_du_lich_Mai_Tien_Dat.docx`](outputs/Bai_6_Quan_ly_cong_ty_du_lich_Mai_Tien_Dat.docx) bằng Word hoặc ứng dụng đọc `.docx`.
2. Xem phần **A. Mục tiêu** để tra vị trí trả lời sáu câu hỏi.
3. Đọc theo thứ tự: pha phân tích, pha thiết kế, cơ sở dữ liệu và thiết kế giao diện.

### Chuẩn bị môi trường cho phần mềm (khi có source code)

1. Cài Visual Studio và workload **.NET desktop development**.
2. Cài **.NET Framework 4.7.2 Developer Pack**. Chỉ cài runtime thường chưa đủ để build project nhắm đến .NET Framework 4.7.2.
3. Cài SQL Server Database Engine; ghi lại tên instance, ví dụ `localhost\SQLEXPRESS`. Cài SSMS để quản trị và kiểm tra dữ liệu.
4. Tạo CSDL theo ERD ở Hình P.21. Trong gói hiện tại chưa có file `.sql`, nên cần có script tạo bảng và dữ liệu mẫu trước khi chạy phần mềm.
5. Khi solution được bổ sung, mở file `.sln` trong Visual Studio, cấu hình connection string trong phần cấu hình ứng dụng, build rồi chạy bằng **F5**.

Ví dụ connection string cho SQL Server Express cục bộ với Windows Authentication:

```text
Server=localhost\SQLEXPRESS;Database=QuanLyCongTyDuLich;Integrated Security=True;TrustServerCertificate=True;
```

Thay `localhost\SQLEXPRESS` và tên CSDL theo máy đang cài. Ví dụ này chỉ là cấu hình phát triển cục bộ; không đưa thông tin đăng nhập thật vào mã nguồn hoặc kho Git.

## Kiến trúc dự kiến

```text
WinForms (UI) → Service → Data Access (ADO.NET) → SQL Server
```

Form nhận thao tác và hiển thị kết quả. Service kiểm tra quy tắc nghiệp vụ, tính toán và điều phối transaction. Data Access thực hiện đọc/ghi CSDL.

## Xử lý lỗi thường gặp

| Lỗi | Nguyên nhân thường gặp | Cách xử lý |
|---|---|---|
| `MSB3644: .NETFramework,Version=v4.7.2 reference assemblies were not found` | Thiếu bộ tham chiếu để biên dịch .NET Framework 4.7.2. | Cài .NET Framework 4.7.2 Developer Pack/Targeting Pack; mở lại Visual Studio và build lại. |
| `A network-related or instance-specific error occurred while establishing a connection to SQL Server` | SQL Server chưa chạy, sai tên instance hoặc máy không kết nối được đến instance. | Kiểm tra dịch vụ SQL Server trong Services/SQL Server Configuration Manager; xác nhận `Server` trong connection string; thử kết nối instance đó bằng SSMS. |
| `Login failed for user` | Kiểu xác thực trong connection string không khớp hoặc tài khoản chưa có quyền. | Với Windows Authentication, dùng `Integrated Security=True` và cấp quyền cho tài khoản Windows. Nếu dùng SQL Authentication, bật chế độ phù hợp và dùng tài khoản SQL được cấp quyền. |
| `Cannot open database ... requested by the login` | CSDL chưa được tạo hoặc tài khoản không có quyền truy cập. | Tạo CSDL theo ERD, kiểm tra tên trong `Database=...` và quyền của tài khoản. |
| `Invalid object name ...` | Bảng chưa tồn tại, tên bảng sai hoặc script triển khai không khớp mô hình. | Chạy script tạo schema đúng phiên bản; đối chiếu tên bảng/khóa với ERD P.21. Gói hiện tại chưa kèm script SQL. |
| Không tìm thấy target `.NET Framework 4.7.2` trong Visual Studio | Chưa cài Developer Pack hoặc project chưa được nạp lại sau khi cài. | Cài Targeting Pack qua Visual Studio Installer hoặc Developer Pack; đóng và mở lại solution. |
| Không mở được file báo cáo `.docx` | Tệp tải chưa đầy đủ hoặc ứng dụng không hỗ trợ định dạng. | Tải lại tệp, mở bằng Word hoặc LibreOffice Writer, rồi kiểm tra tệp có đuôi `.docx`.
