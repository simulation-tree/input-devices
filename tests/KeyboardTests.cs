using Worlds;

namespace InputDevices.Tests
{
    public class KeyboardTests : InputDeviceTests
    {
        [Test]
        public void VerifyCompliance()
        {
            using World world = CreateWorld();
            Keyboard keyboard = new(world);

            Assert.That(keyboard.IsCompliant, Is.True);
        }
    }
}