using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IRoomRepository
    {
        List<Room> GetAllRooms();

        Room GetRoomById(int roomId);

        Room AddRoom(Room room);

        Room UpdateRoom(int roomId, Room room);

        Room DeleteRoom(int roomId);
    }
}
