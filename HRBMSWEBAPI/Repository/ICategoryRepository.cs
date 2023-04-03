using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface ICategoryRepository
    {
        List<RoomCategories> GetAllRoomCategories();

        RoomCategories GetRoomCategoriesById(int catId);

        RoomCategories AddCat(RoomCategories cat);

        RoomCategories UpdateCat(int catId, RoomCategories cat);

        RoomCategories DeleteCat(int catId);
    }
}
