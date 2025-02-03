using InputDevices.Components;
using System;
using System.Diagnostics;
using System.Numerics;
using Worlds;

namespace InputDevices
{
    public readonly partial struct GlobalMouse : IMouse
    {
        public readonly ref Vector2 Position => ref As<Mouse>().Position;
        public readonly ref Vector2 Scroll => ref As<Mouse>().Scroll;

        /// <summary>
        /// Creates a global mouse device that receives data regardless
        /// of the window it belongs to.
        /// </summary>
        public GlobalMouse(World world)
        {
            ThrowIfInstanceAlreadyExists(world);

            this.world = world;
            value = world.CreateEntity(new IsMouse(default, default), new LastMouseState(), new LastDeviceUpdateTime());
            AddTag<IsGlobal>();
        }

        readonly void IEntity.Describe(ref Archetype archetype)
        {
            archetype.AddTagType<IsGlobal>();
            archetype.Add<Mouse>();
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            return As<Mouse>().GetButtonState(control);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            As<Mouse>().SetButtonState(control, state);
        }

        [Conditional("DEBUG")]
        private static void ThrowIfInstanceAlreadyExists(World world)
        {
            if (world.TryGetFirst(out GlobalMouse _))
            {
                throw new InvalidOperationException($"There can only be one `{nameof(GlobalMouse)}` instance");
            }
        }

        public static implicit operator Mouse(GlobalMouse globalMouse)
        {
            return globalMouse.As<Mouse>();
        }

        public static implicit operator InputDevice(GlobalMouse globalMouse)
        {
            return globalMouse.As<InputDevice>();
        }
    }
}
