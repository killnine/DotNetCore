using System;
using System.Timers;
using Device.Client.Domain.Events;
using Model.Domain.Types;

namespace Device.Client.Domain.Devices
{
    public abstract class DeviceSimulatorBase
    {
        private readonly Timer _updateTimer = new Timer();
        private readonly Timer _publishTimer = new Timer();
        protected DateTime _created = DateTime.UtcNow;

        public Guid Id { get; set; }
        public int Version { get; set; }
        public int PeriodMinutes { get; set; } = 5;
        public DeviceType Type { get; set; }
        public int MaximumUpdateRateMilliseconds { get; set; } = 250;

        public event EventHandler<DeviceDataChangedArgs> DataChanged;

        public DeviceSimulatorBase(Guid id) 
        {
            Id = id;

            //The timer will allow us to regularly update the Simulator data
            _updateTimer.AutoReset = true;
            _updateTimer.Interval = 50;
            _updateTimer.Elapsed += (sender, e) => Update();
            _updateTimer.Start();

            //The timer will allow us to regularly subscribe to changes so we can send out on the message bus
            _publishTimer.AutoReset = true;
            _publishTimer.Interval = 250;
            _publishTimer.Elapsed += (sender, e) => DataChanged?.Invoke(this, GetDeviceData());
            _publishTimer.Start();
        }

        protected abstract void Update();
        protected abstract DeviceDataChangedArgs GetDeviceData();
    }
}
