using System.ComponentModel.DataAnnotations;

namespace TestTaskProfile.ViewModels.Models
{
    public class LoginModel
    {
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
