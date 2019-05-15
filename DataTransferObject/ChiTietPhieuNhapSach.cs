using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class ChiTietPhieuNhapSach
    {
        public string MaChiTietPhieuNhapSach { get; set; }
        public string MaPhieuNhapSach { get; set; }
        public string MaSach { get; set; }
        public int SoLuongNhap { get; set; }
        public int DonGiaNhap { get; set; }
        public ChiTietPhieuNhapSach() { }
        public ChiTietPhieuNhapSach(string maCTPNS,string maPhieuNhapSach,string maSach, int slNhap, int donGiaNhap)
        {
            MaChiTietPhieuNhapSach = maCTPNS;
            MaPhieuNhapSach = maPhieuNhapSach;
            MaSach = maSach;
            SoLuongNhap = slNhap;
            DonGiaNhap = donGiaNhap;
        }
    }
}
