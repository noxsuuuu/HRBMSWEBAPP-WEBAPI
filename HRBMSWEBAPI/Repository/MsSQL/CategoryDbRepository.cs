using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.MsSQL
{
    public class CategoryDbRepository : ICategoryRepository
    {
        HRMSDbContext _dbContext;

        public CategoryDbRepository(HRMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public RoomCategories AddCat(RoomCategories cat)
        {
            _dbContext.Add(cat);
            _dbContext.SaveChanges();
            return cat;
        }

        public RoomCategories DeleteCat(int catId)
        {
            var cat = GetRoomCategoriesById(catId);
            if (cat != null)
            {
                _dbContext.RoomCategories.Remove(cat);
                _dbContext.SaveChanges();
            }
            return cat;
        }

        public List<RoomCategories> GetAllRoomCategories()
        {
            return _dbContext.RoomCategories.AsNoTracking().ToList();
        }


        public RoomCategories GetRoomCategoriesById(int catId)
        {
            return _dbContext.RoomCategories.AsNoTracking().ToList().FirstOrDefault(t => t.Id == catId);
        }

        public RoomCategories UpdateCat(int catId, RoomCategories cat)
        {
            _dbContext.RoomCategories.Update(cat);
            _dbContext.SaveChanges();
            return cat;
        }
    }
}
