using System.Data;
using System.Data.SqlClient;
using System;
using DataTransferObject;

namespace DataAccessLayer
{
    public class HoaDonTable : DBConnection
    {
        public HoaDonTable() : base() { }
        public bool DeleteRow(string maHoaDon)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("DELETE FROM HoaDon WHERE MaHoaDon = @mahoadon",_connection);
                command.Parameters.Add("@mahoadon", SqlDbType.Char).Value = maHoaDon;
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
        public HoaDon GetRow(string maHoaDon)
        {
            try
            {
                var hoaDon = new HoaDon();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM HoaDon WHERE MaHoaDon = @mahoadon", _connection);
                command.Parameters.Add("@mahoadon", SqlDbType.Char).Value = maHoaDon;

                SqlDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    hoaDon.MaHoaDon = reader["MaHoaDon"].ToString();
                    hoaDon.MaKhachHang = reader["MaKhachHang"].ToString();
                    hoaDon.NgayHoaDon = (DateTime)reader["NgayHoaDon"];
                    hoaDon.MaNhanVien = reader["MaNhanVien"].ToString();
                    hoaDon.TienKhachDaTra = (decimal)reader["TienKhachDaTra"];
                    hoaDon.GiamGia = (decimal)reader["GiamGia"];
                    reader.Close();
                }
                return hoaDon;
            }
            catch (Exception ex)
            {
                _connection.Close();
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        //public DataTable GetRowsByNgayHoaDon(DateTime batDau, DateTime ketThuc)
        //{
        //    try
        //    {
        //        if (_connection.State != ConnectionState.Open)
        //            _connection.Open();

        //        SqlCommand command = new SqlCommand("SELECT * FROM HoaDon WHERE NgayHoaDon BETWEEN @batdau AND @ketthuc ORDER BY MaHoaDon ASC", _connection);
        //        command.Parameters.Add("@batdau", SqlDbType.Date).Value = batDau;
        //        command.Parameters.Add("@ketthuc", SqlDbType.Date).Value = ketThuc;
        //        SqlDataAdapter da = new SqlDataAdapter(command);
        //        DataTable dt = new DataTable();
        //        da.Fill(dt);
        //        _connection.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        _connection.Close();
        //        Console.WriteLine(ex.Message);
        //    }
        //    return null;
        //}

        public DataTable GetRows(int number)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT TOP (@number) * FROM HoaDon ORDER BY MaHoaDon ASC", _connection);
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
        public DataTable GetResultTable()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "select hd.MaHoaDon\n"
                           + "	  ,hd.NgayHoaDon as NgayBan\n"
                           + "	  ,kh.HoTenKH as KhachHang\n"
                           + "	  ,nv.TenNhanVien as NguoiBan\n"
                           + "	  ,tmp.TongTien\n"
                           + "	  ,tmp.TongTien - hd.TienKhachDaTra - hd.GiamGia as TienNo\n"
                           + "from HoaDon hd\n"
                           + "inner join NhanVien nv on hd.MaNhanVien = nv.MaNhanVien\n"
                           + "inner join KhachHang kh on hd.MaKhachHang = kh.MaKhachHang\n"
                           + "inner join (select MaHoaDon,sum(DonGiaBan * SoLuongBan) as TongTien from ChiTietHoaDon\n"
                           + "		    group by MaHoaDon) tmp on tmp.MaHoaDon = hd.MaHoaDon\n"
                           + "order by hd.MaHoaDon asc";
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

        public DataTable GetAllRows()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM HoaDon ORDER BY MaHoaDon ASC", _connection);
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

        public bool AddRow(HoaDon obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                const string sql = "INSERT INTO [dbo].[HoaDon]\n"
                       + "           ([MaHoaDon]\n"
                       + "           ,[MaKhachHang]\n"
                       + "           ,[MaNhanVien]\n"
                       + "           ,[NgayHoaDon]\n"
                       + "           ,[GiamGia]\n"
                       + "           ,[TienKhachDaTra])\n"
                       + "     VALUES\n"
                       + "           (@MaHoaDon\n"
                       + "           ,@MaKhachHang\n"
                       + "           ,@MaNhanVien\n"
                       + "           ,@NgayHoaDon\n"
                       + "           ,@GiamGia\n"
                       + "           ,@TienKhachDaTra)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaHoaDon", SqlDbType.Char).Value = obj.MaHoaDon;
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
                cmd.Parameters.Add("@NgayHoaDon", SqlDbType.Date).Value = obj.NgayHoaDon;
                cmd.Parameters.Add("@GiamGia", SqlDbType.Money).Value = obj.GiamGia;
                cmd.Parameters.Add("@TienKhachDaTra", SqlDbType.Money).Value = obj.TienKhachDaTra;
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

        public bool UpdateRow(HoaDon obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                const string sql = "UPDATE [dbo].[HoaDon]\n"
                           + "   SET [MaKhachHang] = @MaKhachHang\n"
                           + "      ,[MaNhanVien] = @MaNhanVien\n"
                           + "      ,[NgayHoaDon] = @NgayHoaDon\n"
                           + "      ,[GiamGia] = @GiamGia\n"
                           + "      ,[TienKhachDua] = @TienKhachDua\n"
                           + " WHERE [MaHoaDon] = @MaHoaDon";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaHoaDon", SqlDbType.Char).Value = obj.MaHoaDon;
                cmd.Parameters.Add("@MaKhachHang", SqlDbType.Char).Value = obj.MaKhachHang;
                cmd.Parameters.Add("@MaNhanVien", SqlDbType.Char).Value = obj.MaNhanVien;
                cmd.Parameters.Add("@NgayHoaDon", SqlDbType.Date).Value = obj.NgayHoaDon;
                cmd.Parameters.Add("@GiamGia", SqlDbType.Money).Value = obj.GiamGia;
                cmd.Parameters.Add("@TienKhachDaTra", SqlDbType.Money).Value = obj.TienKhachDaTra;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[HoaDon] WHERE MaHoaDon = @id", _connection);
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
