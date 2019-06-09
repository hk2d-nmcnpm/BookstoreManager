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
    public class PhieuThuBus
    {
        PhieuThuTable objPhieuThu = new PhieuThuTable();
        NhanVienTable objNV = new NhanVienTable();
        KhachHangTable objKH = new KhachHangTable();
        public bool AddPhieuThu(PhieuThu pt)
        {
            if (!objPhieuThu.IsRowExists(pt.MaPhieuThu))
                return objPhieuThu.AddRow(pt);
            else
                return false;
        }
        public bool DeletePhieuThu(string mapt)
        {
            return objPhieuThu.DeleteRow(mapt);
        }
        public bool UpdatePhieuThu(PhieuThu pt)
        {
            if (objPhieuThu.IsRowExists(pt.MaPhieuThu) && objNV.IsRowExists(pt.MaNhanVien) && objKH.IsRowExists(pt.MaKhachHang))
                return objPhieuThu.UpdateRow(pt);
            else
                return false;
        }
        public DataTable GetPhieuThu()
        {
            return objPhieuThu.GetAllRows();
        }
        public PhieuThu GetPhieuThuByMa(string mapt)
        {
            return objPhieuThu.GetRow(mapt);
        }
        public DataTable GetPhieuThuByTop(int number)
        {
            return objPhieuThu.GetRows(number);
        }
        public int TongTien()
        {
            return 0;
        }
        public DataTable GetDisplayTable()
        {
            return objPhieuThu.GetDisplayTable();
        }
    }
}
