using BusinessLogicLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace BookstoreManager
{
    public partial class MainForm : Form
    {
        //field
        bool _anThanhMenu;

        KhachHangBus khBus=new KhachHangBus();
        PhieuThuBus phieuthuBus = new PhieuThuBus();
        NhanVienBus nvBus = new NhanVienBus();
        SachBus sachBus = new SachBus();
        HoaDonBus hdBus = new HoaDonBus();
        ChiTietHoaDonBus cthdBus = new ChiTietHoaDonBus();
        PhieuNhapSachBus pnBus = new PhieuNhapSachBus();
        ChiTietPhieuNhapSachBus ctpnBus = new ChiTietPhieuNhapSachBus();
        BaoCaoTonBus bctBus = new BaoCaoTonBus();
        ChiTietBaoCaoTonBUS ctbctBus = new ChiTietBaoCaoTonBUS();

        NhanVien loginnv;
        DataTable dsSach;
        DataTable dsHoaDon;
        DataTable dsKhachHang;
        DataTable dsPhieuThu;
        DataTable dsPhieuNhap;
        DataTable baoCaoCongNo;
        DataTable baoCaoTon;
        DataTable dsTheLoaiSach;
        DataTable dsNhanVien;
        DataTable dsBaoCaoTonMonth;
        DataTable dsBaoCaoTonAll;


        List<int> thang = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        List<int> nam = new List<int>() { 2017, 2018, 2019 };

        public MainForm()
        {
            InitializeComponent();
            MainTab.ItemSize = new Size(0, 1);
            _anThanhMenu = false;
            CBB_BCT_Nam.DataSource = nam;
            CBB_BCT_Thang.DataSource = thang;
        }
        private void BT_KhoSach_ThemSach_Click(object sender, EventArgs e)
        {
            BookDetailsForm form = new BookDetailsForm();
            int last_book_id = 0;
            if(dsSach.Rows.Count > 0)
                last_book_id = int.Parse(dsSach.AsEnumerable().Last()["MaSach"].ToString());
            form.TB_MaSoSach.Text = (last_book_id+1).ToString("000000");
            form.CBB_TheLoai.DataSource = dsTheLoaiSach;
            form.CBB_TheLoai.DisplayMember = "TenTheLoai";
            form.CBB_TheLoai.ValueMember = "MaTheLoai";
            if(form.ShowDialog() == DialogResult.OK)
            {
                var sach = new Sach()
                {
                    MaSach = form.TB_MaSoSach.Text,
                    TenSach = form.TB_TenSach.Text,
                    DonGia = decimal.Parse(form.TB_DonGia.Text),
                    TacGia = form.TB_TacGia.Text,
                    MoTa = form.TB_MoTa.Text,
                    SoTrang = int.Parse(form.TB_SoTrang.Text),
                    MaTheLoai = form.CBB_TheLoai.SelectedValue.ToString(),
                    AnhBia = form.PTB_AnhBia.Image is null ? null : ConvertImageToByteArray(form.PTB_AnhBia.Image, form.PTB_AnhBia.Image.RawFormat),
                    NamXuatBan = int.Parse(form.TB_NamXuatBan.Text),
                    NhaXuatBan = form.TB_NhaXuatBan.Text,
                    SoLuongTon = 0
                };
                SachBus sb = new SachBus();
                if (sb.AddSach(sach))
                    Console.WriteLine("A book has been added");
                else
                    MessageBox.Show("Không thể tạo thêm sách, vui lòng kiểm tra lại", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }
        private void BT_DSPhieuThu_TaoPhieuThu_Click(object sender, EventArgs e)
        {
            ReceiptForm form = new ReceiptForm();
            int last_id = 0;
            if (dsPhieuNhap.Rows.Count > 0)
                last_id = int.Parse(dsPhieuThu.AsEnumerable().Last()["MaPhieuThu"].ToString());
            form.TB_MaPhieu.Text = (last_id + 1).ToString("000000");
            form.CBB_KhachHang.DataSource = new BindingSource(GetKhachHangDictionary(), null);
            form.CBB_KhachHang.DisplayMember = "Value";
            form.CBB_KhachHang.ValueMember = "Key";
            form.CBB_NhanVien.DataSource = new BindingSource(GetNhanVienDictionary(), null);
            form.CBB_NhanVien.DisplayMember = "Value";
            form.CBB_NhanVien.ValueMember = "Key";
            if(form.ShowDialog() == DialogResult.OK)
            {
                var pt = new PhieuThu()
                {
                    MaPhieuThu = form.TB_MaPhieu.Text,
                    MaKhachHang = form.CBB_KhachHang.SelectedValue.ToString(),
                    MaNhanVien = form.CBB_NhanVien.SelectedValue.ToString(),
                    NgayThu = form.DTP_NgayThu.Value,
                    SoTienThu = decimal.Parse(form.TB_SoTienThu.Text),
                    LyDoThu = form.TB_LyDoThu.Text,
                };

                KhachHang kh = new KhachHang();
                kh = khBus.GetKhachHangByMaKH(form.CBB_KhachHang.SelectedValue.ToString());
                kh.SoTienNo -= decimal.Parse(form.TB_SoTienThu.Text);
                khBus.UpdateKhachHang(kh);

               
                if (phieuthuBus.AddPhieuThu(pt))
                    Console.WriteLine("A receiption has been added");
                else
                    MessageBox.Show("Không thể tạo phiếu thu, vui lòng kiểm tra lại", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
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
            int last = 0;
            if (dsHoaDon.Rows.Count > 0)
                last = int.Parse(dsHoaDon.AsEnumerable().Last()["MaHoaDon"].ToString());
            TB_HoaDon_MaHoaDon.Text = (last + 1).ToString("000000");
            DGV_HoaDon.Rows.Clear();
            CBB_HoaDon_KhachHang.Text = "";
            CBB_HoaDon_NVBan.SelectedValue = loginnv.MaNhanVien;
            TB_HoaDon_GiamGia.Text = decimal.Zero.ToString();
            TB_HoaDon_KhachDua.Text = decimal.Zero.ToString();
            HoaDon_TinhTien();
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

            dsPhieuNhap = new PhieuNhapSachBus().GetDisplayTable();

            int last = 0;
            if (dsPhieuNhap.Rows.Count > 0)
                last = int.Parse(dsPhieuNhap.AsEnumerable().Last()["MaPhieuNhapSach"].ToString());
            else last = 0;
            Console.WriteLine("last hoa don 1 day {0}", last);
            TB_PNS_MaPhieu.Text = (last + 1).ToString("000000");

        }
        private void BT_PhieuNhapSach_HuyPhieu_Click(object sender, EventArgs e)
        {
            MainTab.SelectedTab = TP_DSPhieuNhap;
            LB_TieuDe.Text = "Danh sách phiếu nhập sách";
        }
        private void BT_KhachHang_TaoKhachHang_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();
            int last_id = 0;
            if (dsKhachHang.Rows.Count > 0)
                last_id = int.Parse(dsKhachHang.AsEnumerable().Last()["MaKhachHang"].ToString());
            form.TB_MaKH.Text = (last_id + 1).ToString("000000");
            if (form.ShowDialog() == DialogResult.OK)
            {
                var kh = new KhachHang()
                {
                    MaKhachHang = form.TB_MaKH.Text,
                    HoTenKH = form.TB_HoTen.Text,
                    DiaChi = form.TB_DiaChi.Text,
                    Email = form.TB_Email.Text,
                    SoDienThoai = form.TB_SDT.Text,
                    SoTienNo = 0,
                    TongTien = 0,
                    NgayMuaCuoi = DateTime.Now
                };
                KhachHangBus khb = new KhachHangBus();
                if (khb.AddKhachHang(kh))
                    Console.WriteLine("A customer has been added");
                else
                    MessageBox.Show("Không thể tạo khách hàng, vui lòng kiểm tra lại", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }
        private void BT_AnHienMenu_Click(object sender, EventArgs e)
        {
            const int _distance = 60;
            if (_anThanhMenu == false)
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
        private void TSB_DSHD_ChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_DSHoaDon.Rows)
            {
                row.Selected = true;
            }
        }
        private void TB_DSHD_Loc_MaHoaDon_TextChanged(object sender, EventArgs e)
        {
            Load_DSHoaDon();
        }
        private void DTP_DSHD_Loc_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            Load_DSHoaDon();
        }
        private void DTP_DSHD_Loc_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            Load_DSHoaDon();
        }
        private void TB_DSKH_Loc_MaKH_TextChanged(object sender, EventArgs e)
        {
            Load_DSKhachHang();
        }
        private void TB_DSKH_Loc_TenKH_TextChanged(object sender, EventArgs e)
        {
            Load_DSKhachHang();
        }
        private void TB_DSKH_Loc_LoaiKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DSKhachHang();
        }
        private void TB_DSPT_MaPhieu_TextChanged(object sender, EventArgs e)
        {
            Load_DSPhieuThu();
        }
        private void DTP_DSPT_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            Load_DSPhieuThu();
        }
        private void DTP_DSPT_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            Load_DSPhieuThu();
        }
        private void TB_DSPT_TenKH_TextChanged(object sender, EventArgs e)
        {
            Load_DSPhieuThu();
        }
        private void BT_HoaDon_Them_Click(object sender, EventArgs e)
        {
            Console.WriteLine(CBB_HoaDon_MaSachTenSach.SelectedValue.ToString());
            var result = new SachBus().GetSachByMaSach(CBB_HoaDon_MaSachTenSach.SelectedValue.ToString().Trim());
            var thanhTien = result.DonGia * int.Parse(TB_HoaDon_SoLuong.Text);
            DGV_HoaDon.Rows.Add(
                result.MaSach,
                result.TenSach,
                new TheLoaiSachBus().GetByMaTheLoai(result.MaTheLoai).TenTheLoai,
                TB_HoaDon_SoLuong.Text,
                result.DonGia,
                thanhTien
                );
            HoaDon_TinhTien();
        }
        private void TB_HoaDon_GiamGia_TextChanged(object sender, EventArgs e)
        {
            HoaDon_TinhTien();
        }
        private void TB_HoaDon_KhachDua_TextChanged(object sender, EventArgs e)
        {
            HoaDon_TinhTien();
        }
        private void TSB_HoaDon_ChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_HoaDon.Rows)
            {
                row.Selected = true;
            }
        }
        private void TSB_HoaDon_Xoa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_HoaDon.SelectedRows)
            {
                DGV_HoaDon.Rows.Remove(row);
            }
            HoaDon_TinhTien();
        }
        private void BT_HoaDon_Luu_Click(object sender, EventArgs e)
        {
            char[] abc = { ' ', 'V', 'N', 'D' };

            if (DGV_HoaDon.Rows.Count > 0)
            {
                int last = int.Parse(TB_HoaDon_MaHoaDon.Text);
                decimal khachtra;
                if (decimal.Parse(TB_HoaDon_ConLai.Text.ToString().Trim(abc)) < 0)//còn nợ
                    khachtra = decimal.Parse(TB_HoaDon_KhachDua.Text.ToString().Trim(abc));
                else khachtra = decimal.Parse(TB_HoaDon_TienPhaiTra.Text.ToString().Trim(abc));//trả hết ko nợ

                //int last = int.Parse(TB_HoaDon_MaHoaDon.Text);
                HoaDon hd = new HoaDon()
                {
                    MaHoaDon = TB_HoaDon_MaHoaDon.Text,
                    MaKhachHang = (string)CBB_HoaDon_KhachHang.SelectedValue,
                    MaNhanVien = (string)CBB_HoaDon_NVBan.SelectedValue,
                    NgayHoaDon = DTP_HoaDon_NgayBan.Value,
                    GiamGia = decimal.Parse(TB_HoaDon_GiamGia.Text),
                    TienKhachDaTra = khachtra
                };

                if (hdBus.AddHoaDon(hd))
                {
                    ChiTietHoaDon ct;
                    foreach (DataGridViewRow row in DGV_HoaDon.Rows)
                    {
                        ct = new ChiTietHoaDon()
                        {
                            MaChiTietHoaDon = hd.MaHoaDon + row.Index.ToString("0000"),
                            MaSach = row.Cells[0].Value.ToString(),
                            MaHoaDon = hd.MaHoaDon,
                            DonGiaBan = Convert.ToDecimal(row.Cells[4].Value),
                            SoLuongBan = Convert.ToInt32(row.Cells[3].Value)
                        };
                        if (!cthdBus.AddChiTietHD(ct))
                            Console.WriteLine("Error");

                        Sach sach = sachBus.GetSachByMaSach(row.Cells[0].Value.ToString());

                        sach.SoLuongTon -= int.Parse(row.Cells[3].Value.ToString());
                        sachBus.UpdateSach(sach);

                    }
                }

                decimal sono = Convert.ToDecimal(TB_HoaDon_ConLai.Text.ToString().Trim(abc));
                string makh = CBB_HoaDon_KhachHang.SelectedValue.ToString();
                KhachHang kh = khBus.GetKhachHangByMaKH(makh);
                //update tiền nợ nếu khách hàng còn nợ
                if (sono < 0)
                {
                    kh.SoTienNo -= sono;
                    khBus.UpdateKhachHang(kh);
                }

                    MessageBox.Show("Lưu hóa đơn thành công!");

                TB_HoaDon_SoLuong.Text = "1";
                TB_HoaDon_GiamGia.Text = "0";
                TB_HoaDon_KhachDua.Text = "0";
                TB_HoaDon_ConLai.Text = "0";
                TB_HoaDon_TienPhaiTra.Text = "0";
                TB_HoaDon_TongTien.Text = "0";

                dsHoaDon = hdBus.GetResultTable();
               
                if (dsHoaDon.Rows.Count > 0)
                    last = int.Parse(dsHoaDon.AsEnumerable().Last()["MaHoaDon"].ToString());
                else last = 0;

                TB_HoaDon_MaHoaDon.Text = (last + 1).ToString("000000");

            }
            else
                MessageBox.Show("Danh sách sách đang trống, vui lòng kiểm tra lại!");

            DGV_HoaDon.Rows.Clear();
            Load_DSHoaDon();
            
        }
        private void TB_DSSach_TacGia_TextChanged(object sender, EventArgs e)
        {
            Load_DSSach();
        }
        private void TB_DSSach_TenSach_TextChanged(object sender, EventArgs e)
        {
            Load_DSSach();
        }
        private void TB_DSSach_MaSach_TextChanged(object sender, EventArgs e)
        {
            Load_DSSach();
        }
        private void CBB_DSSach_TheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            Load_DSSach();
        }
        private void DongBo(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;


            //Get_DSTenTheLoai();
            dsHoaDon = new HoaDonBus().GetResultTable();
            dsSach = new SachBus().GetSach();
            dsTheLoaiSach = new TheLoaiSachBus().GetTheLoai();
            dsKhachHang = new KhachHangBus().GetKhachHang();
            dsPhieuThu = new PhieuThuBus().GetDisplayTable();
            dsPhieuNhap = new PhieuNhapSachBus().GetDisplayTable();
            dsNhanVien = new NhanVienBus().GetNhanVien();
            Load_DSHoaDon();
            Load_DSKhachHang();
            Load_DSPhieuThu();
            Load_DSPhieuNhap();
            //baoCaoTon = new BaoCaoTonBus().GetBCTon();
            //Load_BaoCaoTon();
            Load_DSSach();

            this.Cursor = Cursors.Arrow;
        }
        private byte[] ConvertImageToByteArray(Image imageToConvert, ImageFormat formatOfImage)
        {
            byte[] Ret;
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    imageToConvert.Save(ms, formatOfImage);
                    Ret = ms.ToArray();
                }
            }
            catch (Exception) { throw; }
            return Ret;
        }
        private void BT_PNS_Them_Click(object sender, EventArgs e)
        {
            Console.WriteLine(CBB_PNS_TenSach.SelectedValue.ToString());
            var result = new SachBus().GetSachByMaSach(CBB_PNS_TenSach.SelectedValue.ToString().Trim());
            var thanhTien = decimal.Parse(TB_PNS_DonGia.Text) * int.Parse(TB_PNS_SoLuong.Text);
            DGV_PNS.Rows.Add(
                result.MaSach,
                result.TenSach,
                new TheLoaiSachBus().GetByMaTheLoai(result.MaTheLoai).TenTheLoai,
                result.TacGia,
                TB_PNS_SoLuong.Text,
                TB_PNS_DonGia.Text,
                thanhTien
                );
            PhieuNhapSach_TinhTien();
        }
        private void BT_PNS_Luu_Click(object sender, EventArgs e)
        {
            int last = 0;
            if (dsPhieuNhap.Rows.Count > 0)
                last = int.Parse(dsPhieuNhap.AsEnumerable().Last()["MaPhieuNhapSach"].ToString());

            if (DGV_PNS.Rows.Count > 0)
            {
                PhieuNhapSach pn = new PhieuNhapSach()
                {
                    MaPhieuNhapSach = TB_PNS_MaPhieu.Text,
                    MaNhanVien = CBB_PNS_NhanVien.SelectedValue.ToString(),
                    NgayNhap = (DateTime)DTP_PNS_NgayNhap.Value
                };

                if (pnBus.AddPhieuNhap(pn))
                {
                    ChiTietPhieuNhapSach ct;
                    foreach (DataGridViewRow row in DGV_PNS.Rows)
                    {
                        ct = new ChiTietPhieuNhapSach()
                        {
                            MaChiTietPhieuNhapSach = pn.MaPhieuNhapSach + row.Index.ToString("0000"),
                            MaSach = row.Cells[0].Value.ToString(),
                            MaPhieuNhapSach = pn.MaPhieuNhapSach,
                            DonGiaNhap = Convert.ToDecimal(row.Cells[5].Value),
                            SoLuongNhap = Convert.ToInt32(row.Cells[4].Value)
                        };
                        if (!ctpnBus.AddChiTietPN(ct))
                            Console.WriteLine("Error");
                        //cập nhật số lượng tồn của sách
                        Sach sach = sachBus.GetSachByMaSach(row.Cells[0].Value.ToString());
                        sach.SoLuongTon += int.Parse(row.Cells[4].Value.ToString());
                        sachBus.UpdateSach(sach);
                    }
                }

                //tạo mã phiếu nhập mới khi đã nhập xong
                dsPhieuNhap = pnBus.GetDisplayTable();

                if (dsPhieuNhap.Rows.Count > 0)
                    last = int.Parse(dsPhieuNhap.AsEnumerable().Last()["MaPhieuNhapSach"].ToString());
                TB_PNS_MaPhieu.Text = (last + 1).ToString("000000");
            }
            else
                MessageBox.Show("Không được để trống, vui lòng kiểm tra lại!");

            //nhập xong thì clear màn hình
            DGV_PNS.Rows.Clear();
            Load_DSPhieuNhap();
            TB_PNS_SoLuong.Text = null;
            TB_PNS_DonGia.Text = null;

        }
        private void DTP_DSPN_DenNgay_ValueChanged(object sender, EventArgs e)
        {
            Load_DSPhieuNhap();
        }
        private void DTP_DSPN_TuNgay_ValueChanged(object sender, EventArgs e)
        {
            Load_DSPhieuNhap();
        }
        private void TB_DSPN_MaPhieu_TextChanged(object sender, EventArgs e)
        {
            Load_DSPhieuNhap();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
                Close();
            else
            {
                loginnv = nvBus.GetNhanVienByMa(loginForm.TB_TenDangNhap.Text.Trim());
                LB_TenNV.Text = loginnv.TenNhanVien.Trim();
                LB_ChucVu.Text = nvBus.ChucVu[loginnv.ChucVu];
                DongBo(sender, new EventArgs());
            }
        }
        #region Sync
        private void Load_DSHoaDon()
        {
            CBB_HoaDon_NVBan.DataSource = new BindingSource(GetNhanVienDictionary(),null);
            CBB_HoaDon_NVBan.DisplayMember = "Value";
            CBB_HoaDon_NVBan.ValueMember = "Key";
            CBB_HoaDon_KhachHang.DataSource = new BindingSource(GetKhachHangDictionary(), null);
            CBB_HoaDon_KhachHang.DisplayMember = "Value";
            CBB_HoaDon_KhachHang.ValueMember = "Key";
            CBB_HoaDon_MaSachTenSach.DataSource = new BindingSource(GetTenSachDictionary(), null);
            CBB_HoaDon_MaSachTenSach.DisplayMember = "Value";
            CBB_HoaDon_MaSachTenSach.ValueMember = "Key";
            int last = 0;


            DGV_DSHoaDon.Rows.Clear();
            var tb = from record in dsHoaDon.AsEnumerable()
                     where record["MaHoaDon"].ToString().ToUpper().Contains(TB_DSHD_Loc_MaHoaDon.Text.ToUpper())
                     && ((DateTime)record["NgayBan"]).Date >= DTP_DSHD_Loc_TuNgay.Value.Date
                     && ((DateTime)record["NgayBan"]).Date <= DTP_DSHD_Loc_DenNgay.Value.Date
                     select record;
            LB_DSHD_TongSoHD.Text = tb.Count() + "/" + dsHoaDon.Rows.Count;
            LB_DSHD_TongTien.Text = (from x in tb select (decimal)x["TongTien"]).Sum() + " VND";
            LB_DSHD_TongNo.Text = (from x in tb select (decimal)x["TienNo"]).Sum() + " VND";
            if (tb.Count() != 0)
                foreach (DataRow row in tb.CopyToDataTable().Rows)
                {
                    var maHoaDon = row["MaHoaDon"].ToString();
                    var ngayBan = ((DateTime)row["NgayBan"]).ToString("dd/MM/yyyy");
                    var nguoiBan = row["NguoiBan"].ToString();
                    var khachHang = row["KhachHang"].ToString();
                    var tongTien = (decimal)row["TongTien"];
                    var tienNo = (decimal)row["TienNo"];
                    var trangThai = tienNo == 0 ? "Đã Thanh Toán" : "Còn nợ";
                    DGV_DSHoaDon.Rows.Add(maHoaDon, ngayBan, nguoiBan, khachHang, tongTien, tienNo, trangThai);
                }
        }
        private void Load_DSPhieuNhap()
        {
            CBB_PNS_NhanVien.DataSource = new BindingSource(GetNhanVienDictionary(), null);
            CBB_PNS_NhanVien.DisplayMember = "Value";
            CBB_PNS_NhanVien.ValueMember = "Key";
            CBB_PNS_TenSach.DataSource = new BindingSource(GetTenSachDictionary(), null);
            CBB_PNS_TenSach.DisplayMember = "Value";
            CBB_PNS_TenSach.ValueMember = "Key";
            DGV_DSPN.Rows.Clear();
            var tb = from record in dsPhieuNhap.AsEnumerable()
                     where record["MaPhieuNhapSach"].ToString().ToUpper().Contains(TB_DSPN_MaPhieu.Text.ToUpper())
                     && ((DateTime)record["NgayNhap"]).Date >= DTP_DSPN_TuNgay.Value.Date
                     && ((DateTime)record["NgayNhap"]).Date <= DTP_DSPN_DenNgay.Value.Date
                     select record;
            LB_DSPN_SoPhieu.Text = dsHoaDon.Rows.Count.ToString();
            LB_DSPN_TongTien.Text = (from x in dsPhieuNhap.AsEnumerable() select (decimal)x["TongTien"]).Sum() + " VND";
            if (tb.Count() != 0)
                foreach (DataRow row in tb.CopyToDataTable().Rows)
                {
                    DGV_DSPN.Rows.Add(
                        row["MaPhieuNhapSach"],
                        ((DateTime)row["NgayNhap"]).ToString("dd/MM/yyyy"),
                        row["TenNhanVien"],
                        row["TongSoLuong"],
                        row["TongTien"]);
                }
        }
        private void Load_DSPhieuThu()
        {
            DGV_DSPT.Rows.Clear();
            var tb = from record in dsPhieuThu.AsEnumerable()
                     where record["MaPhieuThu"].ToString().ToUpper().Contains(TB_DSPT_MaPhieu.Text.ToUpper())
                     && record["HoTenKH"].ToString().ToUpper().Contains(TB_DSPT_TenKH.Text.ToUpper())
                     && ((DateTime)record["NgayThu"]).Date >= DTP_DSPT_TuNgay.Value.Date
                     && ((DateTime)record["NgayThu"]).Date <= DTP_DSPT_DenNgay.Value.Date
                     select record;
            LB_DSPT_TongSo.Text = dsPhieuThu.Rows.Count.ToString();
            LB_DSPT_TongTienThu.Text = (from x in dsPhieuThu.AsEnumerable() select (decimal)x["SoTienThu"]).Sum() + " VND";
            if (tb.Count() != 0)
                foreach (DataRow row in tb.CopyToDataTable().Rows)
                {
                    DGV_DSPT.Rows.Add(
                        row["MaPhieuThu"],
                        row["HoTenKH"],
                        row["DiaChi"],
                        row["SoDienThoai"],
                        row["Email"],
                        ((DateTime)row["NgayThu"]).ToString("dd/MM/yyyy"),
                        row["SoTienThu"],
                        row["TenNhanVien"],
                        row["LyDoThu"]
                        );
                }
        }
        private void Load_DSKhachHang()
        {
            EnumerableRowCollection <DataRow> tb = dsKhachHang.AsEnumerable();

            DGV_DSKH.Rows.Clear();
            switch(TB_DSKH_Loc_LoaiKH.SelectedItem)
            {
                case "Bình Thường":
                    tb = from record in dsKhachHang.AsEnumerable()
                         where record["MaKhachHang"].ToString().ToUpper().Contains(TB_DSKH_Loc_MaKH.Text.ToUpper())
                         && record["HoTenKH"].ToString().ToUpper().Contains(TB_DSKH_Loc_TenKH.Text.ToUpper())
                         && (decimal)record["SoTienNo"] <= 0
                         select record;
                    break;
                case "Còn Nợ":
                    tb = from record in dsKhachHang.AsEnumerable()
                         where record["MaKhachHang"].ToString().ToUpper().Contains(TB_DSKH_Loc_MaKH.Text.ToUpper())
                         && record["HoTenKH"].ToString().ToUpper().Contains(TB_DSKH_Loc_TenKH.Text.ToUpper())
                         && (decimal)record["SoTienNo"] > 0
                         select record;
                    break;
                default:
                    tb = from record in dsKhachHang.AsEnumerable()
                         where record["MaKhachHang"].ToString().ToUpper().Contains(TB_DSKH_Loc_MaKH.Text.ToUpper())
                         && record["HoTenKH"].ToString().ToUpper().Contains(TB_DSKH_Loc_TenKH.Text.ToUpper())
                         select record;
                    break;
            }
            LB_DSKH_TongSoKH.Text = dsHoaDon.Rows.Count.ToString();
            LB_DSKH_SoKHNo.Text = (from x in tb where (decimal)x["SoTienNo"] > 0 select (decimal)x["TongTien"]).Count().ToString();
            if (tb.Count() != 0)
                foreach (DataRow row in tb.CopyToDataTable().Rows)
                {
                    var maKH = row["MaKhachHang"].ToString();
                    var tenKH = row["HoTenKH"].ToString();
                    var sdt = row["SoDienThoai"].ToString();
                    var diaChi = row["DiaChi"].ToString();
                    var email = row["Email"].ToString();
                    var lanMua = ((DateTime)row["NgayMuaCuoi"]).ToString("dd/MM/yyyy");
                    var tongTien = (decimal)row["TongTien"];
                    var tongNo = (decimal)row["SoTienNo"];
                    DGV_DSKH.Rows.Add(maKH, tenKH, sdt, diaChi, email, lanMua, tongTien, tongNo);
                }
        }
        private void Load_BaoCaoTon()
        {
            DGV_DSPT.Rows.Clear();
            var tb = from record in dsPhieuThu.AsEnumerable()
                     where record["MaPhieuThu"].ToString().ToUpper().Contains(TB_DSPT_MaPhieu.Text.ToUpper())
                     && record["HoTenKH"].ToString().ToUpper().Contains(TB_DSPT_TenKH.Text.ToUpper())
                     && ((DateTime)record["NgayThu"]).Date >= DTP_DSPT_TuNgay.Value.Date
                     && ((DateTime)record["NgayThu"]).Date <= DTP_DSPT_DenNgay.Value.Date
                     select record;
            LB_DSPT_TongSo.Text = dsPhieuThu.Rows.Count.ToString();
            LB_DSPT_TongTienThu.Text = (from x in dsPhieuThu.AsEnumerable() select (decimal)x["SoTienThu"]).Sum() + " VND";
            if (tb.Count() != 0)
                foreach (DataRow row in tb.CopyToDataTable().Rows)
                {
                    DGV_DSPT.Rows.Add(
                        row["MaPhieuThu"],
                        row["HoTenKH"],
                        row["DiaChi"],
                        row["SoDienThoai"],
                        row["Email"],
                        ((DateTime)row["NgayThu"]).ToString("dd/MM/yyyy"),
                        row["SoTienThu"]);
                }
        }
        private void Load_DSSach()
        {
            CBB_DSSach_TheLoai.DataSource = dsTheLoaiSach;
            CBB_DSSach_TheLoai.DisplayMember = "TenTheLoai";
            CBB_DSSach_TheLoai.ValueMember = "MaTheLoai";
            DGV_DSSach.Rows.Clear();
            var tb = from record in dsSach.AsEnumerable()
                     where record["MaSach"].ToString().ToUpper().Contains(TB_DSSach_MaSach.Text.ToUpper())
                     && record["TenSach"].ToString().ToUpper().Contains(TB_DSSach_TenSach.Text.ToUpper())
                     && record["TacGia"].ToString().ToUpper().Contains(TB_DSSach_TacGia.Text.ToUpper())
                     && record["MaTheLoai"].ToString() == CBB_DSSach_TheLoai.SelectedValue.ToString()
                     select record;
            LB_DSSach_TongSoDauSach.Text = dsSach.Rows.Count.ToString();
            LB_DSSach_TongSoSach.Text = (from x in dsSach.AsEnumerable() select (int)x["SoLuongTon"]).Sum().ToString();
            if (tb.Count() != 0)
                foreach (DataRow row in tb.CopyToDataTable().Rows)
                {
                    var maSach = row["MaSach"].ToString();
                    var tenSach = row["TenSach"].ToString();
                    var tacGia = row["TacGia"].ToString();
                    var theLoai = new TheLoaiSachBus().GetByMaTheLoai(row["MaTheLoai"].ToString()).TenTheLoai;
                    var soLuong = (int)row["SoLuongTon"];
                    var tinhTrang = soLuong > 0 ? "Được phép bán" : "Không được bán";
                    DGV_DSSach.Rows.Add(maSach, tenSach, tacGia, theLoai, soLuong, tinhTrang);
                }
        }
        #endregion

        private Dictionary<string, string> GetTenSachDictionary()
        {
            var q = from record in dsSach.AsEnumerable()
                         select new
                         {
                             Id = (string)record["MaSach"],
                             Item = ((string)record["TenSach"]).Trim() + " - " + ((string)record["TacGia"]).Trim()
                         };
            return q.ToDictionary(t => t.Id, t => t.Item);
        }
        private Dictionary<string, string> GetKhachHangDictionary()
        {
            var q = from record in dsKhachHang.AsEnumerable()
                         select new
                         {
                             Id = (string)record["MaKhachHang"],
                             Item = ((string)record["HoTenKH"]).Trim() + " - " + ((string)record["SoDienThoai"]).Trim()
                         };
            return q.ToDictionary(t => t.Id, t => t.Item);
        }
        private Dictionary<string, string> GetNhanVienDictionary()
        {
            var q = from record in dsNhanVien.AsEnumerable()
                         select new
                         {
                             Id = (string)record["MaNhanVien"],
                             Item = (string)record["TenNhanVien"] + " - " + ((string)record["MaNhanVien"]).Trim()
                         };
            return q.ToDictionary(t => t.Id, t => t.Item);
        }
        private void HoaDon_TinhTien()
        {
            decimal tongtien = 0;
            foreach (DataGridViewRow row in DGV_HoaDon.Rows)
            {
                tongtien += (decimal)row.Cells[5].Value;
            }
            TB_HoaDon_TongTien.Text = tongtien + " VND";
            decimal tienphaitra = tongtien - decimal.Parse(TB_HoaDon_GiamGia.Text);
            TB_HoaDon_TienPhaiTra.Text = tienphaitra + " VND";
            TB_HoaDon_ConLai.Text = decimal.Parse(TB_HoaDon_KhachDua.Text) - tienphaitra + " VND";
        }
        private void PhieuNhapSach_TinhTien()
        {
            decimal tongtien = 0;
            foreach (DataGridViewRow row in DGV_PNS.Rows)
            {
                tongtien += decimal.Parse(row.Cells[6].Value.ToString());
            }
            TB_PNS_TongTien.Text = tongtien + " VND";
        }

        private void TSB_DSHD_Xoa_Click(object sender, EventArgs e)
        {
            var msb = MessageBox
                .Show("Bạn có thực sự muốn xóa (những) hóa đơn này",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if(msb == DialogResult.Yes)
            {
                var bus = new HoaDonBus();
                foreach (DataGridViewRow row in DGV_DSHoaDon.SelectedRows)
                    if (!bus.DeleteHoaDon(row.Cells[0].Value.ToString()))
                        MessageBox.Show(
                            "Không thể xóa hóa đơn " + row.Cells[0].Value.ToString() + " vui lòng kiểm tra lại",
                            "Không thể xóa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }

        private void TSB_DSHD_Sua_Click(object sender, EventArgs e)
        {
            DGV_HoaDon.Rows.Clear();
            var hdb = new HoaDonBus();
            HoaDon hd = hdb.GetHoaDonByMa(DGV_DSHoaDon.SelectedRows[0].Cells[0].Value.ToString());
            DTP_HoaDon_NgayBan.Value = hd.NgayHoaDon;
            TB_HoaDon_MaHoaDon.Text = hd.MaHoaDon;
            CBB_HoaDon_KhachHang.SelectedValue = hd.MaKhachHang;
            CBB_HoaDon_NVBan.SelectedValue = hd.MaNhanVien;
            TB_HoaDon_KhachDua.Text = hd.TienKhachDaTra.ToString();
            TB_HoaDon_GiamGia.Text = hd.GiamGia.ToString();
            var ctb = new ChiTietHoaDonBus();
            foreach (string s in ctb.GetMaCTHoaDonList(hd.MaHoaDon))
            {
                var ct = ctb.GetChiTietHDByMa(s);
                var result = new SachBus().GetSachByMaSach(ct.MaSach.Trim());
                var thanhTien = result.DonGia * ct.SoLuongBan;
                DGV_HoaDon.Rows.Add(
                    result.MaSach,
                    result.TenSach,
                    new TheLoaiSachBus().GetByMaTheLoai(result.MaTheLoai).TenTheLoai,
                    TB_HoaDon_SoLuong.Text,
                    result.DonGia,
                    thanhTien
                    );
            }
            HoaDon_TinhTien();
            MainTab.SelectedIndex = 1;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {

        }

        private void TSB_DSSach_Xoa_Click(object sender, EventArgs e)
        {
            var msb = MessageBox
                .Show("Bạn có thực sự muốn xóa (những) đầu sách này.\nChỉ có thể xóa sách khi chúng không nằm trong bất cứ hóa đơn nào!",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (msb == DialogResult.Yes)
            {
                var bus = new SachBus();
                foreach (DataGridViewRow row in DGV_DSSach.SelectedRows)
                    if (!bus.DeleteSach(row.Cells[0].Value.ToString()))
                        MessageBox.Show(
                            "Không thể xóa sách " + row.Cells[0].Value.ToString().Trim() + ".\nVui lòng kiểm tra lại thông tin.",
                            "Không thể xóa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }

        private void TSB_DSSach_Sua_Click(object sender, EventArgs e)
        {
            BookDetailsForm form = new BookDetailsForm();
            form.TB_MaSoSach.Text = DGV_DSSach.SelectedRows[0].Cells[0].Value.ToString();
            form.CBB_TheLoai.DataSource = dsTheLoaiSach;
            form.CBB_TheLoai.DisplayMember = "TenTheLoai";
            form.CBB_TheLoai.ValueMember = "MaTheLoai";
            SachBus sb = new SachBus();
            var sach = sb.GetSachByMaSach(form.TB_MaSoSach.Text);
            form.CBB_TheLoai.SelectedValue = sach.MaTheLoai;
            if(sach.AnhBia != null)
                using (MemoryStream ms = new MemoryStream(sach.AnhBia))
                {
                    form.PTB_AnhBia.Image = Image.FromStream(ms,true);
                }
            form.TB_DonGia.Text = sach.DonGia.ToString();
            form.TB_MoTa.Text = sach.MoTa.Trim();
            form.TB_NamXuatBan.Text = sach.NamXuatBan.ToString();
            form.TB_NhaXuatBan.Text = sach.NhaXuatBan.Trim();
            form.TB_SoTrang.Text = sach.SoTrang.ToString();
            form.TB_TacGia.Text = sach.TacGia.Trim();
            form.TB_TenSach.Text = sach.TenSach.Trim();
            form.CBB_TheLoai.ValueMember = "MaTheLoai";
            if (form.ShowDialog() == DialogResult.OK)
            {
                var sach2 = new Sach()
                {
                    MaSach = sach.MaSach,
                    TenSach = form.TB_TenSach.Text,
                    DonGia = decimal.Parse(form.TB_DonGia.Text),
                    TacGia = form.TB_TacGia.Text,
                    MoTa = form.TB_MoTa.Text,
                    SoTrang = int.Parse(form.TB_SoTrang.Text),
                    MaTheLoai = form.CBB_TheLoai.SelectedValue.ToString(),
                    AnhBia = form.PTB_AnhBia.Image is null ? null : ConvertImageToByteArray(form.PTB_AnhBia.Image, form.PTB_AnhBia.Image.RawFormat),
                    NamXuatBan = int.Parse(form.TB_NamXuatBan.Text),
                    NhaXuatBan = form.TB_NhaXuatBan.Text,
                    SoLuongTon = sach.SoLuongTon
                };
                if (sb.UpdateSach(sach2))
                    Console.WriteLine("A book has been updated");
                else
                    MessageBox.Show("Không thể thay đổi sách, vui lòng kiểm tra lại", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }

        private void TSB_DSPN_Xoa_Click(object sender, EventArgs e)
        {
            var msb = MessageBox
                .Show("Bạn có thực sự muốn xóa (những) phiếu nhập sách này?",
                "Cảnh báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (msb == DialogResult.Yes)
            {
                var bus = new PhieuNhapSachBus();
                foreach (DataGridViewRow row in DGV_DSPN.SelectedRows)
                    if (!bus.DeletePhieuNhap(row.Cells[0].Value.ToString()))
                        MessageBox.Show(
                            "Không thể xóa phiếu " + row.Cells[0].Value.ToString().Trim() + ".\nVui lòng kiểm tra lại thông tin.",
                            "Không thể xóa",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }

        private void TSB_DSPN_Sua_Click(object sender, EventArgs e)
        {
            DGV_PNS.Rows.Clear();
            var pnb = new PhieuNhapSachBus();
            PhieuNhapSach pn = pnb.GetPhieuNhapByMa(DGV_DSPN.SelectedRows[0].Cells[0].Value.ToString());
            DTP_PNS_NgayNhap.Value = pn.NgayNhap;
            TB_PNS_MaPhieu.Text = pn.MaPhieuNhapSach;
            CBB_PNS_NhanVien.SelectedValue = pn.MaNhanVien;
            var ctb = new ChiTietPhieuNhapSachBus();
            foreach (string s in ctb.GetMaCTPNList(pn.MaPhieuNhapSach))
            {
                var ct = ctb.GetChiTietPNByMa(s);
                var result = new SachBus().GetSachByMaSach(ct.MaSach.Trim());
                var thanhTien = ct.DonGiaNhap * ct.SoLuongNhap;
                DGV_PNS.Rows.Add(
                    result.MaSach,
                    result.TenSach,
                    new TheLoaiSachBus().GetByMaTheLoai(result.MaTheLoai).TenTheLoai,
                    result.TacGia,
                    ct.SoLuongNhap.ToString(),
                    ct.DonGiaNhap.ToString(),
                    thanhTien
                    );
            }
            PhieuNhapSach_TinhTien();
            MainTab.SelectedIndex = 4;
        }

        private new void KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TSB_KH_ChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_DSKH.Rows)
                row.Selected = true;
        }

        private void TSB_KH_XoaMuc_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("Bạn có chắc chắn muốn xóa khỏi cơ sở dữ liệu?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DGV_DSKH.SelectedRows)
                {
                    string maKH = row.Cells[0].Value.ToString();
                    if (!khBus.DeleteKhachHang(maKH))
                        MessageBox.Show("Vì lý do ràng buộc nên không thể xóa!");
                    else
                        DGV_DSKH.Rows.Remove(row);
                }
            }
            else
                return;
        }

        private void TSB_KH_ChinhSua_Click(object sender, EventArgs e)
        {
            CustomerForm form = new CustomerForm();

            form.TB_MaKH.Text = DGV_DSKH.SelectedRows[0].Cells[0].Value.ToString();


            KhachHang kh = khBus.GetKhachHangByMaKH(form.TB_MaKH.Text);

            form.TB_HoTen.Text = kh.HoTenKH;
            form.TB_SDT.Text = kh.SoDienThoai;
            form.TB_DiaChi.Text = kh.DiaChi;
            form.TB_Email.Text = kh.Email;

            if (form.ShowDialog() == DialogResult.OK)
            {
                KhachHang kh2 = new KhachHang()
                {
                    MaKhachHang = kh.MaKhachHang,
                    HoTenKH = form.TB_HoTen.Text,
                    SoDienThoai = form.TB_SDT.Text,
                    DiaChi = form.TB_DiaChi.Text,
                    Email = form.TB_Email.Text,
                    SoTienNo = kh.SoTienNo,
                    TongTien = kh.TongTien,
                    NgayMuaCuoi = DateTime.Now
                };



                if (khBus.UpdateKhachHang(kh2))
                    MessageBox.Show("Khách hàng " + kh.MaKhachHang+"-"+kh.HoTenKH + " đã update thành công!");
                else
                    MessageBox.Show("Không thể cập nhật khách hàng", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }

        private void TSB_KH_ChiTiet_Click(object sender, EventArgs e)
        {
            if (DGV_DSKH.SelectedRows.Count > 0)
            {
                var khForm = new CustomerForm();
                khForm.TB_MaKH.Text = DGV_DSKH.SelectedRows[0].Cells[0].Value.ToString();
                khForm.TB_MaKH.Enabled = false;
                khForm.TB_HoTen.Text = DGV_DSKH.SelectedRows[0].Cells[1].Value.ToString();
                khForm.TB_HoTen.Enabled = false;
                khForm.TB_SDT.Text = DGV_DSKH.SelectedRows[0].Cells[2].Value.ToString();
                khForm.TB_SDT.Enabled = false;
                khForm.TB_DiaChi.Text = DGV_DSKH.SelectedRows[0].Cells[3].Value.ToString();
                khForm.TB_DiaChi.Enabled = false;
                khForm.TB_Email.Text = DGV_DSKH.SelectedRows[0].Cells[4].Value.ToString();
                khForm.TB_Email.Enabled = false;
                khForm.BT_Huy.Hide();
                khForm.BT_Luu.Hide();
                khForm.ShowDialog();
            }
        }

        private void TSB_KH_ThemMuc_Click(object sender, EventArgs e)
        {
            BT_DSKH_Them.PerformClick();
        }

        private void TSB_PT_ChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_DSPT.Rows)
                row.Selected = true;
        }

        private void TSB_PT_ThemMuc_Click(object sender, EventArgs e)
        {
            BT_DSPhieuThu_TaoPhieuThu.PerformClick();
        }

        private void TSB_DSPT_XoaMuc_Click(object sender, EventArgs e)
        {
            var x = MessageBox.Show("Bạn có chắc chắn muốn xóa, sẽ bị biến mất vĩnh viễn!", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (x == DialogResult.Yes)
            {
                foreach (DataGridViewRow row in DGV_DSPT.SelectedRows)
                {
                    string maPT = row.Cells[0].Value.ToString();
                    phieuthuBus.DeletePhieuThu(maPT);
                    DGV_DSPT.Rows.Remove(row);
                }
            }
            else
                return;
        }

        private void TSB_DSPT_ChinhSua_Click(object sender, EventArgs e)
        {
            ReceiptForm form = new ReceiptForm();


            form.TB_MaPhieu.Text = DGV_DSPT.SelectedRows[0].Cells[0].Value.ToString();

            PhieuThuBus ptb = new PhieuThuBus();

            PhieuThu pt = ptb.GetPhieuThuByMa(form.TB_MaPhieu.Text.ToString());

            form.CBB_KhachHang.DataSource = dsKhachHang;
            form.CBB_KhachHang.DisplayMember = "HoTenKH";
            form.CBB_KhachHang.ValueMember = "MaKhachHang";

            form.CBB_NhanVien.DataSource = dsNhanVien;
            form.CBB_NhanVien.DisplayMember = "TenNhanVien";
            form.CBB_NhanVien.ValueMember = "MaNhanVien";

            form.CBB_KhachHang.SelectedValue = pt.MaKhachHang;

            form.CBB_NhanVien.SelectedValue = pt.MaNhanVien;

            form.DTP_NgayThu.Value = Convert.ToDateTime(DGV_DSPT.SelectedRows[0].Cells[5].Value.ToString());

            form.TB_SoTienThu.Text = pt.SoTienThu.ToString();
            form.TB_LyDoThu.Text = pt.LyDoThu;


            if (form.ShowDialog() == DialogResult.OK)
            {
                var pt2 = new PhieuThu()
                {
                    MaPhieuThu = pt.MaPhieuThu,
                    MaKhachHang = form.CBB_KhachHang.SelectedValue.ToString(),
                    MaNhanVien = form.CBB_NhanVien.SelectedValue.ToString(),
                    NgayThu = Convert.ToDateTime(form.DTP_NgayThu.Value),
                    SoTienThu = Convert.ToDecimal(form.TB_SoTienThu.Text.ToString()),
                    LyDoThu = form.TB_LyDoThu.Text
                };

                if (ptb.UpdatePhieuThu(pt2))
                    MessageBox.Show("Phiếu thu " + pt.MaPhieuThu + " đã update thành công!");
                else
                    MessageBox.Show("Không thể cập nhật phiếu thu, vui lòng kiểm tra lại", "Không thực hiện được", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DongBo(sender, new EventArgs());
            }
        }

        private void TSB_DSPT__ChiTiet_Click(object sender, EventArgs e)
        {
            ReceiptForm form = new ReceiptForm();
            form.TB_MaPhieu.Text = DGV_DSPT.SelectedRows[0].Cells[0].Value.ToString();
            form.Text = "Chi tiết";

            form.CBB_KhachHang.DataSource = dsKhachHang;
            form.CBB_KhachHang.DisplayMember = "HoTenKH";
            form.CBB_KhachHang.ValueMember = "MaKhachHang";

            form.CBB_NhanVien.DataSource = dsNhanVien;
            form.CBB_NhanVien.DisplayMember = "TenNhanVien";
            form.CBB_NhanVien.ValueMember = "MaNhanVien";


            var pt = phieuthuBus.GetPhieuThuByMa(form.TB_MaPhieu.Text);
            form.TB_MaPhieu.Enabled = false;
            form.TB_MaPhieu.Text = pt.MaPhieuThu;
            form.DTP_NgayThu.Enabled = false;
            form.DTP_NgayThu.Value = pt.NgayThu;
            form.TB_SoTienThu.Enabled = false;
            form.TB_SoTienThu.Text = pt.SoTienThu.ToString();
            form.TB_LyDoThu.Enabled = false;
            form.TB_LyDoThu.Text = pt.LyDoThu;
            form.CBB_KhachHang.Enabled = false;
            form.CBB_KhachHang.SelectedValue = pt.MaKhachHang;
            form.CBB_NhanVien.Enabled = false;
            form.CBB_NhanVien.SelectedValue = pt.MaNhanVien;
            form.BT_Huy.Hide();
            form.BT_Luu.Hide();
            form.ShowDialog();
        }

        private void TSB_DSPN_Them_Click(object sender, EventArgs e)
        {
            BT_DSPhieuNhap_TaoPhieuNhap.PerformClick();
        }

        private void TSB_DSPN_Chontatca_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_DSPN.Rows)
                row.Selected = true;
        }

        private void TSB_PhieuNS_ChonTatCa_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_PNS.Rows)
                row.Selected = true;
        }

        private void TSB_PhieuNS_XoaMuc_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in DGV_PNS.SelectedRows)
                DGV_PNS.Rows.Remove(row);
        }

        private void TB_HoaDon_SoLuong_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string masach = CBB_HoaDon_MaSachTenSach.SelectedValue.ToString();
                Sach sach = sachBus.GetSachByMaSach(masach);
                if (int.Parse(TB_HoaDon_SoLuong.Text.ToString()) > sach.SoLuongTon && sach.SoLuongTon!=0)
                {
                    MessageBox.Show("Số lượng sách mua không được vượt quá " + sach.SoLuongTon);
                    TB_HoaDon_SoLuong.Text = sach.SoLuongTon + "";
                }
                    
                if (int.Parse(TB_HoaDon_SoLuong.Text.ToString()) == 0)
                {
                    //MessageBox.Show("Không bán 0 quyển sách.");
                    TB_HoaDon_SoLuong.Text = 1 + "";
                }           
            }
            catch { }
        }

        private void BTN_BCT_Lap_Click(object sender, EventArgs e)
        {
            BTN_BCT_Luu.Enabled = true;



            int thang = int.Parse(CBB_BCT_Thang.SelectedValue.ToString());
            int nam = int.Parse(CBB_BCT_Nam.SelectedValue.ToString());

            dsBaoCaoTonMonth = bctBus.GetBaoCaoChiTiet(thang, nam);
            dsBaoCaoTonAll = bctBus.GetAllRows();

            DGV_BCT.Rows.Clear();

            if (dsBaoCaoTonMonth.Rows.Count == 0)
            {
                MessageBox.Show("Tháng này không có trong cơ sở dữ liệu");
                return;
            }



            //MessageBox.Show("gfghh : " + dsBaoCaoTonMonth.Rows.Count);
            foreach (DataRow row in dsBaoCaoTonMonth.Rows)
            {
                string masach = row["MaSach"].ToString();
                string tensach = row["TenSach"].ToString();
                int tondau = int.Parse(row["TonDau"].ToString());
                int phatsinh = int.Parse(row["PhatSinh"].ToString());
                int toncuoi = int.Parse(row["TonCuoi"].ToString());
                DGV_BCT.Rows.Add(masach, tensach, tondau, phatsinh, toncuoi);
            }
        }

        private void BTN_BCT_Luu_Click(object sender, EventArgs e)
        {
            if (DGV_BCT.Rows.Count > 0 && DGV_BCT.Rows[0].Cells[0].Value != null)
            {
                int last = 0;
                if (dsBaoCaoTonAll.AsEnumerable() != null && dsBaoCaoTonAll.AsEnumerable().Any())
                    last = int.Parse(dsBaoCaoTonAll.AsEnumerable().Last()["MaBaoCaoTon"].ToString()) + 1;
                else
                    last = 1;

                BaoCaoTon bct = new BaoCaoTon()
                {
                    MaBaoCaoTon = last.ToString("000000"),
                    Thang = int.Parse(CBB_BCT_Thang.SelectedValue.ToString()),
                    Nam = int.Parse(CBB_BCT_Nam.SelectedValue.ToString())
                };


                if (bctBus.IsRowExists(bct.Thang, bct.Nam))
                {
                    bct = bctBus.GetBaoCaoFromThangNam(bct.Thang, bct.Nam);
                    MessageBox.Show("Đã có trong database, sẽ cập nhật!  " + bct.MaBaoCaoTon);
                    //bccnBus.UpdateBaoCao(bccn);

                    ctbctBus.DeleteAll(bct.MaBaoCaoTon);

                    int count = 0;
                    foreach (DataRow row in dsBaoCaoTonMonth.Rows)
                    {
                        count++;
                        //MessageBox.Show(dsBaoCaoTonMonth.Rows.Count + "");
                        ChiTietBaoCaoTon ctbct = new ChiTietBaoCaoTon()
                        {
                            MaChiTietBaoCaoTon = bct.MaBaoCaoTon.Trim() + count.ToString("0000"),
                            MaBaoCaoTon = bct.MaBaoCaoTon,
                            MaSach = row["MaSach"].ToString(),
                            TonDau = Convert.ToInt32(row["TonDau"].ToString()),
                            TonCuoi = Convert.ToInt32(row["TonCuoi"].ToString()),
                            PhatSinh = Convert.ToInt32(row["PhatSinh"].ToString())
                        };
                        ctbctBus.AddChiTietBaoCao(ctbct);
                    }
                }
                else
                {
                    MessageBox.Show("Sẽ thêm mới tháng này!");
                    bctBus.AddBaoCao(bct);

                    int count = 0;
                    foreach (DataRow row in dsBaoCaoTonMonth.Rows)
                    {
                        count++;
                        //Console.WriteLine("Phát sinh: {0} ", row.Cells[4].Value.ToString());
                        ChiTietBaoCaoTon ctbct = new ChiTietBaoCaoTon()
                        {
                            MaChiTietBaoCaoTon = bct.MaBaoCaoTon + count.ToString("0000"),
                            MaBaoCaoTon = bct.MaBaoCaoTon,
                            MaSach = row["MaSach"].ToString(),
                            TonDau = Convert.ToInt32(row["TonDau"].ToString()),
                            TonCuoi = Convert.ToInt32(row["TonCuoi"].ToString()),
                            PhatSinh = Convert.ToInt32(row["PhatSinh"].ToString())
                        };
                        ctbctBus.AddChiTietBaoCao(ctbct);
                    }
                }
            }
            else
                MessageBox.Show("Không có data", "Warning", MessageBoxButtons.OK);
        }
    }
}
