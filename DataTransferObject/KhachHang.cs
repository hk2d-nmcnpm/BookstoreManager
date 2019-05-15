using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class KhachHang
    {
        public string MaKhachHang { get; set; }
        public string HoTenKH { get; set; }
        public string SoDienThoai { get; set; }
        public string DiaChi { get; set; }
        public string Email { get; set; }
        public float SoTienNo { get; set; }
        public KhachHang() { }
        public KhachHang(string maKH, string hoten,string sdt,string diaChi,string email, float tienNo)
        {
            MaKhachHang = maKH;
            HoTenKH = hoten;
            SoDienThoai = sdt;
            DiaChi = diaChi;
            Email = email;
            SoTienNo = tienNo;
        }
    }
}
