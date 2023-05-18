using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoom();

        //getAllRooms stored procedure
        List<Room> spGetAllRooms();
        Task<Room> GetRoomById(int room_id);
        Room AddRoom(Room room);
        Task DeleteRoom(int room_id);
        Room UpdateRoom(int room_id, Room room);
    }
}
