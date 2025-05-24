using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace InputDevices
{
    public struct KeyboardState
    {
        public const uint MaxKeyCount = 320;

        private Buffer keys;

        public bool this[int index]
        {
            get => IsKeyDown(index);
            set => SetKeyDown(index, value);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                for (int i = 0; i < 5; i++)
                {
                    hash = hash * 23 + keys[i].GetHashCode();
                }

                return hash;
            }
        }

        public readonly bool IsKeyDown(int index)
        {
            ThrowIfOutOfRange(index);

            int arrayIndex = index >> 6;
            int bitIndex = index & 63;
            ulong mask = 1UL << bitIndex;
            return (keys[arrayIndex] & mask) != 0;
        }

        public void SetKeyDown(int index, bool value)
        {
            ThrowIfOutOfRange(index);

            int arrayIndex = index >> 6;
            int bitIndex = index & 63;
            ulong mask = 1UL << bitIndex;
            if (value)
            {
                keys[arrayIndex] |= mask;
            }
            else
            {
                keys[arrayIndex] &= ~mask;
            }
        }

        [Conditional("DEBUG")]
        private static void ThrowIfOutOfRange(int index)
        {
            if (index >= MaxKeyCount)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
        }

#if NET
        [InlineArray(5)]
        private struct Buffer
        {
            private ulong element0;
        }
#else
        private unsafe struct Buffer
        {
            private fixed ulong buffer[5];

            public ulong this[int index]
            {
                get => buffer[index];
                set => buffer[index] = value;
            }
        }
#endif
    }
}
