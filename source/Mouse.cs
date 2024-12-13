using InputDevices.Components;
using System;
using System.Numerics;
using Worlds;

namespace InputDevices
{
    public readonly struct Mouse : IMouse
    {
        private readonly InputDevice device;

        public readonly ref Vector2 Position
        {
            get
            {
                ref IsMouse state = ref device.AsEntity().GetComponent<IsMouse>();
                return ref state.Position;
            }
        }

        public readonly ref Vector2 Scroll
        {
            get
            {
                ref IsMouse state = ref device.AsEntity().GetComponent<IsMouse>();
                return ref state.Scroll;
            }
        }

        public readonly ref MouseState State => ref device.AsEntity().GetComponent<IsMouse>().state;
        public readonly ref MouseState LastState => ref device.AsEntity().GetComponent<LastMouseState>().value;

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
            ref MouseState state = ref State;
            ref MouseState lastState = ref LastState;
            return new ButtonState(state[control], lastState[control]);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            ref MouseState currentState = ref State;
            ref MouseState lastState = ref LastState;
            if (state.value == ButtonState.State.Held)
            {
                currentState[control] = true;
                lastState[control] = true;
            }
            else if (state.value == ButtonState.State.WasPressed)
            {
                currentState[control] = true;
                lastState[control] = false;
            }
            else if (state.value == ButtonState.State.WasReleased)
            {
                currentState[control] = false;
                lastState[control] = true;
            }
            else
            {
                currentState[control] = false;
                lastState[control] = false;
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
