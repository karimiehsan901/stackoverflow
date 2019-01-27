namespace stackoverflow.Models.db
{
    public class AnswerComment
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }

        public AnswerComment(int id, string content, string day, string hour, int answerId, int userId)
        {
            Id = id;
            Content = content;
            Day = day;
            Hour = hour;
            AnswerId = answerId;
            UserId = userId;
        }
    }
}