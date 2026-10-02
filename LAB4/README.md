# e-SHOPPING

Đề tài: Hệ thống cửa hàng online e-Shopping
Họ tên: Mai Tiến Đạt - 1250080030
Lớp: CNPM1

## Hướng dẫn cài đặt

### 1. Cần cài trước

Máy cần có Visual Studio (2019 hoặc 2022, tick workload ".NET desktop development"), .NET Framework 4.7.2, SQL Server Express và SQL Server Management Studio (SSMS).

### 2. Lấy mã nguồn

Giải nén project vào một thư mục, ví dụ D:\eShopping.

### 3. Tạo cơ sở dữ liệu

Mở SSMS và đăng nhập vào SQL Server (Server name thường là .\SQLEXPRESS). Chọn File -> Open -> File, mở file script SQL của project rồi bấm Execute (F5). Bấm Refresh trong Object Explorer, thấy database eShopping là thành công.

### 4. Sửa chuỗi kết nối

Mở file App.config, sửa dòng connectionStrings cho đúng tên server trên máy bạn:

```xml
<add name="eShopping"
     connectionString="Server=.\SQLEXPRESS;Database=eShopping;Integrated Security=True;"
     providerName="System.Data.SqlClient" />
```

### 5. Chạy chương trình

Mở file .sln bằng Visual Studio, chọn Build -> Rebuild Solution, sau đó bấm F5. Cửa sổ "HỆ THỐNG CỬA HÀNG ONLINE e-SHOPPING" hiện ra là cài đặt thành công.

### 6. Dùng thử

Bấm "Đăng nhập / Đăng ký" để đăng nhập, vào "Chọn sản phẩm / Giỏ hàng" để thêm sản phẩm, rồi bấm "Tính tiền / Đặt hàng" và "Xác nhận đặt hàng". Thấy thông báo đặt hàng thành công kèm số đơn là chạy đúng. Dịch vụ thanh toán và email trong bài là lớp Mock nên không gửi email thật.

### 7. Lỗi thường gặp

Nếu không kết nối được CSDL, kiểm tra SQL Server đã chạy chưa và tên server trong App.config có đúng không. Nếu báo Cannot open database "eShopping" thì chưa chạy script SQL ở bước 3. Nếu thiếu System.Configuration, chuột phải References -> Add Reference -> tick System.Configuration. Warning "SqlConnection is obsolete" chỉ là cảnh báo, chương trình vẫn chạy bình thường.
