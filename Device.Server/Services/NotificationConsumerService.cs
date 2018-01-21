using System;
using System.Text;
using Device.Server.Services.Interfaces;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Device.Server.Services
{
    public class NotificationConsumerService : INotificationConsumerService
    {
        private readonly ILogger<NotificationConsumerService> _logger;
        private readonly string _hostname;

        public NotificationConsumerService(string hostname, ILogger<NotificationConsumerService> logger)
        {
            _logger = logger;
            _hostname = hostname;

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "Manroland",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body;
                    var message = Encoding.UTF8.GetString(body);
                    _logger.LogInformation($"Received message! {DateTime.UtcNow} {message}");
                };
                channel.BasicConsume(queue: "Manroland",
                                     autoAck: true,
                                     consumer: consumer);
                _logger.LogInformation($"Consumer started... (Press any key to exit)");
                Console.WriteLine("Consumer started...");
                Console.ReadLine();
            }
        }
    }
}
