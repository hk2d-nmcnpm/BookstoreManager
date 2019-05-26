using System;
using System.Data.SqlClient;
using System.Data;
using DataTransferObject;


namespace DataAccessLayer
{
    public class PhieuNhapSachTable: DBConnection
    {
        public PhieuNhapSachTable() : base() { }
        public bool AddRow(PhieuNhapSach obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[PhieuNhapSach]\n"
                           + "           ([MaPhieuNhapSach]\n"
                           + "           ,[NgayNhap]\n"
                           + "           ,[MaNhanVien])\n"
                           + "     VALUES\n"
                           + "           (@MaPhieuNhapSach\n"
                           + "           ,@NgayNhap\n"
                           + "           ,@MaNhanVien)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaPhieuNhapSach", SqlDbType.Char).Value = obj.MaPhieuNhapSach;
                cmd.Parameters.Add("@NgayNhap", SqlDbType.Date).Value = obj.NgayNhap;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
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
        public bool DeleteRow(string maPhieuNhapSach)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[PhieuNhapSach] WHERE MaPhieuNhapSach = @maphieunhapsach", _connection);
                command.Parameters.Add("@maphieunhapsach", SqlDbType.Char).Value = maPhieuNhapSach;
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
        public PhieuNhapSach GetRow(string maPhieuNhapSach)
        {
            try
            {
                var obj = new PhieuNhapSach();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PhieuNhapSach WHERE MaPhieuNhapSach = @maphieunhapsach", _connection);
                command.Parameters.Add("@maphieunhapsach", SqlDbType.Char).Value = maPhieuNhapSach;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaPhieuNhapSach = reader["MaPhieuNhapSach"].ToString();
                    obj.MaNhanVien = reader["MaNhanVien"].ToString();
                    obj.NgayNhap = (DateTime)reader["NgayNhap"];
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

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM PhieuNhapSach ORDER BY MaPhieuNhapSach ASC", _connection);
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

                SqlCommand command = new SqlCommand("SELECT * FROM PhieuNhapSach ORDER BY MaPhieuNhapSach ASC", _connection);
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
        public bool UpdateRow(PhieuNhapSach obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[PhieuNhapSach]\n"
                           + "   SET [NgayNhap] = @NgayNhap\n"
                           + "      ,[MaNhanVien] = @MaNhanVien\n"
                           + " WHERE [MaPhieuNhapSach] = @MaPhieuNhapSach";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaPhieuNhapSach", SqlDbType.Char).Value = obj.MaPhieuNhapSach;
                cmd.Parameters.Add("@NgayNhap", SqlDbType.Date).Value = obj.NgayNhap;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[PhieuNhapSach] WHERE MaPhieuNhapSach = @id", _connection);
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
