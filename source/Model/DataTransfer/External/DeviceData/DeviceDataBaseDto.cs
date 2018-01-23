using System;

namespace Model.DataTransfer.External.DeviceData
{
    public class DeviceDataBaseDto
    {
        public Guid Id { get; set; }
        public int DeviceTypeId { get; set; }
        public int Version { get; set; }
    }
}
