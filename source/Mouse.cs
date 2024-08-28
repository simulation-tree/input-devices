using InputDevices.Components;
using Simulation;
using System;
using System.Numerics;
using Unmanaged;

namespace InputDevices
{
    public readonly struct Mouse : IMouse
    {
        private readonly InputDevice device;

        public readonly Vector2 Position
        {
            get
            {
                ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
                return state.Position;
            }
            set
            {
                ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
                state.Position = value;
            }
        }

        public readonly Vector2 Scroll
        {
            get
            {
                ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
                return state.Scroll;
            }
            set
            {
                ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
                state.Scroll = value;
            }
        }

        World IEntity.World => (Entity)device;
        eint IEntity.Value => (Entity)device;

#if NET
        [Obsolete("Default constructor not available", true)]
        public Mouse()
        {
            throw new InvalidOperationException("Cannot create a mouse without a world.");
        }
#endif

        public Mouse(World world, eint existingEntity)
        {
            device = new(world, existingEntity);
        }

        public Mouse(World world)
        {
            device = new(world);
            Entity entity = device;
            entity.AddComponent(new IsMouse());
            entity.AddComponent(new LastMouseState());
        }

        Query IEntity.GetQuery(World world)
        {
            return new Query(world, RuntimeType.Get<IsMouse>());
        }

        public readonly void SetPosition(Vector2 position, TimeSpan timestamp)
        {
            ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
            state.Position = position;

            device.SetUpdateTime(timestamp);
        }

        public readonly void AddScroll(Vector2 scroll, TimeSpan timestamp)
        {
            ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
            state.Scroll = scroll;

            device.SetUpdateTime(timestamp);
        }

        public readonly bool IsButtonDown(uint control)
        {
            ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
            return state.state[control];
        }

        public readonly void SetButtonDown(uint control, bool pressed, TimeSpan timestamp)
        {
            ref IsMouse state = ref ((Entity)device).GetComponent<IsMouse>();
            state.state[control] = pressed;

            device.SetUpdateTime(timestamp);
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            Entity entity = device;
            MouseState state = entity.GetComponent<IsMouse>().state;
            MouseState lastState = entity.GetComponent<LastMouseState>().value;
            return new ButtonState(state[control], lastState[control]);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            Entity entity = device;
            ref IsMouse currentState = ref entity.GetComponent<IsMouse>();
            ref LastMouseState lastState = ref entity.GetComponent<LastMouseState>();
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
            return mouse.device;
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
