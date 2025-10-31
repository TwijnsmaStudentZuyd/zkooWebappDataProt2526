using System.ComponentModel.DataAnnotations;

namespace zkooWebserver.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(40, MinimumLength =8, ErrorMessage ="The {0} must be atleast {2} and at most {1} characters in length")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword", ErrorMessage = "Passwords do not match")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter your password again to confirm it")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
