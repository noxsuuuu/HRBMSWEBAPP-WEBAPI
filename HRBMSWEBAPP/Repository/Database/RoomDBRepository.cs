using HRBMSWEBAPP.Data;
using HRBMSWEBAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HRBMSWEBAPP.Repository.Database
{
    public class RoomDBRepository : IRoomDBRepository
    {
        HRBMSDBCONTEXT _context;

        public RoomDBRepository(HRBMSDBCONTEXT context)
        {
            _context = context;
        }

        public Room AddRoom(Room room)
        {
            _context.Add(room);
            _context.SaveChangesAsync();
            return room;
        }

        public Room DeleteRoom(int room_id)
        {
            var room = GetRoomById(room_id);
            if (room != null)
            {
                _context.Room.Remove(room);
                _context.SaveChanges();
            }
 
            return room;
        }

        public List<Room> GetAllRoom()
        {
            return _context.Room.AsNoTracking().ToList();
        }

        public Room GetRoomById(int room_id)
        {
            var room = _context.Room
                   .Include(e => e.Category)
                   .FirstOrDefault(m => m.Id == room_id);

            if (room == null)
            {
                return null;
            }

            return room;
        }

        public Room UpdateRoom(int room_id, Room room)
        {
            _context.Update(room);
             _context.SaveChanges();

            return room;
        }
    }
}
