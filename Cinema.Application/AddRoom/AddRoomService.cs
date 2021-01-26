using System.Threading.Tasks;
using Cinema.Domain.Room;

namespace Cinema.Application.AddRoom
{
    public class AddRoomService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly ThrowExceptionService _throwExceptionService;

        public AddRoomService(IRoomRepository roomRepository, ThrowExceptionService throwExceptionService)
        {
            _roomRepository = roomRepository;
            _throwExceptionService = throwExceptionService;
        }

        public Task Handle(string roomName, int numberOfRows, int numberSeatsPerRow)
        {
            var room = new Room(roomName, numberOfRows, numberSeatsPerRow);

            _throwExceptionService.ThrowIfNull(room, nameof(room), nameof(roomName), roomName);

            _roomRepository.AddRoom(room);

            //Should save changes if UOW applied
            return Task.CompletedTask;
        }
    }
}
