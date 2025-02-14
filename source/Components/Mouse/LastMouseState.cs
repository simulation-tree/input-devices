namespace InputDevices.Components
{
    public struct LastMouseState
    {
        public MouseState value;

        public LastMouseState(MouseState value)
        {
            this.value = value;
        }
    }
}
