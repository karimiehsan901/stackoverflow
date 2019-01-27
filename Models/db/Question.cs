namespace stackoverflow.Models.db
{
    public class Question
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public string Title { get; set; }
        public int UserId { get; set; }

        public Question(int id, string content, string day, string hour, string title, int userId)
        {
            Id = id;
            Content = content;
            Day = day;
            Hour = hour;
            Title = title;
            UserId = userId;
        }
    }
}