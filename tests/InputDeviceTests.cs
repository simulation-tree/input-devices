using Types;
using Worlds;
using Worlds.Tests;

namespace InputDevices.Tests
{
    public abstract class InputDeviceTests : WorldTests
    {
        static InputDeviceTests()
        {
            TypeRegistry.Load<InputDevices.TypeBank>();
        }

        protected override Schema CreateSchema()
        {
            Schema schema = base.CreateSchema();
            schema.Load<InputDevices.SchemaBank>();
            return schema;
        }
    }
}