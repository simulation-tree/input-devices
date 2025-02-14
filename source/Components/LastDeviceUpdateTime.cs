using System;

namespace InputDevices.Components
{
    public struct LastDeviceUpdateTime
    {
        public TimeSpan value;

        public LastDeviceUpdateTime(TimeSpan value)
        {
            this.value = value;
        }
    }
}
