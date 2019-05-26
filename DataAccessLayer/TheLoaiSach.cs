using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataTransferObject;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class TheLoaiSachTable : DBConnection
    {
        public TheLoaiSachTable(): base() { }
        public bool AddRow(TheLoaiSach theLoai)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                const string cmdText = "INSERT INTO TheLoaiSach VALUES (@MaTheLoai,@TenTheLoai)";
                var command = new SqlCommand(cmdText, _connection);
                command.Parameters.Add("@MaTheLoai", SqlDbType.Char).Value = theLoai.MaTheLoai;
                command.Parameters.Add("@TenTheLoai", SqlDbType.NChar).Value = theLoai.TenTheLoai;
                command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public bool UpdateRow(TheLoaiSach theLoai)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                const string cmdText = "UPDATE TheLoaiSach SET TenTheLoai = @TenTheLoai WHERE MaTheLoai = @MaTheLoai";
                var command = new SqlCommand(cmdText, _connection);
                command.Parameters.Add("@MaTheLoai", SqlDbType.Char).Value = theLoai.MaTheLoai;
                command.Parameters.Add("@TenTheLoai", SqlDbType.NChar).Value = theLoai.TenTheLoai;
                command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return false;
        }
        public bool DeleteRow(string maTheLoai)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                const string cmdText = "DELETE FROM TheLoaiSach WHERE MaTheLoai = @MaTheLoai";
                var command = new SqlCommand(cmdText, _connection);
                command.Parameters.Add("@MaTheLoai", SqlDbType.Char).Value = maTheLoai;
                command.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public TheLoaiSach GetRow(string maTheLoai)
        {
            try
            {
                TheLoaiSach theLoai = new TheLoaiSach();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                const string sql = "SELECT * FROM TheLoaiSach WHERE MaTheLoai = @matheloai";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@matheloai", SqlDbType.Char).Value = maTheLoai;
                var rd = cmd.ExecuteReader();
                if(rd.Read())
                {
                    theLoai.MaTheLoai = rd["MaTheLoai"].ToString();
                    theLoai.TenTheLoai = rd["TenTheLoai"].ToString();
                    rd.Close();
                }

                //_connection.Close();
                return theLoai;
            }
            catch(Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable GetRows(int number)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM TheLoaiSach ORDER BY MaTheLoai ASC", _connection);
                command.Parameters.Add("@number", SqlDbType.Int).Value = number;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                _connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        public DataTable GetAllRows()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM TheLoaiSach ORDER BY MaTheLoai ASC", _connection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                _connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return null;
        }
        public bool IsRowExists(string id)
        {
            bool result = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[TheLoaiSach] WHERE MaTheLoai = @id", _connection);
                command.Parameters.Add("@id", SqlDbType.Char).Value = id;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count == 1)
                    result = true;
                _connection.Close();
                return result;
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return result;
        }
    }
}
