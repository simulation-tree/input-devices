using InputDevices.Components;
using System;
using Worlds;

namespace InputDevices
{
    public readonly struct InputDevice : IEntity
    {
        private readonly Entity entity;

        readonly World IEntity.World => entity.GetWorld();
        readonly uint IEntity.Value => entity.GetEntityValue();

        readonly Definition IEntity.GetDefinition(Schema schema)
        {
            return new Definition().AddComponentType<LastDeviceUpdateTime>(schema);
        }

#if NET
        [Obsolete("Default constructor not available", true)]
        public InputDevice()
        {
            throw new InvalidOperationException("Cannot create an input device without a world.");
        }
#endif

        public InputDevice(World world, uint existingEntity)
        {
            entity = new(world, existingEntity);
        }

        public InputDevice(World world)
        {
            entity = new(world);
            entity.AddComponent(new LastDeviceUpdateTime());
        }

        public readonly void Dispose()
        {
            entity.Dispose();
        }

        public readonly void SetUpdateTime(TimeSpan timestamp)
        {
            ref LastDeviceUpdateTime state = ref entity.GetComponent<LastDeviceUpdateTime>();
            state.value = timestamp;
        }
    }
}
