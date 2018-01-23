using System;
using System.IO;
using Device.Client.Domain.Devices;
using Device.Client.Domain.Devices.Interfaces;
using Device.Client.Services;
using Device.Client.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Device.Client
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
                .WriteTo.Console()
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