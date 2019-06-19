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
            var manv = TB_TenDangNhap.Text;
            var mk = TB_MatKhau.Text;
            NhanVienBus nvbus = new NhanVienBus();
            if (nvbus.KiemTraTaiKhoan(manv, mk))
            {
                MessageBox.Show("Đã đăng nhập thành công");
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Vui lòng kiểm tra lại mã nhân viên và mật khẩu");
        }
    }
}
