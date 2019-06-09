using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class PhieuThuTable: DBConnection
    {
        public PhieuThuTable() : base() { }
        public bool AddRow(PhieuThu obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[PhieuThu]\n"
                           + "           ([MaPhieuThu]\n"
                           + "           ,[MaKhachHang]\n"
                           + "           ,[MaNhanVien]\n"
                           + "           ,[NgayThu]\n"
                           + "           ,[SoTienThu]\n"
                           + "           ,[LyDoThu])\n"
                           + "     VALUES\n"
                           + "           (@MaPhieuThu\n"
                           + "           ,@MaKhachHang\n"
                           + "           ,@MaNhanVien\n"
                           + "           ,@NgayThu\n"
                           + "           ,@SoTienThu\n"
                           + "           ,@LyDoThu)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaPhieuThu", SqlDbType.Char).Value = obj.MaPhieuThu;
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
                cmd.Parameters.Add("@NgayThu", SqlDbType.Date).Value = obj.NgayThu;
                cmd.Parameters.Add("@SoTienThu", SqlDbType.Money).Value = obj.SoTienThu;
                cmd.Parameters.Add("@LyDoThu", SqlDbType.NChar).Value = obj.LyDoThu ?? (object)DBNull.Value;
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
        public bool DeleteRow(string maPhieuThu)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[PhieuThu] WHERE MaPhieuThu = @maphieuthu", _connection);
                command.Parameters.Add("@maphieuthu", SqlDbType.Char).Value = maPhieuThu;
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
        public PhieuThu GetRow(string maPhieuThu)
        {
            try
            {
                var obj = new PhieuThu();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM PhieuThu WHERE MaPhieuThu = @maphieuthu", _connection);
                command.Parameters.Add("@maphieuthu", SqlDbType.Char).Value = maPhieuThu;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaPhieuThu = reader["MaPhieuThu"].ToString();
                    obj.MaNhanVien = reader["MaNhanVien"].ToString();
                    obj.MaKhachHang = reader["MaKhachHang"].ToString();
                    obj.NgayThu = (DateTime)reader["NgayThu"];
                    obj.SoTienThu = (decimal)reader["SoTienThu"];
                    obj.LyDoThu = reader["LyDoThu"] as string;
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

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM PhieuThu ORDER BY MaPhieuThu ASC", _connection);
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

                SqlCommand command = new SqlCommand("SELECT * FROM PhieuThu ORDER BY MaPhieuThu ASC", _connection);
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
        public DataTable GetDisplayTable()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "select pt.MaPhieuThu, kh.HoTenKH,kh.DiaChi, kh.SoDienThoai, kh.Email, pt.NgayThu, pt.SoTienThu, nv.TenNhanVien, pt.LyDoThu\n"
                           + "from PhieuThu pt\n"
                           + "inner join KhachHang kh on pt.MaKhachHang = kh.MaKhachHang\n"
                           + "inner join NhanVien nv on pt.MaNhanVien = nv.MaNhanVien\n"
                           + "order by pt.MaPhieuThu asc";
                SqlCommand command = new SqlCommand(sql, _connection);
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
        public bool UpdateRow(PhieuThu obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[PhieuThu]\n"
                           + "   SET [MaKhachHang] = @MaKhachHang\n"
                           + "      ,[MaNhanVien] = @MaNhanVien\n"
                           + "      ,[NgayThu] = @NgayThu\n"
                           + "      ,[SoTienThu] = @SoTienThu\n"
                           + "      ,[LyDoThu] = @LyDoThu\n"
                           + " WHERE [MaPhieuThu] = @MaPhieuThu";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaPhieuThu", SqlDbType.Char).Value = obj.MaPhieuThu;
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
                cmd.Parameters.Add("@NgayThu", SqlDbType.Date).Value = obj.NgayThu;
                cmd.Parameters.Add("@SoTienThu", SqlDbType.Money).Value = obj.SoTienThu;
                cmd.Parameters.Add("@LyDoThu", SqlDbType.NChar).Value = obj.LyDoThu ?? (object)DBNull.Value;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[PhieuThu] WHERE MaPhieuThu = @id", _connection);
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
