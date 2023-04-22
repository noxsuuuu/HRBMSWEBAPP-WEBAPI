//using HRBMSWEBAPP.Data;
//using HRBMSWEBAPP.Models;
//using System.ComponentModel.DataAnnotations;

//namespace HRBMSWEBAPP.Validations
//{
//    public class UniqueRoomNumber : ValidationAttribute
//    {
//        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
//        {
//            var dbContext = (HRBMSDBCONTEXT)validationContext.GetService(typeof(HRBMSDBCONTEXT));
//            var roomId = (int)value;

//            // Check if the roomId already exists in the database
//            //var existingRoom = dbContext.Room.FirstOrDefault(r => r.Id == roomId);
//            //var existingFloor = dbContext.Room.FirstOrDefault(r => r.Floor_Number == roomId);
//            //if (existingRoom != null || existingFloor != null)
//            //{
//            //    return new ValidationResult("The Room Number already exists.");
//            //}

//            var room = (Room)validationContext.ObjectInstance;
//            var existingRoom = dbContext.Room.FirstOrDefault(b => room.Id == room.Id && b.Floor_Number == room.Floor_Number);
//            if (existingRoom != null)
//            {
//                return new ValidationResult("The Room Already Exist");
//            }

//            return ValidationResult.Success;
//        }
//    }
//}
