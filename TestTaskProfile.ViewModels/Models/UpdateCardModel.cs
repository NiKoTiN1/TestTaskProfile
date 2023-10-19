using System.ComponentModel.DataAnnotations;

namespace TestTaskProfile.ViewModels.Models
{
    public class UpdateCardModel
    {
        [MaxLength(19)]
        public string Number { get; set; }

        public DateTime Valid { get; set; }

        [MaxLength(100)]
        public string CardHolderName { get; set; }

        [MaxLength(3)]
        public string CVV { get; set; }
    }
}
