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
    public class BaoCaoTonBus
    {
        BaoCaoTonTable objBCT = new BaoCaoTonTable();
        public bool AddBCTon(BaoCaoTon bct)
        {
            if (!objBCT.IsRowExists(bct.MaChiTietTon))
                return objBCT.AddRow(bct);
            else
                return false;
        }
        public bool DeleteBCTon(string mabct)
        {
            return objBCT.DeleteRow(mabct);
        }
        public bool UpdateBCTon(BaoCaoTon bct)
        {
            if (objBCT.IsRowExists(bct.MaChiTietTon))
                return objBCT.UpdateRow(bct);
            else
                return false;

        }
        public DataTable GetBCTon()
        {
            return objBCT.GetAllRows();
        }
        public BaoCaoTon GetBCTonByMa(string mabct)
        {
            return objBCT.GetRow(mabct);
        }
        public DataTable GetBCTonByTop(int number)
        {
            return objBCT.GetRows(number);
        }
    }
}
