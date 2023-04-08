using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using HRBMSWEBAPP.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRBMSWEBAPP.Models
{
    public class Room
    {
        [DisplayName("Room ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [DisplayName("Room Number")]
        [UniqueRoomNumber]
        public int Room_Number { get; set; }

        [DisplayName("Floor Number")]

        public int Floor_Number { get; set; }

        [ValidateNever]
        public RoomCategories Category { get; set; }
       
        [ValidateNever]
        public Booking Bookings { get; set; }

        [ValidateNever]
        [NotMapped]
        public IEnumerable<SelectListItem> RoomList { get; set; }

    }
}
