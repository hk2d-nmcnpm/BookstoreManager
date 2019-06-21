using System;
using System.Data;
using System.Data.SqlClient;
using DataTransferObject;
using System.Text;
using System.Security.Cryptography;

namespace DataAccessLayer
{
    public class NhanVienTable: DBConnection
    {
        public NhanVienTable() : base() { }
        public bool DeleteRow(string maNhanVien)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[NhanVien] WHERE MaNhanVien = @manhanvien", _connection);
                command.Parameters.Add("@manhanvien", SqlDbType.Char).Value = maNhanVien;
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
        public NhanVien GetRow(string maNhanVien)
        {
            try
            {
                var obj = new NhanVien();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM NhanVien WHERE MaNhanVien = @manhanvien", _connection);
                command.Parameters.Add("@manhanvien", SqlDbType.Char).Value = maNhanVien;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaNhanVien = reader["MaNhanVien"].ToString();
                    obj.TenNhanVien = reader["TenNhanVien"].ToString();
                    obj.NgaySinh = (DateTime)reader["NgaySinh"];
                    obj.ChucVu = (int)reader["ChucVu"];
                    obj.MatKhau = (string)reader["MatKhau"];
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

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM NhanVien ORDER BY MaNhanVien ASC", _connection);
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
                SqlCommand command = new SqlCommand("SELECT * FROM NhanVien ORDER BY MaNhanVien ASC", _connection);
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

        public bool AddRow(NhanVien obj)
        {
            using (MD5 md5 = MD5.Create())
            {
                string passMD5 = GetMd5Hash(md5, obj.MatKhau);
                try
                {
                    if (_connection.State != ConnectionState.Open)
                        _connection.Open();
                    string sql = "INSERT INTO [dbo].[NhanVien]\n"
                           + "           ([MaNhanVien]\n"
                           + "           ,[TenNhanVien]\n"
                           + "           ,[NgaySinh]\n"
                           + "           ,[ChucVu]\n"
                           + "           ,[MatKhau])\n"
                           + "     VALUES\n"
                           + "           (@MaNhanVien\n"
                           + "           ,@TenNhanVien\n"
                           + "           ,@NgaySinh\n"
                           + "           ,@ChucVu\n"
                           + "           ,@MatKhau)";
                    SqlCommand cmd = new SqlCommand(sql, _connection);
                    cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
                    cmd.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = obj.TenNhanVien;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = obj.NgaySinh;
                    cmd.Parameters.Add("@ChucVu", SqlDbType.TinyInt).Value = obj.ChucVu;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.Char).Value = passMD5;
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    _connection.Close();
                    Console.WriteLine(ex.Message);
                }
            }
            return false;
        }

        public bool UpdateRow(NhanVien obj)
        {
            using (MD5 md5 = MD5.Create())
            {
                string passMD5 = GetMd5Hash(md5, obj.MatKhau);
                try
                {
                    if (_connection.State != ConnectionState.Open)
                        _connection.Open();
                    const string sql = "UPDATE [dbo].[NhanVien]\n"
                               + "   SET [TenNhanVien] = @TenNhanVien\n"
                               + "      ,[NgaySinh] = @NgaySinh\n"
                               + "      ,[ChucVu] = @ChucVu\n"
                               + "      ,[MatKhau] = @MatKhau\n"
                               + " WHERE [MaNhanVien] = @MaNhanVien";
                    SqlCommand cmd = new SqlCommand(sql, _connection);
                    cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
                    cmd.Parameters.Add("@TenNhanVien", SqlDbType.NVarChar).Value = obj.TenNhanVien;
                    cmd.Parameters.Add("@NgaySinh", SqlDbType.Date).Value = obj.NgaySinh;
                    cmd.Parameters.Add("@ChucVu", SqlDbType.TinyInt).Value = obj.ChucVu;
                    cmd.Parameters.Add("@MatKhau", SqlDbType.Char).Value = passMD5;
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                    return true;
                }
                catch (Exception ex)
                {
                    _connection.Close();
                    Console.WriteLine(ex.Message);
                }
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[NhanVien] WHERE MaNhanVien = @id", _connection);
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
        public bool CheckPassword(string manv, string mk)
        {
            
            bool result = false;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string sql = "SELECT * FROM NhanVien WHERE MaNhanVien = @manhanvien";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@manhanvien", SqlDbType.Char).Value = manv;
                SqlDataReader reader = cmd.ExecuteReader();
                string passMd5 = "";
                if (reader.Read())
                {
                    passMd5 = reader["MatKhau"].ToString();
                    reader.Close();
                }
                using (MD5 md5 = MD5.Create())
                {
                    if (VerifyMd5Hash(md5, mk, passMd5))
                    {
                        result = true;
                    }
                    else
                        result = false;

                }
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
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
   
}
