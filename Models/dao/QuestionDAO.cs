namespace stackoverflow.Models.dao
{
    public class QuestionDAO : DAO
    {
        private static QuestionDAO instance;

        public static QuestionDAO Instance()
        {
            if (instance == null)
            {
                instance = new QuestionDAO();
            }

            return instance;
        }

        private QuestionDAO()
        {
        }
    }
}