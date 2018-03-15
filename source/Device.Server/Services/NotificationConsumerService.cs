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
        private readonly string _queue;
        private readonly string _hostname;

        //TODO: How can we know how to consume the message?
        //TODO: The Queue and its handling logic should be intertwined (e.g. "Manroland" queue maps to the Manroland Device data handler
        //TODO: If the queue processes a type it doesn't have an explicit handler for, just log the raw data and be done.
        public NotificationConsumerService(string hostname, string queue, ILogger<NotificationConsumerService> logger)
        {
            _logger = logger;
            _queue = queue;
            _hostname = hostname;

            var factory = new ConnectionFactory() { HostName = _hostname };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: _queue,
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
