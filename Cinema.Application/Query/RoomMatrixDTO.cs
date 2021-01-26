namespace Cinema.Application.Query
{
    public class RoomMatrixDTO
    {
        public int NumberOfPurchasedTickets { get; set; }
        public decimal PercentageOccupied { get; set; }
        public decimal CurrentIncome { get; set; }
        public decimal PotentialTotalIncome { get; set; }
    }
}
