namespace stackoverflow.Models.dao
{
    public class AnswerCommentDAO : DAO
    {
        private static AnswerCommentDAO instance;

        public static AnswerCommentDAO Instance()
        {
            if (instance == null)
            {
                instance = new AnswerCommentDAO();
            }

            return instance;
        }

        private AnswerCommentDAO()
        {
        }
    }
}