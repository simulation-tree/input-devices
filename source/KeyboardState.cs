using System;
using System.Diagnostics;

namespace InputDevices
{
    public unsafe struct KeyboardState
    {
        public const uint MaxKeyCount = 320;

        private fixed ulong keys[5];

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
                for (uint i = 0; i < 5; i++)
                {
                    hash = hash * 23 + keys[i].GetHashCode();
                }

                return hash;
            }
        }

        public readonly bool IsKeyDown(int index)
        {
            ThrowIfOutOfRange(index);

            int arrayIndex = index / 64;
            int bitIndex = index % 64;
            ulong mask = 1UL << bitIndex;
            return (keys[arrayIndex] & mask) != 0;
        }

        public void SetKeyDown(int index, bool value)
        {
            ThrowIfOutOfRange(index);

            int arrayIndex = index / 64;
            int bitIndex = index % 64;
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
    }
}
