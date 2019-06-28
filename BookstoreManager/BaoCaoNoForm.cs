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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreManager
{
    public partial class BaoCaoNoForm : Form
    {
        DataTable dt = new DataTable();
        public BaoCaoNoForm()
        {
            InitializeComponent();
        }

        private void btnLap_Click(object sender, EventArgs e)
        {
            int thang = int.Parse(CBB_Thang.SelectedValue.ToString());
            int nam = int.Parse(CBB_Nam.SelectedValue.ToString());

            dt = new BaoCaoCongNoBus().GetBaoCaoChiTiet(thang, nam);

            reportViewerNo.ProcessingMode = ProcessingMode.Local;
            reportViewerNo.LocalReport.ReportPath = "..\\..\\ReportNo.rdlc";

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "baocaocongnoDataset";
            rds.Value = dt;

            reportViewerNo.LocalReport.DataSources.Clear();
            reportViewerNo.LocalReport.DataSources.Add(rds);
            reportViewerNo.RefreshReport();
        }

        private void BaoCaoNoForm_Load(object sender, EventArgs e)
        {
            List<int> thang = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> nam = new List<int>() { 2017, 2018, 2019 };
            CBB_Thang.DataSource = thang;
            CBB_Nam.DataSource = nam;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dt.Rows.Count > 0 && dt.Rows[0]["MaKhachHang"].ToString() != null)
            {
                int last = 0;
                BaoCaoCongNoBus bctBus = new BaoCaoCongNoBus();
                ChiTietBaoCaoCongNoBUS ctbctBus = new ChiTietBaoCaoCongNoBUS();
                DataTable dsBaoCaoTonAll = bctBus.GetAllRows();
                if (dsBaoCaoTonAll.AsEnumerable() != null && dsBaoCaoTonAll.AsEnumerable().Any())
                    last = int.Parse(dsBaoCaoTonAll.AsEnumerable().Last()["MaBaoCaoCongNo"].ToString()) + 1;
                else
                    last = 1;

                BaoCaoCongNo bccn = new BaoCaoCongNo()
                {
                    MaBaoCaoCongNo = last.ToString("000000"),
                    Thang = int.Parse(CBB_Thang.SelectedValue.ToString()),
                    Nam = int.Parse(CBB_Nam.SelectedValue.ToString())
                };


                if (bctBus.IsRowExists(bccn.Thang, bccn.Nam))
                {
                    MessageBox.Show("Đã có trong database, sẽ cập nhật!  " + bccn.MaBaoCaoCongNo);
                    ctbctBus.DeleteAll(bccn.MaBaoCaoCongNo);
                }
                else
                {
                    MessageBox.Show("Sẽ thêm mới tháng này!");
                    bctBus.AddBaoCao(bccn);
                }

                int count = 0;
                foreach (DataRow row in dt.Rows)
                {
                    count++;
                    ChiTietBaoCaoCongNo ctbct = new ChiTietBaoCaoCongNo()
                    {
                        MaChiTietBaoCaoCongNo = bccn.MaBaoCaoCongNo.Trim() + count.ToString("0000"),
                        MaBaoCaoCongNo = bccn.MaBaoCaoCongNo,
                        MaKhachHang= row["MaKhachHang"].ToString(),
                        NoDau = Convert.ToDecimal(row["NoDau"].ToString()),
                        NoCuoi = Convert.ToDecimal(row["NoCuoi"].ToString()),
                        PhatSinh = Convert.ToDecimal(row["PhatSinh"].ToString())
                    };
                    ctbctBus.AddChiTietBaoCao(ctbct);
                }
            }
            else
                MessageBox.Show("Không có data để lưu!", "Warning", MessageBoxButtons.OK);
        }
    }
}
