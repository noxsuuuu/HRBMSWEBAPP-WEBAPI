using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.MsSQL
{
    public class BookingDbRepository : IBookingRepository
    {
        HRMSDbContext _dbContext;

        public BookingDbRepository(HRMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Bookings AddBookings(Bookings book)
        {
            _dbContext.Add(book);
            _dbContext.SaveChanges();
            return book;
        }

        public Bookings DeleteBookings(int bookId)
        {
            var book = GetBookingsById(bookId);
            if (book != null)
            {
                _dbContext.Bookings.Remove(book);
                _dbContext.SaveChanges();
            }
            return book;
        }

        public List<Bookings> GetAllBookings()
        {
            return _dbContext.Bookings.AsNoTracking().ToList();
        }


        public Bookings GetBookingsById(int bookId)
        {
            return _dbContext.Bookings.AsNoTracking().ToList().FirstOrDefault(t => t.Id == bookId);
        }

        public Bookings UpdateBookings(int bookId, Bookings book)
        {
            _dbContext.Bookings.Update(book);
            _dbContext.SaveChanges();
            return book;
        }
    }
}
