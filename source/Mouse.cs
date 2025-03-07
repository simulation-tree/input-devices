using InputDevices.Components;
using System.Numerics;
using Worlds;

namespace InputDevices
{
    public readonly partial struct Mouse : IMouse
    {
        public readonly ref Vector2 Position => ref GetComponent<IsMouse>().state.position;
        public readonly ref Vector2 Delta => ref GetComponent<IsMouse>().state.delta;
        public readonly ref Vector2 Scroll => ref GetComponent<IsMouse>().state.scroll;
        public readonly ref MouseState State => ref GetComponent<IsMouse>().state;
        public readonly ref MouseState LastState => ref GetComponent<LastMouseState>().value;

        public readonly Entity Window
        {
            get
            {
                ref IsMouse component = ref GetComponent<IsMouse>();
                uint windowEntity = GetReference(component.windowReference);
                return new Entity(world, windowEntity);
            }
            set
            {
                ref IsMouse component = ref GetComponent<IsMouse>();
                ref rint windowReference = ref component.windowReference;
                if (windowReference == default)
                {
                    windowReference = AddReference(value);
                }
                else
                {
                    uint windowEntity = GetReference(windowReference);
                    if (windowEntity != value.value)
                    {
                        SetReference(windowReference, value);
                    }
                    else
                    {
                        //same window
                    }
                }
            }
        }

        readonly void IEntity.Describe(ref Archetype archetype)
        {
            archetype.Add<InputDevice>();
            archetype.AddComponentType<IsMouse>();
            archetype.AddComponentType<LastMouseState>();
        }

        public Mouse(World world)
        {
            this.world = world;
            value = world.CreateEntity(new IsMouse(), new LastMouseState(), new LastDeviceUpdateTime());
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
            return mouse.As<InputDevice>();
        }

        public enum Button : byte
        {
            LeftButton = 1,
            MiddleButton = 2,
            RightButton = 3,
            ForwardButton = 4,
            BackButton = 5
        }

        public enum Cursor : byte
        {
            Default = 0,
            Text = 1,
            Wait = 2,
            Crosshair = 3,
            WaitWithArrow = 4,
            ResizeNWSE = 5,
            ResizeNESW = 6,
            ResizeHorizontal = 7,
            ResizeVertical = 8,
            ResizeAll = 9,
            NotAllowed = 10,
            Hand = 11,
            ResizeNW = 12,
            ResizeN = 13,
            ResizeNE = 14,
            ResizeE = 15,
            ResizeSE = 16,
            ResizeS = 17,
            ResizeSW = 18,
            ResizeW = 19
        }
    }
}