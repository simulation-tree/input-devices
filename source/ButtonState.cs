using System;

namespace InputDevices
{
    public readonly struct ButtonState : IEquatable<ButtonState>
    {
        public readonly State value;

        public readonly bool WasPressed => value == State.WasPressed;
        public readonly bool Held => value == State.Held;
        public readonly bool WasReleased => value == State.WasReleased;
        public readonly bool IsPressed => value == State.Held || value == State.WasPressed;
        public readonly bool IsReleased => value == State.Released || value == State.WasReleased;

        public ButtonState(State state)
        {
            this.value = state;
        }

        public ButtonState(bool previousState, bool currentState)
        {
            if (previousState && currentState)
            {
                value = State.Held;
            }
            else if (!previousState && currentState)
            {
                value = State.WasPressed;
            }
            else if (previousState && !currentState)
            {
                value = State.WasReleased;
            }
            else
            {
                value = State.Released;
            }
        }

        public unsafe readonly override string ToString()
        {
            Span<char> buffer = stackalloc char[16];
            int length = ToString(buffer);
            return buffer.Slice(0, length).ToString();
        }

        public readonly int ToString(Span<char> destination)
        {
            if (value == State.Released)
            {
                destination[0] = 'R';
                destination[1] = 'e';
                destination[2] = 'l';
                destination[3] = 'e';
                destination[4] = 'a';
                destination[5] = 's';
                destination[6] = 'e';
                destination[7] = 'd';
                return 8;
            }
            else if (value == State.WasPressed)
            {
                destination[0] = 'W';
                destination[1] = 'a';
                destination[2] = 's';
                destination[3] = 'P';
                destination[4] = 'r';
                destination[5] = 'e';
                destination[6] = 's';
                destination[7] = 's';
                destination[8] = 'e';
                destination[9] = 'd';
                return 10;
            }
            else if (value == State.Held)
            {
                destination[0] = 'H';
                destination[1] = 'e';
                destination[2] = 'l';
                destination[3] = 'd';
                return 4;
            }
            else
            {
                destination[0] = 'W';
                destination[1] = 'a';
                destination[2] = 's';
                destination[3] = 'R';
                destination[4] = 'e';
                destination[5] = 'l';
                destination[6] = 'e';
                destination[7] = 'a';
                destination[8] = 's';
                destination[9] = 'e';
                destination[10] = 'd';
                return 11;
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is ButtonState state && Equals(state);
        }

        public bool Equals(ButtonState other)
        {
            return value == other.value;
        }

        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public enum State : byte
        {
            Released,
            WasPressed,
            Held,
            WasReleased
        }

        public static bool operator ==(ButtonState left, ButtonState right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ButtonState left, ButtonState right)
        {
            return !(left == right);
        }
    }
}
