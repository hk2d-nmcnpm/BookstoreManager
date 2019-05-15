using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public string NgaySinh { get; set; }
        public NhanVien() { }
        public NhanVien(string maNV, string tenNV, string ngaySinh)
        {
            MaNhanVien = maNV;
            TenNhanVien = tenNV;
            NgaySinh = ngaySinh;
        }
    }
}
