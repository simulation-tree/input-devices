using Worlds;

namespace InputDevices.Components
{
    [Component]
    public struct LastMouseState
    {
        public MouseState value;

        public LastMouseState(MouseState value)
        {
            this.value = value;
        }
    }
}
