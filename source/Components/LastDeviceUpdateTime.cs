using System;
using Worlds;

namespace InputDevices.Components
{
    [Component]
    public struct LastDeviceUpdateTime
    {
        public TimeSpan value;

        public LastDeviceUpdateTime(TimeSpan value)
        {
            this.value = value;
        }
    }
}
