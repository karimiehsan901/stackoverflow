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
            var cmd = new MySqlCommand("insert into main_session (session_id, session_key, value) values (" + sessionId + ", username," + username + ")", DBConnection.Instance().MySqlConnection);
            cmd.ExecuteNonQuery();
        }
    }
}