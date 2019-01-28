namespace stackoverflow.Models.dao
{
    public class QuestionCommentDAO : DAO
    {
        private static QuestionCommentDAO instance;

        public static QuestionCommentDAO Instance()
        {
            if (instance == null)
            {
                instance = new QuestionCommentDAO();
            }

            return instance;
        }

        private QuestionCommentDAO()
        {
        }
    }
}