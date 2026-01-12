-- =============================================
-- Script tạo database QLSV cho SQL Server LocalDB
-- Chạy: sqlcmd -S "(localdb)\MSSQLLocalDB" -E -i DBInit.sql
-- =============================================

-- Kiểm tra và xóa database nếu tồn tại
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLSV')
BEGIN
    DROP DATABASE QLSV;
END
GO

-- Tạo database QLSV
CREATE DATABASE QLSV;
GO

-- Chuyển sang database QLSV
USE QLSV;
GO

-- Bảng Lop
CREATE TABLE Lop
(
    MaLop VARCHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(100) NOT NULL
);
GO

-- Bảng SinhVien
CREATE TABLE SinhVien
(
    MaSV VARCHAR(20) PRIMARY KEY,
    HoTen NVARCHAR(100) NOT NULL,
    Phai BIT NOT NULL,
    NgaySinh DATETIME NOT NULL,
    DiaChi NVARCHAR(200),
    DienThoai VARCHAR(20),
    Malop VARCHAR(10) NOT NULL,
    FOREIGN KEY (Malop) REFERENCES Lop(MaLop)
);
GO

-- Chèn dữ liệu vào bảng Lop
INSERT INTO Lop VALUES
('L001', 'Lop 10A1'),
('L002', 'Lớp 10A2'),
('L003', 'Lớp 10B1');

-- Chèn dữ liệu vào bảng SinhVien
INSERT INTO SinhVien VALUES
('SV001', 'Nguyễn Văn A', 1, '2008-01-15', 'Hà Nội', '0912345678', 'L001'),
('SV002', 'Trần Thị B', 0, '2008-05-20', 'Hà Nội', '0987654321', 'L001'),
('SV003', 'Phạm Văn C', 1, '2008-03-10', 'Hà Nội', '0913456789', 'L001'),
('SV004', 'Hoàng Thị D', 0, '2008-07-25', 'Hà Nội', '0934567890', 'L002'),
('SV005', 'Võ Văn E', 1, '2008-02-14', 'Hà Nội', '0945678901', 'L002'),
('SV006', 'Đặng Thị F', 0, '2008-06-18', 'Hà Nội', '0956789012', 'L002'),
('SV007', 'Bùi Văn G', 1, '2008-04-22', 'Hà Nội', '0967890123', 'L003'),
('SV008', 'Lý Thị H', 0, '2008-08-30', 'Hà Nội', '0978901234', 'L003'),
('SV009', 'Tô Văn I', 1, '2008-09-12', 'Hà Nội', '0989012345', 'Lttt'),
('SV010', 'Phan Thị K', 0, '2008-11-05', 'Hà Nội', '0990123456', 'Lttt');

GO

PRINT 'Tạo database QLSV thành công!';
