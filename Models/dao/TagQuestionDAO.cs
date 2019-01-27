namespace stackoverflow.Models.dao
{
    public class TagQuestionDAO
    {
        private static TagQuestionDAO instance;

        public static TagQuestionDAO Instance()
        {
            if (instance == null)
            {
                instance = new TagQuestionDAO();
            }

            return instance;
        }

        private TagQuestionDAO()
        {
        }
    }
}