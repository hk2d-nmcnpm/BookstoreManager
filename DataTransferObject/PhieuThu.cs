using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class PhieuThu
    {
        public string MaPhieuThu { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public string NgayThu { get; set; }
        public float SoTienThu { get; set; }
        public PhieuThu() { }
        public PhieuThu(string maPT,string maKH, string maNV,string ngayThu, float soTien)
        {
            MaPhieuThu = maPT;
            MaKhachHang = maKH;
            MaNhanVien = maNV;
            NgayThu = ngayThu;
            SoTienThu = soTien;
        }
    }
}
