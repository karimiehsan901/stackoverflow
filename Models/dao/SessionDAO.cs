using MySql.Data.MySqlClient;

namespace stackoverflow.Models.dao
{
    public class SessionDAO : DAO
    {
        private static SessionDAO instance;

        public static SessionDAO Instance()
        {
            if (instance == null)
            {
                instance = new SessionDAO();
            }

            return instance;
        }

        private SessionDAO()
        {
        }

        public void Login(string sessionId, string username)
        {
            var cmd = new MySqlCommand("insert into main_session (session_id, session_key, value) values (\'" + sessionId + "\', \'username\',\'" + username + "\')", DBConnection.Instance().MySqlConnection);
            cmd.ExecuteNonQuery();
        }

        public void Logout(string sessionId)
        {
            var cmd = new MySqlCommand("delete from main_session where session_id=\'" + sessionId + "\'", DBConnection.Instance().MySqlConnection);
            cmd.ExecuteNonQuery();
        }

        public string GetUsername(string sessionId)
        {
            string value = null;
            var cmd = new MySqlCommand("select value from main_session where session_key=\'username\' and session_id=\'" + sessionId + "\'", DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                value = (string) rd["value"];
            }
            rd.Close();
            return value;

        }
    }
}