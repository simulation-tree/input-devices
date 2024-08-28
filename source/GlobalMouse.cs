using InputDevices.Components;
using Simulation;
using System;
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

        World IEntity.World => (Entity)mouse;
        eint IEntity.Value => (Entity)mouse;

#if NET
        [Obsolete("Default constructor not available", true)]
        public GlobalMouse()
        {
            throw new InvalidOperationException("Cannot create a global mouse without a world.");
        }
#endif

        public GlobalMouse(World world, eint existingEntity)
        {
            mouse = new Mouse(world, existingEntity);
        }

        public GlobalMouse(World world)
        {
            mouse = new Mouse(world);
            Entity entity = mouse;
            entity.AddComponent(new IsGlobal());
        }

        Query IEntity.GetQuery(World world)
        {
            return new Query(world, RuntimeType.Get<IsMouse>());
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            return mouse.GetButtonState(control);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            mouse.SetButtonState(control, state);
        }

        public static implicit operator InputDevice(GlobalMouse mouse)
        {
            return mouse.mouse;
        }

        public static implicit operator Mouse(GlobalMouse mouse)
        {
            return mouse.mouse;
        }

        public static implicit operator Entity(GlobalMouse mouse)
        {
            return mouse.mouse;
        }
    }
}
