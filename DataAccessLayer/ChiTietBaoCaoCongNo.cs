using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class ChiTietBaoCaoCongNoTable:DBConnection
    {
        public ChiTietBaoCaoCongNoTable() : base() { }
        public bool AddChiTiet(ChiTietBaoCaoCongNo ctbccn)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "insert into ChiTietBaoCaoCongNo values(@MaChiTiet," +
                    "@MaBaoCaoCongNo," +
                    "@MaKhachHang," +
                    "@NoDau," +
                    "@NoCuoi," +
                    "@PhatSinh)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTiet", SqlDbType.Char).Value = ctbccn.MaChiTietBaoCaoCongNo;
                cmd.Parameters.Add("@MaBaoCaoCongNo", SqlDbType.Char).Value = ctbccn.MaBaoCaoCongNo;
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = ctbccn.MaKhachHang;
                cmd.Parameters.Add("@NoDau", SqlDbType.Decimal).Value = ctbccn.NoDau;
                cmd.Parameters.Add("@NoCuoi", SqlDbType.Decimal).Value = ctbccn.NoCuoi;
                cmd.Parameters.Add("@PhatSinh", SqlDbType.Decimal).Value = ctbccn.PhatSinh;
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
        public bool RemoveAll(string MaBaoCaoCongNo)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string query = "delete from ChiTietBaoCaoCongNo where MaBaoCaoCongNo=@MaBaoCaoCongNo";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.Add("@MaBaoCaoCongNo", SqlDbType.Char).Value = MaBaoCaoCongNo;
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
