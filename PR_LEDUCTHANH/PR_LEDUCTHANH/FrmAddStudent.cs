using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PR_LEDUCTHANH
{
    public partial class FrmAddStudent : Form
    {
        private string connString;

        public FrmAddStudent(string connectionString)
        {
            InitializeComponent();
            connString = connectionString;
            LoadLopComboBox();
        }

        private void LoadLopComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaLop, TenLop FROM Lop ORDER BY TenLop", conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbLopAdd.DataSource = dt;
                    cmbLopAdd.DisplayMember = "TenLop";
                    cmbLopAdd.ValueMember = "MaLop";
                    cmbLopAdd.SelectedIndex = 0;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu
            if (string.IsNullOrWhiteSpace(txtMaSV.Text))
            {
                MessageBox.Show("Vui lòng nhập mã sinh viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        @"INSERT INTO SinhVien (MaSV, HoTen, Phai, NgaySinh, DiaChi, DienThoai, Malop) 
                          VALUES (@MaSV, @HoTen, @Phai, @NgaySinh, @DiaChi, @DienThoai, @Malop)", conn);

                    cmd.Parameters.AddWithValue("@MaSV", txtMaSV.Text);
                    cmd.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    cmd.Parameters.AddWithValue("@Phai", rbNam.Checked ? 1 : 0);
                    cmd.Parameters.AddWithValue("@NgaySinh", dtpNgaySinh.Value);
                    cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                    cmd.Parameters.AddWithValue("@DienThoai", txtDienThoai.Text);
                    cmd.Parameters.AddWithValue("@Malop", cmbLopAdd.SelectedValue.ToString());

                    cmd.ExecuteNonQuery();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
