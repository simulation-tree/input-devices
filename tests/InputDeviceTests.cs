using Types;
using Worlds;
using Worlds.Tests;

namespace InputDevices.Tests
{
    public abstract class InputDeviceTests : WorldTests
    {
        static InputDeviceTests()
        {
            MetadataRegistry.Load<InputDevicesMetadataBank>();
        }

        protected override Schema CreateSchema()
        {
            Schema schema = base.CreateSchema();
            schema.Load<InputDevicesSchemaBank>();
            return schema;
        }
    }
}