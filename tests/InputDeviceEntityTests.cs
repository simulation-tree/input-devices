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

            Assert.That(keyboard.Is(), Is.True);
        }

        [Test]
        public void CheckIfMouseIsItself()
        {
            using World world = CreateWorld();
            Mouse mouse = new(world);

            Assert.That(mouse.Is(), Is.True);
        }
    }
}