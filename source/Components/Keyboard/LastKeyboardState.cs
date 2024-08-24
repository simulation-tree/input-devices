namespace InputDevices.Components
{
    public struct LastKeyboardState
    {
        public KeyboardState value;

        public LastKeyboardState(KeyboardState value)
        {
            this.value = value;
        }
    }
}
