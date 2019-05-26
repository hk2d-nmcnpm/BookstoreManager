using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class ChiTietPhieuNhapSachTable: DBConnection
    {
        public ChiTietPhieuNhapSachTable() : base() { }
        public bool AddRow(ChiTietPhieuNhapSach obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "INSERT INTO [dbo].[ChiTietPhieuNhapSach]\n"
                           + "           ([MaChiTietPhieuNhapSach]\n"
                           + "           ,[MaPhieuNhapSach]\n"
                           + "           ,[MaSach]\n"
                           + "           ,[SoLuongNhap]\n"
                           + "           ,[DonGiaNhap])\n"
                           + "     VALUES\n"
                           + "           (@MaChiTietPhieuNhapSach\n"
                           + "           ,@MaPhieuNhapSach\n"
                           + "           ,@MaSach\n"
                           + "           ,@SoLuongNhap\n"
                           + "           ,@DonGiaNhap)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietPhieuNhapSach", SqlDbType.Char).Value = obj.MaChiTietPhieuNhapSach;
                cmd.Parameters.Add("@MaPhieuNhapSach", SqlDbType.Char).Value = obj.MaPhieuNhapSach;
                cmd.Parameters.Add("@MaSach", SqlDbType.Char).Value = obj.MaSach;
                cmd.Parameters.Add("@SoLuongNhap", SqlDbType.Int).Value = obj.SoLuongNhap;
                cmd.Parameters.Add("@DonGiaNhap", SqlDbType.Money).Value = obj.DonGiaNhap;
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
        public bool DeleteRow(string maCTPNS)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM [dbo].[ChiTietPhieuNhapSach] WHERE MaChiTietPhieuNhapSach = @machitietpns", _connection);
                command.Parameters.Add("@machitietpns", SqlDbType.Char).Value = maCTPNS;
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
        public ChiTietPhieuNhapSach GetRow(string maCTPNS)
        {
            try
            {
                var obj = new ChiTietPhieuNhapSach();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM ChiTietPhieuNhapSach WHERE MaChiTietPhieuNhapSach = @machitietpns", _connection);
                command.Parameters.Add("@machitietpns", SqlDbType.Char).Value = maCTPNS;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaChiTietPhieuNhapSach = reader["MaChiTietPhieuNhapSach"].ToString();
                    obj.MaPhieuNhapSach = reader["MaPhieuNhapSach"].ToString();
                    obj.MaSach = reader["MaSach"].ToString();
                    obj.SoLuongNhap = (int)reader["SoLuongNhap"];
                    obj.DonGiaNhap = (decimal)reader["DonGiaNhap"];
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
        public DataTable GetRowsByMaPhieuNhap(string maPNS)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM ChiTietPhieuNhapSach WHERE MaPhieuNhapSach = @mapns ORDER BY MaChiTietPhieuNhapSach ASC", _connection);
                command.Parameters.Add("@mapns", SqlDbType.Char).Value = maPNS;
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

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM ChiTietPhieuNhapSach ORDER BY MaChiTietPhieuNhapSach ASC", _connection);
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

                SqlCommand command = new SqlCommand("SELECT * FROM ChiTietPhieuNhapSach ORDER BY MaChiTietPhieuNhapSach ASC", _connection);
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
        public bool UpdateRow(ChiTietPhieuNhapSach obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[ChiTietPhieuNhapSach]\n"
                           + "   SET [MaPhieuNhapSach] = @MaPhieuNhapSach\n"
                           + "      ,[MaSach] = @MaSach\n"
                           + "      ,[SoLuongNhap] = @SoLuongNhap\n"
                           + "      ,[DonGiaNhap] = @DonGiaNhap\n"
                           + " WHERE [MaChiTietPhieuNhapSach] = @MaChiTietPhieuNhapSach";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaChiTietPhieuNhapSach", SqlDbType.Char).Value = obj.MaChiTietPhieuNhapSach;
                cmd.Parameters.Add("@MaPhieuNhapSach", SqlDbType.Char).Value = obj.MaPhieuNhapSach;
                cmd.Parameters.Add("@MaSach", SqlDbType.Char).Value = obj.MaSach;
                cmd.Parameters.Add("@SoLuongNhap", SqlDbType.Int).Value = obj.SoLuongNhap;
                cmd.Parameters.Add("@DonGiaNhap", SqlDbType.Money).Value = obj.DonGiaNhap;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[ChiTietPhieuNhapSach] WHERE MaChiTietPhieuNhapSach = @id", _connection);
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
