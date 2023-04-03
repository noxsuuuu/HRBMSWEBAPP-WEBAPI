using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IBookingRepository
    {
        List<Bookings> GetAllBookings();

        Bookings GetBookingsById(int bookId);

        Bookings AddBookings(Bookings book);

        Bookings UpdateBookings(int bookId, Bookings book);

        Bookings DeleteBookings(int bookId);
    }
}
