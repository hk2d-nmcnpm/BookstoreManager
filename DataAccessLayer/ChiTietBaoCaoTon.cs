using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class ChiTietBaoCaoTonTable:DBConnection
    {
        public ChiTietBaoCaoTonTable() : base() { }
        public bool AddChiTiet(ChiTietBaoCaoTon ctbct)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "insert into ChiTietBaoCaoTon values(@MaChiTiet," +
                    "@MaBaoCaoTon," +
                    "@MaSach," +
                    "@TonDau," +
                    "@TonCuoi," +
                    "@PhatSinh)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTiet", SqlDbType.Char).Value = ctbct.MaChiTietBaoCaoTon;
                cmd.Parameters.Add("@MaBaoCaoTon", SqlDbType.Char).Value = ctbct.MaBaoCaoTon;
                cmd.Parameters.Add("@MaSach", SqlDbType.Char).Value = ctbct.MaSach;
                cmd.Parameters.Add("@TonDau", SqlDbType.Int).Value = ctbct.TonDau;
                cmd.Parameters.Add("@TonCuoi", SqlDbType.Int).Value = ctbct.TonCuoi;
                cmd.Parameters.Add("@PhatSinh", SqlDbType.Int).Value = ctbct.PhatSinh;
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + "jhgjdhghfghjgfh");
                _connection.Close();
            }
            return false;
        }
        public bool RemoveAll(string MaBaoCaoCongTon)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string query = "delete from ChiTietBaoCaoTon where MaBaoCaoTon=@MaBaoCaoTon";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.Add("@MaBaoCaoTon", SqlDbType.Char).Value = MaBaoCaoCongTon;
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                _connection.Close();
            }
            return false;
        }
    }
}
