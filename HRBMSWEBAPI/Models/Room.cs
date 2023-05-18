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

        [ValidateNever]
        public RoomCategories Category { get; set; }

        [DisplayName("Room Status")]
        public bool Status { get; set; }



        public Room() { }

        public Room(int id, int categoryId, bool status)
        {
            Id = id;
            CategoryId = categoryId;

            Status = status;
        }
    }
}
