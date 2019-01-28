namespace stackoverflow.Models.db
{
    public class Session
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public string SessionKey { get; set; }
        public string Value { get; set; }

        public Session(int id, string sessionId, string sessionKey, string value)
        {
            Id = id;
            SessionId = sessionId;
            SessionKey = sessionKey;
            Value = value;
        }
    }
}