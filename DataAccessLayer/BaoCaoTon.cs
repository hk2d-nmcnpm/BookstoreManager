using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class BaoCaoTonTable: DBConnection
    {
        public BaoCaoTonTable() : base() { }
        public bool AddRow(BaoCaoTon obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[BaoCaoTon]\n"
                           + "           ([MaChiTietTon]\n"
                           + "           ,[Thang]\n"
                           + "           ,[Nam]\n"
                           + "           ,[MaSach]\n"
                           + "           ,[TonDau]\n"
                           + "           ,[PhatSinh]\n"
                           + "           ,[TonCuoi])\n"
                           + "     VALUES\n"
                           + "           (@MaChiTietTon\n"
                           + "           ,@Thang\n"
                           + "           ,@Nam\n"
                           + "           ,@MaSach\n"
                           + "           ,@TonDau\n"
                           + "           ,@PhatSinh\n"
                           + "           ,@TonCuoi)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietTon", SqlDbType.Char).Value = obj.MaChiTietTon;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = obj.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = obj.Nam;
                cmd.Parameters.Add("@MaSach", SqlDbType.Char).Value = obj.MaSach;
                cmd.Parameters.Add("@TonDau", SqlDbType.Int).Value = obj.TonDau;
                cmd.Parameters.Add("@PhatSinh", SqlDbType.Int).Value = obj.PhatSinh;
                cmd.Parameters.Add("@TonCuoi", SqlDbType.Int).Value = obj.TonCuoi;
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
        public bool DeleteRow(string maChiTietTon)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[BaoCaoTon] WHERE MaChiTietTon = @mactton", _connection);
                command.Parameters.Add("@mactton", SqlDbType.Char).Value = maChiTietTon;
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
        public BaoCaoTon GetRow(string maChiTietTon)
        {
            try
            {
                var obj = new BaoCaoTon();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM BaoCaoTon WHERE MaChiTietTon = @mactton", _connection);
                command.Parameters.Add("@mactton", SqlDbType.Char).Value = maChiTietTon;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaChiTietTon = reader["MaChiTietTon"].ToString();
                    obj.MaSach = reader["MaSach"].ToString();
                    obj.Nam = (int)reader["Nam"];
                    obj.PhatSinh = (int)reader["PhatSinh"];
                    obj.Thang = (int)reader["Thang"];
                    obj.TonCuoi = (int)reader["TonCuoi"];
                    obj.TonDau = (int)reader["TonDau"];
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

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM BaoCaoTon ORDER BY MaChiTietTon ASC", _connection);
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

                SqlCommand command = new SqlCommand("SELECT * FROM BaoCaoTon WHERE Nam = @nam AND Thang = @thang ORDER BY MaChiTietTon ASC", _connection);
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

                SqlCommand command = new SqlCommand("SELECT * FROM BaoCaoTon ORDER BY MaChiTietTon ASC", _connection);
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
        public bool UpdateRow(BaoCaoTon obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[BaoCaoTon]\n"
                           + "   SET [Thang] = @Thang\n"
                           + "      ,[Nam] = @Nam\n"
                           + "      ,[MaSach] = @MaSach\n"
                           + "      ,[TonDau] = @TonDau\n"
                           + "      ,[PhatSinh] = @PhatSinh\n"
                           + "      ,[TonCuoi] = @TonCuoi\n"
                           + " WHERE [MaChiTietTon] = @MaChiTietTon";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietTon", SqlDbType.Char).Value = obj.MaChiTietTon;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = obj.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = obj.Nam;
                cmd.Parameters.Add("@MaSach", SqlDbType.Char).Value = obj.MaSach;
                cmd.Parameters.Add("@TonDau", SqlDbType.Int).Value = obj.TonDau;
                cmd.Parameters.Add("@PhatSinh", SqlDbType.Int).Value = obj.PhatSinh;
                cmd.Parameters.Add("@TonCuoi", SqlDbType.Int).Value = obj.TonCuoi;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[BaoCaoTon] WHERE MaChiTietTon = @id", _connection);
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
