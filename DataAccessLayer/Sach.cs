using System.Data;
using System.Data.OleDb;
using System;
using DataTransferObject;

namespace DataAccessLayer
{
    class SachTable : DBConnection
    {
        public SachTable() : base() { }
        public bool DeleteRowByMaSach(string maSach)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                OleDbCommand command = new OleDbCommand("DELETE FROM Sach WHERE MaSach = @masach",_connection);
                command.Parameters.Add("@masach", OleDbType.Char, 10).Value = maSach;
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
        public Sach GetRowByMaSach(string maSach)
        {
            Sach sach = null;
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                OleDbCommand command = new OleDbCommand("SELECT * FROM Sach WHERE MaSach = @masach ORDER BY MaSach ASC", _connection);
                command.Parameters.Add("@masach", OleDbType.Char, 10).Value = maSach;

                OleDbDataReader reader = command.ExecuteReader();
                if(reader.Read())
                {
                    sach = new Sach();
                    sach.MaSach = reader["MaSach"].ToString();
                    sach.TenSach = reader["TenSach"].ToString();
                    sach.TacGia = reader["TacGia"].ToString();
                    sach.MoTa = reader["MoTa"].ToString();
                    sach.SoLuongTon = (int)reader["SoLuongTon"];
                    sach.AnhBia = (byte[])reader["AnhBia"];
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
            return null;
        }
        public DataTable GetRows(int number)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                OleDbCommand command = new OleDbCommand("SELECT TOP @number FROM Sach ORDER BY MaSach ASC", _connection);
                command.Parameters.Add("@number", OleDbType.Integer, 10).Value = number;
                OleDbDataAdapter da = new OleDbDataAdapter(command);
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
                OleDbCommand command = new OleDbCommand("SELECT FROM Sach ORDER BY MaSach ASC", _connection);
                OleDbDataAdapter da = new OleDbDataAdapter(command);
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
                const string cmdText = "INSERT INTO Sach VALUES (@MaSach,@TenSach,@MaTheLoai,@TacGia,@SoLuongTon,@DonGia,@NamXuatBan,@NhaXuatBan,@SoTrang,@MoTa,@AnhBia)";
                OleDbCommand command = new OleDbCommand(cmdText, _connection);
                command.Parameters.Add("@MaSach", OleDbType.Char).Value = sach.MaSach;
                command.Parameters.Add("@TenSach", OleDbType.WChar).Value = sach.TenSach;
                command.Parameters.Add("@MaTheLoai", OleDbType.Char).Value = sach.MaTheLoai;
                command.Parameters.Add("@TacGia", OleDbType.WChar).Value = sach.TacGia;
                command.Parameters.Add("@SoLuongTon", OleDbType.Integer).Value = sach.SoLuongTon;
                command.Parameters.Add("@DonGia", OleDbType.Currency).Value = sach.DonGia;
                command.Parameters.Add("@NamXuatBan", OleDbType.Integer).Value = sach.NamXuatBan;
                command.Parameters.Add("@NhaXuatBan", OleDbType.WChar).Value = sach.NhaXuatBan;
                command.Parameters.Add("@SoTrang", OleDbType.Integer).Value = sach.SoTrang;
                command.Parameters.Add("@MoTa", OleDbType.WChar).Value = sach.MoTa;
                command.Parameters.Add("@AnhBia", OleDbType.Binary).Value = sach.AnhBia;
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
                const string cmdText = "SET Sach SET "
                    + "TenSach = @TenSach,"
                    + "MaTheLoai = @MaTheLoai,"
                    + "TacGia = @TacGia,"
                    + "SoLuongTon = @SoLuongTon,"
                    + "DonGia = @DonGia,"
                    + "NamXuatBan = @NamXuatBan,"
                    + "NhaXuatBan = @NhaXuatBan,"
                    + "SoTrang = @SoTrang,"
                    + "MoTa = @MoTa,"
                    + "AnhBia = @AnhBia"
                    + " WHERE MaSach = @MaSach";
                OleDbCommand command = new OleDbCommand(cmdText, _connection);
                command.Parameters.Add("@MaSach", OleDbType.Char).Value = sach.MaSach;
                command.Parameters.Add("@TenSach", OleDbType.WChar).Value = sach.TenSach;
                command.Parameters.Add("@MaTheLoai", OleDbType.Char).Value = sach.MaTheLoai;
                command.Parameters.Add("@TacGia", OleDbType.WChar).Value = sach.TacGia;
                command.Parameters.Add("@SoLuongTon", OleDbType.Integer).Value = sach.SoLuongTon;
                command.Parameters.Add("@DonGia", OleDbType.Currency).Value = sach.DonGia;
                command.Parameters.Add("@NamXuatBan", OleDbType.Integer).Value = sach.NamXuatBan;
                command.Parameters.Add("@NhaXuatBan", OleDbType.WChar).Value = sach.NhaXuatBan;
                command.Parameters.Add("@SoTrang", OleDbType.Integer).Value = sach.SoTrang;
                command.Parameters.Add("@MoTa", OleDbType.WChar).Value = sach.MoTa;
                command.Parameters.Add("@AnhBia", OleDbType.Binary).Value = sach.AnhBia;
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
    }
}
