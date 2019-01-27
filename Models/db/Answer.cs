namespace stackoverflow.Models.db
{
    public class Answer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Day { get; set; }
        public string Hour { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }

        public Answer(int id, string content, string day, string hour, int questionId, int userId)
        {
            Id = id;
            Content = content;
            Day = day;
            Hour = hour;
            QuestionId = questionId;
            UserId = userId;
        }
    }
}