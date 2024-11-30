using InputDevices.Components;
using System;
using System.Numerics;
using Worlds;

namespace InputDevices
{
    public readonly struct Mouse : IMouse
    {
        private readonly InputDevice device;

        public readonly Vector2 Position
        {
            get
            {
                ref IsMouse state = ref device.AsEntity().GetComponentRef<IsMouse>();
                return state.Position;
            }
            set
            {
                ref IsMouse state = ref device.AsEntity().GetComponentRef<IsMouse>();
                state.Position = value;
            }
        }

        public readonly Vector2 Scroll
        {
            get
            {
                ref IsMouse state = ref device.AsEntity().GetComponentRef<IsMouse>();
                return state.Scroll;
            }
            set
            {
                ref IsMouse state = ref device.AsEntity().GetComponentRef<IsMouse>();
                state.Scroll = value;
            }
        }

        readonly uint IEntity.Value => device.GetEntityValue();
        readonly World IEntity.World => device.GetWorld();
        readonly Definition IEntity.Definition => new Definition().AddComponentTypes<IsMouse, LastMouseState>();

#if NET
        [Obsolete("Default constructor not available", true)]
        public Mouse()
        {
            throw new NotSupportedException("Default constructor not available");
        }
#endif

        public Mouse(World world, uint existingEntity)
        {
            device = new(world, existingEntity);
        }

        public Mouse(World world)
        {
            device = new(world);
            device.AddComponent(new IsMouse());
            device.AddComponent(new LastMouseState());
        }

        public readonly void Dispose()
        {
            device.Dispose();
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            MouseState state = device.AsEntity().GetComponentRef<IsMouse>().state;
            MouseState lastState = device.AsEntity().GetComponentRef<LastMouseState>().value;
            return new ButtonState(state[control], lastState[control]);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            ref IsMouse currentState = ref device.AsEntity().GetComponentRef<IsMouse>();
            ref LastMouseState lastState = ref device.AsEntity().GetComponentRef<LastMouseState>();
            if (state.value == ButtonState.State.Held)
            {
                currentState.state[control] = true;
                lastState.value[control] = true;
            }
            else if (state.value == ButtonState.State.WasPressed)
            {
                currentState.state[control] = true;
                lastState.value[control] = false;
            }
            else if (state.value == ButtonState.State.WasReleased)
            {
                currentState.state[control] = false;
                lastState.value[control] = true;
            }
            else
            {
                currentState.state[control] = false;
                lastState.value[control] = false;
            }
        }

        public static implicit operator InputDevice(Mouse mouse)
        {
            return mouse.device;
        }

        public static implicit operator Entity(Mouse mouse)
        {
            return mouse.device.AsEntity();
        }

        public enum Button : byte
        {
            LeftButton = 1,
            MiddleButton = 2,
            RightButton = 3,
            ForwardButton = 4,
            BackButton = 5
        }
    }
}
