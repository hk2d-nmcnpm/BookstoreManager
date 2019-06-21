namespace BookstoreManager
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BookstoreName = new System.Windows.Forms.Label();
            this.BT_Login = new System.Windows.Forms.Button();
            this.TB_TenDangNhap = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_MatKhau = new System.Windows.Forms.TextBox();
            this.Link_QuenMatKhau = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.BookstoreName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(397, 62);
            this.panel1.TabIndex = 1;
            // 
            // BookstoreName
            // 
            this.BookstoreName.AutoSize = true;
            this.BookstoreName.Font = new System.Drawing.Font("Adobe Gothic Std B", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BookstoreName.ForeColor = System.Drawing.Color.White;
            this.BookstoreName.Location = new System.Drawing.Point(159, 19);
            this.BookstoreName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BookstoreName.Name = "BookstoreName";
            this.BookstoreName.Size = new System.Drawing.Size(125, 30);
            this.BookstoreName.TabIndex = 0;
            this.BookstoreName.Text = "Bookstore";
            // 
            // BT_Login
            // 
            this.BT_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.BT_Login.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(202)))), ((int)(((byte)(254)))));
            this.BT_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BT_Login.ForeColor = System.Drawing.Color.White;
            this.BT_Login.Location = new System.Drawing.Point(142, 331);
            this.BT_Login.Name = "BT_Login";
            this.BT_Login.Size = new System.Drawing.Size(120, 44);
            this.BT_Login.TabIndex = 2;
            this.BT_Login.Text = "Đăng nhập";
            this.BT_Login.UseVisualStyleBackColor = false;
            this.BT_Login.Click += new System.EventHandler(this.BT_Login_Click);
            // 
            // TB_TenDangNhap
            // 
            this.TB_TenDangNhap.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_TenDangNhap.Location = new System.Drawing.Point(29, 152);
            this.TB_TenDangNhap.Name = "TB_TenDangNhap";
            this.TB_TenDangNhap.Size = new System.Drawing.Size(337, 34);
            this.TB_TenDangNhap.TabIndex = 3;
            this.TB_TenDangNhap.Text = "000001";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(25, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mã nhân viên:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(25, 215);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mật khẩu:";
            // 
            // TB_MatKhau
            // 
            this.TB_MatKhau.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_MatKhau.Location = new System.Drawing.Point(29, 254);
            this.TB_MatKhau.Name = "TB_MatKhau";
            this.TB_MatKhau.PasswordChar = '●';
            this.TB_MatKhau.Size = new System.Drawing.Size(337, 34);
            this.TB_MatKhau.TabIndex = 5;
            this.TB_MatKhau.Text = "abcabc";
            // 
            // Link_QuenMatKhau
            // 
            this.Link_QuenMatKhau.AutoSize = true;
            this.Link_QuenMatKhau.LinkColor = System.Drawing.Color.White;
            this.Link_QuenMatKhau.Location = new System.Drawing.Point(96, 400);
            this.Link_QuenMatKhau.Name = "Link_QuenMatKhau";
            this.Link_QuenMatKhau.Size = new System.Drawing.Size(217, 23);
            this.Link_QuenMatKhau.TabIndex = 7;
            this.Link_QuenMatKhau.TabStop = true;
            this.Link_QuenMatKhau.Text = "Quên mật khẩu đăng nhập";
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::BookstoreManager.Properties.Resources.literature_32px1;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel2.Location = new System.Drawing.Point(123, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(37, 31);
            this.panel2.TabIndex = 8;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(159)))), ((int)(((byte)(199)))));
            this.ClientSize = new System.Drawing.Size(397, 447);
            this.Controls.Add(this.Link_QuenMatKhau);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TB_MatKhau);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_TenDangNhap);
            this.Controls.Add(this.BT_Login);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label BookstoreName;
        private System.Windows.Forms.Button BT_Login;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_MatKhau;
        private System.Windows.Forms.LinkLabel Link_QuenMatKhau;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TextBox TB_TenDangNhap;
    }
}