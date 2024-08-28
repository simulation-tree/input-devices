# Input Devices
Abstraction of common input devices.

### Keyboard and mice
The `Keyboard` and `Mouse` entities are automatically created by implementation systems. They represent devices for the currently focused window:

```cs
using World world = new();
while (true)
{
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
}
```

### Global keyboard and mouse
In addition to the above, there are `GlobalKeyboard` and `GlobalMouse` entities that must be created manually. These receive inputs regardless of windowing focus, and are useful for implementing global hotkeys:
```cs
using World world = new();
GlobalKeyboard globalKeyboard = new(world);
while (true)
{
    if (globalKeyboard.IsPressed(Keyboard.Button.G))
    {
        //g is held
    }
    else if (globalKeyboard.WasPressed(Keyboard.Button.Escape))
    {
        //escape was pressed
    }
}
```
> Both of these device entities can be implictly cast to `Keyboard` and `Mouse` respectively.