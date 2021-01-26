using System.Threading.Tasks;
using Cinema.Application;
using Cinema.Application.Query;
using Cinema.Pages.Shared;

namespace Cinema.Pages
{
    public class ShowRoomMatrixPage
    {
        private readonly RoomPage _roomPage;
        private readonly IQueryService _queryService;
        private readonly ThrowExceptionService _throwExceptionService;

        public ShowRoomMatrixPage(RoomPage roomPage, IQueryService queryService, ThrowExceptionService throwExceptionService)
        {
            _roomPage = roomPage;
            _queryService = queryService;
            _throwExceptionService = throwExceptionService;
        }

        public async Task Start()
        {
            var roomName = await _roomPage.SelectRoom();

            var matrix = await _queryService.GetRoomMatrix(roomName);
            _throwExceptionService.ThrowIfNull(matrix, nameof(roomName), nameof(roomName), roomName);

            await Printer.PrintLine("Number of purchased tickets: " + matrix.NumberOfPurchasedTickets);
            await Printer.PrintLine("Percentage occupied: " + matrix.PercentageOccupied + "%");
            await Printer.PrintLine("Current income: " + matrix.CurrentIncome);
            await Printer.PrintLine("Potential total income: " + matrix.PotentialTotalIncome);
        }
    }
}
