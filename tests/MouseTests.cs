using Worlds;

namespace InputDevices.Tests
{
    public class MouseTests : InputDeviceTests
    {
        [Test]
        public void VerifyCompliance()
        {
            using World world = CreateWorld();
            Mouse mouse = new(world);

            Assert.That(mouse.IsCompliant, Is.True);
        }
    }
}