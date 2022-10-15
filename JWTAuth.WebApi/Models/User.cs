namespace JWTAuth.WebApi.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string? DisplayName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public DateTime? CreatedDate { get; set; }

        public User() { }

        public User(Guid userId,
            string? displayName,
            string? userName,
            string? email,
            string? password,
            DateTime? createdDate)
        {
            UserId = userId;
            DisplayName = displayName;
            UserName = userName;
            Email = email;
            Password = password;
            CreatedDate = createdDate;
        }
    }
}