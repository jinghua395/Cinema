using System;
using System.Collections.Generic;
using Cinema.Domain.Room;

namespace Cinema.Application.Query
{
    public class RoomDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int NumberOfRows { get; set; }
        public int NumberOfSeatsPerRow { get; set; }

        public IEnumerable<SeatDTO> Seats { get; set; }
    }

    public class SeatDTO
    {
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }
        public SeatStatus SeatStatus { get; set; }
    }
}
