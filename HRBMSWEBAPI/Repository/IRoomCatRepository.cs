using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IRoomCatRepository
    {
        Task<List<RoomCategories>> GetAllRoomCategories();
        Task<RoomCategories> GetRoomCategoriesById(int category_id);
        RoomCategories AddRoomCategories(RoomCategories category);
        Task DeleteRoomCategories(int category_id);
        RoomCategories UpdateRoomCategories(int category_id, RoomCategories category);
    }
}
