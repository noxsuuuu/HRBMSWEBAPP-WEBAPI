using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        User GetUserById(int userId);

        User AddUser(User user);

        User UpdateUser(int userId, User user);

        User DeleteUser(int userId);
    }
}
