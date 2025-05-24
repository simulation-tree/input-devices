using InputDevices.Components;
using System;
using System.Diagnostics;
using Worlds;

namespace InputDevices
{
    public readonly partial struct GlobalKeyboard : IKeyboard
    {
        public GlobalKeyboard(World world)
        {
            ThrowIfInstanceAlreadyExists(world);

            this.world = world;
            value = world.CreateEntity(new IsKeyboard(), new LastDeviceUpdateTime());
            AddTag<IsGlobal>();
        }

        readonly void IEntity.Describe(ref Archetype archetype)
        {
            archetype.Add<Keyboard>();
            archetype.AddTagType<IsGlobal>();
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            return As<Keyboard>().GetButtonState(control);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            As<Keyboard>().SetButtonState(control, state);
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
            return globalKeyboard.As<Keyboard>();
        }

        public static implicit operator InputDevice(GlobalKeyboard globalKeyboard)
        {
            return globalKeyboard.As<InputDevice>();
        }
    }
}