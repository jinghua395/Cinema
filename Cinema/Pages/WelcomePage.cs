using System;
using System.Threading.Tasks;

namespace Cinema.Pages
{
    public class WelcomePage
    {
        private readonly AddRoomPage _addRoomPage;
        private readonly ShowRoomPage _showRoomPage;
        private readonly ShowRoomMatrixPage _showRoomMatrix;
        private readonly BuyTicketPage _buyTicketPage;

        public WelcomePage(AddRoomPage addRoomPage, ShowRoomPage showRoomPage, ShowRoomMatrixPage showRoomMatrix, BuyTicketPage buyTicketPage)
        {
            _addRoomPage = addRoomPage;
            _showRoomPage = showRoomPage;
            _showRoomMatrix = showRoomMatrix;
            _buyTicketPage = buyTicketPage;
        }

        public async Task Start()
        {
            while (true)
            {
                try
                {
                    await Printer.PrintLine("Welcome! Select a command number");
                    await Printer.PrintLine("1. Add Room");
                    await Printer.PrintLine("2. Show Room");
                    await Printer.PrintLine("3. Buy ticket");
                    await Printer.PrintLine("4. Show room matrix");

                    var input = Console.ReadLine();
                    var command = ParseCommandNumber(input);

                    switch (command)
                    {
                        case 1:
                            await _addRoomPage.Start();
                            break;
                        case 2:
                            await _showRoomPage.Start();
                            break;
                        case 3:
                            await _buyTicketPage.Start();
                            break;
                        case 4:
                            await _showRoomMatrix.Start();
                            break;
                        default:
                            throw new ArgumentException($"Invalid command {command}");
                    }

                    await Printer.PrintLine();
                    await Printer.PrintLine("Command finished, return back to welcome page");
                    await Printer.PrintLine();
                }
                catch (Exception e)
                {
                    await Printer.PrintError($"{e.Message}, return back to welcome page");
                    await Printer.PrintError();
                }
            }
        }

        private int ParseCommandNumber(string input)
        {
            var success = int.TryParse(input, out var num);

            if (!success)
                throw new ArgumentException("Invalid command number, use 1, 2, 3 or 4");

            if (num < 1 || num > 4)
                throw new ArgumentException("Invalid command number, use 1, 2, 3 or 4");

            return num;
        }
    }
}
