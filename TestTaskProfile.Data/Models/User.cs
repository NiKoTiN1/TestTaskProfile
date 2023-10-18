using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTaskProfile.Data.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [ForeignKey("RefreshTokenId")]
        public RefreshToken RefreshToken { get; set; }
        public Guid RefreshTokenId { get; set; }

        [ForeignKey("CardId")]
        public Card? Card { get; set; }
        public Guid CardId { get; set; }
    }
}
