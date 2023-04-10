using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBooking();
        Task<Booking> GetBookingById(int booking_id);
        //Task AddBooking(Booking booking);
        Booking AddBooking(Booking booking);
        Task DeleteBooking(int booking_id);
        Booking UpdateBooking(int booking_id, Booking booking);

    }
}
