using InputDevices.Components;
using Simulation;
using System;
using System.Numerics;
using Unmanaged;

namespace InputDevices
{
    public readonly struct Mouse : IMouse
    {
        public readonly InputDevice device;

        public readonly Vector2 Position
        {
            get
            {
                ref IsMouse state = ref device.entity.GetComponentRef<IsMouse>();
                return state.Position;
            }
            set
            {
                ref IsMouse state = ref device.entity.GetComponentRef<IsMouse>();
                state.Position = value;
            }
        }

        public readonly Vector2 Scroll
        {
            get
            {
                ref IsMouse state = ref device.entity.GetComponentRef<IsMouse>();
                return state.Scroll;
            }
            set
            {
                ref IsMouse state = ref device.entity.GetComponentRef<IsMouse>();
                state.Scroll = value;
            }
        }

        uint IEntity.Value => device.entity.value;
        World IEntity.World => device.entity.world;
        Definition IEntity.Definition => new([RuntimeType.Get<IsMouse>(), RuntimeType.Get<LastMouseState>()], []);

#if NET
        [Obsolete("Default constructor not available", true)]
        public Mouse()
        {
            throw new InvalidOperationException("Cannot create a mouse without a world.");
        }
#endif

        public Mouse(World world, uint existingEntity)
        {
            device = new(world, existingEntity);
        }

        public Mouse(World world)
        {
            device = new(world);
            device.entity.AddComponent(new IsMouse());
            device.entity.AddComponent(new LastMouseState());
        }

        readonly ButtonState IInputDevice.GetButtonState(uint control)
        {
            MouseState state = device.entity.GetComponentRef<IsMouse>().state;
            MouseState lastState = device.entity.GetComponentRef<LastMouseState>().value;
            return new ButtonState(state[control], lastState[control]);
        }

        readonly void IInputDevice.SetButtonState(uint control, ButtonState state)
        {
            ref IsMouse currentState = ref device.entity.GetComponentRef<IsMouse>();
            ref LastMouseState lastState = ref device.entity.GetComponentRef<LastMouseState>();
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
