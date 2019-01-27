namespace stackoverflow.Models.db
{
    public class TagQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int TagId { get; set; }

        public TagQuestion(int id, int questionId, int tagId)
        {
            Id = id;
            QuestionId = questionId;
            TagId = tagId;
        }
    }
}