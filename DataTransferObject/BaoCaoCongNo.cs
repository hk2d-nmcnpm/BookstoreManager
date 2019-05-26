using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class BaoCaoCongNo
    {
        public string MaChiTietCongNo { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }
        public string MaKhachHang { get; set; }
        public decimal NoDau { get; set; }
        public decimal NoPhatSinh { get; set; }
        public decimal NoCuoi { get; set; }
        public BaoCaoCongNo() { }
        public BaoCaoCongNo(string maCTCongNo,int thang,int nam,string maKH, decimal noDau, decimal noPS, decimal noCuoi)
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
