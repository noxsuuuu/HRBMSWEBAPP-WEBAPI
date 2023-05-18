using HRBMSWEBAPI.Data;
using HRBMSWEBAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPI.Repository.Database
{
    public class RoomDbRepository : IRoomRepository
    {

        HRBMSDBCONTEXT _context;

        public RoomDbRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }

        public List<Room> spGetAllRooms()
        {
            return _context.Room.FromSqlRaw($"exec getallrooms").ToList();
        }
        public Room AddRoom(Room room)
        {
            _context.Add(room);
            _context.SaveChanges();
            return room;
        }
        public Task DeleteRoom(int room_id)
        {
            var room = this._context.Room.FindAsync(room_id);
            if (room.Result != null)
            {
                this._context.Room.Remove(room.Result);
            }

            return this._context.SaveChangesAsync();
        }

        public Task spDeleteRoom(int roomId)
        {
            //return _context.Room.FromSqlRaw($"exec getallrooms{roomId}").ToList();
            var room = this._context.Room.FindAsync(roomId);
            if (room.Result != null)
            {
                this._context.Database.ExecuteSqlRaw($"exec deleteroom {roomId}");
            }

            return this._context.SaveChangesAsync();
        }


        public Room UpdateRoom(int room_id, Room room)
        {
            _context.Update(room);
            _context.SaveChanges();

            return room;
        }
        public Task<List<Room>> GetAllRoom()
        {
            return this._context.Room.AsNoTracking().ToListAsync();
        }


        public Task<Room> GetRoomById(int room_id)
        {
            var room = this._context.Room
                           .FirstOrDefaultAsync(m => m.Id == room_id);

            if (room == null)
            {
                return null;
            }

            return room;
        }
    }
}
