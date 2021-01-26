using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cinema.Application.Query;

namespace Cinema.Infrastructure
{
    public class QueryService : IQueryService
    {
        private readonly DbContext _dbContext;

        public QueryService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<IEnumerable<string>> GetAllRoomNames()
        {
            return Task.FromResult(_dbContext.Rooms.Select(r => r.Name));
        }

        public Task<RoomDTO> GetRoom(string roomName)
        {
            var room = _dbContext.Rooms.SingleOrDefault(r => string.Equals(r.Name, roomName, StringComparison.InvariantCultureIgnoreCase));

            if (room == null) return null;

            var mapped = new RoomDTO
            {
                Name = room.Name,
                Id = room.Id,
                NumberOfSeatsPerRow = room.NumberOfSeatsPerRow,
                NumberOfRows = room.NumberOfRows,
                Seats = room.Seats.Select(s => new SeatDTO
                {
                    SeatNumber = s.SeatNumber,
                    SeatStatus = s.SeatStatus,
                    RowNumber = s.RowNumber
                })
            };

            return Task.FromResult(mapped);
        }

        public Task<RoomMatrixDTO> GetRoomMatrix(string roomName)
        {
            var room = _dbContext.Rooms.SingleOrDefault(r => r.Name.ToLower() == roomName.ToLower());

            if (room == null) return null;

            var mapped = new RoomMatrixDTO
            {
                CurrentIncome = room.CurrentIncome(),
                NumberOfPurchasedTickets = room.NumberOfReservations,
                PercentageOccupied = room.PercentageOccupied(),
                PotentialTotalIncome = room.PotentialTotalIncome()
            };

            return Task.FromResult(mapped);
        }
    }
}
