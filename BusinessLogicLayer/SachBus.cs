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
    public class SachBus
    {
        SachTable objSach = new SachTable();
        TheLoaiSachTable objTheLoai = new TheLoaiSachTable();
        public DataTable GetSach()
        {
            return objSach.GetAllRows();
        }
        public bool DeleteSach(string masach)
        {
            if (objSach.IsRowExists(masach))
                return objSach.DeleteRow(masach);
            else
                return false;
        }
        public DataTable GetSachByTheLoai(string matheloai)
        {
            return objSach.GetRowsByTheLoaiSach(matheloai);
        }
        public Sach GetSachByMaSach(string masach)
        {
            return objSach.GetRow(masach);
        }
        public DataTable GetSachTheoTop(int topnumber)
        {
            return objSach.GetRows(topnumber);
        }
        public bool AddSach(Sach s)
        {
            if (!objSach.IsRowExists(s.MaSach) && objTheLoai.IsRowExists(s.MaTheLoai))
                return objSach.AddRow(s);
            else
                return false;
        }
        public bool UpdateSach(Sach s)
        {
            if (objSach.IsRowExists(s.MaSach) && objTheLoai.IsRowExists(s.MaTheLoai))
                return objSach.UpdateRow(s);
            else
                return false;                 
        }
        public bool DeleteSach(string masach)
        {
            return objSach.DeleteRow(masach);
        }
    }
}
