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
        //public Booking AddBooking(Booking booking)
        //{

        //    _context.Add(booking);
        //    _context.SaveChanges();

        //    return booking; 
        //}
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
        //public Booking DeleteBooking(int bookingId)
        //{
        //    /*var booking = this._context.Booking.FindAsync(bookingId);
        //    if (booking.Result != null)
        //    {
        //        this._context.Booking.Remove(booking.Result);
        //    }

        //    return this._context.SaveChangesAsync();*/

        //    var booking = GetBookingById(bookingId);
        //    if(booking != null) 
        //    {
        //        _context.Booking.Remove(booking);
        //        _context.SaveChanges();

        //    }
        //    return booking;

        //}

        //public Booking UpdateBooking(int bookingId, Booking booking)
        //{
        //    /*this._context.Update(booking);
        //    return this._context.SaveChangesAsync();*/

        //    _context.Booking.Update(booking);
        //    _context.SaveChanges();

        //    return booking;


        //}
        

        public Task UpdateBooking(int bookingId, Booking booking)
        {
            this._context.Update(booking);
            return this._context.SaveChangesAsync();
        }
        public Task<List<Booking>> GetAllBooking()
        {
            return this._context.Booking.Include(c => c.Room).Include(c => c.User).AsNoTracking().ToListAsync();
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




        //public List<Booking> GetAllBooking()
        //{
        //    return _context.Booking.Include(e => e.Room).ToList();
        //}

        //public Booking GetBookingById(int booking_id)
        //{
        //    /*var booking = _context.Booking
        //           *//* .Include(e => e.User)
        //            *//*.Include(e => e.Room)
        //            .FirstOrDefault(m => m.Id == booking_id);

        //     if (booking == null)
        //     {
        //         return null;
        //     }

        //     return booking;*/

        //    return _context.Booking.AsNoTracking().FirstOrDefault(t => t.Id == booking_id);

        //}
    }
}
