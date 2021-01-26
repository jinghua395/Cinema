using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Application.Query;
using Cinema.Infrastructure;

namespace Cinema.Pages.Shared
{
    public class RoomPage
    {
        private readonly IQueryService _query;

        public RoomPage(IQueryService query)
        {
            _query = query;
        }

        public async Task<IEnumerable<string>> ListRoom()
        {
            var rooms = (await _query.GetAllRoomNames()).ToList();
            foreach (var r in rooms)
            {
                await Printer.PrintLine(r);
            }

            return rooms;
        }

        public async Task<string> SelectRoom()
        {
            await Printer.PrintLine("Select a room");
            var rooms = await ListRoom();

            var room = await Printer.Read();
            ValidateIfRoomExisting(rooms, room);

            return room;
        }

        public void ValidateIfRoomExisting(IEnumerable<string> rooms, string room)
        {
            if (!rooms.Select(r => r.ToLower()).Contains(room.ToLower()))
            {
                throw new ArgumentException("Invalid room " + room);
            }
        }
    }
}
