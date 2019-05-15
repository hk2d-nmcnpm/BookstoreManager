using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class PhieuNhapSach
    {
        public string MaPhieuNhapSach { get; set; }
        public string NgayNhap { get; set; }
        public string MaNhanVien { get; set; }
        public PhieuNhapSach() { }
        public PhieuNhapSach(string maPNS, string ngayNhap,string maNV)
        {
            MaPhieuNhapSach = maPNS;
            NgayNhap = ngayNhap;
            MaNhanVien = maNV;
        }
    }
}
