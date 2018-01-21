using System.Collections.Generic;
namespace Model.DataTransfer.Device
{
    public class ManrolandDeviceDataDto : DeviceDataBaseDto
    {
        public decimal DryerTemperatureInlet { get; set; }
        public decimal DryerTemperatureOutlet { get; set; }

        public IDictionary<string, decimal> DryerFanVibration { get; set; } = new Dictionary<string, decimal>();

        public IDictionary<string, bool> OilFilterBypass { get; set; } = new Dictionary<string, bool>();
    }
}
