using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IRoomCatDBRepository
    {
        List<RoomCategories> GetAllRoomCategories();
        RoomCategories GetRoomCategoriesById(int category_id);
        RoomCategories AddRoomCategories(RoomCategories category);
        RoomCategories DeleteRoomCategories(int category_id);
        RoomCategories UpdateRoomCategories(int category_id, RoomCategories category);
    }
}
