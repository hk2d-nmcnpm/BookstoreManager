using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    class DBConnection
    {
        const string connectionString = "Data Source=DESKTOP-9EOMK9V;Initial Catalog=bookstore-manager;Integrated Security=True";
        protected OleDbConnection _connection;
        public DBConnection()
        {
            try
            {
                _connection = new OleDbConnection(connectionString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
