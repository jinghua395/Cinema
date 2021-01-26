using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Cinema.Application.BuyTicket;
using Cinema.Pages.Shared;

namespace Cinema.Pages
{
    public class BuyTicketPage
    {
        private readonly RoomPage _roomPage;
        private readonly BuyTicketService _buyTicketService;

        public BuyTicketPage(RoomPage roomPage, BuyTicketService buyTicketService)
        {
            _roomPage = roomPage;
            _buyTicketService = buyTicketService;
        }

        public async Task Start()
        {
            var room = await _roomPage.SelectRoom();

            await Printer.PrintLine("Input number of row");
            var input = await Printer.Read();
            var rowNumber = ParseNumber(input);

            await Printer.PrintLine("Input number of seat");
            input = await Printer.Read();
            var seatNumber = ParseNumber(input);

            var result = await _buyTicketService.Handle(room, rowNumber, seatNumber);

            if (result.Success)
            {
                await Printer.PrintLine("Ticket is purchased, price: " + result.Price);
            }
            else
            {
                await Printer.PrintLine("Failed to purchase ticket");
            }
        }

        private int ParseNumber(string input)
        {
            var success = int.TryParse(input, out var num);

            if (!success)
                throw new ArgumentException("Invalid input");

            return num;
        }
    }
}
