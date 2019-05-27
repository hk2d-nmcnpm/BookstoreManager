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
        KhachHangTable objKH = new KhachHangTable();
        public bool AddBaoCaoCN(BaoCaoCongNo bccn)
        {
            if (!objBCCN.IsRowExists(bccn.MaChiTietCongNo))
                return objBCCN.AddRow(bccn);
            else
                return false;
        }
        public bool DeleteBaoCaoCN(string mabccn)
        {
            return objBCCN.DeleteRow(mabccn);
        }
        public bool UpdateBaoCaoCN(BaoCaoCongNo bccn)
        {
            if (objBCCN.IsRowExists(bccn.MaChiTietCongNo)&&objKH.IsRowExists(bccn.MaKhachHang))
                return objBCCN.UpdateRow(bccn);
            else
                return false;

        }
        public DataTable GetBaoCaoCN()
        {
            return objBCCN.GetAllRows();
        }
        public BaoCaoCongNo GetBaoCaoCNByMa(string mabccn)
        {
            return objBCCN.GetRow(mabccn);
        }
        public DataTable GetBaoCaoCNByTop(int number)
        {
            return objBCCN.GetRows(number);
        }
        public int TongTien()
        {
            return 0;
        }
    }
}
