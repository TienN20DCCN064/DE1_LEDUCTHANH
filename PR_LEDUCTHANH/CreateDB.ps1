$connectionString = "Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=master;"

try {
    $connection = New-Object System.Data.SqlClient.SqlConnection
    $connection.ConnectionString = $connectionString
    $connection.Open()
    
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    IF EXISTS (SELECT * FROM sys.databases WHERE name = 'QLSV')
    BEGIN
        ALTER DATABASE QLSV SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
        DROP DATABASE QLSV;
    END
    
    CREATE DATABASE QLSV;
"@
    
    $command.ExecuteNonQuery()
    Write-Host "Tạo database QLSV thành công!" -ForegroundColor Green
    
    $connection.Close()
    
    # Bây giờ kết nối tới QLSV để tạo bảng
    $connection2 = New-Object System.Data.SqlClient.SqlConnection
    $connection2.ConnectionString = "Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=QLSV;"
    $connection2.Open()
    
    $command2 = $connection2.CreateCommand()
    $command2.CommandText = @"
    CREATE TABLE Lop
    (
        MaLop VARCHAR(10) PRIMARY KEY,
        TenLop NVARCHAR(100) NOT NULL
    );
    
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
    
    INSERT INTO Lop VALUES
    ('L001', 'Lớp 10A1'),
    ('L002', 'Lớp 10A2'),
    ('L003', 'Lớp 10B1');

    INSERT INTO SinhVien VALUES
    ('SV001', 'Nguyễn Văn A', 1, '2008-01-15', N'Hà Nội', '0912345678', 'L001'),
    ('SV002', 'Trần Thị B', 0, '2008-05-20', N'Hà Nội', '0987654321', 'L001'),
    ('SV003', 'Phạm Văn C', 1, '2008-03-10', N'Hà Nội', '0913456789', 'L001'),
    ('SV004', 'Hoàng Thị D', 0, '2008-07-25', N'Hà Nội', '0934567890', 'L002'),
    ('SV005', 'Võ Văn E', 1, '2008-02-14', N'Hà Nội', '0945678901', 'L002'),
    ('SV006', 'Đặng Thị F', 0, '2008-06-18', N'Hà Nội', '0956789012', 'L002'),
    ('SV007', 'Bùi Văn G', 1, '2008-04-22', N'Hà Nội', '0967890123', 'L003'),
    ('SV008', 'Lý Thị H', 0, '2008-08-30', N'Hà Nội', '0978901234', 'L
"@
    
    $command2.ExecuteNonQuery()
    Write-Host "Tạo bảng và chèn dữ liệu thành công!" -ForegroundColor Green
    
    $connection2.Close()
}
catch {
    Write-Host "Lỗi: $_" -ForegroundColor Red
}
