using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRBMSWEBAPP.Models
{
    public class Room
    {
        [DisplayName("Room ID")]
        [Key]
        public int Id { get; set; }
        [DisplayName("Room Status")]
        public bool Status { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        [ValidateNever]
        public RoomCategories Category { get; set; }
        [DisplayName("Category ID")]
        public int CategoryId { get; set; }


        [NotMapped]
        public string DisplayStatus => Status ? "Available" : "Booked";

        public Room()
        {

        }

        public Room(int id, bool status, int catId)
        {
            Id = id;
            Status = status;
            CategoryId = catId;
        }


    }
}
