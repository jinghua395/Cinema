using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Domain.Room;

namespace Cinema.Infrastructure
{
    public class RoomRepository : IRoomRepository
    {
        private readonly DbContext _context;

        public RoomRepository(DbContext context)
        {
            _context = context;
        }

        public Task<Room> GetRoom(string roomName)
        {
            return Task.FromResult(_context.Rooms.SingleOrDefault(r => r.Name == roomName));
        }

        public void AddRoom(Room room)
        {
            var found = _context.Rooms.Any(r => r.Id == room.Id || r.Name == room.Name);

            if (found)
            {
                throw new ArgumentException("Room is existing" + room.Name);
            }

            _context.Rooms.Add(room);
        }

        public void UpdateRoom(Room room)
        {
            var count = _context.Rooms.RemoveAll(r => r.Id == room.Id);

            if (count <= 0)
            {
                throw new ArgumentException("Not found room " + room.Name);
            }

            _context.Rooms.Add(room);
        }
    }
}
