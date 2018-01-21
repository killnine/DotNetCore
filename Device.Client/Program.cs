using System;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Device.Client.Domain.Devices;
using Device.Client.Services;
using Device.Client.Services.Interfaces;
using Serilog;
namespace Device.Server
{
    class Program
    {
        public static IConfiguration Configuration { get; set; }

        static void Main(string[] args)
        {
            //Set up configuration
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            //Set up dependency injection
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddSingleton<INotificationService>(provider => new NotificationService(Configuration["RabbitMQHost"], provider.GetService<ILogger<NotificationService>>()))
                .AddSingleton<ISimulatorService, SimulatorService>()
                .AddSingleton<IDeviceSimulatorBase, ManrolandDevice>()
                .BuildServiceProvider();

            //Set up logging
            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.ColoredConsole()
                .CreateLogger();

            var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
            loggerFactory.AddSerilog(dispose: true);

            //Start up service instance
            var service = serviceProvider.GetService<ISimulatorService>();

            //Wait?
            Console.ReadLine();
        }
    }
}