# Quản Lý Hồ Sơ Bệnh Án

Hệ thống quản lý phòng khám trọn quy trình: tiếp nhận, khám, xét nghiệm, toa thuốc, thanh toán, thống kê.

Đồ án môn Phân tích & Thiết kế hướng đối tượng (OOAD) 

Công nghệ: .NET Framework 4.7.2, C# WinForms, SQL Server LocalDB, Visual Studio 2022.

---

## Mục lục

1. Giới thiệu
2. Tính năng
3. Quy trình khám bệnh
4. Kiến trúc
5. Cài đặt nhanh
6. Kịch bản chạy thử
7. Cơ sở dữ liệu
8. Quy tắc nghiệp vụ
9. Công nghệ sử dụng
10. Khắc phục sự cố
11. Hướng phát triển
12. Tác giả

---

## 1. Giới thiệu

Ứng dụng desktop Windows Forms giúp phòng khám số hóa toàn bộ vòng đời của một lượt khám bệnh: đăng ký hồ sơ lần đầu, thu lệ phí năm, đặt lịch khám định kỳ, khám và ghi nhận triệu chứng, chỉ định xét nghiệm, kê toa, lập hóa đơn, thanh toán đa hình thức và báo cáo thống kê.

Điểm nhấn của dự án là tính đúng đắn của dữ liệu: mọi nghiệp vụ chạy trong transaction, có khóa chống xung đột khi nhiều người thao tác cùng lúc, và được bảo vệ thêm một lớp bằng ràng buộc ở tầng cơ sở dữ liệu.

## 2. Tính năng

| Phân hệ | Form | Chức năng chính |
|---|---|---|
| Danh mục | `FrmDanhMuc` | Quản lý Khoa, Bác sĩ, Nhân viên, Triệu chứng, Loại xét nghiệm, Thuốc |
| Tiếp nhận | `FrmTiepNhan` | Đăng ký lần đầu (kèm ảnh bệnh nhân), thu lệ phí năm, gia hạn 12 tháng, tra cứu hồ sơ, xem lịch sử khám |
| Lịch hẹn | `FrmLichHen` | Đặt / hủy lịch khám định kỳ, tối đa 1 lịch mỗi quý |
| Khám bệnh | `FrmKhamBenh` | Tạo phiếu khám, ghi triệu chứng, yêu cầu xét nghiệm, lập toa thuốc, kết luận |
| Xét nghiệm | `FrmKetQuaXN` | Kỹ thuật viên nhập kết quả cho các chỉ định đang chờ |
| Thanh toán | `FrmThanhToan` | Lập hóa đơn tự động, thanh toán nhiều lần / nhiều hình thức, hoàn tất và khóa phiếu |
| Thống kê | `FrmThongKe` | Doanh thu, số lượt khám, thuốc đã kê, khối lượng khám theo bác sĩ trong khoảng thời gian tùy chọn |

## 3. Quy trình khám bệnh

```text
+------------------------+
| Đăng ký lần đầu        |
| + lệ phí năm           |
+-----------+------------+
            |
            v
+------------------------+
| Cấp hồ sơ              |
| hiệu lực 12 tháng      |
+-----------+------------+
            |
            v
      Loại khám?
     /          \
 Điều trị      Định kỳ
    |              |
    |              v
    |      +---------------+
    |      | Đặt lịch      |
    |      | theo quý      |
    |      +-------+-------+
    |              |
    v              v
+------------------------+
| Tạo phiếu khám         |
+-----------+------------+
            |
            v
+------------------------+
| Ghi triệu chứng        |
+-----------+------------+
            |
            v
+------------------------+
| Yêu cầu xét nghiệm     |
+-----------+------------+
            |
            v
+------------------------+
| Nhập kết quả xét nghiệm|
+-----------+------------+
            |
            v
+------------------------+
| Lập toa thuốc          |
+-----------+------------+
            |
            v
+------------------------+
| Kết luận               |
+-----------+------------+
            |
            v
+------------------------+
| Lập hóa đơn            |
+-----------+------------+
            |
            v
+------------------------+
| Thanh toán đủ          |
+-----------+------------+
            |
            v
+------------------------+
| Hoàn tất, khóa dữ liệu |
+------------------------+
```

### Vòng đời của phiếu khám

```text
[Tạo phiếu] --> Đang khám --[Kết luận]--> Chờ thanh toán --[Hóa đơn đã thanh toán đủ]--> Hoàn tất (chỉ đọc)
```

| Trạng thái | Ý nghĩa |
|---|---|
| Đang khám | Phiếu vừa tạo, đang ghi triệu chứng, xét nghiệm, toa thuốc |
| Chờ thanh toán | Đã có kết luận, chờ lập hóa đơn và thanh toán |
| Hoàn tất | Hóa đơn đã trả đủ, phiếu bị khóa (chỉ đọc) |

## 4. Kiến trúc

Dự án tách lớp rõ ràng, form không chứa SQL và không chứa luật nghiệp vụ.

```text
+--------------------------------------------------------------+
| Presentation - Forms/                                        |
| FrmMain, FrmTiepNhan, FrmKhamBenh, FrmThanhToan, ...         |
+------------------------------+-------------------------------+
                               |  gọi                ^
                               v                     |  KetQuaXuLy
+------------------------------+-------------------------------+
| Business - Services/                                         |
| TiepNhanService, KhamBenhService, ThanhToanService,          |
| ThongKeService, DanhMucService                               |
+------------------------------+-------------------------------+
                               |
                               v
+------------------------------+-------------------------------+
| Data - Data/Db.cs                                            |
| InTx, Query, Scalar, Cmd, NextCode                           |
+------------------------------+-------------------------------+
                               |
                               v
+--------------------------------------------------------------+
| SQL Server - QuanLyBenhAn                                    |
+--------------------------------------------------------------+
```

### Cấu trúc thư mục

```text
QuanLyBenhAn_WinForms/
|-- QuanLyBenhAn.sln
|-- README.md
`-- QuanLyBenhAn/
    |-- App.config                 # Connection string "QuanLyBenhAnDB"
    |-- Program.cs                 # Điểm khởi chạy -> FrmMain
    |-- Database/
    |   `-- QuanLyBenhAn.sql       # Tạo CSDL + 18 bảng + dữ liệu mẫu
    |-- Data/
    |   `-- Db.cs                  # Lớp truy cập dữ liệu dùng chung (ADO.NET)
    |-- Models/
    |   `-- ThuocItem.cs           # Dòng thuốc trong toa
    |-- Services/                  # Toàn bộ luật nghiệp vụ
    |   |-- TiepNhanService.cs
    |   |-- KhamBenhService.cs
    |   |-- ThanhToanService.cs
    |   |-- ThongKeService.cs
    |   `-- DanhMucService.cs
    `-- Forms/                     # Giao diện WinForms (7 form + FrmMain)
```

### Các kỹ thuật đáng chú ý

- **KetQuaXuLy (Result pattern):** service trả về Ok / Fail kèm thông báo và dữ liệu, form chỉ việc hiển thị, không dùng exception để điều khiển luồng.
- **Db.InTx:** gói mỗi nghiệp vụ vào một transaction. Thành công thì Commit, thất bại hoặc có lỗi thì Rollback, đồng thời dịch lỗi SQL (trùng khóa, vi phạm khóa ngoại) sang tiếng Việt dễ hiểu.
- **Chống xung đột đồng thời:** dùng `UPDLOCK`, `HOLDLOCK` khi sinh mã và kiểm tra điều kiện, tránh hai người cùng tạo trùng mã hoặc cùng đặt 2 lịch trong một quý.
- **Db.NextCode:** sinh mã tăng dần có tiền tố (`BN000001`, `HS000001`, `PK000001`, `HD000001`, ...).
- **Truy vấn tham số hóa 100%:** không nối chuỗi từ dữ liệu người dùng; tên bảng ở màn danh mục được kiểm tra qua whitelist.
- **Phòng thủ hai lớp:** luật nghiệp vụ kiểm tra ở service, và được CSDL chốt lại bằng `CHECK`, `UNIQUE`, filtered index, computed column.

## 5. Cài đặt nhanh

### Yêu cầu

| Thành phần | Phiên bản |
|---|---|
| Hệ điều hành | Windows 10 / 11 |
| IDE | Visual Studio 2022, workload .NET desktop development |
| Framework | .NET Framework 4.7.2 |
| CSDL | SQL Server hoặc LocalDB (đi kèm Visual Studio) |

### Các bước

**Bước 1. Tạo cơ sở dữ liệu**

Mở SSMS (hoặc SQL Server Object Explorer trong Visual Studio) và chạy file:

```text
QuanLyBenhAn\Database\QuanLyBenhAn.sql
```

Script tự tạo database `QuanLyBenhAn`, các bảng, chỉ mục và dữ liệu mẫu.

Lưu ý: script có lệnh `DROP TABLE IF EXISTS`, chạy lại sẽ xóa sạch dữ liệu cũ.

**Bước 2. Cấu hình chuỗi kết nối** (bỏ qua nếu dùng LocalDB mặc định)

Mở `QuanLyBenhAn\App.config` và sửa `Data Source` cho khớp máy của bạn:

```xml
<connectionStrings>
  <add name="QuanLyBenhAnDB" providerName="System.Data.SqlClient"
       connectionString="Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=QuanLyBenhAn;Integrated Security=True" />
</connectionStrings>
```

| Môi trường | Giá trị `Data Source` |
|---|---|
| LocalDB (mặc định) | `(localdb)\MSSQLLocalDB` |
| SQL Server Express | `.\SQLEXPRESS` |
| SQL Server đầy đủ | `TENMAY` hoặc `TENMAY\TENINSTANCE` |

Dùng tài khoản SQL thay cho Windows Authentication: thay `Integrated Security=True` bằng `User ID=sa;Password=...`.

**Bước 3. Chạy ứng dụng**

Mở `QuanLyBenhAn.sln` bằng Visual Studio 2022, nhấn F5. Màn hình chính `FrmMain` hiện ra với 7 phân hệ.

## 6. Kịch bản chạy thử nhanh (5 phút)

Làm theo đúng thứ tự dưới đây để đi hết một vòng nghiệp vụ:

| # | Form | Thao tác | Kết quả mong đợi |
|:-:|---|---|---|
| 1 | Tiếp nhận | Đăng ký bệnh nhân mới, nhập lệ phí năm | Được cấp mã hồ sơ `HS...`, hiệu lực 1 năm |
| 2 | Khám bệnh | Tạo phiếu Điều trị, ghi triệu chứng, yêu cầu xét nghiệm | Phiếu ở trạng thái Đang khám |
| 3 | Kết quả xét nghiệm | Chọn chỉ định đang chờ, nhập kết quả | Chỉ định có kết quả và ngày trả |
| 4 | Khám bệnh | Lập toa thuốc, nhập kết luận | Phiếu chuyển sang Chờ thanh toán |
| 5 | Thanh toán | Lập hóa đơn, thanh toán, hoàn tất | Phiếu Hoàn tất, dữ liệu bị khóa |
| 6 | Thống kê | Chọn khoảng ngày, bấm thống kê | Thấy doanh thu, thuốc đã kê, số ca theo bác sĩ |

Thử thêm: đặt lịch định kỳ (khám định kỳ được miễn tiền khám), thanh toán chia nhiều lần bằng nhiều hình thức khác nhau.

## 7. Cơ sở dữ liệu

18 bảng, chuẩn hóa, ràng buộc chặt chẽ ngay ở tầng CSDL.

### Quan hệ giữa các bảng

| Bảng cha | Bảng con | Quan hệ | Ý nghĩa |
|---|---|---|---|
| BenhNhan | HoSoBenhAn | 1 - 1 | Mỗi bệnh nhân có một hồ sơ |
| BenhNhan | PhieuDangKy | 1 - N | Bệnh nhân đăng ký |
| BenhNhan | LePhiNam | 1 - N | Bệnh nhân đóng lệ phí |
| PhieuDangKy | LePhiNam | 1 - N | Phiếu đăng ký kèm lệ phí |
| HoSoBenhAn | LichHen | 1 - N | Hồ sơ đặt lịch |
| HoSoBenhAn | PhieuKham | 1 - N | Hồ sơ được khám |
| LichHen | PhieuKham | 1 - 0..1 | Lịch hẹn dẫn tới phiếu khám |
| Khoa | BacSi | 1 - N | Khoa gồm nhiều bác sĩ |
| Khoa | PhieuKham | 1 - N | Khoa tiếp nhận phiếu khám |
| BacSi | PhieuKham | 1 - N | Bác sĩ phụ trách |
| PhieuKham | ChiTietTrieuChung | 1 - N | Phiếu ghi nhận triệu chứng |
| TrieuChung | ChiTietTrieuChung | 1 - N | Triệu chứng xuất hiện trong phiếu |
| PhieuKham | ChiTietXetNghiem | 1 - N | Phiếu chỉ định xét nghiệm |
| LoaiXetNghiem | ChiTietXetNghiem | 1 - N | Loại xét nghiệm được chỉ định |
| PhieuKham | ToaThuoc | 1 - 0..1 | Phiếu kê một toa |
| ToaThuoc | ChiTietToa | 1 - N (ít nhất 1) | Toa gồm các thuốc |
| Thuoc | ChiTietToa | 1 - N | Thuốc xuất hiện trong toa |
| PhieuKham | HoaDon | 1 - 0..1 | Phiếu lập một hóa đơn |
| HoaDon | ThanhToan | 1 - N | Hóa đơn thanh toán nhiều lần |
| NhanVien | HoaDon | 1 - N | Nhân viên lập hóa đơn |

### Nhóm bảng

| Nhóm | Bảng |
|---|---|
| Danh mục | `Khoa`, `BacSi`, `NhanVien`, `TrieuChung`, `LoaiXetNghiem`, `Thuoc` |
| Tiếp nhận | `BenhNhan`, `PhieuDangKy`, `LePhiNam`, `HoSoBenhAn`, `LichHen` |
| Khám bệnh | `PhieuKham`, `ChiTietTrieuChung`, `ChiTietXetNghiem`, `ToaThuoc`, `ChiTietToa` |
| Tài chính | `HoaDon`, `ThanhToan` |

### Ràng buộc do CSDL đảm bảo

- `BenhNhan` duy nhất theo bộ `(HoTen, NgaySinh, DienThoai)`, không tạo trùng bệnh nhân.
- `HoSoBenhAn.MaBN` là `UNIQUE`, mỗi bệnh nhân chỉ có một hồ sơ.
- `LichHen` có cột tính toán `Quy`, `Nam` (persisted) và unique index có điều kiện `(MaHS, Quy, Nam) WHERE TrangThai <> 'Hủy'`, tối đa một lịch/quý.
- `PhieuKham`: khám Định kỳ bắt buộc có `MaLich` (`CHECK`), mỗi lịch chỉ dùng cho một phiếu (unique index có điều kiện).
- `ChiTietXetNghiem`: `KetQua` và `NgayTraKQ` phải cùng có hoặc cùng rỗng.
- `ToaThuoc` và `HoaDon` gắn `UNIQUE` với `SoPhieuKham`, mỗi phiếu tối đa một toa, một hóa đơn.
- `HoaDon.TongTien` là cột tính toán `TienKham + TienXetNghiem + TienThuoc`, không thể lệch số.
- Các cột tiền có `CHECK >= 0` (hoặc `> 0` với số tiền giao dịch), hình thức thanh toán chỉ nhận 4 giá trị hợp lệ.

### Dữ liệu mẫu có sẵn

4 nhân viên (CSKH, Thu ngân, KTV xét nghiệm, Quản lý), 4 khoa, 4 bác sĩ, 5 triệu chứng, 3 loại xét nghiệm, 3 loại thuốc.

Đơn giá trong dữ liệu mẫu chỉ dùng để minh họa, không phải bảng giá chính thức.

## 8. Quy tắc nghiệp vụ

| Mã | Quy tắc |
|:-:|---|
| BR01 - BR03 | Đăng ký lần đầu là một giao dịch duy nhất: tạo bệnh nhân + phiếu đăng ký + thu lệ phí năm + cấp hồ sơ. Không cho đăng ký trùng bệnh nhân. |
| BR02, BR06 | Hồ sơ có hiệu lực 12 tháng. Gia hạn cộng thêm 12 tháng tính từ ngày hết hạn (hoặc từ hôm nay nếu đã hết hạn). Hồ sơ hết hạn thì không được khám. |
| BR04 | Mỗi lượt khám tạo một phiếu khám riêng, gồm loại khám Điều trị hoặc Định kỳ. |
| BR05 | Mỗi loại xét nghiệm chỉ chỉ định một lần trên mỗi phiếu. Mỗi phiếu chỉ có một toa thuốc. |
| BR07 | Tra cứu hồ sơ theo mã hồ sơ, số điện thoại, họ tên hoặc ngày sinh. |
| BR08 | Mỗi hồ sơ chỉ được một lịch khám định kỳ mỗi quý. Ngày hẹn phải ở tương lai và không vượt hạn hồ sơ. |
| BR09 | Bác sĩ phải thuộc đúng khoa đã chọn. Khám định kỳ phải dùng lịch hẹn Đã đặt của chính hồ sơ đó trong quý hiện tại. |
| BR10 | Chỉ bác sĩ phụ trách phiếu mới được lập toa. Toa phải có ít nhất 1 thuốc, không lặp thuốc, số lượng > 0. |
| BR11 | Hóa đơn = tiền khám + tiền xét nghiệm + tiền thuốc. Khám định kỳ miễn tiền khám. Chỉ lập hóa đơn khi mọi xét nghiệm đã có kết quả. Hóa đơn 0đ tự động ghi nhận đã thanh toán. Chỉ Hoàn tất khi hóa đơn đã trả đủ, sau đó phiếu bị khóa. |
| BR12 | Một hóa đơn có thể trả nhiều lần, nhiều hình thức (tiền mặt, chuyển khoản, thẻ, ví điện tử), tổng không được vượt số tiền phải trả. |

Ngoài ra: phiếu điều trị phải ghi ít nhất một triệu chứng trước khi kết luận; phiếu đã Hoàn tất không thể chỉnh sửa.

## 9. Công nghệ sử dụng

| Lớp | Công nghệ |
|---|---|
| Giao diện | Windows Forms (.NET Framework 4.7.2) |
| Ngôn ngữ | C# |
| Truy cập dữ liệu | ADO.NET thuần (`SqlConnection`, `SqlCommand`, `SqlDataAdapter`) |
| Cơ sở dữ liệu | Microsoft SQL Server / LocalDB (T-SQL) |
| Cấu hình | `App.config` + `System.Configuration` |
| Build | Visual Studio 2022 (MSBuild) |

## 10. Khắc phục sự cố

### NullReferenceException tại Db.CS (ConnectionStrings["QuanLyBenhAnDB"] returned null)

Chương trình không tìm thấy chuỗi kết nối lúc chạy. Kiểm tra:

1. Tên trong `App.config` phải khớp chính xác `QuanLyBenhAnDB` (phân biệt chữ hoa/thường).
2. Thẻ `<connectionStrings>` nằm trực tiếp trong `<configuration>`.
3. `QuanLyBenhAn` đang là Startup Project (chuột phải project, chọn Set as Startup Project).
4. File `bin\Debug\QuanLyBenhAn.exe.config` có chứa chuỗi kết nối. Nếu không, hãy Rebuild Solution.

### Cannot open database "QuanLyBenhAn" / lỗi 4060

Chưa chạy script tạo CSDL, hoặc `Data Source` đang trỏ sai máy chủ. Chạy lại `Database\QuanLyBenhAn.sql` trên đúng instance mà `App.config` đang dùng.

### A network-related or instance-specific error / không kết nối được máy chủ

- Kiểm tra dịch vụ SQL Server đã chạy (SQL Server Configuration Manager hoặc `services.msc`).
- Với LocalDB, thử khởi động bằng lệnh: `sqllocaldb start MSSQLLocalDB`.
- Kiểm tra lại tên instance trong `Data Source`.

### Không có LocalDB trên máy

Cài thêm thành phần SQL Server Express LocalDB trong Visual Studio Installer (tab Individual components), hoặc đổi `Data Source` sang SQL Server Express đã cài sẵn (`.\SQLEXPRESS`).

## 11. Hướng phát triển

- Đăng nhập và phân quyền theo vai trò (CSKH, Thu ngân, KTV, Quản lý, Bác sĩ)
- In toa thuốc, hóa đơn và phiếu kết quả xét nghiệm (PDF)
- Biểu đồ trực quan cho màn hình thống kê
- Quản lý tồn kho thuốc và cảnh báo chống chỉ định khi kê toa
- Nhắc lịch hẹn qua SMS / email
- Unit test cho tầng `Services`

## 12. Giấy phép và tác giả

Dự án phục vụ mục đích học tập trong khuôn khổ môn học.

Nhóm thực hiện: Mai Tiến Đạt - 1250080030
