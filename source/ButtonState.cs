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

        public readonly override string ToString()
        {
            Span<char> buffer = stackalloc char[16];
            int length = ToString(buffer);
            return new string(buffer[..length]);
        }

        public readonly int ToString(Span<char> buffer)
        {
            if (value == State.Released)
            {
                "Released".CopyTo(buffer);
                return 8;
            }
            else if (value == State.WasPressed)
            {
                "WasPressed".CopyTo(buffer);
                return 10;
            }
            else if (value == State.Held)
            {
                "Held".CopyTo(buffer);
                return 4;
            }
            else
            {
                "WasReleased".CopyTo(buffer);
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
