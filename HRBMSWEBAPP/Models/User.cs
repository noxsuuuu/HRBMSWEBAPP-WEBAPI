//using HRBMSWEBAPP.Validations;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;

//namespace HRBMSWEBAPP.Models
//{
//    public class User
//    {
//        [DisplayName("User ID")]
//        [Key]
//        public int Id { get; set; }

//        [DisplayName("First Name")]
//        public string First_Name { get; set; }

//        [DisplayName("Last Name")]
//        public string Last_Name { get; set; }

//        [NotMapped]
//        [DisplayName("Full Name")]
//        public string Full_Name
//        {
//            get { return First_Name + " " + Last_Name; }
//            set { }
//        }

//        [DisplayName("Email Address")]
//        [EmailAddress]
//        [EmailExist]
//        public string? Email { get; set; }

//        [RegularExpression("^(09|\\+639)\\d{9}$", ErrorMessage = "Invalid phone number.")]
//        public string Phone { get; set; }

//        public string Address { get; set; }

//        //[DisplayName("Role ID")]       
//        //public int RoleId { get; set; }

//        //[ValidateNever]
//        //public Role Role { get; set; }


//        [ValidateNever]
//        public ICollection<Booking> Bookings { get; set; }

//        [ValidateNever]
//        public ICollection<Invoice> Invoices { get; set; }




//        public User()
//        {

//        }

//        public User(int id, string firstName, string lastName, string email, string phone)
//        {
//            Id = id;
//            First_Name = firstName;
//            Last_Name = lastName;
//            Email = email;
//            Phone = phone;

//        }
//    }
//}
