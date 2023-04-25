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

        //public Room AddRoom(Room room)
        //{
        //    _context.Add(room);
        //    _context.SaveChangesAsync();
        //    return room;
        //}
        public async Task AddRoom(Room room)
        {
            await this._context.Room.AddAsync(room);
            await this._context.SaveChangesAsync();
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
        //public Room DeleteRoom(int room_id)
        //{
        //    var room = GetRoomById(room_id);
        //    if (room != null)
        //    {
        //        _context.Room.Remove(room);
        //        _context.SaveChanges();
        //    }

        //    return room;
        //}

        public Task UpdateRoom(int room_id, Room room)
        {
            this._context.Update(room);
            return this._context.SaveChangesAsync();
        }
        public Task<List<Room>> GetAllRoom()
        {
            return this._context.Room.Include(e=>e.Category).AsNoTracking().ToListAsync();
        }
        public List<Room> GetAllRoom1()
        {
            return this._context.Room.Include(e => e.Category).AsNoTracking().ToList();
        }

        //public List<Room> GetAllRoom()
        //{
        //    return _context.Room.AsNoTracking().ToList();
        //}

        //public Room GetRoomById(int room_id)
        //{
        //    var room = _context.Room
        //           .Include(e => e.Category)
        //           .FirstOrDefault(m => m.Id == room_id);

        //    if (room == null)
        //    {
        //        return null;
        //    }

        //    return room;
        //}
        public Task<Room> GetRoomById(int room_id)
        {
            var room = this._context.Room
                           .Include(e => e.Category)
                           .FirstOrDefaultAsync(m => m.Id == room_id);

            if (room == null)
            {
                return null;
            }

            return room;
        }

        //public Room UpdateRoom(int room_id, Room room)
        //{
        //    _context.Update(room);
        //     _context.SaveChanges();

        //    return room;
        //}
    }
}
