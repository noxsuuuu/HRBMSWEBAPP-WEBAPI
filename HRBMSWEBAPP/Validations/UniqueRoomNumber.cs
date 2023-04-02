using HRBMSWEBAPP.Data;
using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPP.Validations
{
    public class UniqueRoomNumber : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (value is string)
                {
                    var idproperty = validationContext.ObjectType.GetProperty("Id");
                    int _id = Convert.ToInt16(idproperty.GetValue(validationContext.ObjectInstance));

                    int roomnumber = (int)value;

                    bool roomExist = false;

                    if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "DBDevelopment")
                    {
                        HRBMSDBCONTEXT _context = new HRBMSDBCONTEXT();

                        roomExist = (_context.Room?
                             .Any(e => e.Room_Number == roomnumber && e.Id != _id))
                                 .GetValueOrDefault();
                        //here
                    }
                    //else
                    //{
                    //    HRBMS_InMemContext hrbmscontext = new HRBMS_InMemContext();

                    //    emailExist = hrbmscontext.employees
                    //        .Exists(employee => employee.Email == email && employee.Id != employeeId);
                    //}

                    if (roomExist)
                    {
                        return new ValidationResult("Room Already Booked!");
                    }
                }
                else
                {
                    return new ValidationResult("Invalid Room Number");
                }
            }
            return ValidationResult.Success;
        }
    }
}
