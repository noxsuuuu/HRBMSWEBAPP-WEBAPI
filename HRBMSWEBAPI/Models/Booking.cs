using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRBMSWEBAPI.Models
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

        //public ICollection<Employee> Employees { get; set; }
        public Booking()
        {

        }
        public Booking(int id, DateTime checkin, DateTime checkout, int roomId, bool stats)
        {
            RoomId = id;
            CheckIn = checkin;
            CheckOut = checkout;
            RoomId = roomId;


        }
    }
}
