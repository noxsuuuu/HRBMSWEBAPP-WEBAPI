using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.MsSQL
{
    public class RoomDbRepository :IRoomRepository
    {
        HRMSDbContext _dbContext;

        public RoomDbRepository(HRMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Room AddRoom(Room room)
        {
            _dbContext.Add(room);
            _dbContext.SaveChanges();
            return room;
        }

        public Room DeleteRoom(int roomId)
        {
            var room = GetRoomById(roomId);
            if (room != null)
            {
                _dbContext.Rooms.Remove(room);
                _dbContext.SaveChanges();
            }
            return room;
        }

        public List<Room> GetAllRooms()
        {
            return _dbContext.Rooms.AsNoTracking().ToList();
        }


        public Room GetRoomById(int roomId)
        {
            return _dbContext.Rooms.AsNoTracking().ToList().FirstOrDefault(t => t.Id == roomId);
        }

        public Room UpdateRoom(int roomId, Room room)
        {
            _dbContext.Rooms.Update(room);
            _dbContext.SaveChanges();
            return room;
        }
    }
}
