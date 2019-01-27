namespace stackoverflow.Models.db
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public User(int id, string name, string username, string password, string email)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Email = email;
        }
    }
}