HỆ THỐNG QUẢN LÝ THƯ VIỆN - LAB 2

Dự án phần mềm desktop quản lý nghiệp vụ thư viện, bao gồm quản lý sách, độc giả, quy trình mượn/trả sách, xử lý vi phạm và thống kê dữ liệu.

1. Thông tin sinh viên
Họ và tên: Mai Tiến Đạt
MSSV: 1250080030
Lớp: 12_ĐH_CNPM1

2. Công nghệ sử dụng
C#
Windows Forms 
Microsoft SQL Server


3. Cấu trúc thư mục dự án
QuanLyThuVien/
│
├── Data/                   # Tầng truy xuất dữ liệu 
│   └── Db.cs               # Lớp hỗ trợ kết nối và truy vấn SQL Server
│
├── Services/               # Tầng xử lý nghiệp vụ
│   ├── DanhMucService.cs   # Nghiệp vụ nhân viên, thể loại, NXB
│   ├── SachService.cs      # Nghiệp vụ quản lý đầu sách
│   ├── DocGiaService.cs    # Nghiệp vụ quản lý độc giả và thẻ
│   ├── MuonTraService.cs   # Nghiệp vụ mượn, trả sách và phạt
│   └── ThongKeService.cs   # Nghiệp vụ tổng hợp số liệu
│
├── Forms/                  # Tầng giao diện người dùng 
│   ├── FrmMain.cs          # Giao diện điều hướng chính
├── Models.cs               # Định nghĩa các lớp thực thể 
├── App.config              # File cấu hình ứng dụng 
└── Program.cs              # Điểm bắt đầu chạy ứng dụng
