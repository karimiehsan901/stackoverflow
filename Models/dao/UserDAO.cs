using MySql.Data.MySqlClient;
using stackoverflow.Models.db;

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

        public User GetUserByUsername(string username)
        {
            var cmd = new MySqlCommand("select * from main_user where username=\'" + username + "\'", DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                var id = (int) rd["id"];
                var password = (string) rd["password"];
                var email = (string) rd["email"];
                var name = (string) rd["password"];
                var user = new User(id, name, username, password, email);
                rd.Close();
                return user;
            }
            rd.Close();
            return null;
        }

        public bool Exists(string email, string username)
        {
            var cmd = new MySqlCommand("select * from main_user where username=\'" + username + "\' or email=\'" + email + "\'", DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            var exists = rd.Read();
            rd.Close();
            return exists;
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            var cmd = new MySqlCommand("select * from main_user where username=\'" + username + "\' and password=\'" + password + "\'", DBConnection.Instance().MySqlConnection);
            var rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                var id = (int) rd["id"];
                var email = (string) rd["email"];
                var name = (string) rd["password"];
                var user = new User(id, name, username, password, email);
                rd.Close();
                return user;
            }
            rd.Close();
            return null;
        }
    }
}