using BusinessLogicLayer;
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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void BT_Login_Click(object sender, EventArgs e)
        {
            string TenDangNhap = TB_TenDangNhap.Text;
            string MatKhau = TB_MatKhau.Text;
            NhanVienBus nvbus = new NhanVienBus();
            if (nvbus.Kiemtrataikhoan(TenDangNhap, MatKhau))
            {
                MessageBox.Show("Đã đăng nhập thành công");
                DialogResult = DialogResult.OK;
            }

            else
                MessageBox.Show("Vui lòng xem lại user và password");
        }
    }
}
