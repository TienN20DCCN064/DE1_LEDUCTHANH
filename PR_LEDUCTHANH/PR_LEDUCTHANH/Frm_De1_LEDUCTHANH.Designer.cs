namespace PR_LEDUCTHANH
{
    partial class Frm_De1_LEDUCTHANH
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            cmbLop = new ComboBox();
            btnExit = new Button();
            dgvSinhVien = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(120, 28);
            label1.TabIndex = 0;
            label1.Text = "Chon Lop:";
            // 
            // cmbLop
            // 
            cmbLop.Font = new Font("Segoe UI", 11F);
            cmbLop.FormattingEnabled = true;
            cmbLop.Location = new Point(150, 18);
            cmbLop.Name = "cmbLop";
            cmbLop.Size = new Size(500, 32);
            cmbLop.TabIndex = 1;
            // 
            // btnExit
            // 
            btnExit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnExit.Location = new Point(660, 18);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(100, 32);
            btnExit.TabIndex = 2;
            btnExit.Text = "Exit";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += BtnExit_Click;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(20, 70);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.Size = new Size(750, 350);
            dgvSinhVien.TabIndex = 3;
            dgvSinhVien.CellClick += DgvSinhVien_CellClick;
            // 
            // Frm_De1_LEDUCTHANH
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvSinhVien);
            Controls.Add(btnExit);
            Controls.Add(cmbLop);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 10F);
            Name = "Frm_De1_LEDUCTHANH";
            Text = "Le Duc Thanh - DE1";
            Load += Frm_De1_LEDUCTHANH_Load;
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbLop;
        private Button btnExit;
        private DataGridView dgvSinhVien;
    }
}
