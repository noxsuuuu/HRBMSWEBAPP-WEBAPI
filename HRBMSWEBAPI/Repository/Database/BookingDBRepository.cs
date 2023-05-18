using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.Database
{
    public class BookingDbRepository : IBookingRepository
    {

        HRBMSDBCONTEXT _context;

        public BookingDbRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }

        /*public Task AddBooking(Booking booking)
        {
            this._context.Add(booking);
            return this._context.SaveChangesAsync();
        }*/

        public Booking AddBooking(Booking newBooking)
        {
            _context.Add(newBooking);
            _context.SaveChanges();

            return newBooking;
        }


        public Task<Booking> GetBookingById(int booking_id)
        {
            var booking = this._context.Booking
                .FirstOrDefaultAsync(m => m.Id == booking_id);

            if (booking == null)
            {
                return null;
            }

            return booking;
        }

        public Task<List<Booking>> GetAllBooking()
        {
            return this._context.Booking.ToListAsync();
        }
        public List<Booking> spGetAllBooking()
        {
            return _context.Booking.FromSqlRaw($"exec getallbooking").ToList();
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
        public Booking UpdateBooking(int bookingId, Booking booking)
        {
            _context.Update(booking);
            _context.SaveChanges();
            return booking;
        }

    }
}
