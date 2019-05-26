using System;
using System.Data.SqlClient;
using DataTransferObject;
using System.Data;


namespace DataAccessLayer
{
    public class ThamSoTable : DBConnection
    {
        public ThamSoTable() : base() { }
        public ThamSo GetRow(string maThamSo)
        {
            try
            {
                var obj = new ThamSo();
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[ThamSo] WHERE MaThamSo = @mathamso", _connection);
                command.Parameters.Add("@mathamso", SqlDbType.Char).Value = maThamSo;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    obj.MaThamSo = reader["MaThamSo"].ToString();
                    obj.TenThamSo = reader["TenThamSo"].ToString();
                    obj.GiaTri = (int)reader["GiaTri"];
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
        public DataTable GetAllRows()
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[ThamSo] ORDER BY MaThamSo ASC", _connection);
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
        public bool UpdateRow(ThamSo obj)
        {
            try
            {
                if (_connection.State != ConnectionState.Open)
                    _connection.Open();
                string sql = "UPDATE [dbo].[ThamSo]\n"
                           + "   SET [TenThamSo] = @TenThamSo\n"
                           + "      ,[GiaTri] = @GiaTri\n"
                           + " WHERE [MaThamSo] = @MaThamSo";
                var cmd = new SqlCommand(sql, _connection);
                cmd.Parameters.Add("@MaThamSo", SqlDbType.Char).Value = obj.MaThamSo;
                cmd.Parameters.Add("@TenThamSo", SqlDbType.Char).Value = obj.TenThamSo;
                cmd.Parameters.Add("@GiaTri", SqlDbType.Int).Value = obj.GiaTri;
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

                SqlCommand command = new SqlCommand("SELECT * FROM [dbo].[ThamSo] WHERE MaThamSo = @id", _connection);
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
