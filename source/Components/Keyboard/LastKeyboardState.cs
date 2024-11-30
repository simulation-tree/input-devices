using Worlds;

namespace InputDevices.Components
{
    [Component]
    public struct LastKeyboardState
    {
        public KeyboardState value;

        public LastKeyboardState(KeyboardState value)
        {
            this.value = value;
        }
    }
}
