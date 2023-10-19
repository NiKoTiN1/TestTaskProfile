using System.ComponentModel.DataAnnotations;

namespace TestTaskProfile.ViewModels.Models
{
    public class AddCardModel
    {
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
    }
}
