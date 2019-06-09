using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System;
using DataTransferObject;

namespace DataAccessLayer
{
    public class SachTable : DBConnection
    {
        public SachTable() : base() { }
        public bool DeleteRow(string maSach)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM Sach WHERE MaSach = @masach",_connection);
                command.Parameters.Add("@masach", SqlDbType.Char, 10).Value = maSach;
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
        public Sach GetRow(string maSach)
        {
            Sach sach = null;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Sach WHERE MaSach = @masach", _connection);
                command.Parameters.Add("@masach", SqlDbType.Char, 10).Value = maSach;

                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    sach = new Sach();
                    sach.MaSach = reader["MaSach"].ToString();
                    sach.TenSach = reader["TenSach"].ToString();
                    sach.TacGia = reader["TacGia"].ToString();
                    sach.MoTa = reader["MoTa"].ToString();
                    sach.SoLuongTon = (int)reader["SoLuongTon"];
                    sach.AnhBia = reader["AnhBia"] is DBNull ? null: (byte[])reader["AnhBia"];
                    sach.DonGia = (decimal)reader["DonGia"];
                    sach.MaTheLoai = reader["MaTheLoai"].ToString();
                    sach.NamXuatBan = (int)reader["NamXuatBan"];
                    sach.NhaXuatBan = reader["NhaXuatBan"].ToString();
                    sach.SoTrang = (int)reader["SoTrang"];
                    reader.Close();
                }
    
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return sach;
        }
        public DataTable GetRows(int number)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM Sach ORDER BY MaSach ASC", _connection);
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
        public DataTable GetRowsByTheLoaiSach(string maTheLoai)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM Sach WHERE MaTheLoai = @theloaisach ORDER BY MaSach ASC", _connection);
                command.Parameters.Add("@theloaisach", SqlDbType.Char).Value = maTheLoai;
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
                SqlCommand command = new SqlCommand("SELECT * FROM Sach ORDER BY MaSach ASC", _connection);
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

        public bool AddRow(Sach sach)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[Sach]\n"
                           + "           ([MaSach]\n"
                           + "           ,[TenSach]\n"
                           + "           ,[MaTheLoai]\n"
                           + "           ,[TacGia]\n"
                           + "           ,[SoLuongTon]\n"
                           + "           ,[DonGia]\n"
                           + "           ,[NamXuatBan]\n"
                           + "           ,[NhaXuatBan]\n"
                           + "           ,[SoTrang]\n"
                           + "           ,[MoTa]\n"
                           + "           ,[AnhBia])\n"
                           + "     VALUES\n"
                           + "           (@MaSach\n"
                           + "           ,@TenSach\n"
                           + "           ,@MaTheLoai\n"
                           + "           ,@TacGia\n"
                           + "           ,@SoLuongTon\n"
                           + "           ,@DonGia\n"
                           + "           ,@NamXuatBan\n"
                           + "           ,@NhaXuatBan\n"
                           + "           ,@SoTrang\n"
                           + "           ,@MoTa\n"
                           + "           ,@AnhBia)";
                SqlCommand command = new SqlCommand(sql, _connection);
                command.Parameters.Add("@MaSach", SqlDbType.Char).Value = sach.MaSach;
                command.Parameters.Add("@TenSach", SqlDbType.NChar).Value = sach.TenSach;
                command.Parameters.Add("@MaTheLoai", SqlDbType.Char).Value = sach.MaTheLoai;
                command.Parameters.Add("@TacGia", SqlDbType.NChar).Value = sach.TacGia ?? (object)DBNull.Value;
                command.Parameters.Add("@SoLuongTon", SqlDbType.Int).Value = sach.SoLuongTon;
                command.Parameters.Add("@DonGia", SqlDbType.Money).Value = sach.DonGia;
                command.Parameters.Add("@NamXuatBan", SqlDbType.Int).Value = sach.NamXuatBan;
                command.Parameters.Add("@NhaXuatBan", SqlDbType.NChar).Value = sach.NhaXuatBan ?? (object)DBNull.Value;
                command.Parameters.Add("@SoTrang", SqlDbType.Int).Value = sach.SoTrang;
                command.Parameters.Add("@MoTa", SqlDbType.NChar).Value = sach.MoTa ?? (object)DBNull.Value;
                command.Parameters.Add("@AnhBia", SqlDbType.Image).Value = sach.AnhBia ?? (object)DBNull.Value;
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

        public bool UpdateRow(Sach sach)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[Sach]\n"
                           + "   SET [TenSach] = @TenSach\n"
                           + "      ,[MaTheLoai] = @MaTheLoai\n"
                           + "      ,[TacGia] = @TacGia\n"
                           + "      ,[SoLuongTon] = @SoLuongTon\n"
                           + "      ,[DonGia] = @DonGia\n"
                           + "      ,[NamXuatBan] = @NamXuatBan\n"
                           + "      ,[NhaXuatBan] = @NhaXuatBan\n"
                           + "      ,[SoTrang] = @SoTrang\n"
                           + "      ,[MoTa] = @MoTa\n"
                           + "      ,[AnhBia] = @AnhBia\n"
                           + " WHERE [MaSach] = @MaSach";
                SqlCommand command = new SqlCommand(sql, _connection);
                command.Parameters.Add("@MaSach", SqlDbType.Char).Value = sach.MaSach;
                command.Parameters.Add("@TenSach", SqlDbType.NChar).Value = sach.TenSach;
                command.Parameters.Add("@MaTheLoai", SqlDbType.Char).Value = sach.MaTheLoai;
                command.Parameters.Add("@TacGia", SqlDbType.NChar).Value = sach.TacGia ?? (object)DBNull.Value;
                command.Parameters.Add("@SoLuongTon", SqlDbType.Int).Value = sach.SoLuongTon;
                command.Parameters.Add("@DonGia", SqlDbType.Money).Value = sach.DonGia;
                command.Parameters.Add("@NamXuatBan", SqlDbType.Int).Value = sach.NamXuatBan;
                command.Parameters.Add("@NhaXuatBan", SqlDbType.NChar).Value = sach.NhaXuatBan ?? (object)DBNull.Value;
                command.Parameters.Add("@SoTrang", SqlDbType.Int).Value = sach.SoTrang;
                command.Parameters.Add("@MoTa", SqlDbType.NChar).Value = sach.MoTa ?? (object)DBNull.Value;
                command.Parameters.Add("@AnhBia", SqlDbType.Image).Value = sach.AnhBia ?? (object)DBNull.Value;
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
        public bool IsRowExists(string id)
        {
            bool result = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[Sach] WHERE MaSach = @id", _connection);
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
