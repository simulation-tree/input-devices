using System.Numerics;
using Worlds;

namespace InputDevices.Components
{
    [Component]
    public struct IsMouse
    {
        public MouseState state;

        public unsafe ref Vector2 Position
        {
            get
            {
                fixed (Vector2* position = &state.position)
                {
                    return ref *position;
                }
            }
        }

        public unsafe ref Vector2 Scroll
        {
            get
            {
                fixed (Vector2* scroll = &state.scroll)
                {
                    return ref *scroll;
                }
            }
        }

        public IsMouse(MouseState state)
        {
            this.state = state;
        }
    }
}
