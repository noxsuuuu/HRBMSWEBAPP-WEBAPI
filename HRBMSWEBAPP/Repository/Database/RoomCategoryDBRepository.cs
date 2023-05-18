using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NuGet.Common;
using System.Net.Http;

namespace HRBMSWEBAPP.Repository.Database
{
    public class RoomCategoryDBRepository : IRoomCatDBRepository
    {
        HRBMSDBCONTEXT _context;
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;
        public RoomCategoryDBRepository(HRBMSDBCONTEXT context, IConfiguration configs)
        {
            _httpClient = new HttpClient();
            // Local server
            _httpClient.BaseAddress = new Uri("https://localhost:7098/api");
            _configs = configs;
            _context = context;
        }

        public Task AddRoomCategories(RoomCategories category)
        {
            this._context.Add(category);
            

            return this._context.SaveChangesAsync();
        }

        public async Task DeleteRoomCategories(int catId, string token)
        {
            
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            //var newRoomAsString = JsonConvert.SerializeObject(newRoom);

            var response = await _httpClient.DeleteAsync($"https://localhost:7098/api/RoomCategory/{catId}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsByteArrayAsync();
                Console.WriteLine("Delete Room Category Response: ", data);
            }


            //var category = this._context.Categories.FindAsync(id);
            //if (category.Result != null)
            //{
            //    this._context.Categories.Remove(category.Result);
            //}
            //return this._context.SaveChangesAsync();

        }
        
        public async Task<List<RoomCategories>> GetAllRoomCategories(string token)
        {
            // return this._context.Categories.ToListAsync();
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.GetAsync("https://localhost:7098/api/RoomCategory");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<List<RoomCategories>>(content);
                return category ?? new List<RoomCategories>();
            }
            return new List<RoomCategories>();


        }
        public List<RoomCategories> spGetAllCategories()
        {
            return _context.Categories.FromSqlRaw($"exec getallcategories").ToList();
        }

        public Task<RoomCategories> GetRoomCategoriesById(int category_id)
        {
            var category = this._context.Categories
                    .FirstOrDefaultAsync(m => m.Id == category_id);

            if (category == null)
            {
                 return null;
            }

             return category;
        }

        public Task UpdateRoomCategories(int category_id, RoomCategories category)
        {
             this._context.Update(category);
             

            return this._context.SaveChangesAsync();
        }
    }
}
