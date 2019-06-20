using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataTransferObject
{
    public class ChiTietBaoCaoTon
    {
        public string MaChiTietBaoCaoTon { set; get; }
        public string MaBaoCaoTon { set; get; }
        public string MaSach { set; get; }
        public int TonDau { set; get; }
        public int TonCuoi { set; get; }
        public int PhatSinh { set; get; }
        public ChiTietBaoCaoTon() { }
        public ChiTietBaoCaoTon(string mactbct, string mabct, string masach, int tondau, int toncuoi, int phatsinh)
        {
            MaChiTietBaoCaoTon = mactbct;
            MaBaoCaoTon = mabct;
            MaSach = masach;
            TonDau = tondau;
            TonCuoi = toncuoi;
            PhatSinh = phatsinh;
        }
    }
}
