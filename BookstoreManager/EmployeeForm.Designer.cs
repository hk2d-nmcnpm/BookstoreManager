namespace BookstoreManager
{
    partial class EmployeeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BT_Huy = new System.Windows.Forms.Button();
            this.BT_Luu = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_MatKhau = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_HoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_MaNV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CBB_ChucVu = new System.Windows.Forms.ComboBox();
            this.DTP_NgaySinh = new System.Windows.Forms.DateTimePicker();
            this.CB_HienMatKhau = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_Huy
            // 
            this.BT_Huy.Location = new System.Drawing.Point(275, 377);
            this.BT_Huy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Huy.Name = "BT_Huy";
            this.BT_Huy.Size = new System.Drawing.Size(88, 32);
            this.BT_Huy.TabIndex = 14;
            this.BT_Huy.Text = "Hủy bỏ";
            this.BT_Huy.UseVisualStyleBackColor = true;
            this.BT_Huy.Click += new System.EventHandler(this.BT_Huy_Click);
            // 
            // BT_Luu
            // 
            this.BT_Luu.Location = new System.Drawing.Point(368, 377);
            this.BT_Luu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BT_Luu.Name = "BT_Luu";
            this.BT_Luu.Size = new System.Drawing.Size(85, 32);
            this.BT_Luu.TabIndex = 13;
            this.BT_Luu.Text = "Lưu lại";
            this.BT_Luu.UseVisualStyleBackColor = true;
            this.BT_Luu.Click += new System.EventHandler(this.BT_Luu_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CB_HienMatKhau);
            this.groupBox1.Controls.Add(this.DTP_NgaySinh);
            this.groupBox1.Controls.Add(this.CBB_ChucVu);
            this.groupBox1.Controls.Add(this.TB_MatKhau);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_HoTen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_MaNV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 9);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(451, 359);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // TB_MatKhau
            // 
            this.TB_MatKhau.Location = new System.Drawing.Point(11, 319);
            this.TB_MatKhau.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_MatKhau.Name = "TB_MatKhau";
            this.TB_MatKhau.Size = new System.Drawing.Size(432, 27);
            this.TB_MatKhau.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 295);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Mật khẩu mới:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 228);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Chức vụ:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ngày sinh:";
            // 
            // TB_HoTen
            // 
            this.TB_HoTen.Location = new System.Drawing.Point(11, 118);
            this.TB_HoTen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_HoTen.Name = "TB_HoTen";
            this.TB_HoTen.Size = new System.Drawing.Size(432, 27);
            this.TB_HoTen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ và tên: ";
            // 
            // TB_MaNV
            // 
            this.TB_MaNV.Enabled = false;
            this.TB_MaNV.Location = new System.Drawing.Point(11, 55);
            this.TB_MaNV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TB_MaNV.Name = "TB_MaNV";
            this.TB_MaNV.Size = new System.Drawing.Size(432, 27);
            this.TB_MaNV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã nhân viên: ";
            // 
            // CBB_ChucVu
            // 
            this.CBB_ChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBB_ChucVu.FormattingEnabled = true;
            this.CBB_ChucVu.Location = new System.Drawing.Point(11, 254);
            this.CBB_ChucVu.Name = "CBB_ChucVu";
            this.CBB_ChucVu.Size = new System.Drawing.Size(432, 28);
            this.CBB_ChucVu.TabIndex = 12;
            // 
            // DTP_NgaySinh
            // 
            this.DTP_NgaySinh.CustomFormat = "dd/MM/yyyy";
            this.DTP_NgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_NgaySinh.Location = new System.Drawing.Point(11, 187);
            this.DTP_NgaySinh.Name = "DTP_NgaySinh";
            this.DTP_NgaySinh.Size = new System.Drawing.Size(432, 27);
            this.DTP_NgaySinh.TabIndex = 13;
            // 
            // CB_HienMatKhau
            // 
            this.CB_HienMatKhau.AutoSize = true;
            this.CB_HienMatKhau.Location = new System.Drawing.Point(311, 294);
            this.CB_HienMatKhau.Name = "CB_HienMatKhau";
            this.CB_HienMatKhau.Size = new System.Drawing.Size(139, 24);
            this.CB_HienMatKhau.TabIndex = 14;
            this.CB_HienMatKhau.Text = "Hiện mật khẩu";
            this.CB_HienMatKhau.UseVisualStyleBackColor = true;
            this.CB_HienMatKhau.CheckedChanged += new System.EventHandler(this.CB_HienMatKhau_CheckedChanged);
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 418);
            this.Controls.Add(this.BT_Huy);
            this.Controls.Add(this.BT_Luu);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "EmployeeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thông tin nhân viên";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button BT_Huy;
        public System.Windows.Forms.Button BT_Luu;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DateTimePicker DTP_NgaySinh;
        public System.Windows.Forms.ComboBox CBB_ChucVu;
        public System.Windows.Forms.TextBox TB_MatKhau;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox TB_HoTen;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox TB_MaNV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox CB_HienMatKhau;
    }
}