namespace stackoverflow.Models.dao
{
    public class LikeQuestionDAO : DAO
    {
        private static LikeQuestionDAO instance;

        public static LikeQuestionDAO Instance()
        {
            if (instance == null)
            {
                instance = new LikeQuestionDAO();
            }

            return instance;
        }

        private LikeQuestionDAO()
        {
        }
    }
}