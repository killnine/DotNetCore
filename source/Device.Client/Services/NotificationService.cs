using RabbitMQ.Client;
using System.Text;
using System;
using Device.Client.Services.Interfaces;
using Device.Client.Domain.Messaging;
using Microsoft.Extensions.Logging;

namespace Device.Client.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ILogger<NotificationService> _logger;
        private readonly string _hostname;

        public NotificationService(string hostname, ILogger<NotificationService> logger)
        {
            _hostname = hostname;
            _logger = logger;
        }

        public NotificationResult Send(string queueName, object message)
        {
            var result = new NotificationResult();

            try
            {
                _logger.LogTrace($"Attempting to message RabbitMQ (Host: {_hostname}) with message: {message} to queue {queueName}");

                var factory = new ConnectionFactory() { HostName = _hostname };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: queueName,
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    string msg = Newtonsoft.Json.JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(msg);

                    channel.BasicPublish(exchange: "",
                                         routingKey: queueName,
                                         basicProperties: null,
                                         body: body);
                }
            }
            catch(Exception ex)
            {
                _logger.LogError($"Unable to successfully call RabbitMQ (Host: {_hostname}) with message: {message} to queue {queueName}: {ex.Message}");
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }
    }
}
