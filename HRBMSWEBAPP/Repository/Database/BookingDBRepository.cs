using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Repository.Database
{
    public class BookingDBRepository : IBookingDBRepository
    {
        HRBMSDBCONTEXT _context;

        public BookingDBRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }
        public Task AddBooking(Booking booking)
        {

            this._context.Add(booking);
            return this._context.SaveChangesAsync();
        }

        public Task DeleteBooking(int bookingId)
        {
            var booking = this._context.Booking.FindAsync(bookingId);
            if (booking.Result != null)
            {
                this._context.Booking.Remove(booking.Result);
            }

            return this._context.SaveChangesAsync();
        }

        public Task UpdateBooking(int bookingId, Booking booking)
        {
            this._context.Update(booking);
            return this._context.SaveChangesAsync();
        }

        public Task<List<Booking>> GetAllBooking()
        {
            return this._context.Booking.Include(e => e.User).Include(e => e.Room).ToListAsync();
        }

        public Task<Booking> GetBookingById(int booking_id)
        {
            var booking = this._context.Booking
                    .Include(e => e.User)
                    .Include(e => e.Room)
                    .FirstOrDefaultAsync(m => m.Id == booking_id);

            if (booking == null)
            {
                return null;
            }

            return booking;
        }
    }
}
