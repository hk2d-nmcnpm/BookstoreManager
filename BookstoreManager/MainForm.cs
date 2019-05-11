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
    public partial class MainForm : Form
    {
        //field
        bool _anThanhMenu;

        public MainForm()
        {
            InitializeComponent();
            MainTab.ItemSize = new Size(0, 1);
            _anThanhMenu = false;
        }
        private void BT_KhoSach_ThemSach_Click(object sender, EventArgs e)
        {
            BookDetailsForm form = new BookDetailsForm();
            form.ShowDialog();
        }
        private void MN_TraCuu_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_TraCuuSach;
            LB_TieuDe.Text = "Tra cứu sách";
        }
        private void MN_HoaDon_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_DSHoaDon;
            LB_TieuDe.Text = "Danh sách hóa đơn";
        }
        private void MN_NhapSach_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_DSPhieuNhap;
            LB_TieuDe.Text = "Danh sách phiếu nhập sách";
        }
        private void MN_PhieuThu_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_DSPhieuThu;
            LB_TieuDe.Text = "Phiếu thu tiền";
        }
        private void MN_BaoCaoTon_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_BaoCaoTon;
            LB_TieuDe.Text = "Báo cáo tồn";
        }
        private void MN_BaoCaoNo_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_BaoCaoNo;
            LB_TieuDe.Text = "Báo cáo nợ";
        }
        private void MN_KhachHang_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_DSKhachHang;
            LB_TieuDe.Text = "Danh sách khách hàng";
        }

        private void BT_DSHoaDon_TaoHoaDon_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_TaoHoaDon;
            LB_TieuDe.Text = "Tạo hóa đơn";
        }

        private void BT_TaoHoaDon_HuyDon_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_DSHoaDon;
            LB_TieuDe.Text = "Danh sách hóa đơn";
        }

        private void BT_DSPhieuNhap_TaoPhieuNhap_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_TaoPhieuNhapSach;
            LB_TieuDe.Text = "Tạo phiếu nhập sách";
        }

        private void BT_PhieuNhapSach_HuyPhieu_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_DSPhieuNhap;
            LB_TieuDe.Text = "Danh sách phiếu nhập sách";
        }

        private void BT_KhachHang_TaoKhachHang_Click(object sender, EventArgs e)
        {
            CustomerForm _form = new CustomerForm();
            _form.ShowDialog();
        }
        private void BT_AnHienMenu_Click(object sender, EventArgs e)
        {
            const int _distance = 60;
            if(_anThanhMenu == false)
            {
                MainSplitContainer.SplitterDistance = _distance;
                BT_AnHienMenu.Text = "Hiện";
                PN_BanQuyen.Size = new Size(_distance, 26);
                _anThanhMenu = true;
            }
            else
            {
                MainSplitContainer.SplitterDistance = 260;
                BT_AnHienMenu.Text = "Ẩn";
                PN_BanQuyen.Size = new Size(260, 50);
                _anThanhMenu = false;
            }
        }

        private void BT_DSPhieuThu_TaoPhieuThu_Click(object sender, EventArgs e)
        {
            ReceiptForm form = new ReceiptForm();
            form.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if(loginForm.ShowDialog() == DialogResult.OK)
                return;
            else
                Close();
        }
    }
}
