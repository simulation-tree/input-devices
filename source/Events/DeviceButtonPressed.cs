using Simulation;
using Unmanaged;

namespace InputDevices.Events
{
    public readonly struct DeviceButtonPressed
    {
        public readonly uint device;
        public readonly RuntimeType deviceType;
        public readonly uint control;

        private DeviceButtonPressed(uint device, RuntimeType deviceType, uint control)
        {
            this.device = device;
            this.deviceType = deviceType;
            this.control = control;
        }

        public static DeviceButtonPressed Create<T>(uint device, uint control) where T : unmanaged, IInputDevice
        {
            return new(device, RuntimeType.Get<T>(), control);
        }

        public static DeviceButtonPressed Create<T>(T device, uint control) where T : unmanaged, IInputDevice
        {
            return new(device.Value, RuntimeType.Get<T>(), control);
        }
    }
}
