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
                return UpdateHoaDon(hd);
        }
        public bool DeleteHoaDon(string mahoadon)
        {
            ChiTietHoaDonBus ctb = new ChiTietHoaDonBus();
            foreach(string ct in ctb.GetMaCTHoaDonList(mahoadon))
            {
                if (ctb.DeleteChiTietHD(ct))
                    Console.WriteLine("Delete: {0}",ct);
            }
            return objHoaDon.DeleteRow(mahoadon);
        }
        public bool UpdateHoaDon(HoaDon hd)
        {
            if (objHoaDon.IsRowExists(hd.MaHoaDon))
            {
                ChiTietHoaDonBus ctb = new ChiTietHoaDonBus();
                foreach (string ct in ctb.GetMaCTHoaDonList(hd.MaHoaDon))
                {
                    if (ctb.DeleteChiTietHD(ct))
                        Console.WriteLine("Delete: {0}", ct);
                }
                return objHoaDon.UpdateRow(hd);
            }

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
        public DataTable GetResultTable()
        {
            return objHoaDon.GetResultTable();
        }
        public string GetMaKH(string MaHD)
        {
            return objHoaDon.GetMaKH(MaHD);
        }
    }
}
