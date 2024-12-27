using InputDevices.Components;
using System;
using System.Diagnostics;
using Worlds;

namespace InputDevices
{
    public readonly struct GlobalKeyboard : IKeyboard
    {
        private readonly Keyboard keyboard;

        readonly World IEntity.World => keyboard.GetWorld();
        readonly uint IEntity.Value => keyboard.GetEntityValue();

        readonly Definition IEntity.GetDefinition(Schema schema)
        {
            return Definition.Get<Keyboard>(schema).AddComponentType<IsGlobal>(schema);
        }

#if NET
        [Obsolete("Default constructor not available", true)]
        public GlobalKeyboard()
        {
            throw new InvalidOperationException("Cannot create a global keyboard without a world");
        }
#endif

        public GlobalKeyboard(World world, uint existingEntity)
        {
            ThrowIfInstanceAlreadyExists(world);
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

        [Conditional("DEBUG")]
        private static void ThrowIfInstanceAlreadyExists(World world)
        {
            if (world.TryGetFirst(out GlobalKeyboard _))
            {
                throw new InvalidOperationException($"There can only be one `{nameof(GlobalKeyboard)}` instance");
            }
        }

        public static implicit operator Keyboard(GlobalKeyboard globalKeyboard)
        {
            return globalKeyboard.keyboard;
        }

        public static implicit operator InputDevice(GlobalKeyboard globalKeyboard)
        {
            return globalKeyboard.keyboard;
        }

        public static implicit operator Entity(GlobalKeyboard globalKeyboard)
        {
            return globalKeyboard.keyboard;
        }
    }
}