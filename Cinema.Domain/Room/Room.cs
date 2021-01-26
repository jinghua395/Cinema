using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Domain.Room
{
    //Aggregate root, entity
    public sealed class Room
    {
        public Room(string name)
        {
            Id = Guid.NewGuid();

            Name = name;

            InitiateSeats(10, 10);
        }

        public Room(string name, int numberOfRows, int numberOfSeats)
        {
            Id = Guid.NewGuid();

            Name = name;

            InitiateSeats(numberOfRows, numberOfSeats);

            NumberOfReservations = 0;
        }

        private void InitiateSeats(int numberOfRows, int numberOfSeats)
        {
            ValidateNumberOfSeats(numberOfRows, numberOfSeats);

            NumberOfRows = numberOfRows;
            NumberOfSeatsPerRow = numberOfSeats;
            Capacity = numberOfRows * numberOfSeats;

            _seats = new List<Seat>();
            

            for (var r = 1; r <= numberOfRows; r++)
            {
                var price = 10;
                if (Capacity > 50)
                {
                    price = r <= NumberOfRows / 2 ? 12 : 10;
                }

                for (var s = 1; s <= numberOfSeats; s++)
                {
                    _seats.Add(new Seat(r, s, price));
                }
            }
        }

        internal void ValidateNumberOfSeats(int numberOfRows, int numberOfSeats)
        {
            //Do not know validation logic, this is for example
            if (numberOfRows < 5 || numberOfRows > 20)
            {
                throw new ArgumentException("Number of rows should be in between 5 and 20");
            }

            if (numberOfSeats < 5 || numberOfSeats > 20)
            {
                throw new ArgumentException("Number of seats per row should be in between 5 and 20");
            }
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public int NumberOfRows { get; private set; }
        public int NumberOfSeatsPerRow { get; private set; }
        public int Capacity { get; private set; }

        public int NumberOfReservations { get; private set; }

        private List<Seat> _seats;
        public IReadOnlyCollection<Seat> Seats => _seats;

        public (bool, decimal) Reserve(int rowNumber, int seatNumber)
        {
            var found = _seats.SingleOrDefault(s => s.RowNumber == rowNumber && s.SeatNumber == seatNumber);

            if (found == null)
            {
                return (false, -1m);
            }

            //Consider make price calculation as a DomainService if it becomes too complicated
            found.Reserve();
            NumberOfReservations++;

            return (true, found.Price);
        }

        public decimal PercentageOccupied()
        {
            return NumberOfReservations * 1m / Capacity;
        }

        public decimal CurrentIncome()
        {
            var reserved = Seats.Where(s => s.SeatStatus == SeatStatus.Reserved);

            return reserved.Sum(r => r.Price);
        } 

        public decimal PotentialTotalIncome()
        {
            return Seats.Sum(r => r.Price);
        }
    }
}
