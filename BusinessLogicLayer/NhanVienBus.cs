﻿using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class NhanVienBus
    {
        NhanVienTable objNhanVien = new NhanVienTable();
        public Dictionary<int, string> ChucVu { get; } = new Dictionary<int, string>()
        {
            [1] = "Quản trị viên",
            [2] = "Nhân Viên",
        };
        public DataTable GetNhanVien()
        {
            return objNhanVien.GetAllRows();
        }
        public NhanVien GetNhanVienByMa(string manv)
        {
            return objNhanVien.GetRow(manv);
        }
        public DataTable GetNhanVienTheoTop(int topnumber)
        {
            return objNhanVien.GetRows(topnumber);
        }
        public bool AddNhanVien(NhanVien nv)
        {
            if (!objNhanVien.IsRowExists(nv.MaNhanVien))
                return objNhanVien.AddRow(nv);
            else
                return false;
        }
        public bool DeleteNhanVien(string manv)
        {
            return objNhanVien.DeleteRow(manv);
        }
        public bool UpdateNhanVien(NhanVien nv)
        {
            if (objNhanVien.IsRowExists(nv.MaNhanVien))
                return objNhanVien.UpdateRow(nv);
            else
                return false;
        }
        public bool KiemTraTaiKhoan(string manv, string mk)
        {
            return objNhanVien.IsRowExists(manv) && objNhanVien.CheckPassword(manv, mk);
        }
    }
}
