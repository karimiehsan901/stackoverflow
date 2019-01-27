namespace stackoverflow.Models.dao
{
    public class AnswerDAO : DAO
    {
        private static AnswerDAO instance;

        public static AnswerDAO Instance()
        {
            if (instance == null)
            {
                instance = new AnswerDAO();
            }

            return instance;
        }

        private AnswerDAO()
        {
        }
    }
}