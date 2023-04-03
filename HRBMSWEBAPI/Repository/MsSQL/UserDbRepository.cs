using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.MsSQL
{
    public class UserDbRepository : IUserRepository
    {
        HRMSDbContext _dbContext;

        public UserDbRepository(HRMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User AddUser(User user)
        {
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return user;
        }

        public User DeleteUser(int userId)
        {
            var user = GetUserById(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.AsNoTracking().ToList();
        }


        public User GetUserById(int userId)
        {
            return _dbContext.Users.AsNoTracking().ToList().FirstOrDefault(t => t.Id == userId);
        }

        public User UpdateUser(int userId, User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
            return user;
        }
    }
}
