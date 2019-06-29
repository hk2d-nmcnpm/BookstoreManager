using BusinessLogicLayer;
using DataTransferObject;
using Microsoft.Reporting.WinForms;
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
    public partial class BaoCaoTonForm : Form
    {
        DataTable dt = new DataTable();
        public BaoCaoTonForm()
        {
            InitializeComponent();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            int thang = int.Parse(CBB_Thang.SelectedValue.ToString());
            int nam = int.Parse(CBB_Nam.SelectedValue.ToString());
            
            dt = new BaoCaoTonBus().GetBaoCaoChiTiet(thang, nam);

            if(dt.Rows.Count<=0)
            {
                MessageBox.Show("Không có dữ liệu để lập báo cáo","Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }

            reportViewerTon.ProcessingMode = ProcessingMode.Local;
            reportViewerTon.LocalReport.ReportPath = "..\\..\\ReportTon.rdlc";

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "baocaotonDataset";
            rds.Value = dt;
            
            reportViewerTon.LocalReport.DataSources.Clear();
            reportViewerTon.LocalReport.DataSources.Add(rds);
            reportViewerTon.RefreshReport();
        }

        private void BaoCaoTonForm_Load(object sender, EventArgs e)
        {
            List<int> thang = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> nam = new List<int>() { 2017, 2018, 2019 };
            CBB_Thang.DataSource = thang;
            CBB_Nam.DataSource = nam;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaSach"].ToString() != null)
            {
                int last = 0;
                BaoCaoTonBus bctBus = new BaoCaoTonBus();
                ChiTietBaoCaoTonBUS ctbctBus = new ChiTietBaoCaoTonBUS();
                DataTable dsBaoCaoTonAll = bctBus.GetAllRows();
                if (dsBaoCaoTonAll.AsEnumerable() != null && dsBaoCaoTonAll.AsEnumerable().Any())
                    last = int.Parse(dsBaoCaoTonAll.AsEnumerable().Last()["MaBaoCaoTon"].ToString()) + 1;
                else
                    last = 1;

                BaoCaoTon bct = new BaoCaoTon()
                {
                    MaBaoCaoTon = last.ToString("000000"),
                    Thang = int.Parse(CBB_Thang.SelectedValue.ToString()),
                    Nam = int.Parse(CBB_Nam.SelectedValue.ToString())
                };


                if (bctBus.IsRowExists(bct.Thang, bct.Nam))
                {
                    MessageBox.Show("Báo cáo tháng này đã có trong database, sẽ cập nhật! ");
                    ctbctBus.DeleteAll(bct.MaBaoCaoTon);
                }
                else
                {
                    MessageBox.Show("Sẽ thêm mới tháng này!");
                    bctBus.AddBaoCao(bct);
                }

                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    count++;
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
                MessageBox.Show("Không có data để lưu!", "Warning", MessageBoxButtons.OK);
        }
    }
}
