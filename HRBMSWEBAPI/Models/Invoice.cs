using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HRBMSWEBAPP.Models
{
    public class Invoice
    {
        [DisplayName("Invoice ID")]
        [Key]
        public int Id { get; set; }

        //[DisplayName("User ID")]
        //public int UserId { get; set; }

        [ValidateNever]
        public ApplicationUser User { get; set; }

        [DisplayName("Booking ID")]
        public int BookId { get; set; }

        [ValidateNever]
        public Booking Booking { get; set; }

        [DisplayName("Room ID")]
        public int RoomId { get; set; }

        [ValidateNever]
        public Room Room { get; set; }

        [DisplayName("Category ID")]
        public int CatId { get; set; }

        [ValidateNever]
        public RoomCategories Category { get; set; }

        [DisplayName("Check In")]
        public DateTime CheckIn { get; set; }

        [DisplayName("Check Out")]
        public DateTime CheckOut { get; set; }

        [DisplayName("Price")]
        [DisplayFormat(DataFormatString = "₱{0:N}", ApplyFormatInEditMode = true, NullDisplayText = "")]
        [Required]
        public int Price { get; set; }

        [DisplayName("Total Price")]
        [DisplayFormat(DataFormatString = "₱{0:N}", ApplyFormatInEditMode = true, NullDisplayText = "")]
        [Required]
        public double TotalPrice { get; set; }
        
        public Invoice()
        {           
        }

        public Invoice(int id, int userid, int bookid, int catid, int roomid, DateTime Cout, DateTime Cin, int price, double totalp)
        {
           Id = id;
           //UserId = userid;  
           BookId = bookid;
           CatId = catid;
           RoomId = roomid;
           CheckIn = Cin;
           CheckOut = Cout;
           Price = price;
           TotalPrice = totalp;


        }


    }
}
