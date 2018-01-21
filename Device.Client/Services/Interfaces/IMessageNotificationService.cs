using System;
using Device.Client.Domain.Messaging;

namespace Device.Client.Services.Interfaces
{
    public interface INotificationService
    {
        NotificationResult Send(string queueName, object message);
    }
}
