using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cinema.Domain.Test
{
    [TestClass]
    public class RoomTest
    {
        [TestMethod]
        [DataRow(0, 5, true)]
        [DataRow(-1, 5, true)]
        [DataRow(1, 5, true)]
        [DataRow(21, 5, true)]
        [DataRow(10, 4, true)]
        [DataRow(10, 21, true)]
        [DataRow(20, 20, false)]
        [DataRow(5, 5, false)]
        
        public void ValidateNumberOfSeats_TestCases_Ok(int numberOfRows, int numberOfSeatsPerRow, bool shouldThrow)
        {
            var room = new Room.Room("A");

            if (shouldThrow)
            {
                Assert.ThrowsException<ArgumentException>(() =>
                    room.ValidateNumberOfSeats(numberOfRows, numberOfSeatsPerRow));
            }
        }

        [TestMethod]
        [DataRow(5, 5, -1, 1, false, -1)]
        [DataRow(5, 5, 0, 5, false, -1)]
        [DataRow(5, 5, 2, 2, true, 10)]
        [DataRow(5, 5, 5, 5, true, 10)]
        [DataRow(5, 5, 6, 5, false, -1)]
        [DataRow(10, 10, 4, 5, true, 12)]
        [DataRow(10, 10, 5, 5, true, 12)]
        [DataRow(10, 10, 6, 5, true, 10)]
        public void Reserve_TestCases_Ok(int numberOfRows, int numberOfSeatsPerRow, int rowNumber, int seatNumber, 
            bool expectedSucc, int expectedPrice)
        {
            var room = new Room.Room("A", numberOfRows, numberOfSeatsPerRow);

            var (succ, price) = room.Reserve(rowNumber, seatNumber);

            Assert.AreEqual(expectedSucc, succ);
            Assert.AreEqual(expectedPrice, price);
        }
    }
}
