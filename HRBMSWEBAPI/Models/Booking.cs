using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRBMSWEBAPP.Models
{
    public class Booking
    {
        [DisplayName("Booking ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Room ID")]
        public int RoomId { get; set; }

        [DisplayName("Check In")]
        [Required]
        public DateTime CheckIn { get; set; }

        [DisplayName("Check Out")]
        [Required]
        public DateTime CheckOut { get; set; }


        [DisplayName("Room Status")]
        public bool Status { get; set; }

        [NotMapped]
        public string DisplayStatus => Status ? "Available" : "Booked";

      /*  [DisplayName("User ID")]
        public int UserId { get; set; }



        [ValidateNever]
        public User User { get; set; }
*/
        [ValidateNever]
        public Room Room { get; set; }



        //public ICollection<Employee> Employees { get; set; }
        public Booking()
        {

        }
        public Booking(int id, DateTime checkin, DateTime checkout, int roomId, bool stats)
        {
            Id = id;
            CheckIn = checkin;
            CheckOut = checkout;
            RoomId = roomId;
            //UserId = userid;
            Status = stats;

        }
    }
}
