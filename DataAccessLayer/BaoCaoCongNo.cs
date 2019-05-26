using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class BaoCaoCongNoTable:DBConnection
    {
        public BaoCaoCongNoTable() : base() { }
        public bool AddRow(BaoCaoCongNo obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[BaoCaoCongNo]\n"
                           + "           ([MaChiTietCongNo]\n"
                           + "           ,[Thang]\n"
                           + "           ,[Nam]\n"
                           + "           ,[MaKhachHang]\n"
                           + "           ,[NoDau]\n"
                           + "           ,[NoPhatSinh]\n"
                           + "           ,[NoCuoi])\n"
                           + "     VALUES\n"
                           + "           (@MaChiTietCongNo\n"
                           + "           ,@Thang\n"
                           + "           ,@Nam\n"
                           + "           ,@MaKhachHang\n"
                           + "           ,@NoDau\n"
                           + "           ,@NoPhatSinh\n"
                           + "           ,@NoCuoi)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietCongNo", SqlDbType.Char).Value = obj.MaChiTietCongNo;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = obj.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = obj.Nam;
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@NoDau", SqlDbType.Money).Value = obj.NoDau;
                cmd.Parameters.Add("@NoPhatSinh", SqlDbType.Money).Value = obj.NoPhatSinh;
                cmd.Parameters.Add("@NoCuoi", SqlDbType.Money).Value = obj.NoCuoi;
                cmd.ExecuteNonQuery();
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
        public bool DeleteRow(string maCTCongNo)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[BaoCaoCongNo] WHERE MaChiTietCongNo = @mactcongno", _connection);
                command.Parameters.Add("@mactcongno", SqlDbType.Char).Value = maCTCongNo;
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
        public BaoCaoCongNo GetRow(string maCTCongNo)
        {
            try
            {
                var obj = new BaoCaoCongNo();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[BaoCaoCongNo] WHERE MaChiTietCongNo = @mactcongno", _connection);
                command.Parameters.Add("@mactcongno", SqlDbType.Char).Value = maCTCongNo;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaChiTietCongNo = reader["MaChiTietCongNo"].ToString();
                    obj.MaKhachHang = reader["MaKhachHang"].ToString();
                    obj.Nam = (int)reader["Nam"];
                    obj.NoPhatSinh = (decimal)reader["NoPhatSinh"];
                    obj.Thang = (int)reader["Thang"];
                    obj.NoDau = (decimal)reader["NoDau"];
                    obj.NoCuoi = (decimal)reader["NoCuoi"];
                    reader.Close();
                }

            }
            catch (Exception ex)
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

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM [dbo].[BaoCaoCongNo] ORDER BY MaChiTietCongNo ASC", _connection);
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
        public DataTable GetRowsByThang(int thang, int nam)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[BaoCaoCongNo] WHERE Nam = @nam AND Thang = @thang ORDER BY MaChiTietCongNo ASC", _connection);
                command.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
                command.Parameters.Add("@nam", SqlDbType.Int).Value = nam;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[BaoCaoCongNo] ORDER BY MaChiTietCongNo ASC", _connection);
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
        public bool UpdateRow(BaoCaoCongNo obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[BaoCaoCongNo]\n"
                           + "   SET [Thang] = @Thang\n"
                           + "      ,[Nam] = @Nam\n"
                           + "      ,[MaKhachHang] = @MaKhachHang\n"
                           + "      ,[NoDau] = @NoDau\n"
                           + "      ,[NoPhatSinh] = @NoPhatSinh\n"
                           + "      ,[NoCuoi] = @NoCuoi\n"
                           + " WHERE [MaChiTietCongNo] = @MaChiTietCongNo";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietCongNo", SqlDbType.Char).Value = obj.MaChiTietCongNo;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = obj.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = obj.Nam;
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@NoDau", SqlDbType.Money).Value = obj.NoDau;
                cmd.Parameters.Add("@NoPhatSinh", SqlDbType.Money).Value = obj.NoPhatSinh;
                cmd.Parameters.Add("@NoCuoi", SqlDbType.Money).Value = obj.NoCuoi;
                cmd.ExecuteNonQuery();
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
        public bool IsRowExists(string id)
        {
            bool result = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[BaoCaoCongNo] WHERE MaChiTietCongNo = @id", _connection);
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
