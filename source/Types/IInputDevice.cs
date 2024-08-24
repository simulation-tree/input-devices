using Simulation;

namespace InputDevices
{
    public interface IInputDevice : IEntity
    {
        ButtonState GetButtonState(uint control);
        void SetButtonState(uint control, ButtonState state);
    }
}
