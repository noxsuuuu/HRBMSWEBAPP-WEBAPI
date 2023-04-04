using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository
{
    public interface IRoomDBRepository
    {
        List<Room> GetAllRoom();
        Room GetRoomById(int room_id);
        Room AddRoom(Room room);
        Room DeleteRoom(int room_id);
        Room UpdateRoom(int room_id, Room room);
    }
}
