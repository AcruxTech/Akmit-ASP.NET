namespace Akmit.DataAccess.Models
{
    public class UserRto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
        public string Url { get; set; }

        public int? ClassRtoId { get; set; }
    }
}
