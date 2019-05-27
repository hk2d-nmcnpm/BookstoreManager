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
    public class ChiTietPhieuNhapSachBus
    {
        ChiTietPhieuNhapSachTable objCTPN = new ChiTietPhieuNhapSachTable();
        PhieuNhapSachTable objPN = new PhieuNhapSachTable();
        public bool AddChiTietPN(ChiTietPhieuNhapSach ctpn)
        {
            if (!objCTPN.IsRowExists(ctpn.MaChiTietPhieuNhapSach)&&objPN.IsRowExists(ctpn.MaPhieuNhapSach))
                return objCTPN.AddRow(ctpn);
            else
                return false;
        }
        public bool DeleteChiTietPN(string mactpn)
        {
            return objCTPN.DeleteRow(mactpn);
        }
        public bool UpdateChiTietPN(ChiTietPhieuNhapSach ctpn)
        {
            if (objCTPN.IsRowExists(ctpn.MaChiTietPhieuNhapSach))
                return objCTPN.UpdateRow(ctpn);
            else
                return false;

        }
        public DataTable GetChiTietPN()
        {
            return objCTPN.GetAllRows();
        }
        public ChiTietPhieuNhapSach GetChiTietPNByMa(string mactpn)
        {
            return objCTPN.GetRow(mactpn);
        }
        public DataTable GetChiTietPNByTop(int number)
        {
            return objCTPN.GetRows(number);
        }
    }
}
