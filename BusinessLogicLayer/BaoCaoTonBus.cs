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
        BaoCaoTonTable objBCCT = new BaoCaoTonTable();

        public bool AddBaoCao(BaoCaoTon bct)
        {
            return objBCCT.AddBaoCaoTon(bct);
        }
        public DataTable GetBaoCaoChiTiet(int thang, int nam)
        {
            return objBCCT.ThongKeBaoCaoTon(thang, nam);
        }
        public DataTable GetAllRows()
        {
            return objBCCT.GetAllRows();
        }

        public bool IsRowExists(int thang, int nam)
        {
            return objBCCT.IsRowExists(thang, nam);
        }

        public bool UpdateBaoCao(BaoCaoTon bct)
        {
            return objBCCT.UpdateBaoCao(bct);
        }

        public BaoCaoTon GetBaoCaoFromThangNam(int thang, int nam)
        {
            return objBCCT.GetBaoCaoFromThangNam(thang, nam);
        }
    }
}
