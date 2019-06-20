using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer
{
    public class ChiTietBaoCaoCongNoBUS
    {
        ChiTietBaoCaoCongNoTable objCTBCCN = new ChiTietBaoCaoCongNoTable();
        public bool AddChiTietBaoCao(ChiTietBaoCaoCongNo ctbccn)
        {
            return objCTBCCN.AddChiTiet(ctbccn);
        }
        public bool DeleteAll(string MaBaoCaoCongNo)
        {
            return objCTBCCN.RemoveAll(MaBaoCaoCongNo);
        }
    }
}
