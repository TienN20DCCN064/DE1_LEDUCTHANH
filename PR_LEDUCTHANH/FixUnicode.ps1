# Tạo lại database QLSV với UTF-8 collation
$connectionString = "Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=master;"

try {
    $connection = New-Object System.Data.SqlClient.SqlConnection
    $connection.ConnectionString = $connectionString
    $connection.Open()
    
    # Xóa database cũ
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLSV')
    BEGIN
        ALTER DATABASE QLSV SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
        DROP DATABASE QLSV;
    END
"@
    $command.ExecuteNonQuery()
    Write-Host "Xóa database cũ thành công!" -ForegroundColor Green
    
    # Tạo database mới với UTF-8 collation
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    CREATE DATABASE QLSV COLLATE Vietnamese_CI_AS;
"@
    $command.ExecuteNonQuery()
    Write-Host "Tạo database QLSV thành công!" -ForegroundColor Green
    
    $connection.Close()
    
    # Kết nối tới QLSV để tạo bảng
    $connection2 = New-Object System.Data.SqlClient.SqlConnection
    $connection2.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=QLSV;"
    $connection2.Open()
    
    $command2 = $connection2.CreateCommand()
    $command2.CommandText = @"
    CREATE TABLE Lop
    (
        MaLop VARCHAR(10) PRIMARY KEY,
        TenLop NVARCHAR(100) COLLATE Vietnamese_CI_AS NOT NULL
    );
    
    CREATE TABLE SinhVien
    (
        MaSV VARCHAR(20) PRIMARY KEY,
        HoTen NVARCHAR(100) COLLATE Vietnamese_CI_AS NOT NULL,
        Phai BIT NOT NULL,
        NgaySinh DATETIME NOT NULL,
        DiaChi NVARCHAR(200) COLLATE Vietnamese_CI_AS,
        DienThoai VARCHAR(20),
        Malop VARCHAR(10) NOT NULL,
        FOREIGN KEY (Malop) REFERENCES Lop(MaLop)
    );
    
    INSERT INTO Lop (MaLop, TenLop) VALUES (N'L001', N'Lớp 10A1');
    INSERT INTO Lop (MaLop, TenLop) VALUES (N'L002', N'Lớp 10A2');
    INSERT INTO Lop (MaLop, TenLop) VALUES (N'L003', N'Lớp 10B1');
    
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV001', N'Nguyễn Văn A', 1, N'2008-01-15', N'Hà Nội', N'0912345678', N'L001');
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV002', N'Trần Thị B', 0, N'2008-05-20', N'Hà Nội', N'0987654321', N'L001');
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV003', N'Phạm Văn C', 1, N'2008-03-10', N'Hà Nội', N'0913456789', N'L001');
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV004', N'Hoàng Thị D', 0, N'2008-07-25', N'Hà Nội', N'0934567890', N'L002');
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV005', N'Võ Văn E', 1, N'2008-02-14', N'Hà Nội', N'0945678901', N'L002');
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV006', N'Đặng Thị F', 0, N'2008-06-18', N'Hà Nội', N'0956789012', N'L002');
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV007', N'Bùi Văn G', 1, N'2008-04-22', N'Hà Nội', N'0967890123', N'L003');
    INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) VALUES 
    (N'SV008', N'Lý Thị H', 0, N'2008-08-30', N'Hà Nội', N'0978901234', N'L003');
"@
    $command2.ExecuteNonQuery()
    Write-Host "Tạo bảng và chèn dữ liệu thành công!" -ForegroundColor Green
    
    $connection2.Close()
}
catch {
    Write-Host "Lỗi: $_" -ForegroundColor Red
}
