using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IUserDBRepository
    {
        Task<List<User>> GetAllUser();
        Task<User> GetUserById(int user_id);
        Task AddUser(User user);
        Task DeleteUser(int user_id);
        Task UpdateUser(int user_id, User user);
    }
}
