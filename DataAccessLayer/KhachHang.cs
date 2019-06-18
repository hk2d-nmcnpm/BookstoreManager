using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class KhachHangTable: DBConnection
    {
        public KhachHangTable(): base(){}
        public bool AddRow(KhachHang obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[KhachHang]\n"
                           + "           ([MaKhachHang]\n"
                           + "           ,[HoTenKH]\n"
                           + "           ,[SoDienThoai]\n"
                           + "           ,[DiaChi]\n"
                           + "           ,[Email]\n"
                           + "           ,[SoTienNo]\n"
                           + "           ,[TongTien]\n"
                           + "           ,[NgayMuaCuoi])\n"
                           + "     VALUES\n"
                           + "           (@MaKhachHang\n"
                           + "           ,@HoTenKH\n"
                           + "           ,@SoDienThoai\n"
                           + "           ,@DiaChi\n"
                           + "           ,@Email\n"
                           + "           ,@SoTienNo\n"
                           + "           ,@TongTien\n"
                           + "           ,@NgayMuaCuoi)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@HoTenKH", SqlDbType.NVarChar).Value = obj.HoTenKH;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.Char).Value = obj.SoDienThoai ?? (object)DBNull.Value;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NChar).Value = obj.DiaChi ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Email", SqlDbType.NChar).Value = obj.Email ?? (object)DBNull.Value;
                cmd.Parameters.Add("@SoTienNo", SqlDbType.Money).Value = obj.SoTienNo;
                cmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = obj.TongTien;
                cmd.Parameters.Add("@NgayMuaCuoi", SqlDbType.Date).Value = obj.NgayMuaCuoi;
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
        public bool DeleteRow(string maKhachHang)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[KhachHang] WHERE MaKhachHang = @makhachhang", _connection);
                command.Parameters.Add("@makhachhang", SqlDbType.Char).Value = maKhachHang;
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
        public KhachHang GetRow(string maKhachHang)
        {
            try
            {
                var obj = new KhachHang();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM KhachHang WHERE MaKhachHang = @makhachhang", _connection);
                command.Parameters.Add("@makhachhang", SqlDbType.Char).Value = maKhachHang;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaKhachHang = reader["MaKhachHang"].ToString();
                    obj.HoTenKH = reader["HoTenKH"].ToString();
                    obj.SoDienThoai = reader["SoDienThoai"].ToString();
                    obj.DiaChi = reader["DiaChi"].ToString();
                    obj.Email = reader["Email"].ToString();
                    obj.SoTienNo = (decimal)reader["SoTienNo"];
                    obj.TongTien = (decimal)reader["TongTien"];
                    obj.NgayMuaCuoi = (DateTime)reader["NgayMuaCuoi"];
                    reader.Close();
                }
                return obj;
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

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM KhachHang ORDER BY MaKhachHang ASC", _connection);
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

                SqlCommand command = new SqlCommand("SELECT * FROM KhachHang ORDER BY MaKhachHang ASC", _connection);
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
        public bool UpdateRow(KhachHang obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                const string sql = "UPDATE [dbo].[KhachHang]\n"
                           + "   SET [HoTenKH] = @HoTenKH\n"
                           + "      ,[SoDienThoai] = @SoDienThoai\n"
                           + "      ,[DiaChi] = @DiaChi\n"
                           + "      ,[Email] = @Email\n"
                           + "      ,[SoTienNo] = @SoTienNo\n"
                           + "      ,[TongTien] = @TongTien\n"
                           + "      ,[NgayMuaCuoi] = @NgayMuaCuoi\n"
                           + " WHERE [MaKhachHang] = @MaKhachHang";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@HoTenKH", SqlDbType.NVarChar).Value = obj.HoTenKH;
                cmd.Parameters.Add("@SoDienThoai", SqlDbType.Char).Value = obj.SoDienThoai ?? (object)DBNull.Value;
                cmd.Parameters.Add("@DiaChi", SqlDbType.NChar).Value = obj.DiaChi ?? (object)DBNull.Value;
                cmd.Parameters.Add("@Email", SqlDbType.NChar).Value = obj.Email ?? (object)DBNull.Value;
                cmd.Parameters.Add("@SoTienNo", SqlDbType.Money).Value = obj.SoTienNo;
                cmd.Parameters.Add("@TongTien", SqlDbType.Money).Value = obj.TongTien;
                cmd.Parameters.Add("@NgayMuaCuoi", SqlDbType.Date).Value = obj.NgayMuaCuoi;
                cmd.ExecuteNonQuery();
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
        public bool IsRowExists(string id)
        {
            bool result = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[KhachHang] WHERE MaKhachHang = @id", _connection);
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
