using System;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Application.AddRoom;
using Cinema.Pages.Shared;

namespace Cinema.Pages
{
    public class AddRoomPage
    {
        private readonly RoomPage _roomPage;
        private readonly AddRoomService _addRoomService;

        public AddRoomPage(AddRoomService addRoomService, RoomPage roomPage)
        {
            _addRoomService = addRoomService;
            _roomPage = roomPage;
        }

        public async Task Start()
        {
            await Printer.PrintLine("Existing room");
            var rooms = await _roomPage.ListRoom();

            await Printer.PrintLine("Input new room name");
            var roomName = await Printer.Read();
            
            if (rooms.Select(r => r.ToLower()).Contains(roomName.ToLower()))
            {
                throw new ArgumentException("Room is already existed");
            }

            await Printer.PrintLine("Input number of rows");
            var input = await Printer.Read();
            var numberOfRows = ParseNumber(input);

            await Printer.PrintLine("Input number of seats per row");
            input = await Printer.Read();
            var numberOfSeatsPerRow = ParseNumber(input);

            //TODO: maybe should verify if numberOfRows or numberOfSeatsPerRow are too big

            await _addRoomService.Handle(roomName, numberOfRows, numberOfSeatsPerRow);
        }

        private int ParseNumber(string input)
        {
            var success = int.TryParse(input, out var num);

            if (!success)
                throw new ArgumentException("Invalid input");

            return num;
        }
    }
}
