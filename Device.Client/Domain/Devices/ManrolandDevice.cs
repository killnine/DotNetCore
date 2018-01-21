using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Device.Client.Domain.Device;
using Device.Client.Domain.Events;
using Microsoft.Extensions.Logging;
using Model.DataTransfer.Device;
using Model.Domain.Types;

namespace Device.Client.Domain.Devices
{ 
    public class ManrolandDevice : DeviceSimulatorBase, IDeviceSimulatorBase
    {
        public ILogger<ManrolandDevice> _logger;

        private const decimal MAX_TEMPERATURE = 425;
        private const decimal STANDBY_TEMPERATURE = 100;
        private const decimal VIBRATION_MEDIAN = 0.5M;

        private const string FRONT_DRYER = "Front";
        private const string REAR_DRYER = "Rear";
        private const string UNIT1_FILTER = "Unit 1";
        private const string UNIT2_FILTER = "Unit 2";

        public decimal DryerTemperatureInlet { get; set; }
        public decimal DryerTemperatureOutlet { get; set; }
        public IDictionary<string,decimal> DryerFanVibration { get; set; } = new ConcurrentDictionary<string,decimal>();
        public IDictionary<string,bool> OilFilterBypass { get; set; } = new ConcurrentDictionary<string,bool>();

        public ManrolandDevice(ILogger<ManrolandDevice> logger) : this(Guid.NewGuid(), logger) { }

        public ManrolandDevice(Guid id, ILogger<ManrolandDevice> logger) : base(id)
        {
            _logger = logger;

            Type = DeviceType.Manroland;

            DryerTemperatureInlet = STANDBY_TEMPERATURE;
            DryerTemperatureOutlet = STANDBY_TEMPERATURE;

            DryerFanVibration.Add(FRONT_DRYER, 0.0M);
            DryerFanVibration.Add(REAR_DRYER, 0.0M);

            OilFilterBypass.Add(UNIT1_FILTER, false);
            OilFilterBypass.Add(UNIT2_FILTER, false);
        }

        protected override void Update()
        {
            _logger.LogTrace($"Updating Device {Id} data points.");

            var now = DateTime.UtcNow;

            ////TODO: Update the temperature values
            //DryerTemperatureInlet = STANDBY_TEMPERATURE;
            //DryerTemperatureOutlet = STANDBY_TEMPERATURE;

            ////TODO: Update the Vibration values
            //DryerFanVibration[FRONT_DRYER] = 100;
            //DryerFanVibration[REAR_DRYER] = 100;

            ////TODO: Update the bypass values
            //OilFilterBypass[UNIT1_FILTER] = false;
            //OilFilterBypass[UNIT2_FILTER] = true;

            _logger.LogTrace($"Updating Device {Id} data points: {this}");
        }

        protected override DeviceDataChangedArgs GetDeviceData()
        {
            _logger.LogTrace($"Retrieving {Id} updating data points: {this}");

            return new DeviceDataChangedArgs(Id, Type, new ManrolandDeviceDataDto()
            {
                Id = Id,
                DeviceTypeId = (int)Type,
                Version = Version,
                DryerFanVibration = DryerFanVibration,
                DryerTemperatureInlet = DryerTemperatureInlet,
                DryerTemperatureOutlet = DryerTemperatureOutlet,
                OilFilterBypass = OilFilterBypass
            });
        }
    }
}
