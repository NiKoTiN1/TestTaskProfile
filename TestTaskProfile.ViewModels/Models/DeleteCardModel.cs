using System.ComponentModel.DataAnnotations;

namespace TestTaskProfile.ViewModels.Models
{
    public class DeleteCardModel
    {
        [Required]
        public Guid CardId { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}
