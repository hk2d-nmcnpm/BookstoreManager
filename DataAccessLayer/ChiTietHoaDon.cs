using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class ChiTietHoaDonTable: DBConnection
    {
        public ChiTietHoaDonTable() : base() { }
        public bool AddRow(ChiTietHoaDon obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[ChiTietHoaDon]\n"
                           + "           ([MaChiTietHoaDon]\n"
                           + "           ,[MaHoaDon]\n"
                           + "           ,[MaSach]\n"
                           + "           ,[SoLuongBan]\n"
                           + "           ,[DonGiaBan])\n"
                           + "     VALUES\n"
                           + "           (@MaChiTietHoaDon\n"
                           + "           ,@MaHoaDon\n"
                           + "           ,@MaSach\n"
                           + "           ,@SoLuongBan\n"
                           + "           ,@DonGiaBan)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietHoaDon", SqlDbType.Char).Value = obj.MaChiTietHoaDon;
                cmd.Parameters.Add("@MaHoaDon", SqlDbType.Char).Value = obj.MaHoaDon;
                cmd.Parameters.Add("@MaSach", SqlDbType.Char).Value = obj.MaSach;
                cmd.Parameters.Add("@SoLuongBan", SqlDbType.Int).Value = obj.SoLuongBan;
                cmd.Parameters.Add("@DonGiaBan", SqlDbType.Money).Value = obj.DonGiaBan;
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
        public bool DeleteRow(string maCTHoaDon)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[ChiTietHoaDon] WHERE MaChiTietHoaDon = @machitiethoadon", _connection);
                command.Parameters.Add("@machitiethoadon", SqlDbType.Char).Value = maCTHoaDon;
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
        public ChiTietHoaDon GetRow(string maCTHoaDon)
        {
            try
            {
                var obj = new ChiTietHoaDon();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM ChiTietHoaDon WHERE MaChiTietHoaDon = @machitiethoadon", _connection);
                command.Parameters.Add("@machitiethoadon", SqlDbType.Char).Value = maCTHoaDon;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaChiTietHoaDon = reader["MaChiTietHoaDon"].ToString();
                    obj.MaHoaDon = reader["MaHoaDon"].ToString();
                    obj.MaSach = reader["MaSach"].ToString();
                    obj.SoLuongBan = (int)reader["SoLuongBan"];
                    obj.DonGiaBan = (decimal)reader["DonGiaBan"];
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
        public DataTable GetRowsByMaHoaDon(string maHoaDon)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM ChiTietHoaDon WHERE MaHoaDon = @mahoadon ORDER BY MaChiTietHoaDon ASC", _connection);
                command.Parameters.Add("@mahoadon", SqlDbType.Char).Value = maHoaDon;
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
        public DataTable GetRows(int number)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM ChiTietHoaDon ORDER BY MaChiTietHoaDon ASC", _connection);
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

                SqlCommand command = new SqlCommand("SELECT * FROM ChiTietHoaDon ORDER BY MaChiTietHoaDon ASC", _connection);
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
        public bool UpdateRow(ChiTietHoaDon obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[ChiTietHoaDon]\n"
                           + "   SET [MaHoaDon] = @MaHoaDon\n"
                           + "      ,[MaSach] = @MaSach\n"
                           + "      ,[SoLuongBan] = @SoLuongBan\n"
                           + "      ,[DonGiaBan] = @DonGiaBan\n"
                           + " WHERE [MaChiTietHoaDon] = @MaChiTietHoaDon";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietHoaDon", SqlDbType.Char).Value = obj.MaChiTietHoaDon;
                cmd.Parameters.Add("@MaHoaDon", SqlDbType.Char).Value = obj.MaHoaDon;
                cmd.Parameters.Add("@MaSach", SqlDbType.Char).Value = obj.MaSach;
                cmd.Parameters.Add("@SoLuongBan", SqlDbType.Int).Value = obj.SoLuongBan;
                cmd.Parameters.Add("@DonGiaBan", SqlDbType.Money).Value = obj.DonGiaBan;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[ChiTietHoaDon] WHERE MaChiTietHoaDon = @id", _connection);
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
