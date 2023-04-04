using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Repository.Database
{
    public class RoomCategoryDBRepository : IRoomCatDBRepository
    {
        HRBMSDBCONTEXT _context;
        public RoomCategoryDBRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }

        public RoomCategories AddRoomCategories(RoomCategories category)
        {
            _context.Add(category);
            _context.SaveChanges();

            return category;
        }

        public RoomCategories DeleteRoomCategories(int category_id)
        {
            var category = _context.Categories.Find(category_id);
            if (category != null)
            {
                _context.Categories.Remove(category);
            }

             _context.SaveChanges();

            return category;

        }
        
        public List<RoomCategories> GetAllRoomCategories()
        {
             return _context.Categories.AsNoTracking().ToList();


        }

        public RoomCategories GetRoomCategoriesById(int category_id)
        {
            var category = _context.Categories
                    .FirstOrDefault(m => m.Id == category_id);

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
