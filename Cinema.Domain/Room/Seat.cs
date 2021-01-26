namespace Cinema.Domain.Room
{
    //Seat class should not contain status (it should be based on time/movie), this is just for quick implementation
    public class Seat
    {
        public Seat(int rowNumber, int seatNumber, decimal price)
        {
            RowNumber = rowNumber;
            SeatNumber = seatNumber;
            SeatStatus = SeatStatus.Available;
            Price = price;
        }

        public void Reserve()
        {
            SeatStatus = SeatStatus.Reserved;
        }

        public int RowNumber { get; private set; }
        public int SeatNumber { get; private set; }
        public SeatStatus SeatStatus { get; private set; } 
        public decimal Price { get; private set; }
    }
}
