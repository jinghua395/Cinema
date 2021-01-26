using System;
using System.Threading.Tasks;
using Cinema.Domain.Room;

namespace Cinema.Application.BuyTicket
{
    public class BuyTicketService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ThrowExceptionService _throwExceptionService;

        public BuyTicketService(ThrowExceptionService throwExceptionService, IRoomRepository roomRepository)
        {
            _throwExceptionService = throwExceptionService;
            _roomRepository = roomRepository;
        }

        public async Task<BuyTicketResultDTO> Handle(string roomName, int rowNumber, int seatNumber)
        {
            var room = await _roomRepository.GetRoom(roomName);
            _throwExceptionService.ThrowIfNull(room, nameof(room), nameof(roomName), roomName);

            var (succ, price) = room.Reserve(rowNumber, seatNumber);

            return new BuyTicketResultDTO
            {
                Success = succ,
                Price = succ? price : (decimal?) null
            };
        }
    }
}
