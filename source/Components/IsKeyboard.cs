using Worlds;

namespace InputDevices.Components
{
    public struct IsKeyboard
    {
        public KeyboardState currentState;
        public KeyboardState lastState;
        public rint windowReference;

        public IsKeyboard(rint windowReference = default)
        {
            this.windowReference = windowReference;
            currentState = default;
            lastState = default;
        }
    }
}
