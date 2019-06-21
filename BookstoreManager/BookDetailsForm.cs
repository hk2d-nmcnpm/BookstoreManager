using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookstoreManager
{
    public partial class BookDetailsForm : Form
    {
        public BookDetailsForm()
        {
            InitializeComponent();
        }

        private void BT_Huy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void BT_Luu_Click(object sender, EventArgs e)
        {
            if (TB_MaSoSach.Text != "" &&
                TB_TenSach.Text != "" &&
                TB_TacGia.Text != "" &&
                TB_MoTa.Text != "" &&
                TB_NamXuatBan.Text != "" &&
                TB_NhaXuatBan.Text != "" &&
                TB_SoTrang.Text != "" &&
                TB_DonGia.Text != "")
                DialogResult = DialogResult.OK;
            else
                MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin", "Không thể lưu lại", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void TB_DonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TB_SoTrang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TB_NamXuatBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void BT_ThemAnhBia_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "*|*.png|*|*.jpg|*|*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName.ToString();
                    Image img = new Bitmap(filePath);
                    PTB_AnhBia.Image = img;
                }

            }
            catch { }
        }
    }
}
