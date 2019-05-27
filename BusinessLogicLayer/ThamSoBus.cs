using DataAccessLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class ThamSoBus
    {
        ThamSoTable objThamSo = new ThamSoTable();
        public bool UpdateThamSo(ThamSo ts)
        {
            if (objThamSo.IsRowExists(ts.MaThamSo))
                return objThamSo.UpdateRow(ts);
            else
                return false;
        }
        public ThamSo GetThamSoByMa(string mats)
        {
            return objThamSo.GetRow(mats);
        }
        public DataTable GetThamSo()
        {
            return objThamSo.GetAllRows();
        }
    }
}
