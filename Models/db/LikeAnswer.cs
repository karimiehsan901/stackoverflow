namespace stackoverflow.Models.db
{
    public class LikeAnswer
    {
        public int Id { get; set; }
        public int AnswerId { get; set; }
        public int UserId { get; set; }
        public bool IsLike { get; set; }

        public LikeAnswer(int id, int answerId, int userId, bool isLike)
        {
            Id = id;
            AnswerId = answerId;
            UserId = userId;
            IsLike = isLike;
        }
    }
}