using System.Threading;
using System.Threading.Tasks;
using Cinema.Domain.Room;
using Cinema.Infrastructure;
using Cinema.Pages;
using Microsoft.Extensions.Hosting;

namespace Cinema
{
    class ServiceLifeCycle : BackgroundService
    {
        private readonly WelcomePage _welcomePage;
        private readonly DbContext _context;

        public ServiceLifeCycle(WelcomePage welcomePage, DbContext context)
        {
            _welcomePage = welcomePage;
            _context = context;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Should run in migration script
            Seeding();

            await _welcomePage.Start();
        }

        private void Seeding()
        {
            _context.Rooms.Add(new Room("A"));
        }
    }
}
