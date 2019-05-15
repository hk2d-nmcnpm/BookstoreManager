using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class ChiTietHoaDon
    {
        public string MaChiTietHoaDon { get; set; }
        public string MaHoaDon { get; set; }
        public string MaSach { get; set; }
        public int SoLuongBan { get; set; }
        public float DonGiaBan { get; set; }
        public ChiTietHoaDon() { }
        public ChiTietHoaDon(string maCTHoaDon,string maHD,string maSach,int slBan,float donGia)
        {
            MaChiTietHoaDon = maCTHoaDon;
            MaHoaDon = maHD;
            MaSach = maSach;
            SoLuongBan = slBan;
            DonGiaBan = donGia;
        }
    }
}
