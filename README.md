# Input Devices
Abstraction of common input devices.

### Global keyboard and mouse
The `Keyboard` and `Mouse` entities are automatically created by implementation systems, and they're
implemented as singletons. They can be used without windows or other systems.

```cs
using World world = new();
if (Entity.TryGetFirst(world, out Keyboard keyboard))
{
    if (keyboard.IsPressed(Keyboard.Button.G))
    {
        //g is held
    }
    else if (keyboard.WasPressed(Keyboard.Button.Escape))
    {
        //escape was pressed
    }
}

if (Entity.TryGetFirst(world, out Mouse mouse))
{
    Vector2 position = mouse.Position;
    Vector2 scroll = mouse.Scroll;
}
```