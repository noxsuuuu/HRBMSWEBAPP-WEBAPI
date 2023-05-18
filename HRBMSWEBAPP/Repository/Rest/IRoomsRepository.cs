using HRBMSWEBAPP.Models;

namespace HRBMSWEBAPP.Repository.Rest;

public interface IRoomsRepository
{
    Task<List<Room>> GetAllRooms(string token);

    //stored procedure
    List<Room> spGetAllRooms();
    Task<Room?> GetRoomById(int roomId);
    Task<Room?> CreateRoom(Room newRoom, string token);
    Task DeleteRoom(int roomId, string token);
    Task<Room?> UpdateRoom(int roomId, Room updatedRoom, string token);
}