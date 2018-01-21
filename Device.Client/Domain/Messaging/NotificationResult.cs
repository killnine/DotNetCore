using System;
namespace Device.Client.Domain.Messaging
{
    public class NotificationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public NotificationResult(bool success = true)
        {
            Success = success;
        }
    }
}
