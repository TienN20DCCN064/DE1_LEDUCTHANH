using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PR_LEDUCTHANH
{
    public partial class Frm_De1_LEDUCTHANH : Form
    {
        // Chuỗi kết nối tới database QLSV sử dụng SQL LocalDB
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Integrated Security=true;Database=QLSV;";

        public Frm_De1_LEDUCTHANH()
        {
            InitializeComponent();

            // Đăng ký sự kiện Load Form
            this.Load += Frm_De1_LEDUCTHANH_Load;
        }

        private void Frm_De1_LEDUCTHANH_Load(object sender, EventArgs e)
        {
            // Kiểm tra kết nối database trước
            if (!CheckDatabaseConnection())
            {
                MessageBox.Show(
                    "Không thể kết nối tới database QLSV.\n\n" +
                    "Vui lòng:\n" +
                    "1. Kiểm tra SQL Server đang chạy\n" +
                    "2. Chạy script DBInit.sql để tạo database\n" +
                    "3. Kiểm tra connection string trong code\n\n" +
                    "Connection: " + connString,
                    "Lỗi Kết Nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            
            // Load danh sách lớp khi Form mở
            LoadLop();
        }

        // Kiểm tra kết nối database
        private bool CheckDatabaseConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Chi tiết lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Load danh sách lớp vào ComboBox
        private void LoadLop()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaLop, TenLop FROM Lop ORDER BY TenLop", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        cmbLop.DataSource = dt;
                        cmbLop.DisplayMember = "TenLop";
                        cmbLop.ValueMember = "MaLop";
                        
                        // Thêm option "Chọn Tất Cả" vào đầu danh sách
                        DataRow row = dt.NewRow();
                        row["MaLop"] = "ALL";
                        row["TenLop"] = "Chọn Tất Cả";
                        dt.Rows.InsertAt(row, 0);
                        
                        cmbLop.DataSource = dt;
                        cmbLop.DisplayMember = "TenLop";
                        cmbLop.ValueMember = "MaLop";
                        cmbLop.SelectedIndex = -1;

                        cmbLop.SelectedIndexChanged += CmbLop_SelectedIndexChanged;
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu lớp học!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi kết nối database: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Khi chọn lớp hoặc Chọn Tất Cả
        private void CmbLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLop.SelectedValue == null) return;

            string malop = cmbLop.SelectedValue.ToString();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter da;
                    
                    if (malop == "ALL")
                    {
                        // Nếu chọn "Chọn Tất Cả", hiển thị tất cả sinh viên
                        da = new SqlDataAdapter(
                            @"SELECT MaSV AS 'Ma Sinh Vien', HoTen AS 'Ho Ten', 
                                      CASE WHEN Phai = 1 THEN 'Nam' ELSE 'Nu' END AS 'Gioi Tinh',
                                      NgaySinh AS 'Ngay Sinh', DiaChi AS 'Dia Chi', DienThoai AS 'Dien Thoai' 
                               FROM SinhVien ORDER BY MaSV", conn);
                    }
                    else
                    {
                        // Nếu chọn một lớp cụ thể
                        da = new SqlDataAdapter(
                            @"SELECT MaSV AS 'Ma Sinh Vien', HoTen AS 'Ho Ten', 
                                      CASE WHEN Phai = 1 THEN 'Nam' ELSE 'Nu' END AS 'Gioi Tinh',
                                      NgaySinh AS 'Ngay Sinh', DiaChi AS 'Dia Chi', DienThoai AS 'Dien Thoai' 
                               FROM SinhVien WHERE Malop=@Malop ORDER BY MaSV", conn);
                        da.SelectCommand.Parameters.AddWithValue("@Malop", malop);
                    }

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    
                    // Thêm row dấu "+" vào DataTable trước khi bind
                    DataRow addRow = dt.NewRow();
                    addRow[0] = "+";
                    dt.Rows.Add(addRow);
                    
                    dgvSinhVien.DataSource = dt;
                    
                    // Ẩn cột row header
                    dgvSinhVien.RowHeadersVisible = false;
                    
                    // Chỉnh lại kích thước cột
                    dgvSinhVien.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Loi khi tai du lieu sinh vien: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Click vào dấu "+" để thêm sinh viên mới
        private void DgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            
            // Kiểm tra xem cell đầu tiên của hàng có chứa "+" không
            if (dgvSinhVien.Rows[e.RowIndex].Cells[0].Value != null && 
                dgvSinhVien.Rows[e.RowIndex].Cells[0].Value.ToString() == "+")
            {
                BtnAdd_Click(null, null);
            }
        }

        // Nút Thoát - Đóng ứng dụng
        private void BtnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ban co chac chan muon thoat ung dung?", "Xac nhan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Nút Thêm Sinh Viên - Mở dialog nhập dữ liệu
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (FrmAddStudent frmAdd = new FrmAddStudent(connString))
            {
                if (frmAdd.ShowDialog() == DialogResult.OK)
                {
                    // Sau khi thêm thành công, reload dữ liệu
                    LoadLop();
                    MessageBox.Show("Them sinh vien thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
