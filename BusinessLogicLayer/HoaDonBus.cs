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
    public class HoaDonBus
    {
        HoaDonTable objHoaDon = new HoaDonTable();
        public bool AddHoaDon(HoaDon hd)
        {
            if (!objHoaDon.IsRowExists(hd.MaHoaDon))
                return objHoaDon.AddRow(hd);
            else
                return false;
        }
        public bool DeleteHoaDon(string mahoadon)
        {
            return objHoaDon.DeleteRow(mahoadon);
        }
        public bool UpdateHoaDon(HoaDon hd)
        {
            if (objHoaDon.IsRowExists(hd.MaHoaDon))
                return objHoaDon.UpdateRow(hd);
            else
                return false;
                
        }
        public DataTable GetHoaDon()
        {
            return objHoaDon.GetAllRows();
        }
        public HoaDon GetHoaDonByMa(string mahoadon)
        {
            return objHoaDon.GetRow(mahoadon);
        }
        public DataTable GetHoaDonByTop(int number)
        {
            return objHoaDon.GetRows(number);
        }
    }
}
