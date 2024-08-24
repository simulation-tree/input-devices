using InputDevices;

public static class InputDeviceFunctions
{
    public static bool WasPressed<T, C>(this T device, C control) where T : unmanaged, IInputDevice where C : unmanaged
    {
        return device.GetButtonState(control).WasPressed;
    }

    public static bool WasReleased<T, C>(this T device, C control) where T : unmanaged, IInputDevice where C : unmanaged
    {
        return device.GetButtonState(control).WasReleased;
    }

    public static bool IsPressed<T, C>(this T device, C control) where T : unmanaged, IInputDevice where C : unmanaged
    {
        return device.GetButtonState(control).IsPressed;
    }

    public unsafe static ButtonState GetButtonState<T, C>(this T device, C control) where T : unmanaged, IInputDevice where C : unmanaged
    {
        uint controlIndex = *(uint*)&control;
        return device.GetButtonState(controlIndex);
    }

    public unsafe static void SetButtonState<T, C>(this T device, C control, ButtonState state) where T : unmanaged, IInputDevice where C : unmanaged
    {
        uint controlIndex = *(uint*)&control;
        device.SetButtonState(controlIndex, state);
    }
}