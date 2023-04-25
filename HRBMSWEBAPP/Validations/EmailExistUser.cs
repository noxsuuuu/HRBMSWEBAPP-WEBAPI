using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using HRBMSWEBAPP.ViewModel;
using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPP.Validations
{
      public class EmailExistUser : ValidationAttribute
        {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var user = (ApplicationUser)validationContext.ObjectInstance;
            var dbContext = (HRBMSDBCONTEXT)validationContext.GetService(typeof(HRBMSDBCONTEXT));
            var emailexist = dbContext.Users.FirstOrDefault(b => b.Email == user.Email);
            if (emailexist != null)
            {
                return new ValidationResult("This email address is already in use.");
            }

            return ValidationResult.Success;
        }
      

    }
}
