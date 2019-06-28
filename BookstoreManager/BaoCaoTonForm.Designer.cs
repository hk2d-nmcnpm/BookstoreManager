namespace BookstoreManager
{
    partial class BaoCaoTonForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnLap = new System.Windows.Forms.Button();
            this.CBB_Nam = new System.Windows.Forms.ComboBox();
            this.CBB_Thang = new System.Windows.Forms.ComboBox();
            this.reportViewerTon = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLuu);
            this.panel1.Controls.Add(this.btnLap);
            this.panel1.Controls.Add(this.CBB_Nam);
            this.panel1.Controls.Add(this.CBB_Thang);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(925, 109);
            this.panel1.TabIndex = 0;
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(647, 29);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(108, 33);
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "Lưu vào database";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnLap
            // 
            this.btnLap.Location = new System.Drawing.Point(504, 30);
            this.btnLap.Name = "btnLap";
            this.btnLap.Size = new System.Drawing.Size(94, 31);
            this.btnLap.TabIndex = 2;
            this.btnLap.Text = "Lập báo cáo";
            this.btnLap.UseVisualStyleBackColor = true;
            this.btnLap.Click += new System.EventHandler(this.btnLap_Click);
            // 
            // CBB_Nam
            // 
            this.CBB_Nam.FormattingEnabled = true;
            this.CBB_Nam.Location = new System.Drawing.Point(300, 36);
            this.CBB_Nam.Name = "CBB_Nam";
            this.CBB_Nam.Size = new System.Drawing.Size(121, 21);
            this.CBB_Nam.TabIndex = 1;
            // 
            // CBB_Thang
            // 
            this.CBB_Thang.FormattingEnabled = true;
            this.CBB_Thang.Location = new System.Drawing.Point(122, 36);
            this.CBB_Thang.Name = "CBB_Thang";
            this.CBB_Thang.Size = new System.Drawing.Size(121, 21);
            this.CBB_Thang.TabIndex = 0;
            // 
            // reportViewerTon
            // 
            this.reportViewerTon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewerTon.Location = new System.Drawing.Point(0, 0);
            this.reportViewerTon.Name = "ReportViewer";
            this.reportViewerTon.ServerReport.BearerToken = null;
            this.reportViewerTon.Size = new System.Drawing.Size(925, 356);
            this.reportViewerTon.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.reportViewerTon);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(925, 356);
            this.panel2.TabIndex = 1;
            // 
            // BaoCaoTonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 465);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BaoCaoTonForm";
            this.ShowIcon = false;
            this.Text = "Báo cáo tồn";
            this.Load += new System.EventHandler(this.BaoCaoTonForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnLap;
        private System.Windows.Forms.ComboBox CBB_Nam;
        private System.Windows.Forms.ComboBox CBB_Thang;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewerTon;
        private System.Windows.Forms.Panel panel2;
    }
}