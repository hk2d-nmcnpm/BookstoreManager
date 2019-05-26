using System;

namespace DataTransferObject
{
    public class PhieuThu
    {
        public string MaPhieuThu { get; set; }
        public string MaKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime NgayThu { get; set; }
        public decimal SoTienThu { get; set; }
        public PhieuThu() { }
        public PhieuThu(string maPT,string maKH, string maNV,DateTime ngayThu, decimal soTien)
        {
            MaPhieuThu = maPT;
            MaKhachHang = maKH;
            MaNhanVien = maNV;
            NgayThu = ngayThu;
            SoTienThu = soTien;
        }
    }
}
