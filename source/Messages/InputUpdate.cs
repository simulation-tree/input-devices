namespace InputDevices.Messages
{
    public readonly struct InputUpdate
    {
        public readonly double deltaTime;

        public InputUpdate(double deltaTime)
        {
            this.deltaTime = deltaTime;
        }
    }
}
