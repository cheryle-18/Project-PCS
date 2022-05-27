using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore
{
    class Koneksi
    {
        static MySqlConnection conn = new MySqlConnection();

        //input required parameters
        public static bool openConn(string server, string db, string id)
        {
            bool res = true;
            conn.ConnectionString = string.Format("server={0}; user id={1}; password={2}; database={3}", server, id, "", db);
            try
            {
                if (conn.State == System.Data.ConnectionState.Closed)
                {
                    conn.Open();
                }
            }
            catch
            {
                res = false;
            }
            return res;
        }

        public static MySqlConnection getConn()
        {
            return conn;
        }
    }
}
