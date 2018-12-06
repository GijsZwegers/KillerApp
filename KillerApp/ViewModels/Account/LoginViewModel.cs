using System.ComponentModel.DataAnnotations;

namespace KillerApp.Presentation.ViewModels.Account
{
    public class LoginViewModel
    {
        [Required]
        [DataType(DataType.Text), MaxLength(20)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
