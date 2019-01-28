using MySql.Data.MySqlClient;

namespace stackoverflow.Models.dao
{
    public class UserDAO : DAO
    {
        private static UserDAO instance;

        public static UserDAO Instance()
        {
            if (instance == null)
            {
                instance = new UserDAO();
            }

            return instance;
        }

        private UserDAO()
        {
        }

        public void CreateUser(string username, string password, string email, string name)
        {
            var cmd = new MySqlCommand("insert into main_user (username, email, password, name) values (\'" +
                                                username + "\', \'" + email + "\',\'"+ password + "\', \'" + name + "\')", DBConnection.Instance().MySqlConnection);
            cmd.ExecuteNonQuery();
        }
    }
}