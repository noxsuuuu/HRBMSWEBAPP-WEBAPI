using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IRoomCatDBRepository
    {
        Task<List<RoomCategories>> GetAllRoomCategories(string token);
        Task<RoomCategories> GetRoomCategoriesById(int category_id);
        Task AddRoomCategories(RoomCategories category);
        Task DeleteRoomCategories(int category_id, string token);
        Task UpdateRoomCategories(int category_id, RoomCategories category);
    }
}
