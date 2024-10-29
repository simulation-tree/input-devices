using InputDevices.Components;
using Simulation;
using System;
using System.Diagnostics;
using System.Numerics;
using Unmanaged;

namespace InputDevices
{
    public readonly struct GlobalMouse : IMouse
    {
        private readonly Mouse mouse;

        public readonly Vector2 Position
        {
            get => mouse.Position;
            set => mouse.Position = value;
        }

        public readonly Vector2 Scroll
        {
            get => mouse.Scroll;
            set => mouse.Scroll = value;
        }

        readonly uint IEntity.Value => mouse.device.entity.value;
        readonly World IEntity.World => mouse.device.entity.world;
        readonly Definition IEntity.Definition => new([RuntimeType.Get<IsMouse>(), RuntimeType.Get<IsGlobal>()], []);

#if NET
        [Obsolete("Default constructor not available", true)]
        public GlobalMouse()
        {
            throw new InvalidOperationException("Cannot create a global mouse without a world.");
        }
#endif

        public GlobalMouse(World world, uint existingEntity)
        {
            mouse = new Mouse(world, existingEntity);
        }

        /// <summary>
        /// Creates a global mouse device that receives data regardless
        /// of the window it belongs to.
        /// </summary>
        public GlobalMouse(World world)
        {
            ThrowIfInstanceAlreadyExists(world);
            mouse = new Mouse(world);
            mouse.AddComponent(new IsGlobal());
        }

        public readonly void Dispose()
        {
            mouse.Dispose();
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            return mouse.GetButtonState(control);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            mouse.SetButtonState(control, state);
        }

        [Conditional("DEBUG")]
        private static void ThrowIfInstanceAlreadyExists(World world)
        {
            if (world.TryGetFirst(out GlobalMouse _))
            {
                throw new InvalidOperationException("There can only be one global mouse instance");
            }
        }
    }
}
