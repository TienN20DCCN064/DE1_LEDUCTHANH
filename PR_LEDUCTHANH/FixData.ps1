# Thay thế dữ liệu tiếng Việt bằng tiếng Anh/không ký tự đặc biệt
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
    Write-Host "Xoa du lieu cu thanh cong!" -ForegroundColor Green
    
    # Chèn dữ liệu lớp bằng tiếng Anh
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    INSERT INTO Lop VALUES
    ('L001', 'Class 10A1'),
    ('L002', 'Class 10A2'),
    ('L003', 'Class 10B1');
"@
    $command.ExecuteNonQuery()
    
    # Chèn dữ liệu sinh viên bằng tiếng Anh
    $command = $connection.CreateCommand()
    $command.CommandText = @"
    INSERT INTO SinhVien VALUES
    ('SV001', 'Nguyen Van A', 1, '2008-01-15', 'Ha Noi', '0912345678', 'L001'),
    ('SV002', 'Tran Thi B', 0, '2008-05-20', 'Ha Noi', '0987654321', 'L001'),
    ('SV003', 'Pham Van C', 1, '2008-03-10', 'Ha Noi', '0913456789', 'L001'),
    ('SV004', 'Hoang Thi D', 0, '2008-07-25', 'Ha Noi', '0934567890', 'L002'),
    ('SV005', 'Vo Van E', 1, '2008-02-14', 'Ha Noi', '0945678901', 'L002'),
    ('SV006', 'Dang Thi F', 0, '2008-06-18', 'Ha Noi', '0956789012', 'L002'),
    ('SV007', 'Bui Van G', 1, '2008-04-22', 'Ha Noi', '0967890123', 'L003'),
    ('SV008', 'Ly Thi H', 0, '2008-08-30', 'Ha Noi', '0978901234', 'L003');
"@
    $command.ExecuteNonQuery()
    Write-Host "Chen du lieu thanh cong!" -ForegroundColor Green
    
    $connection.Close()
}
catch {
    Write-Host "Loi: $_" -ForegroundColor Red
}
