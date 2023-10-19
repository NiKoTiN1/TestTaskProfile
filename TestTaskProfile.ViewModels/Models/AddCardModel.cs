using System.ComponentModel.DataAnnotations;
using TestTaskProfile.ViewModels.Validators;

namespace TestTaskProfile.ViewModels.Models
{
    public class AddCardModel
    {
        [Required]
        [MinLength(12)]
        [MaxLength(19)]
        public string Number { get; set; }

        [Required]
        [GraterThenNowDateAttrebute]
        [RegularExpression("^\\d{4}-\\d{2}-\\d{2}$")]
        public DateTime Valid { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        [RegularExpression("^[A-Z]+ [A-Z]+$")]
        public string CardHolderName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        [RegularExpression("^[0-9]{3}$")]
        public string CVV { get; set; }
    }
}
