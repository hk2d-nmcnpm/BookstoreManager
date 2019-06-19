using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime NgaySinh { get; set; }
        public int ChucVu { get; set; }
        public string MatKhau { get; set; }
        public NhanVien() { }
        public NhanVien(string maNV, string tenNV, DateTime ngaySinh, int chucVu, string matKhau)
        {
            MaNhanVien = maNV;
            TenNhanVien = tenNV;
            NgaySinh = ngaySinh;
            ChucVu = chucVu;
            MatKhau = matKhau;
        }
    }
}
