using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class BaoCaoCongNoBus
    {
        BaoCaoCongNoTable objBCCN = new BaoCaoCongNoTable();

        public bool AddBaoCao(BaoCaoCongNo bccn)
        {
            return objBCCN.AddBaoCaoCongNo(bccn);
        }
        public DataTable GetBaoCaoChiTiet(int thang, int nam)
        {
            return objBCCN.ThongKeBaoCaoCongNo(thang, nam);
        }
        public DataTable GetAllRows()
        {
            return objBCCN.GetAllRows();
        }

        public bool IsRowExists(int thang, int nam)
        {
            return objBCCN.IsRowExists(thang, nam);
        }

        public bool UpdateBaoCao(BaoCaoCongNo bccn)
        {
            return objBCCN.UpdateBaoCao(bccn);
        }

        public BaoCaoCongNo GetBaoCaoFromThangNam(int thang, int nam)
        {
            return objBCCN.GetBaoCaoFromThangNam(thang, nam);
        }
    }
}
