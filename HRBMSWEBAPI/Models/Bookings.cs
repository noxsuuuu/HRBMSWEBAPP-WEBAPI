namespace HRBMSWEBAPI.Models
{
    public class Bookings
    {
        public int Id { get; set; }
        public DateTime? Check_In { get; set; }
        public DateTime? Check_Out { get; set; }
        public bool Status { get; set; }
        public int RoomId { get; set; }
        public int GuestId { get; set; }
    }
}
