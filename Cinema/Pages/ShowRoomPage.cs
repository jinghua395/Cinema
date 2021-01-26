using System.Threading.Tasks;
using Cinema.Application;
using Cinema.Application.Query;
using Cinema.Domain.Room;
using Cinema.Pages.Shared;

namespace Cinema.Pages
{
    public class ShowRoomPage
    {
        private readonly RoomPage _roomPage;
        private readonly IQueryService _queryService;
        private readonly ThrowExceptionService _throwExceptionService;

        public ShowRoomPage(RoomPage roomPage, IQueryService queryService, ThrowExceptionService throwExceptionService)
        {
            _roomPage = roomPage;
            _queryService = queryService;
            _throwExceptionService = throwExceptionService;
        }

        public async Task Start()
        {
            var roomName = await _roomPage.SelectRoom();

            var room = await _queryService.GetRoom(roomName);
            _throwExceptionService.ThrowIfNull(room, nameof(room), nameof(roomName), roomName);

            await Printer.PrintLine("Room: " + room.Name);

            var currentRow = 0;

            foreach (var seat in room.Seats)
            {
                if (seat.RowNumber != currentRow)
                {
                    await Printer.PrintLine();
                    currentRow++;
                    await Printer.Print(currentRow + ": ");
                }

                var status = seat.SeatStatus == SeatStatus.Reserved ? "R" : "A";
                await Printer.Print(seat.SeatNumber + status);
                await Printer.Print(" ");
            }

            await Printer.PrintLine();
        }

    }
}
