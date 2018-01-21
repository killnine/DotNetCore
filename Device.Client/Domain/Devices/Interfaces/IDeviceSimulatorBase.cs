using System;
using Device.Client.Domain.Events;

namespace Device.Client.Domain.Devices
{
    public interface IDeviceSimulatorBase
    {
        event EventHandler<DeviceDataChangedArgs> DataChanged;
    }
}
