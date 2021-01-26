using System;
using System.Threading.Tasks;
using Cinema.Application;
using Cinema.Application.AddRoom;
using Cinema.Application.BuyTicket;
using Cinema.Application.Query;
using Cinema.Domain.Room;
using Cinema.Infrastructure;
using Cinema.Pages;
using Cinema.Pages.Shared;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Cinema
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var hostBuilder = new HostBuilder()
                .ConfigureServices((context, services) =>
                {

                    //Application Services
                    services.AddScoped<AddRoomService>();
                    services.AddScoped<BuyTicketService>();
                    services.AddScoped<IQueryService, QueryService>();
                    services.AddScoped<ThrowExceptionService>();

                    //Infrastructure
                    services.AddSingleton<DbContext>();

                    //Repos
                    services.AddSingleton<IRoomRepository, RoomRepository>();

                    //Presentation
                    services.AddTransient<WelcomePage>();
                    services.AddTransient<AddRoomPage>();
                    services.AddTransient<ShowRoomPage>();
                    services.AddTransient<BuyTicketPage>();
                    services.AddTransient<ShowRoomMatrixPage>();

                    services.AddTransient<RoomPage>();


                    services.AddHostedService<ServiceLifeCycle>();

                })
                .ConfigureLogging((context, builder) =>
                {
                    //Config logging
                });

            await hostBuilder.Build().RunAsync();
        }
    }
}
