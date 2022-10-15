using System.ComponentModel.DataAnnotations;

namespace CRUDApplication.Models
{
    public class UserSignup
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Enter same password")]
        public string ConfirmPassword { get; set; }
    }
}
