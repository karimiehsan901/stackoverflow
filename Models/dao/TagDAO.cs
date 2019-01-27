namespace stackoverflow.Models.dao
{
    public class TagDAO : DAO
    {
        private static TagDAO instance;

        public static TagDAO Instance()
        {
            if (instance == null)
            {
                instance = new TagDAO();
            }

            return instance;
        }

        private TagDAO()
        {
        }
    }
}