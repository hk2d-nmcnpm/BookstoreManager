using BusinessLogicLayer;
using System;
using System.Security.Cryptography;
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
            var mk = CalculateMD5Hash(TB_MatKhau.Text);
            //Console.WriteLine(mk);
            NhanVienBus nvbus = new NhanVienBus();
            if (nvbus.KiemTraTaiKhoan(manv, mk))
            {
                MessageBox.Show("Đã đăng nhập thành công");
                DialogResult = DialogResult.OK;
            }
            else
                MessageBox.Show("Vui lòng kiểm tra lại mã nhân viên và mật khẩu");
        }
        public static string CalculateMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
