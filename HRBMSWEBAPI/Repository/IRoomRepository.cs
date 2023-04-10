using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoom();
        Task<Room> GetRoomById(int room_id);
        Room AddRoom(Room room);
        Task DeleteRoom(int room_id);
        Room UpdateRoom(int room_id, Room room);
    }
}
