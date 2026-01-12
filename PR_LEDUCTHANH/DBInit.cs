using System.Data.SqlClient;

namespace PR_LEDUCTHANH
{
    public static class DBInit
    {
        public static void CreateDatabase()
        {
            // Đường dẫn file database trên D:
            string dbFile = @"D:\LEDUCTHANH\QLSV.mdf";

            // Kết nối tới LocalDB master để tạo database
            string masterConn = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Database=master";

            using (SqlConnection conn = new SqlConnection(masterConn))
            {
                conn.Open();

                // Tạo database QLSV nếu chưa tồn tại
                string sqlCreateDB = $@"
IF DB_ID('QLSV') IS NULL
BEGIN
    CREATE DATABASE QLSV
    ON PRIMARY (NAME=QLSV_Data, FILENAME='{dbFile}', SIZE=5MB, MAXSIZE=50MB, FILEGROWTH=5MB)
END";

                using (SqlCommand cmd = new SqlCommand(sqlCreateDB, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }

            // Chuỗi kết nối tới database vừa tạo
            string connString = $@"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;AttachDbFilename={dbFile}";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                // Tạo bảng Lop
                string sqlLop = @"
IF OBJECT_ID('Lop','U') IS NULL
CREATE TABLE Lop(
    MaLop NVARCHAR(10) PRIMARY KEY,
    TenLop NVARCHAR(50) NOT NULL
)";
                new SqlCommand(sqlLop, conn).ExecuteNonQuery();

                // Tạo bảng SinhVien
                string sqlSV = @"
IF OBJECT_ID('SinhVien','U') IS NULL
CREATE TABLE SinhVien(
    MaSV NVARCHAR(10) PRIMARY KEY,
    HoTen NVARCHAR(50) NOT NULL,
    Phai NVARCHAR(3) NOT NULL,
    NgaySinh DATE NOT NULL,
    DiaChi NVARCHAR(100),
    DienThoai NVARCHAR(15),
    Malop NVARCHAR(10),
    FOREIGN KEY(Malop) REFERENCES Lop(MaLop)
)";
                new SqlCommand(sqlSV, conn).ExecuteNonQuery();

                // Thêm dữ liệu mẫu lớp
                string insertLop = @"
IF NOT EXISTS(SELECT * FROM Lop)
BEGIN
    INSERT INTO Lop VALUES ('L01','Công Nghệ Thông Tin 1')
    INSERT INTO Lop VALUES ('L02','Kế Toán 1')
END";
                new SqlCommand(insertLop, conn).ExecuteNonQuery();

                // Thêm dữ liệu mẫu sinh viên
                string insertSV = @"
IF NOT EXISTS(SELECT * FROM SinhVien)
BEGIN
    INSERT INTO SinhVien VALUES ('SV001','Nguyen Van A','Nam','2000-01-01','HN','0123456789','L01')
    INSERT INTO SinhVien VALUES ('SV002','Tran Thi B','Nu','2000-02-02','HN','0987654321','L01')
    INSERT INTO SinhVien VALUES ('SV003','Le Van C','Nam','2000-03-03','HN','0112233445','L02')
END";
                new SqlCommand(insertSV, conn).ExecuteNonQuery();
            }
        }
    }
}
