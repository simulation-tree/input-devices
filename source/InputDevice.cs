using InputDevices.Components;
using System;
using Worlds;

namespace InputDevices
{
    public readonly partial struct InputDevice : IEntity
    {
        public readonly TimeSpan LastUpdateTime => GetComponent<LastDeviceUpdateTime>().value;

        public InputDevice(World world)
        {
            this.world = world;
            value = world.CreateEntity(new LastDeviceUpdateTime());
        }

        readonly void IEntity.Describe(ref Archetype archetype)
        {
            archetype.AddComponentType<LastDeviceUpdateTime>();
        }

        public readonly void SetUpdateTime(TimeSpan timestamp)
        {
            ref LastDeviceUpdateTime state = ref GetComponent<LastDeviceUpdateTime>();
            state.value = timestamp;
        }
    }
}
