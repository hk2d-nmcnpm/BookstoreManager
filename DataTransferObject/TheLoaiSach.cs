using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    public class TheLoaiSach
    {
        public string MaTheLoai { get; set; }
        public string TenTheLoai { get; set; }
        public TheLoaiSach() { }
        public TheLoaiSach(string maTL, string tenTL)
        {
            MaTheLoai = maTL;
            TenTheLoai = tenTL;
        }
    }
}
