using HRBMSWEBAPI.Models;

namespace HRBMSWEBAPI.Repository
{
    public interface IRoomRepository
    {
        Task<List<Room>> GetAllRoom(); 
        Task<Room> GetRoomById(int room_id);
        //Room AddRoom(Room room);
        //Task DeleteRoom(int room_id);
        //Room UpdateRoom(int room_id, Room room);

        // stored procedures
        Task< List<Room>> spGetAllRooms();
        Task spDeleteRoom(int roomId);
        Room spAddroom(Room room);
        Room spUpdateRoom(int roomId, Room room);

    }
}
