using Worlds;

namespace InputDevices.Components
{
    public struct IsMouse
    {
        public MouseState currentState;
        public MouseState lastState;
        public rint windowReference;

        public IsMouse(rint windowReference = default)
        {
            this.windowReference = windowReference;
            currentState = default;
            lastState = default;
        }
    }
}
