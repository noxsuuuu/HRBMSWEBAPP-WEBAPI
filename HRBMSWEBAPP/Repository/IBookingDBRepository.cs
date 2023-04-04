using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IBookingDBRepository
    {
        List<Booking> GetAllBooking();
        Booking GetBookingById(int booking_id);
        Booking AddBooking(Booking booking);
        Booking DeleteBooking(int booking_id);
        Booking UpdateBooking(int booking_id, Booking booking);
    }
}
