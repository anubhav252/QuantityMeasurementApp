using System.ComponentModel.DataAnnotations;

namespace AuthService.Models
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        public string Username { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public string PasswordSalt { get; set; } = string.Empty;
    }
}
