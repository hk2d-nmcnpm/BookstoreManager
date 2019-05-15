using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObject
{
    class ThamSo
    {
        public string MaThamSo { get; set; }
        public string TenThamSo { get; set; }
        public int GiaTri { get; set; }
        public ThamSo() { }
        public ThamSo(string maTS, string tenTS, int giaTri)
        {
            MaThamSo = maTS;
            TenThamSo = tenTS;
            GiaTri = giaTri;
        }
    }
}
