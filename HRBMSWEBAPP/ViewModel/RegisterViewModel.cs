using HRBMSWEBAPP.Validations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace HRBMSWEBAPP.ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("First Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must only contain letters.")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]
        [EmailAddress]
        [Required]
        [EmailExist]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Phone Number")]
        [RegularExpression("^(09|\\+639)\\d{9}$", ErrorMessage = "Invalid phone number.")]
        [Required]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
