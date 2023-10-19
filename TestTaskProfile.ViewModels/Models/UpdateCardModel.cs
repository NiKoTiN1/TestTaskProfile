using System.ComponentModel.DataAnnotations;
using TestTaskProfile.ViewModels.Validators;

namespace TestTaskProfile.ViewModels.Models
{
    public class UpdateCardModel
    {
        [MaxLength(19)]
        public string Number { get; set; }

        [GraterThenNowDateAttrebute]
        [RegularExpression("^\\d{4}-\\d{2}-\\d{2}$")]
        public DateTime Valid { get; set; }

        [MaxLength(100)]
        [RegularExpression("^[A-Z]+ [A-Z]+$")]
        public string CardHolderName { get; set; }

        [MaxLength(3)]
        [RegularExpression("^[0-9]{3}$")]
        public string CVV { get; set; }
    }
}
