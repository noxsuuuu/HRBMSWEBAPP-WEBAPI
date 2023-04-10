using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class BookingDTO
    {
        [Required]
        public int RoomId { get; set; }
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        

        public BookingDTO() { }

        public  BookingDTO(int roomId, DateTime checkIn, DateTime checkOut)
        {
            RoomId = roomId;
            CheckIn = checkIn;
            CheckOut = checkOut;
        }
    }
}
