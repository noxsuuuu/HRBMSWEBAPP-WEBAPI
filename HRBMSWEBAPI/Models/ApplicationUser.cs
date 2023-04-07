
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRBMSWEBAPP.Models
{
    public class ApplicationUser : IdentityUser
    {

        //[DisplayName("User ID")]
        //[Key]
        //public int Id { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
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
       // [EmailExist]
        public string? Email { get; set; }

        [RegularExpression("^(09|\\+639)\\d{9}$", ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        [ValidateNever]
        [NotMapped]
        public IdentityRole Role { get; set; }

        [ValidateNever]
        [NotMapped]
        public IEnumerable<ApplicationUser> Userss { get; set; }

        //public string Address { get; set; }
        //public ApplicationUser()
        //{

        //}

        //public ApplicationUser(int id, string firstName, string lastName, string email, string phone)
        //{
        //    Id = id;
        //    First_Name = firstName;
        //    Last_Name = lastName;
        //    Email = email;
        //    Phone = phone;

        //}

    }
}
