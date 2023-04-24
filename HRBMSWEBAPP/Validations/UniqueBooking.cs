using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPP.Validations
{
    public class UniqueBooking : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dbContext = (HRBMSDBCONTEXT)validationContext.GetService(typeof(HRBMSDBCONTEXT));
            var bookid = value;

            // Check if the roomId already exists in the database
            //var existingRoom = dbContext.Room.FirstOrDefault(r => r.Id == roomId);
            //var existingFloor = dbContext.Room.FirstOrDefault(r => r.Floor_Number == roomId);
            //if (existingRoom != null || existingFloor != null)
            //{
            //    return new ValidationResult("The Room Number already exists.");
            //}

            var room = (Booking)validationContext.ObjectInstance;
            var existingbook = dbContext.Booking.FirstOrDefault(b => room.Id == room.Id && b.CheckIn == room.CheckIn && b.CheckIn == room.CheckIn);
            if (existingbook != null)
            {
                return new ValidationResult("The Room Already Booked!");
            }

            return ValidationResult.Success;
        }
    }
}
