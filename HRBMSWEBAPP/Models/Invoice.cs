//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel;
//using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

//namespace HRBMSWEBAPP.Models
//{
//    public class Invoice
//    {
//        [DisplayName("Invoice ID")]
//        [Key]
//        public int Id { get; set; }

//        [DisplayName("User ID")]
//        public string UserId { get; set; }

//        [ValidateNever]
//        public ApplicationUser User { get; set; }

//        [DisplayName("Booking ID")]
//        public int BookingId { get; set; }

//        [ValidateNever]
//        public Booking Booking { get; set; }

//        [DisplayName("Room ID")]
//        public int RoomId { get; set; }

//        [ValidateNever]
//        public Room Room { get; set; }

//        [DisplayName("Category ID")]
//        public int CategoryId { get; set; }

//        [ValidateNever]
//        public RoomCategories Category { get; set; }

//        //[DisplayName("Check In")]
//        //public DateTime CheckIn { get; set; }

//        //[DisplayName("Check Out")]
//        //public DateTime CheckOut { get; set; }

//        //[DisplayName("Price")]
//        //[DisplayFormat(DataFormatString = "₱{0:N}", ApplyFormatInEditMode = true, NullDisplayText = "")]
//        //[Required]
//        //public int Price { get; set; }

//        [DisplayName("Total Price")]
//        [DisplayFormat(DataFormatString = "₱{0:N}", ApplyFormatInEditMode = true, NullDisplayText = "")]
//        [Required]
//        public double TotalPrice { get; set; }
        
//        public Invoice()
//        {           
//        }

//        public Invoice(int id, string userid, int bookid, int catid, int roomid, double totalp)
//        {
//           Id = id;
//           UserId = userid;  
//           BookingId = bookid;
//           CategoryId = catid;
//           RoomId = roomid;
//           TotalPrice = totalp;


//        }


//    }
//}
