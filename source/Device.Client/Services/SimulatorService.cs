using System.Collections.Generic;
using Device.Client.Domain.Devices;
using Device.Client.Domain.Devices.Interfaces;
using Device.Client.Domain.Events;
using Device.Client.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace Device.Client.Services
{
    public class SimulatorService : ISimulatorService
    {
        private readonly ILogger<SimulatorService> _logger;
        private readonly INotificationService _notificationService;
        private readonly IDeviceSimulatorBase _simulatedDevice;

        public SimulatorService(INotificationService notificationService, IDeviceSimulatorBase simulatedDevice, ILogger<SimulatorService> logger)
        {
            _notificationService = notificationService;

            _simulatedDevice = simulatedDevice;
            _simulatedDevice.DataChanged += (sender, e) => NotifyDeviceDataChanged(e);

            _logger = logger;
        } 

        private void NotifyDeviceDataChanged(DeviceDataChangedArgs args) 
        {
            _logger.LogDebug($"Calling notification service for changed data on Device {args.DeviceId} (Type: {args.DeviceType.ToString()}): {args.Data}");
            _notificationService.Send(args.DeviceType.ToString(), args.Data);
        }
    }
}
