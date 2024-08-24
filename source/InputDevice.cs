using InputDevices.Components;
using Simulation;
using System;
using Unmanaged;

namespace InputDevices
{
    public readonly struct InputDevice : IEntity, IDisposable
    {
        private readonly Entity entity;

        World IEntity.World => entity;
        eint IEntity.Value => entity;

#if NET
        [Obsolete("Default constructor not available", true)]
        public InputDevice()
        {
            throw new InvalidOperationException("Cannot create an input device without a world.");
        }
#endif

        public InputDevice(World world, eint existingEntity)
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

        Query IEntity.GetQuery(World world)
        {
            return new Query(world, RuntimeType.Get<LastDeviceUpdateTime>());
        }

        public readonly void SetUpdateTime(TimeSpan timestamp)
        {
            ref LastDeviceUpdateTime state = ref entity.GetComponent<LastDeviceUpdateTime>();
            state.value = timestamp;
        }

        public static implicit operator Entity(InputDevice device)
        {
            return device.entity;
        }
    }
}
