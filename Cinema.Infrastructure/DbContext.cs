using System.Collections.Generic;
using Cinema.Domain.Room;

namespace Cinema.Infrastructure
{
    /*
     * Quick implementation, does not support UOW
     */
    public class DbContext
    {
        public readonly List<Room> Rooms;

        public DbContext()
        {
            Rooms = new List<Room>();
        }
    }
}
