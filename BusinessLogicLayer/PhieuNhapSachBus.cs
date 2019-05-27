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
    public class PhieuNhapSachBus
    {
        PhieuNhapSachTable objPhieuNhap = new PhieuNhapSachTable();
        NhanVienTable objNV = new NhanVienTable();
        public bool AddPhieuNhap(PhieuNhapSach pn)
        {
            if (!objPhieuNhap.IsRowExists(pn.MaPhieuNhapSach))
                return objPhieuNhap.AddRow(pn);
            else
                return false;
        }
        public bool DeletePhieuNhap(string maphieunhap)
        {
            return objPhieuNhap.DeleteRow(maphieunhap);
        }
        public bool UpdatePhieuNhap(PhieuNhapSach pn)
        {
            if (objPhieuNhap.IsRowExists(pn.MaPhieuNhapSach) && objNV.IsRowExists(pn.MaNhanVien))
                return objPhieuNhap.UpdateRow(pn);
            else
                return false;
        }
        public DataTable GetPhieuNhap()
        {
            return objPhieuNhap.GetAllRows();
        }
        public PhieuNhapSach GetPhieuNhapByMa(string mapn)
        {
            return objPhieuNhap.GetRow(mapn);
        }
        public DataTable GetPhieuNhapByTop(int number)
        {
            return objPhieuNhap.GetRows(number);
        }
    }
}
