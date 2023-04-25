using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.Validations;

namespace HRBMSWEBAPP.Models
{
    public class ApplicationUser : IdentityUser
    {

        [DisplayName("First Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name must only contain letters.")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name must only contain letters.")]
        public string LastName { get; set; }

        [NotMapped]
        [DisplayName("Full Name")]
        public string Full_Name
        {
            get { return FirstName + " " + LastName; }
            set { }
        }

        [DisplayName("Email Address")]
        [EmailAddress]
        [Required]
        [EmailExist]
        public string? Email { get; set; }

        [DisplayName("Phone Number")]
        [RegularExpression("^(09|\\+639)\\d{9}$", ErrorMessage = "Invalid phone number.")]
        [Required]
        public string PhoneNumber { get; set; }
        /*
                [ValidateNever]
                public ICollection<Room> Room { get; set; }
        */
        [ValidateNever]
        public ICollection<Booking> Bookings { get; set; }

        [ValidateNever]
        [NotMapped]
        public IdentityRole Role { get; set; }

        //public string RoleId { get; set; }

    }
}
