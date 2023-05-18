using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.Database
{
    public class RoomCatDbRepository : IRoomCatRepository
    {
        HRBMSDBCONTEXT _context;
        public RoomCatDbRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }

        public RoomCategories AddRoomCategories(RoomCategories category)
        {
            _context.Add(category);
            _context.SaveChanges();

            return category;
        }

        public Task DeleteRoomCategories(int catId)
        {
            var category = this._context.Categories.FindAsync(catId);
            if (category.Result != null)
            {
                this._context.Categories.Remove(category.Result);
            }
            return this._context.SaveChangesAsync();

        }

        public Task<List<RoomCategories>> GetAllRoomCategories()
        {
            return this._context.Categories.ToListAsync();


        }
        public List<RoomCategories> spGetAllCategories()
        {
            return _context.Categories.FromSqlRaw("getallcategories").ToList();
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

        public RoomCategories UpdateRoomCategories(int category_id, RoomCategories category)
        {
            _context.Update(category);
            _context.SaveChanges();

            return category;
        }


    }
}
