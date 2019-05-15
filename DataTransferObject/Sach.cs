using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class Sach
    {
        public string MaSach { get; set; }
        public string TenSach { get; set; }
        public string MaTheLoai { get; set; }
        public string TacGia { get; set; }
        public int SoLuongTon { get; set; }
        public float DonGia { get; set; }
        public int NamXuatBan { get; set; }
        public string NhaXuatBan { get; set; }
        public int SoTrang { get; set; }
        public string MoTa { get; set; }
        public string AnhBia { get; set; }
        public Sach() { }
        public Sach(string maSach,string tenSach,string maTL, string tacGia,int slTon,float donGia,int namXB, string nhaXB, int soTrang,string moTa,string anhBia)
        {
            MaSach = maSach;
            TenSach = tenSach;
            MaTheLoai = maTL;
            TacGia = tacGia;
            SoLuongTon = slTon;
            DonGia = donGia;
            NamXuatBan = namXB;
            NhaXuatBan = nhaXB;
            SoTrang = soTrang;
            MoTa = moTa;
            AnhBia = anhBia;
        }
    }
}
