namespace stackoverflow.Models.db
{
    public class LikeQuestion
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }
        public bool IsLike { get; set; }

        public LikeQuestion(int id, int questionId, int userId, bool isLike)
        {
            Id = id;
            QuestionId = questionId;
            UserId = userId;
            IsLike = isLike;
        }
    }
}