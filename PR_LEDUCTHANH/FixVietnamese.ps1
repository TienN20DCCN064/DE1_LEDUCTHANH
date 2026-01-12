# Sửa dữ liệu tiếng Việt trong database
$connectionString = "Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Initial Catalog=QLSV;"

try {
    $connection = New-Object System.Data.SqlClient.SqlConnection
    $connection.ConnectionString = $connectionString
    $connection.Open()
    
    # Xóa dữ liệu cũ
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    DELETE FROM SinhVien;
    DELETE FROM Lop;
"@
    $command.ExecuteNonQuery()
    Write-Host "Xóa dữ liệu cũ thành công!" -ForegroundColor Green
    
    # Chèn dữ liệu lớp
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    INSERT INTO Lop VALUES
    ('L001', N'Lớp 10A1'),
    ('L002', N'Lớp 10A2'),
    ('L003', N'Lop 10B1');
"@
    $command.ExecuteNonQuery()
    
    # Chèn dữ liệu sinh viên
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    INSERT INTO SinhVien VALUES
    ('SV001', N'Nguyễn Văn A', 1, '2008-01-15', N'Hà Nội', '0912345678', 'L001'),
    ('SV002', N'Trần Thị B', 0, '2008-05-20', N'Hà Nội', '0987654321', 'L001'),
    ('SV003', N'Phạm Văn C', 1, '2008-03-10', N'Hà Nội', '0913456789', 'L001'),
    ('SV004', N'Hoàng Thị D', 0, '2008-07-25', N'Hà Nội', '0934567890', 'L002'),
    ('SV005', N'Võ Văn E', 1, '2008-02-14', N'Hà Nội', '0945678901', 'L002'),
    ('SV006', N'Đặng Thị F', 0, '2008-06-18', N'Hà Nội', '0956789012', 'L002'),
    ('SV007', N'Bùi Văn G', 1, '2008-04-22', N'Hà Nội', '0967890123', 'L003'),
    ('SV008', N'Lý Thị H', 0, '2008-08-30', N'Hà Nội', '0978901234', 'L003');
"@
    $command.ExecuteNonQuery()
    Write-Host "Chèn dữ liệu tiếng Việt thành công!" -ForegroundColor Green
    
    $connection.Close()
}
catch {
    Write-Host "Lỗi: $_" -ForegroundColor Red
}
