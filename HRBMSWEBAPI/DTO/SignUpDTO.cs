using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class SignUpDTO
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
        // [EmailExist]
        public string? Email { get; set; }

        [RegularExpression("^(09|\\+639)\\d{9}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
