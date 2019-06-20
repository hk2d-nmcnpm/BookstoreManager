using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class ChiTietBaoCaoTonBUS
    {
        ChiTietBaoCaoTonTable objCTBCT = new ChiTietBaoCaoTonTable();
        public bool AddChiTietBaoCao(ChiTietBaoCaoTon ctbct)
        {
            return objCTBCT.AddChiTiet(ctbct);
        }
        public bool DeleteAll(string MaBaoCaoTon)
        {
            return objCTBCT.RemoveAll(MaBaoCaoTon);
        }
    }
}
