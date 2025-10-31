using System.ComponentModel.DataAnnotations;

namespace zkooWebserver.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Invalid Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Invalid Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
