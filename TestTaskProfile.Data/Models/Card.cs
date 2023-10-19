using System.ComponentModel.DataAnnotations;

namespace TestTaskProfile.Data.Models
{
    public class Card
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(19)]
        public string Number { get; set; }

        [Required]
        public DateTime Valid { get; set; }

        [Required]
        [MaxLength(100)]
        public string CardHolderName { get; set; }

        [Required]
        [MaxLength(3)]
        public string CVV { get; set; }

        [Required]
        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
