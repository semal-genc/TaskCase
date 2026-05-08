using System.ComponentModel.DataAnnotations;

namespace TaskCaseAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpireDate { get; set; }
        public ICollection<UserTask>? Tasks { get; set; }
    }
}
