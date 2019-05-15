using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class HoaDon
    {
        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public string NgayHoaDon { get; set; }
        public float GiamGia { get; set; }
        public float TienKhachDua { get; set; }
        public HoaDon () { }
        public HoaDon(string maHD,string maKH, string maNV, string ngayHD, float giamGia, float tienKhachDua)
        {
            MaHoaDon = maHD;
            MaKhachHang = maKH;
            MaNhanVien = maNV;
            NgayHoaDon = ngayHD;
            GiamGia = giamGia;
            TienKhachDua = tienKhachDua;
        }

    }
}
