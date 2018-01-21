using System;
namespace Model.DataTransfer.Device
{
    public class DeviceDataBaseDto
    {
        public Guid Id { get; set; }
        public int DeviceTypeId { get; set; }
        public int Version { get; set; }
    }
}
