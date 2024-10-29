using InputDevices.Components;
using Simulation;
using System;
using Unmanaged;

namespace InputDevices
{
    public readonly struct GlobalKeyboard : IKeyboard
    {
        public readonly Keyboard keyboard;

        readonly World IEntity.World => keyboard.GetWorld();
        readonly uint IEntity.Value => keyboard.GetEntityValue();
        readonly Definition IEntity.Definition => new([RuntimeType.Get<IsKeyboard>(), RuntimeType.Get<IsGlobal>()], []);

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
            keyboard.AddComponent(new IsGlobal());
        }

        public readonly void Dispose()
        {
            keyboard.Dispose();
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            return keyboard.GetButtonState(control);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            keyboard.SetButtonState(control, state);
        }
    }
}