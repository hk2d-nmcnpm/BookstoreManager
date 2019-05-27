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
    public class KhachHangBus
    {
        KhachHangTable objKhachHang = new KhachHangTable();
        public DataTable GetKhachHang()
        {
            return objKhachHang.GetAllRows();
        }
        public KhachHang GetKhachHangByMaKH(string makh)
        {
            return objKhachHang.GetRow(makh);
        }
        public DataTable GetKhachHangTheoTop(int topnumber)
        {
            return objKhachHang.GetRows(topnumber);
        }
        public bool AddKhachHang(KhachHang kh)
        {
            if (!objKhachHang.IsRowExists(kh.MaKhachHang))
                return objKhachHang.AddRow(kh);
            else
                return false;
        }
        public bool DeleteKhachHang(string makh)
        {
            return objKhachHang.DeleteRow(makh);
        }
        public bool UpdateKhachHang(KhachHang kh)
        {
            if (objKhachHang.IsRowExists(kh.MaKhachHang))
                return objKhachHang.UpdateRow(kh);
            else
                return false;
        }
    }
}
