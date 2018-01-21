using System;
using Model.DataTransfer.Device;
using Model.Domain.Types;

namespace Device.Client.Domain.Events
{
    public class DeviceDataChangedArgs
    {
        public Guid DeviceId { get; private set; }
        public DeviceType DeviceType {get; private set; }
        public DeviceDataBaseDto Data { get; private set; }

        public DeviceDataChangedArgs(Guid deviceId, DeviceType deviceType, DeviceDataBaseDto data)
        {
            DeviceId = deviceId;
            DeviceType = deviceType;
            Data = data;
        }
    }
}
