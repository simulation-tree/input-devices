using System;
using Worlds;

namespace InputDevices.Components
{
    [Component]
    public struct IsKeyboard
    {
        public KeyboardState state;
        public rint windowReference;

#if NET
        [Obsolete("Default constructor not supported", true)]
        public IsKeyboard()
        {
            throw new NotSupportedException();
        }
#endif

        public IsKeyboard(KeyboardState state, rint windowReference)
        {
            this.state = state;
            this.windowReference = windowReference;
        }
    }
}
