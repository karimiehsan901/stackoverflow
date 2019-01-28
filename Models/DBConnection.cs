using System.IO;
using MySql.Data.MySqlClient;

namespace stackoverflow.Models
{
    public class DBConnection
    {
        private static DBConnection instance;
        public MySqlConnection MySqlConnection { get; }
        public static DBConnection Instance()
        {
            if (instance == null)
            {
                var connectionString = File.ReadAllText("connection_string.txt");
                var con = new MySqlConnection(connectionString);
                con.Open();
                instance = new DBConnection(con);
            }
            return instance;
        }

        private DBConnection(MySqlConnection connection)
        {
            MySqlConnection = connection;
        }
    }
}