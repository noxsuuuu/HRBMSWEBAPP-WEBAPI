using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HRBMSWEBAPI.Models
{
    public class Room
    {
        [DisplayName("Room ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Category ID")]
        public int CategoryId { get; set; }

        [DisplayName("Room Number")]
       // [UniqueRoomNumber]
        public int Room_Number { get; set; }

        [DisplayName("Floor Number")]

        public int Floor_Number { get; set; }

        [DisplayName("Room Status")]
        public bool Status { get; set; }


        /* [ValidateNever]
         public RoomCategories Category { get; set; }
 */

        public Room() { }

        public Room(int id, int categoryId, int room_Number, int floor_Number, bool status)
        {
            Id = id;
            CategoryId = categoryId;
            Room_Number = room_Number;
            Floor_Number = floor_Number;
            Status = status;
        }
    }
}
