using InputDevices.Components;
using Simulation;
using System;
using Unmanaged;

namespace InputDevices
{
    public readonly struct GlobalKeyboard : IKeyboard
    {
        private readonly Keyboard keyboard;

        World IEntity.World => (Entity)keyboard;
        uint IEntity.Value => (Entity)keyboard;

#if NET
        [Obsolete("Default constructor not available", true)]
        public GlobalKeyboard()
        {
            throw new InvalidOperationException("Cannot create a global keyboard without a world.");
        }
#endif

        public GlobalKeyboard(World world, uint existingEntity)
        {
            keyboard = new(world, existingEntity);
        }

        public GlobalKeyboard(World world)
        {
            keyboard = new(world);
            Entity entity = keyboard;
            entity.AddComponent(new IsGlobal());
        }

        Query IEntity.GetQuery(World world)
        {
            return new Query(world, RuntimeType.Get<IsKeyboard>());
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            return keyboard.GetButtonState(control);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            keyboard.SetButtonState(control, state);
        }

        public static implicit operator InputDevice(GlobalKeyboard keyboard)
        {
            return keyboard.keyboard;
        }

        public static implicit operator Keyboard(GlobalKeyboard keyboard)
        {
            return keyboard.keyboard;
        }

        public static implicit operator Entity(GlobalKeyboard keyboard)
        {
            return keyboard.keyboard;
        }
    }
}