using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Net.Http;

namespace HRBMSWEBAPP.Repository.Database
{
    public class BookingDBRepository : IBookingDBRepository
    {
        HRBMSDBCONTEXT _context;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;
        public BookingDBRepository(HRBMSDBCONTEXT context, IConfiguration configs)
        {
            _httpClient = new HttpClient();
            // Local server
            _httpClient.BaseAddress = new Uri("https://localhost:7098/api");
            _configs = configs;
            _context = context;
        }
        
        public Task AddBooking(Booking booking)
        {
            this._context.Add(booking);
            return this._context.SaveChangesAsync();
        }

        public async Task DeleteBooking(int BookingId, string token)
        {
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //var newRoomAsString = JsonConvert.SerializeObject(newRoom);

            var response = await _httpClient.DeleteAsync($"https://localhost:7098/api/v1/Booking/{BookingId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsByteArrayAsync();
                Console.WriteLine("Delete Booking Response: ", data);
            }
            //var booking = this._context.Booking.FindAsync(BookingId);
            //if (booking.Result != null)
            //{
            //    this._context.Booking.Remove(booking.Result);
            //}

            //return this._context.SaveChangesAsync();
        }
       
        

        public Task UpdateBooking(int bookingId, Booking booking)
        {
            this._context.Update(booking);
            return this._context.SaveChangesAsync();
        }
        public async Task<List<Booking>> GetAllBooking(string token)
        {
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.GetAsync("https://localhost:7098/api/v1/Booking");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var book = JsonConvert.DeserializeObject<List<Booking>>(content);
                return book ?? new List<Booking>();
            }
            return new List<Booking>();
            // return this._context.Booking.Include(c => c.Room).Include(c => c.User).AsNoTracking().ToListAsync();
        }
        public List<Booking> GetAllBooking1()
        {

            return _context.Booking.Include(c => c.User).AsNoTracking().ToList();
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
