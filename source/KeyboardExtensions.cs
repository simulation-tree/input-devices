using InputDevices;
using InputDevices.Components;

public static class KeyboardExtensions
{
    private static readonly char[] controlsChars;

    static KeyboardExtensions()
    {
        controlsChars = new char[KeyboardState.MaxKeyCount];
        controlsChars[(int)Keyboard.Button.A] = 'a';
        controlsChars[(int)Keyboard.Button.B] = 'b';
        controlsChars[(int)Keyboard.Button.C] = 'c';
        controlsChars[(int)Keyboard.Button.D] = 'd';
        controlsChars[(int)Keyboard.Button.E] = 'e';
        controlsChars[(int)Keyboard.Button.F] = 'f';
        controlsChars[(int)Keyboard.Button.G] = 'g';
        controlsChars[(int)Keyboard.Button.H] = 'h';
        controlsChars[(int)Keyboard.Button.I] = 'i';
        controlsChars[(int)Keyboard.Button.J] = 'j';
        controlsChars[(int)Keyboard.Button.K] = 'k';
        controlsChars[(int)Keyboard.Button.L] = 'l';
        controlsChars[(int)Keyboard.Button.M] = 'm';
        controlsChars[(int)Keyboard.Button.N] = 'n';
        controlsChars[(int)Keyboard.Button.O] = 'o';
        controlsChars[(int)Keyboard.Button.P] = 'p';
        controlsChars[(int)Keyboard.Button.Q] = 'q';
        controlsChars[(int)Keyboard.Button.R] = 'r';
        controlsChars[(int)Keyboard.Button.S] = 's';
        controlsChars[(int)Keyboard.Button.T] = 't';
        controlsChars[(int)Keyboard.Button.U] = 'u';
        controlsChars[(int)Keyboard.Button.V] = 'v';
        controlsChars[(int)Keyboard.Button.W] = 'w';
        controlsChars[(int)Keyboard.Button.X] = 'x';
        controlsChars[(int)Keyboard.Button.Y] = 'y';
        controlsChars[(int)Keyboard.Button.Z] = 'z';
        controlsChars[(int)Keyboard.Button.Digit1] = '1';
        controlsChars[(int)Keyboard.Button.Digit2] = '2';
        controlsChars[(int)Keyboard.Button.Digit3] = '3';
        controlsChars[(int)Keyboard.Button.Digit4] = '4';
        controlsChars[(int)Keyboard.Button.Digit5] = '5';
        controlsChars[(int)Keyboard.Button.Digit6] = '6';
        controlsChars[(int)Keyboard.Button.Digit7] = '7';
        controlsChars[(int)Keyboard.Button.Digit8] = '8';
        controlsChars[(int)Keyboard.Button.Digit9] = '9';
        controlsChars[(int)Keyboard.Button.Digit0] = '0';
        controlsChars[(int)Keyboard.Button.Enter] = '\n';
        controlsChars[(int)Keyboard.Button.Escape] = '\e';
        controlsChars[(int)Keyboard.Button.Backspace] = '\b';
        controlsChars[(int)Keyboard.Button.Tab] = '\t';
        controlsChars[(int)Keyboard.Button.Space] = ' ';
        controlsChars[(int)Keyboard.Button.Minus] = '-';
        controlsChars[(int)Keyboard.Button.Equals] = '=';
        controlsChars[(int)Keyboard.Button.LeftBracket] = '[';
        controlsChars[(int)Keyboard.Button.RightBracket] = ']';
        controlsChars[(int)Keyboard.Button.Backslash] = '\\';
        controlsChars[(int)Keyboard.Button.Semicolon] = ';';
        controlsChars[(int)Keyboard.Button.Apostrophe] = '\'';
        controlsChars[(int)Keyboard.Button.Grave] = '`';
        controlsChars[(int)Keyboard.Button.Comma] = ',';
        controlsChars[(int)Keyboard.Button.Period] = '.';
        controlsChars[(int)Keyboard.Button.Slash] = '/';
    }

    public static char GetChar(this Keyboard.Button button)
    {
        return controlsChars[(int)button];
    }
}