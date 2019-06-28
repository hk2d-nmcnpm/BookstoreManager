using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;

namespace DataAccessLayer
{
    public class BaoCaoTonTable: DBConnection
    {
        public BaoCaoTonTable() : base() { }
        public bool AddBaoCaoTon(BaoCaoTon bct)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "insert into BaoCaoTon values(@MaBaoCao,@Thang,@Nam)";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaBaoCao", SqlDbType.Char).Value = bct.MaBaoCaoTon;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = bct.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = bct.Nam;
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return false;
        }
        public DataTable GetAllRows()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                string sql = "select * from BaoCaoTon";
                SqlCommand cmd = new SqlCommand(sql, _connection);
                SqlDataAdapter sqadt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sqadt.Fill(dt);
                _connection.Close();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return null;
        }

        public DataTable ThongKeBaoCaoTon(int thang, int nam)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                SqlCommand cmd = new SqlCommand("BaoCaoTonProc", _connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = nam;
                SqlDataAdapter sqdat = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                sqdat.Fill(ds);
                _connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return null;
        }

        public bool IsRowExists(int thang, int nam)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string query = "select * from BaoCaoTon where Thang=@thang and Nam=@nam";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
                cmd.Parameters.Add("@nam", SqlDbType.Int).Value = nam;
                SqlDataAdapter sqa = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                _connection.Close();
                sqa.Fill(dt);
                if (dt.Rows.Count > 0) return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                _connection.Close();
            }
            return false;
        }

        public bool UpdateBaoCao(BaoCaoTon bccn)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string query = "update BaoCaoTon" +
                    "set Thang=@Thang," +
                    "Nam=@Nam" +
                    "where MaBaoCaoTon=@MaBaoCaoTon";
                SqlCommand cmd = new SqlCommand(query, _connection);
                cmd.Parameters.Add("@MaBaoCaoTon", SqlDbType.Char).Value = bccn.MaBaoCaoTon;
                cmd.Parameters.Add("@Thang", SqlDbType.Int).Value = bccn.Thang;
                cmd.Parameters.Add("@Nam", SqlDbType.Int).Value = bccn.Nam;
                cmd.ExecuteNonQuery();
                _connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                _connection.Close();
            }
            return false;
        }

        public BaoCaoTon GetBaoCaoFromThangNam(int thang, int nam)
        {

            try
            {
                var obj = new BaoCaoTon();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM BaoCaoTon WHERE Thang = @thang and Nam=@nam", _connection);
                command.Parameters.Add("@thang", SqlDbType.Int).Value = thang;
                command.Parameters.Add("@nam", SqlDbType.Int).Value = nam;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaBaoCaoTon = reader["MaBaoCaoTon"].ToString();
                    obj.Thang = int.Parse(reader["Thang"].ToString());
                    obj.Nam = int.Parse(reader["Nam"].ToString());
                    reader.Close();
                }
                _connection.Close();
                return obj;
            }
            catch
            (Exception ex)
            {
                _connection.Close();
            }
            return null;
        }
    }
}
