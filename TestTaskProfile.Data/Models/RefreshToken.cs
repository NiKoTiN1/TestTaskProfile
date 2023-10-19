using System.ComponentModel.DataAnnotations;

namespace TestTaskProfile.Data.Models
{
    public class RefreshToken
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        public DateTime Expiration { get; set; }

        [Required]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
