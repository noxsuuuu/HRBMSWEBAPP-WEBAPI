using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IBookingDBRepository
    {
        Task<List<Booking>> GetAllBooking(string token);
        List<Booking> GetAllBooking1();
        Task<Booking> GetBookingById(int booking_id);
        Task AddBooking(Booking booking);
        Task DeleteBooking(int BookingId, string token);
        Task UpdateBooking(int booking_id, Booking booking);
    


    }
}
