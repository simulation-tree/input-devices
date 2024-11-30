using Worlds;

namespace InputDevices.Components
{
    [Component]
    public struct IsKeyboard
    {
        public KeyboardState state;

        public IsKeyboard(KeyboardState state)
        {
            this.state = state;
        }
    }
}
