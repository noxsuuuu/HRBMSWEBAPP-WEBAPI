//using HRBMSWEBAPP.Data;
//using HRBMSWEBAPP.Models;
//using Microsoft.EntityFrameworkCore;

//namespace HRBMSWEBAPP.Repository.Database
//{
//    public class RoomCategoryDBRepository : IRoomCatDBRepository
//    {
//        HRBMSDBCONTEXT _context;
//        public RoomCategoryDBRepository(HRBMSDBCONTEXT context)
//        {
//            _context = context;
//        }

//        public Task AddRoomCategories(RoomCategories category)
//        {
//            this._context.Add(category);
            

//            return this._context.SaveChangesAsync();
//        }

//        public Task DeleteRoomCategories(int category_id)
//        {
//            var category = this._context.Categories.FindAsync(category_id);
//            if (category.Result != null)
//            {
//                this._context.Categories.Remove(category.Result);
//            }

             

//            return this._context.SaveChangesAsync();

//        }
        
//        public Task<List<RoomCategories>> GetAllRoomCategories()
//        {
//             return this._context.Categories.ToListAsync();


//        }

//        public Task<RoomCategories> GetRoomCategoriesById(int category_id)
//        {
//            var category = this._context.Categories
//                    .FirstOrDefaultAsync(m => m.Id == category_id);

//            if (category == null)
//            {
//                 return null;
//            }

//             return category;
//        }

//        public Task UpdateRoomCategories(int category_id, RoomCategories category)
//        {
//             this._context.Update(category);
             

//            return this._context.SaveChangesAsync();
//        }
//    }
//}
