using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class BaoCaoCongNo
    {
        public string MaChiTietCongNo { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaKhachHang { get; set; }
        public float NoDau { get; set; }
        public float NoPhatSinh { get; set; }
        public float NoCuoi { get; set; }
        public BaoCaoCongNo() { }
        public BaoCaoCongNo(string maCTCongNo,int thang,int nam,string maKH, float noDau, float noPS, float noCuoi)
        {
            MaChiTietCongNo = maCTCongNo;
            Thang = thang;
            Nam = nam;
            MaKhachHang = maKH;
            NoDau = noDau;
            NoPhatSinh = noPS;
            NoCuoi = noCuoi;
        }
    }
}
