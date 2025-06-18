using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace sensors.DataBase
{
    internal class DalConnction
    {
        string connUrl = "server=localhost;user=root;password=;database=sensorgame";
        private MySqlConnection _conn;
        public MySqlConnection openConnction()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connUrl);
            }

            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
            }

            return _conn;
        
        }
        public void closeConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }
    }
}
