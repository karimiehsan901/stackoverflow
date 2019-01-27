namespace stackoverflow.Models.dao
{
    public class LikeAnswerDAO : DAO
    {
        private static LikeAnswerDAO instance;

        public static LikeAnswerDAO Instance()
        {
            if (instance == null)
            {
                instance = new LikeAnswerDAO();
            }

            return instance;
        }
        
    }
}