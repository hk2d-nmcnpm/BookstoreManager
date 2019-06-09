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
    }
}
