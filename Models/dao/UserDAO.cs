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
    }
}