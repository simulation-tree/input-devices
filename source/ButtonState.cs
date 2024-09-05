using System;
using Unmanaged;

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
            USpan<char> buffer = stackalloc char[16];
            uint length = ToString(buffer);
            return new string(buffer.pointer, 0, (int)length);
        }

        public readonly uint ToString(USpan<char> buffer)
        {
            if (value == State.Released)
            {
                buffer[0] = 'R';
                buffer[1] = 'e';
                buffer[2] = 'l';
                buffer[3] = 'e';
                buffer[4] = 'a';
                buffer[5] = 's';
                buffer[6] = 'e';
                buffer[7] = 'd';
                return 8;
            }
            else if (value == State.WasPressed)
            {
                buffer[0] = 'W';
                buffer[1] = 'a';
                buffer[2] = 's';
                buffer[3] = 'P';
                buffer[4] = 'r';
                buffer[5] = 'e';
                buffer[6] = 's';
                buffer[7] = 's';
                buffer[8] = 'e';
                buffer[9] = 'd';
                return 10;
            }
            else if (value == State.Held)
            {
                buffer[0] = 'H';
                buffer[1] = 'e';
                buffer[2] = 'l';
                buffer[3] = 'd';
                return 4;
            }
            else
            {
                buffer[0] = 'W';
                buffer[1] = 'a';
                buffer[2] = 's';
                buffer[3] = 'R';
                buffer[4] = 'e';
                buffer[5] = 'l';
                buffer[6] = 'e';
                buffer[7] = 'a';
                buffer[8] = 's';
                buffer[9] = 'e';
                buffer[10] = 'd';
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
            return HashCode.Combine(value);
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
