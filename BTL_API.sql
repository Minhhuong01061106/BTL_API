create database BTL_API
use BTL_API

CREATE TABLE LoaiTaiKhoan
(
    IdLoaiTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenLoaiTaiKhoan NVARCHAR(100),
    MoTa NVARCHAR(255),
    TrangThai BIT,
    NgayTao DATETIME DEFAULT GETDATE()
);
 
CREATE TABLE TaiKhoan (
    IdTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(100),
    MatKhau NVARCHAR(100),
    TrangThai BIT,
    IdLoaiTaiKhoan INT FOREIGN KEY REFERENCES LoaiTaiKhoan(IdLoaiTaiKhoan)
);
 
CREATE TABLE UserInfo (
    IdUser INT IDENTITY(1,1) PRIMARY KEY,
    TenTaiKhoan NVARCHAR(100),
    NgaySinh DATE,
    DiaChi NVARCHAR(255),
    MoTa NVARCHAR(255),
    TrangThai BIT,
    IdTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(IdTaiKhoan)
);
 
CREATE TABLE LoaiThuNhap (
    IdLoaiThuNhap INT IDENTITY(1,1) PRIMARY KEY,
    IdTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(IdTaiKhoan),
    TenLoaiThuNhap NVARCHAR(100),
    MoTa NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai BIT
);
 select * from LoaiThuNhap
CREATE TABLE ThuNhap (
    IdThuNhap INT IDENTITY(1,1) PRIMARY KEY,
    TenThuNhap NVARCHAR(100),
    IdTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(IdTaiKhoan),
    IdLoaiThuNhap INT FOREIGN KEY REFERENCES LoaiThuNhap(IdLoaiThuNhap),
    SoTien DECIMAL(18,2),
    NgayThuNhap DATE,
    NgayTao DATETIME DEFAULT GETDATE(),
    MoTa NVARCHAR(255),
    TrangThai BIT
);
 
-- 6. LOẠI CHI TIÊU
CREATE TABLE LoaiChiTieu (
    IdLoaiChiTieu INT IDENTITY(1,1) PRIMARY KEY,
    TenLoaiChiTieu NVARCHAR(100),
    MoTa NVARCHAR(255),
    TrangThai BIT,
    NgayTao DATETIME DEFAULT GETDATE()
);
 
-- 7. CHI TIÊU (sửa lỗi: thêm IdLoaiChiTieu)
CREATE TABLE ChiTieu (
    IdChiTieu INT IDENTITY(1,1) PRIMARY KEY,
    TenChiTieu NVARCHAR(100),
    IdTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(IdTaiKhoan),
    IdLoaiChiTieu INT FOREIGN KEY REFERENCES LoaiChiTieu(IdLoaiChiTieu),    -- ĐÃ THÊM
    SoTien DECIMAL(18,2),
    NgayChiTieu DATE,
    MoTa NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai BIT
);
 
-- 8. NGÂN SÁCH
CREATE TABLE NganSach (
    IdNganSach INT IDENTITY(1,1) PRIMARY KEY,
    IdTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(IdTaiKhoan),
    TenNganSach NVARCHAR(100),
    SoTienGioiHan DECIMAL(18,2),
    MoTa NVARCHAR(255),
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai BIT
);
 
-- 9. LOẠI NHẮC NHỞ
CREATE TABLE LoaiNhacNho (
    IdLoaiNhacNho INT IDENTITY(1,1) PRIMARY KEY,
    TenLoaiNhacNho NVARCHAR(100),
    MoTa NVARCHAR(255),
    TrangThai BIT,
    NgayTao DATETIME DEFAULT GETDATE()
);
 
-- 10. NHẮC NHỞ (sửa lỗi: đổi tên bảng + thêm IdLoaiNhacNho)
CREATE TABLE NhacNho (
    IdNhacNho INT IDENTITY(1,1) PRIMARY KEY,
    IdTaiKhoan INT FOREIGN KEY REFERENCES TaiKhoan(IdTaiKhoan),
    IdLoaiNhacNho INT FOREIGN KEY REFERENCES LoaiNhacNho(IdLoaiNhacNho),     -- ĐÃ THÊM
    NoiDung NVARCHAR(255),
    SoTienNhacNho DECIMAL(18,2),
    ChuKyNhacNho NVARCHAR(50),
    NgayKetThuc DATE,
    MoTa NVARCHAR(255),
    TrangThai BIT
);
 
INSERT INTO LoaiTaiKhoan (TenLoaiTaiKhoan, MoTa, TrangThai)
VALUES
(N'Quản trị viên', N'Tài khoản có toàn quyền hệ thống', 1),
(N'Người dùng cá nhân', N'Tài khoản sử dụng để quản lý thu chi cá nhân', 1),
(N'Tài khoản khách', N'Tài khoản dùng thử, hạn chế chức năng', 1);
 
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, TrangThai, IdLoaiTaiKhoan)
VALUES
(N'admin_master', N'123456', 1, 1),
(N'tranminhquan', N'quan@2025', 1, 2),
(N'lethienthanh', N'thanh#99', 1, 2),
(N'user_demo', N'demo123', 1, 3);
 
INSERT INTO UserInfo (TenTaiKhoan, NgaySinh, DiaChi, MoTa, TrangThai, IdTaiKhoan)
VALUES
(N'Lê Hải Nam', '1995-04-12', N'52 Lê Duẩn, Hà Nội', N'Quản trị hệ thống', 1, 1),
(N'Trần Minh Quân', '2003-09-20', N'124 Nguyễn Thị Minh Khai, TP.HCM', N'Sử dụng theo dõi chi tiêu cá nhân', 1, 2),
(N'Lê Thiên Thanh', '1999-03-14', N'85 Trần Phú, Đà Nẵng', N'Theo dõi ngân sách hàng tháng', 1, 3),
(N'Khách dùng thử', '2000-01-01', N'', N'Tài khoản demo', 1, 4);
 
INSERT INTO LoaiThuNhap (IdTaiKhoan, TenLoaiThuNhap, MoTa, TrangThai)
VALUES
(2, N'Lương chính', N'Lương nhận vào mỗi tháng', 1),
(2, N'Thu nhập phụ', N'Thu nhập từ làm freelancer', 1),
(3, N'Lương hàng tháng', N'Lương cố định', 1),
(3, N'Tiền thưởng', N'Thu nhập thưởng dự án', 1);
 
INSERT INTO ThuNhap (TenThuNhap, IdTaiKhoan, IdLoaiThuNhap, SoTien, NgayThuNhap, MoTa, TrangThai)
VALUES
(N'Lương tháng 11', 2, 1, 15000000, '2025-11-01', N'Lương cố định công ty', 1),
(N'Freelancer thiết kế UI', 2, 2, 3500000, '2025-11-10', N'Dự án thiết kế app mobile', 1),
(N'Lương tháng 11', 3, 3, 12000000, '2025-11-02', N'Lương công ty du lịch', 1),
(N'Thưởng dự án quý 4', 3, 4, 5000000, '2025-11-15', N'Thưởng hiệu suất', 1);
 
INSERT INTO LoaiChiTieu (TenLoaiChiTieu, MoTa, TrangThai)
VALUES
(N'Ăn uống', N'Chi phí bữa ăn, đồ uống hàng ngày', 1),
(N'Đi lại', N'Xăng xe, vé xe bus, Grab', 1),
(N'Mua sắm', N'Quần áo, phụ kiện, vật dụng cá nhân', 1),
(N'Hóa đơn', N'Điện, nước, internet', 1),
(N'Giải trí', N'Xem phim, du lịch, hoạt động vui chơi', 1);
 
INSERT INTO ChiTieu (TenChiTieu, IdTaiKhoan, IdLoaiChiTieu, SoTien, NgayChiTieu, MoTa, TrangThai)
VALUES
(N'Ăn trưa tại công ty', 2, 1, 45000, '2025-11-03', N'Bún thịt nướng + nước', 1),
(N'Đổ xăng xe máy', 2, 2, 60000, '2025-11-05', N'Xăng A95', 1),
(N'Mua áo sơ mi', 2, 3, 320000, '2025-11-07', N'Áo sơ mi công sở', 1),
(N'Thanh toán tiền điện', 2, 4, 380000, '2025-11-08', N'Hóa đơn điện tháng 10', 1),
(N'Đi Grab đến công ty', 3, 2, 39000, '2025-11-04', N'Sáng đi làm', 1),
(N'Mua tai nghe Bluetooth', 3, 3, 450000, '2025-11-12', N'Tai nghe dùng cho làm việc', 1),
(N'Xem phim CGV', 3, 5, 120000, '2025-11-16', N'Xem phim cuối tuần', 1);
 
INSERT INTO NganSach (IdTaiKhoan, TenNganSach, SoTienGioiHan, MoTa, TrangThai)
VALUES
(2, N'Ngân sách ăn uống tháng 11', 2000000, N'Hạn mức chi ăn uống', 1),
(2, N'Ngân sách mua sắm tháng 11', 1500000, N'Quần áo & đồ cá nhân', 1),
(3, N'Ngân sách đi lại tháng 11', 800000, N'Di chuyển trong tháng', 1),
(3, N'Ngân sách giải trí tháng 11', 1000000, N'Xem phim, café, du lịch ngắn', 1);
 
INSERT INTO LoaiNhacNho (TenLoaiNhacNho, MoTa, TrangThai)
VALUES
(N'Nhắc chi tiêu', N'Nhắc hạn mức chi tiêu theo từng loại', 1),
(N'Nhắc hóa đơn', N'Nhắc thanh toán hóa đơn định kỳ', 1),
(N'Nhắc tiết kiệm', N'Nhắc gửi tiết kiệm mỗi tháng', 1);
 
INSERT INTO NhacNho (IdTaiKhoan, IdLoaiNhacNho, NoiDung, SoTienNhacNho, ChuKyNhacNho, NgayKetThuc, MoTa, TrangThai)
VALUES
(2, 1, N'Cảnh báo vượt hạn mức ăn uống', 2000000, N'Hàng tuần', '2025-12-31', N'Theo dõi chi ăn uống', 1),
(2, 2, N'Thanh toán hóa đơn internet', 250000, N'Hàng tháng', '2026-01-30', N'Hóa đơn FPT', 1),
(3, 3, N'Gửi tiết kiệm định kỳ', 1000000, N'Hàng tháng', '2026-12-31', N'Tạo thói quen tiết kiệm', 1);

CREATE PROCEDURE GetAllNganSach
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        IdNganSach,
        IdTaiKhoan,
        TenNganSach,
        SoTienGioiHan,
        MoTa,
        NgayTao,
        TrangThai
    FROM NganSach
    ORDER BY NgayTao DESC;
END

EXEC GetAllNganSach;