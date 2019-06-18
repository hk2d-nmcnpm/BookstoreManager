namespace BookstoreManager
{
    partial class CustomerForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TB_Email = new System.Windows.Forms.TextBox();
            this.TB_DiaChi = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TB_SDT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TB_HoTen = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_MaKH = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BT_Luu = new System.Windows.Forms.Button();
            this.BT_Huy = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TB_Email);
            this.groupBox1.Controls.Add(this.TB_DiaChi);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.TB_SDT);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.TB_HoTen);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TB_MaKH);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(338, 292);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin";
            // 
            // TB_Email
            // 
            this.TB_Email.Location = new System.Drawing.Point(8, 259);
            this.TB_Email.Margin = new System.Windows.Forms.Padding(2);
            this.TB_Email.Name = "TB_Email";
            this.TB_Email.Size = new System.Drawing.Size(325, 23);
            this.TB_Email.TabIndex = 11;
            // 
            // TB_DiaChi
            // 
            this.TB_DiaChi.Location = new System.Drawing.Point(8, 204);
            this.TB_DiaChi.Margin = new System.Windows.Forms.Padding(2);
            this.TB_DiaChi.Name = "TB_DiaChi";
            this.TB_DiaChi.Size = new System.Drawing.Size(325, 23);
            this.TB_DiaChi.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 240);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "Email:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 185);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Địa chỉ:";
            // 
            // TB_SDT
            // 
            this.TB_SDT.Location = new System.Drawing.Point(8, 150);
            this.TB_SDT.Margin = new System.Windows.Forms.Padding(2);
            this.TB_SDT.Name = "TB_SDT";
            this.TB_SDT.Size = new System.Drawing.Size(325, 23);
            this.TB_SDT.TabIndex = 5;
            this.TB_SDT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TB_SDT_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 131);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số điện thoại:";
            // 
            // TB_HoTen
            // 
            this.TB_HoTen.Location = new System.Drawing.Point(8, 96);
            this.TB_HoTen.Margin = new System.Windows.Forms.Padding(2);
            this.TB_HoTen.Name = "TB_HoTen";
            this.TB_HoTen.Size = new System.Drawing.Size(325, 23);
            this.TB_HoTen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 77);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Họ và tên: ";
            // 
            // TB_MaKH
            // 
            this.TB_MaKH.Enabled = false;
            this.TB_MaKH.Location = new System.Drawing.Point(8, 45);
            this.TB_MaKH.Margin = new System.Windows.Forms.Padding(2);
            this.TB_MaKH.Name = "TB_MaKH";
            this.TB_MaKH.Size = new System.Drawing.Size(325, 23);
            this.TB_MaKH.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã khách hàng: ";
            // 
            // BT_Luu
            // 
            this.BT_Luu.Location = new System.Drawing.Point(276, 307);
            this.BT_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.BT_Luu.Name = "BT_Luu";
            this.BT_Luu.Size = new System.Drawing.Size(64, 26);
            this.BT_Luu.TabIndex = 9;
            this.BT_Luu.Text = "Lưu lại";
            this.BT_Luu.UseVisualStyleBackColor = true;
            this.BT_Luu.Click += new System.EventHandler(this.BT_Luu_Click);
            // 
            // BT_Huy
            // 
            this.BT_Huy.Location = new System.Drawing.Point(206, 307);
            this.BT_Huy.Margin = new System.Windows.Forms.Padding(2);
            this.BT_Huy.Name = "BT_Huy";
            this.BT_Huy.Size = new System.Drawing.Size(66, 26);
            this.BT_Huy.TabIndex = 11;
            this.BT_Huy.Text = "Hủy bỏ";
            this.BT_Huy.UseVisualStyleBackColor = true;
            this.BT_Huy.Click += new System.EventHandler(this.BT_Huy_Click);
            // 
            // CustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 339);
            this.Controls.Add(this.BT_Huy);
            this.Controls.Add(this.BT_Luu);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "CustomerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Khách hàng";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.TextBox TB_SDT;
        public System.Windows.Forms.TextBox TB_HoTen;
        public System.Windows.Forms.TextBox TB_MaKH;
        public System.Windows.Forms.TextBox TB_Email;
        public System.Windows.Forms.TextBox TB_DiaChi;
        public System.Windows.Forms.Button BT_Luu;
        public System.Windows.Forms.Button BT_Huy;
    }
}