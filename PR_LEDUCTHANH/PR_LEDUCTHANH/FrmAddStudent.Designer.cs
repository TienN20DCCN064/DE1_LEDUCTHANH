namespace PR_LEDUCTHANH
{
    partial class FrmAddStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            Label label1 = new Label();
            Label label2 = new Label();
            Label label3 = new Label();
            Label label4 = new Label();
            Label label5 = new Label();
            Label label6 = new Label();
            Label label7 = new Label();
            
            txtMaSV = new TextBox();
            txtHoTen = new TextBox();
            rbNam = new RadioButton();
            rbNu = new RadioButton();
            dtpNgaySinh = new DateTimePicker();
            txtDiaChi = new TextBox();
            txtDienThoai = new TextBox();
            cmbLopAdd = new ComboBox();
            BtnSave = new Button();
            BtnCancel = new Button();

            SuspendLayout();

            // label1 - Mã SV
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(20, 20);
            label1.Text = "Mã Sinh Viên:";

            // txtMaSV
            txtMaSV.Font = new Font("Segoe UI", 10F);
            txtMaSV.Location = new Point(150, 20);
            txtMaSV.Size = new Size(200, 30);

            // label2 - Họ Tên
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(20, 60);
            label2.Text = "Họ Tên:";

            // txtHoTen
            txtHoTen.Font = new Font("Segoe UI", 10F);
            txtHoTen.Location = new Point(150, 60);
            txtHoTen.Size = new Size(200, 30);

            // label3 - Giới Tính
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(20, 100);
            label3.Text = "Giới Tính:";

            // rbNam
            rbNam.AutoSize = true;
            rbNam.Font = new Font("Segoe UI", 10F);
            rbNam.Location = new Point(150, 100);
            rbNam.Text = "Nam";
            rbNam.Checked = true;

            // rbNu
            rbNu.AutoSize = true;
            rbNu.Font = new Font("Segoe UI", 10F);
            rbNu.Location = new Point(230, 100);
            rbNu.Text = "Nữ";

            // label4 - Ngày Sinh
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(20, 140);
            label4.Text = "Ngày Sinh:";

            // dtpNgaySinh
            dtpNgaySinh.Font = new Font("Segoe UI", 10F);
            dtpNgaySinh.Location = new Point(150, 140);
            dtpNgaySinh.Size = new Size(200, 30);

            // label5 - Địa Chỉ
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(20, 180);
            label5.Text = "Địa Chỉ:";

            // txtDiaChi
            txtDiaChi.Font = new Font("Segoe UI", 10F);
            txtDiaChi.Location = new Point(150, 180);
            txtDiaChi.Size = new Size(200, 30);

            // label6 - Điện Thoại
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F);
            label6.Location = new Point(20, 220);
            label6.Text = "Điện Thoại:";

            // txtDienThoai
            txtDienThoai.Font = new Font("Segoe UI", 10F);
            txtDienThoai.Location = new Point(150, 220);
            txtDienThoai.Size = new Size(200, 30);

            // label7 - Lớp
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F);
            label7.Location = new Point(20, 260);
            label7.Text = "Lớp:";

            // cmbLopAdd
            cmbLopAdd.Font = new Font("Segoe UI", 10F);
            cmbLopAdd.FormattingEnabled = true;
            cmbLopAdd.Location = new Point(150, 260);
            cmbLopAdd.Size = new Size(200, 32);

            // BtnSave
            BtnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnSave.Location = new Point(150, 310);
            BtnSave.Size = new Size(90, 35);
            BtnSave.Text = "Lưu";
            BtnSave.Click += BtnSave_Click;

            // BtnCancel
            BtnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            BtnCancel.Location = new Point(260, 310);
            BtnCancel.Size = new Size(90, 35);
            BtnCancel.Text = "Hủy";
            BtnCancel.Click += BtnCancel_Click;

            // FrmAddStudent
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(400, 370);
            Controls.Add(label1);
            Controls.Add(txtMaSV);
            Controls.Add(label2);
            Controls.Add(txtHoTen);
            Controls.Add(label3);
            Controls.Add(rbNam);
            Controls.Add(rbNu);
            Controls.Add(label4);
            Controls.Add(dtpNgaySinh);
            Controls.Add(label5);
            Controls.Add(txtDiaChi);
            Controls.Add(label6);
            Controls.Add(txtDienThoai);
            Controls.Add(label7);
            Controls.Add(cmbLopAdd);
            Controls.Add(BtnSave);
            Controls.Add(BtnCancel);

            Font = new Font("Segoe UI", 10F);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FrmAddStudent";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Sinh Viên Mới";
            ResumeLayout(false);
            PerformLayout();
        }

        private TextBox txtMaSV;
        private TextBox txtHoTen;
        private RadioButton rbNam;
        private RadioButton rbNu;
        private DateTimePicker dtpNgaySinh;
        private TextBox txtDiaChi;
        private TextBox txtDienThoai;
        private ComboBox cmbLopAdd;
        private Button BtnSave;
        private Button BtnCancel;
    }
}
