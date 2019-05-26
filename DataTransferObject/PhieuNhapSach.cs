using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class PhieuNhapSach
    {
        public string MaPhieuNhapSach { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MaNhanVien { get; set; }
        public PhieuNhapSach() { }
        public PhieuNhapSach(string maPNS, DateTime ngayNhap,string maNV)
        {
            MaPhieuNhapSach = maPNS;
            NgayNhap = ngayNhap;
            MaNhanVien = maNV;
        }
    }
}
