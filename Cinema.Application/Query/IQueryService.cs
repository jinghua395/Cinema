using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cinema.Application.Query
{
    public interface IQueryService
    {
        //TODO: with cancellation token
        Task<IEnumerable<string>> GetAllRoomNames();
        Task<RoomDTO> GetRoom(string roomName);
        Task<RoomMatrixDTO> GetRoomMatrix(string roomName);
    }
}
