using InputDevices.Components;
using Worlds;

namespace InputDevices
{
    public readonly partial struct InputDevice : IEntity
    {
        public readonly double LastUpdateTime => GetComponent<LastDeviceUpdateTime>().time;

        public InputDevice(World world)
        {
            this.world = world;
            value = world.CreateEntity(new LastDeviceUpdateTime());
        }

        readonly void IEntity.Describe(ref Archetype archetype)
        {
            archetype.AddComponentType<LastDeviceUpdateTime>();
        }

        public readonly void SetUpdateTime(double timestamp)
        {
            ref LastDeviceUpdateTime state = ref GetComponent<LastDeviceUpdateTime>();
            state.time = timestamp;
        }
    }
}
