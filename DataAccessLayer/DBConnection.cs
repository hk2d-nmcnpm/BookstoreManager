using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class DBConnection
    {
        const string connectionString = "Data Source=DESKTOP-6L0PUJ0;Initial Catalog=bookstore-manager5;Integrated Security=True";
        protected SqlConnection _connection;
        public DBConnection()
        {
            try
            {
                _connection = new SqlConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
