using Simulation;
using Unmanaged;

namespace InputDevices.Events
{
    public readonly struct DeviceButtonReleased
    {
        public readonly uint device;
        public readonly RuntimeType deviceType;
        public readonly uint control;

        private DeviceButtonReleased(uint device, RuntimeType deviceType, uint control)
        {
            this.device = device;
            this.deviceType = deviceType;
            this.control = control;
        }

        public static DeviceButtonReleased Create<T>(uint device, uint control) where T : unmanaged, IInputDevice
        {
            return new(device, RuntimeType.Get<T>(), control);
        }

        public static DeviceButtonReleased Create<T>(T device, uint control) where T : unmanaged, IInputDevice
        {
            return new(device.Value, RuntimeType.Get<T>(), control);
        }
    }
}
