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
    public class ChiTietHoaDonBus
    {
        ChiTietHoaDonTable objCTHD = new ChiTietHoaDonTable();
        HoaDonTable objHD = new HoaDonTable();
        public bool AddChiTietHD(ChiTietHoaDon cthd)
        {
            if (objHD.IsRowExists(cthd.MaHoaDon) && !objCTHD.IsRowExists(cthd.MaChiTietHoaDon))
            {
                return objCTHD.AddRow(cthd);
            }
            else
                return false;
        }
        public bool DeleteChiTietHD(string macthd)
        {
            return objCTHD.DeleteRow(macthd);
        }
        public bool UpdateChiTietHD(ChiTietHoaDon cthd)
        {
            if (objCTHD.IsRowExists(cthd.MaChiTietHoaDon) && objHD.IsRowExists(cthd.MaHoaDon))
                return objCTHD.UpdateRow(cthd);
            else
                return false;
        }
        public DataTable GetChiTietHD()
        {
            return objCTHD.GetAllRows();
        }
        public ChiTietHoaDon GetChiTietHDByMa(string macthd)
        {
            return objCTHD.GetRow(macthd);
        }
        public DataTable GetChiTietHDByTop(int number)
        {
            return objCTHD.GetRows(number);
        }
    }
}
