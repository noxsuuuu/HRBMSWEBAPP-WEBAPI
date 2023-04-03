using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Repository.Database
{
    public class UserDBRepository : IUserDBRepository
    {
        HRBMSDBCONTEXT _context;
        public UserDBRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }
        public Task AddUser(User user)
        {
            this._context.Add(user);
            return this._context.SaveChangesAsync();
        }

        public Task DeleteUser(int user_id)
        {
            var user = this._context.User.FindAsync(user_id);
            if (user.Result != null)
            {
                this._context.User.Remove(user.Result);
            }

            return this._context.SaveChangesAsync();
        }

        public Task<List<User>> GetAllUser()
        {
            throw new NotImplementedException();
            //return this._context.User.Include(e => e.Category).ToListAsync();
        }

        public Task<User> GetUserById(int user_id)
        {
            throw new NotImplementedException();
            //var user = this._context.User
            //      .Include(e => e.Category)
            //      .FirstOrDefaultAsync(m => m.Id == user_id);

            //if (user == null)
            //{
            //    return null;
            //}

            //return user;
        }

        public Task UpdateUser(int user_id, User user)
        {
            this._context.Update(user);
            return this._context.SaveChangesAsync();
        }
    }
}
