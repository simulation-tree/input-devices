using Worlds;

namespace InputDevices.Tests
{
    public class InputDeviceEntityTests : InputDeviceTests
    {
        [Test]
        public void CheckIfKeyboardIsItself()
        {
            using World world = CreateWorld();
            Keyboard keyboard = new(world);
        }
    }
}