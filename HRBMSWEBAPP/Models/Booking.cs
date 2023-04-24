using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HRBMSWEBAPP.Models
{
    public class Booking
    {
        [DisplayName("Booking ID")]
        [Key]
        public int Id { get; set; }

        [DisplayName("Check In")]
        [Required]
        public DateTime? CheckIn { get; set; }
        [DisplayName("Check Out")]
        [Required]
        public DateTime? CheckOut { get; set; }
        [ValidateNever]
        public ApplicationUser User { get; set; }

        [DisplayName("User ID")]
        public string? UserId { get; set; }
        [ValidateNever]
        public Room Room { get; set; }
        /*[ValidateNever]
        public RoomCategories Category { get; set; }*/
        public int RoomId { get; set; }


        public Booking()
        {

        }

        public Booking(int id, DateTime checkin, DateTime checkout, int roomId, string userid)
        {
            Id = id;
            CheckIn = checkin;
            CheckOut = checkout;
            RoomId = roomId;
            UserId = userid;
        }

    }
}
