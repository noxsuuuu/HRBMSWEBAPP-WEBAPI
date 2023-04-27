using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IBookingDBRepository
    {
        Task<List<Booking>> GetAllBooking();
        List<Booking> GetAllBooking1();
        Task<Booking> GetBookingById(int booking_id);
        Task AddBooking(Booking booking);
        Task DeleteBooking(int booking_id);
        Task UpdateBooking(int booking_id, Booking booking);
    


    }
}
