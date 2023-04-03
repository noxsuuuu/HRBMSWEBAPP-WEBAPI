using System.ComponentModel.DataAnnotations;

namespace HRBMSWEBAPI.DTO
{
    public class BookingDTO
    {
        [Required]
        public DateTime? Check_In { get; set; }
        public DateTime? Check_Out { get; set; }
        public bool status { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }

        public BookingDTO()
        {

        }

        public BookingDTO(DateTime? check_In, DateTime? check_Out, bool status, int roomId, int guestId)
        {
            Check_In = check_In;
            Check_Out = check_Out;
            this.status = status;
            RoomId = roomId;
            GuestId = guestId;
        }
    }
}
