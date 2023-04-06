using HRBMSWEBAPP.Data;
using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPP.Validations
{
      public class EmailExist : ValidationAttribute
        {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is string)
                {
                    var useridproperty = validationContext.ObjectType.GetProperty("Id");
                    int userid = Convert.ToInt16(useridproperty.GetValue(validationContext.ObjectInstance));

                    string email = (string)value;

                    bool emailExist = false;

                    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "DBDevelopment")
                    {
                        HRBMSDBCONTEXT _context = new HRBMSDBCONTEXT();

                        emailExist = (_context.Users?
                            .Any(e => e.Email == email && e.Id != userid.ToString()))
                                .GetValueOrDefault();
                        //here
                    }
                 

                    if (emailExist)
                    {
                        return new ValidationResult("Email address already registered.");
                    }
                }
                else
                {
                    return new ValidationResult("Invalid Email Address.");
                }
            }
            return ValidationResult.Success;
        }

    }
}
