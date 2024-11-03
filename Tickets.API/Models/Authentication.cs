namespace Tickets.API.Models
{
    public class Authentication
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }

        public Authentication(string? userName, string? password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
