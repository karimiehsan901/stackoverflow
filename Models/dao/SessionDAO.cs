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
    }
}