using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class BaoCaoTon
    {
        public string MaChiTietTon { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaSach { get; set; }
        public int TonDau { get; set; }
        public int PhatSinh { get; set; }
        public int TonCuoi { get; set; }
        public BaoCaoTon() { }
        public BaoCaoTon(string maCTTon, int thang, int nam,string maSach, int tonDau, int phatSinh,int tonCuoi)
        {
            MaChiTietTon = maCTTon;
            Thang = thang;
            Nam = nam;
            MaSach = maSach;
            TonDau = tonDau;
            PhatSinh = phatSinh;
            TonCuoi = tonCuoi;
        }


    }
}
