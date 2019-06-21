using BusinessLogicLayer;
using DataTransferObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BookstoreManager
{
    public partial class Regulation : Form
    {
        public Regulation()
        {
            InitializeComponent();
        }

        private void QD_BTN_ChinhSua_Click(object sender, EventArgs e)
        {
            QD_BTN_ChinhSua.Enabled = false;
            QD_BTN_Luu.Enabled = true;
            QD_TB_Nhap.Enabled = true;
            QD_TB_TienNo.Enabled = true;
            QD_TB_ToiThieu.Enabled = true;
            QD_TB_Ton.Enabled = true;
            QD_CKB.Enabled = true;
        }

        private void QD_BTN_Luu_Click(object sender, EventArgs e)
        {
            QD_BTN_ChinhSua.Enabled = true;
            QD_BTN_Luu.Enabled = false;
            QD_TB_Nhap.Enabled = false;
            QD_TB_TienNo.Enabled = false;
            QD_TB_ToiThieu.Enabled = false;
            QD_TB_Ton.Enabled = false;
            QD_CKB.Enabled = false;
            ThamSoBus thamsoBus = new ThamSoBus();
            DataTable dsthamso = thamsoBus.GetThamSo();
            List<ThamSo> thamso = new List<ThamSo>();
            thamso.Clear();
            foreach(DataRow dr in dsthamso.Rows)
            {
                var ts = new ThamSo()
                {
                    MaThamSo = dr["MaThamSo"].ToString().Trim(),
                    TenThamSo=dr["TenThamSo"].ToString().Trim(),
                    GiaTri=int.Parse(dr["GiaTri"].ToString())
                };
                thamso.Add(ts);
            }
            thamso[0].GiaTri = int.Parse(QD_TB_Nhap.Text);
            thamso[1].GiaTri = int.Parse(QD_TB_Ton.Text);
            thamso[2].GiaTri = int.Parse(QD_TB_ToiThieu.Text);
            thamso[3].GiaTri = int.Parse(QD_TB_TienNo.Text);
            thamso[4].GiaTri = QD_CKB.Checked == true ? 1 : 0;

            foreach (ThamSo ts in thamso)
                thamsoBus.UpdateThamSo(ts);
        }
    }
}
