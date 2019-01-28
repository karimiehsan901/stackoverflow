namespace stackoverflow.Models.db
{
    public class Tag
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Tag(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}