namespace BookstoreManager
{
    partial class Regulation
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
            this.QD_BTN_Luu = new System.Windows.Forms.Button();
            this.QD_BTN_ChinhSua = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.QD_TB_ToiThieu = new System.Windows.Forms.TextBox();
            this.QD_TB_TienNo = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.QD_CKB = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.QD_TB_Ton = new System.Windows.Forms.TextBox();
            this.QD_TB_Nhap = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // QD_BTN_Luu
            // 
            this.QD_BTN_Luu.Enabled = false;
            this.QD_BTN_Luu.Location = new System.Drawing.Point(390, 367);
            this.QD_BTN_Luu.Margin = new System.Windows.Forms.Padding(2);
            this.QD_BTN_Luu.Name = "QD_BTN_Luu";
            this.QD_BTN_Luu.Size = new System.Drawing.Size(69, 26);
            this.QD_BTN_Luu.TabIndex = 13;
            this.QD_BTN_Luu.Text = "Lưu";
            this.QD_BTN_Luu.UseVisualStyleBackColor = true;
            this.QD_BTN_Luu.Click += new System.EventHandler(this.QD_BTN_Luu_Click);
            // 
            // QD_BTN_ChinhSua
            // 
            this.QD_BTN_ChinhSua.Location = new System.Drawing.Point(257, 367);
            this.QD_BTN_ChinhSua.Margin = new System.Windows.Forms.Padding(2);
            this.QD_BTN_ChinhSua.Name = "QD_BTN_ChinhSua";
            this.QD_BTN_ChinhSua.Size = new System.Drawing.Size(74, 26);
            this.QD_BTN_ChinhSua.TabIndex = 12;
            this.QD_BTN_ChinhSua.Text = "Chỉnh sửa";
            this.QD_BTN_ChinhSua.UseVisualStyleBackColor = true;
            this.QD_BTN_ChinhSua.Click += new System.EventHandler(this.QD_BTN_ChinhSua_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.QD_TB_ToiThieu);
            this.groupBox6.Controls.Add(this.QD_TB_TienNo);
            this.groupBox6.Controls.Add(this.label33);
            this.groupBox6.Controls.Add(this.label28);
            this.groupBox6.Location = new System.Drawing.Point(212, 129);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox6.Size = new System.Drawing.Size(346, 93);
            this.groupBox6.TabIndex = 10;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Quy định 2";
            // 
            // QD_TB_ToiThieu
            // 
            this.QD_TB_ToiThieu.Enabled = false;
            this.QD_TB_ToiThieu.Location = new System.Drawing.Point(225, 50);
            this.QD_TB_ToiThieu.Margin = new System.Windows.Forms.Padding(2);
            this.QD_TB_ToiThieu.Name = "QD_TB_ToiThieu";
            this.QD_TB_ToiThieu.Size = new System.Drawing.Size(81, 20);
            this.QD_TB_ToiThieu.TabIndex = 4;
            this.QD_TB_ToiThieu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // QD_TB_TienNo
            // 
            this.QD_TB_TienNo.Enabled = false;
            this.QD_TB_TienNo.Location = new System.Drawing.Point(225, 18);
            this.QD_TB_TienNo.Margin = new System.Windows.Forms.Padding(2);
            this.QD_TB_TienNo.Name = "QD_TB_TienNo";
            this.QD_TB_TienNo.Size = new System.Drawing.Size(81, 20);
            this.QD_TB_TienNo.TabIndex = 3;
            this.QD_TB_TienNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(13, 56);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(148, 13);
            this.label33.TabIndex = 2;
            this.label33.Text = "Số lượng tồn tối thiểu sau bán";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(13, 26);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(133, 13);
            this.label28.TabIndex = 1;
            this.label28.Text = "Số tiền nợ cho phép tối đa";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.QD_CKB);
            this.groupBox7.Location = new System.Drawing.Point(212, 253);
            this.groupBox7.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox7.Size = new System.Drawing.Size(346, 84);
            this.groupBox7.TabIndex = 11;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Quy định 3";
            // 
            // QD_CKB
            // 
            this.QD_CKB.AutoSize = true;
            this.QD_CKB.Enabled = false;
            this.QD_CKB.Location = new System.Drawing.Point(57, 43);
            this.QD_CKB.Margin = new System.Windows.Forms.Padding(2);
            this.QD_CKB.Name = "QD_CKB";
            this.QD_CKB.Size = new System.Drawing.Size(259, 17);
            this.QD_CKB.TabIndex = 0;
            this.QD_CKB.Text = "Số tiền thu không được phép vượt quá số tiền nợ";
            this.QD_CKB.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.QD_TB_Ton);
            this.groupBox5.Controls.Add(this.QD_TB_Nhap);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Location = new System.Drawing.Point(212, 17);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox5.Size = new System.Drawing.Size(346, 90);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Quy định 1";
            // 
            // QD_TB_Ton
            // 
            this.QD_TB_Ton.Enabled = false;
            this.QD_TB_Ton.Location = new System.Drawing.Point(225, 59);
            this.QD_TB_Ton.Margin = new System.Windows.Forms.Padding(2);
            this.QD_TB_Ton.Name = "QD_TB_Ton";
            this.QD_TB_Ton.Size = new System.Drawing.Size(81, 20);
            this.QD_TB_Ton.TabIndex = 3;
            this.QD_TB_Ton.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // QD_TB_Nhap
            // 
            this.QD_TB_Nhap.Enabled = false;
            this.QD_TB_Nhap.Location = new System.Drawing.Point(225, 21);
            this.QD_TB_Nhap.Margin = new System.Windows.Forms.Padding(2);
            this.QD_TB_Nhap.Name = "QD_TB_Nhap";
            this.QD_TB_Nhap.Size = new System.Drawing.Size(81, 20);
            this.QD_TB_Nhap.TabIndex = 2;
            this.QD_TB_Nhap.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 65);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(172, 13);
            this.label21.TabIndex = 1;
            this.label21.Text = "Số lượng tồn tối đa cho phép nhập";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 26);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(116, 13);
            this.label20.TabIndex = 0;
            this.label20.Text = "Số lượng nhập tối thiểu";
            // 
            // Regulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 410);
            this.Controls.Add(this.QD_BTN_Luu);
            this.Controls.Add(this.QD_BTN_ChinhSua);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.MaximizeBox = false;
            this.Name = "Regulation";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quy định";
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.Button QD_BTN_Luu;
        public System.Windows.Forms.Button QD_BTN_ChinhSua;
        public System.Windows.Forms.TextBox QD_TB_ToiThieu;
        public System.Windows.Forms.TextBox QD_TB_TienNo;
        public System.Windows.Forms.CheckBox QD_CKB;
        public System.Windows.Forms.TextBox QD_TB_Ton;
        public System.Windows.Forms.TextBox QD_TB_Nhap;
    }
}