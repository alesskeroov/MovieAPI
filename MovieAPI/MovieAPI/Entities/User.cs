using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string Username { get; set; }
        [Required]
        [MinLength(8)]
        public string PasswordHash { get; set; }
        [Required]
        public string Email { get; set; }
        public string Role { get; set; } = "User";
    }
}
