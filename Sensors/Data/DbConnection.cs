using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensors.Data
{
    internal class DbConnection
    {
        private string connectionStr = "server=localhost;user=root;password=;database=sensor_projectDB";
        private MySqlConnection _conn;

        public MySqlConnection Get_conn() => this._conn;
        public MySqlConnection OpenConnection()
        {
            if (_conn == null)
            {
                _conn = new MySqlConnection(connectionStr);
            }
            if (_conn.State != System.Data.ConnectionState.Open)
            {
                _conn.Open();
                Console.WriteLine("connected..");
            }
            return _conn;
        }
        public void CloseConnection()
        {
            if (_conn != null && _conn.State == System.Data.ConnectionState.Open)
            {
                _conn.Close();
                _conn = null;
            }
        }
    }
}
