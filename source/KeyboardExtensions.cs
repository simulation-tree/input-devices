using InputDevices.Components;
using System;
using System.Diagnostics;

namespace InputDevices
{
    public static class KeyboardExtensions
    {
        private static readonly char[] controlsCharacters;

        static KeyboardExtensions()
        {
            controlsCharacters = new char[KeyboardState.MaxKeyCount];
            controlsCharacters[(int)Keyboard.Button.A] = 'a';
            controlsCharacters[(int)Keyboard.Button.B] = 'b';
            controlsCharacters[(int)Keyboard.Button.C] = 'c';
            controlsCharacters[(int)Keyboard.Button.D] = 'd';
            controlsCharacters[(int)Keyboard.Button.E] = 'e';
            controlsCharacters[(int)Keyboard.Button.F] = 'f';
            controlsCharacters[(int)Keyboard.Button.G] = 'g';
            controlsCharacters[(int)Keyboard.Button.H] = 'h';
            controlsCharacters[(int)Keyboard.Button.I] = 'i';
            controlsCharacters[(int)Keyboard.Button.J] = 'j';
            controlsCharacters[(int)Keyboard.Button.K] = 'k';
            controlsCharacters[(int)Keyboard.Button.L] = 'l';
            controlsCharacters[(int)Keyboard.Button.M] = 'm';
            controlsCharacters[(int)Keyboard.Button.N] = 'n';
            controlsCharacters[(int)Keyboard.Button.O] = 'o';
            controlsCharacters[(int)Keyboard.Button.P] = 'p';
            controlsCharacters[(int)Keyboard.Button.Q] = 'q';
            controlsCharacters[(int)Keyboard.Button.R] = 'r';
            controlsCharacters[(int)Keyboard.Button.S] = 's';
            controlsCharacters[(int)Keyboard.Button.T] = 't';
            controlsCharacters[(int)Keyboard.Button.U] = 'u';
            controlsCharacters[(int)Keyboard.Button.V] = 'v';
            controlsCharacters[(int)Keyboard.Button.W] = 'w';
            controlsCharacters[(int)Keyboard.Button.X] = 'x';
            controlsCharacters[(int)Keyboard.Button.Y] = 'y';
            controlsCharacters[(int)Keyboard.Button.Z] = 'z';
            controlsCharacters[(int)Keyboard.Button.Digit1] = '1';
            controlsCharacters[(int)Keyboard.Button.Digit2] = '2';
            controlsCharacters[(int)Keyboard.Button.Digit3] = '3';
            controlsCharacters[(int)Keyboard.Button.Digit4] = '4';
            controlsCharacters[(int)Keyboard.Button.Digit5] = '5';
            controlsCharacters[(int)Keyboard.Button.Digit6] = '6';
            controlsCharacters[(int)Keyboard.Button.Digit7] = '7';
            controlsCharacters[(int)Keyboard.Button.Digit8] = '8';
            controlsCharacters[(int)Keyboard.Button.Digit9] = '9';
            controlsCharacters[(int)Keyboard.Button.Digit0] = '0';
            controlsCharacters[(int)Keyboard.Button.Enter] = '\n';
            controlsCharacters[(int)Keyboard.Button.Escape] = '\e';
            controlsCharacters[(int)Keyboard.Button.Backspace] = '\b';
            controlsCharacters[(int)Keyboard.Button.Tab] = '\t';
            controlsCharacters[(int)Keyboard.Button.Space] = ' ';
            controlsCharacters[(int)Keyboard.Button.Minus] = '-';
            controlsCharacters[(int)Keyboard.Button.Equals] = '=';
            controlsCharacters[(int)Keyboard.Button.LeftBracket] = '[';
            controlsCharacters[(int)Keyboard.Button.RightBracket] = ']';
            controlsCharacters[(int)Keyboard.Button.Backslash] = '\\';
            controlsCharacters[(int)Keyboard.Button.Semicolon] = ';';
            controlsCharacters[(int)Keyboard.Button.Apostrophe] = '\'';
            controlsCharacters[(int)Keyboard.Button.Grave] = '`';
            controlsCharacters[(int)Keyboard.Button.Comma] = ',';
            controlsCharacters[(int)Keyboard.Button.Period] = '.';
            controlsCharacters[(int)Keyboard.Button.Slash] = '/';
            controlsCharacters[(int)Keyboard.Button.LeftShift] = (char)14;
            controlsCharacters[(int)Keyboard.Button.Left] = (char)17;
            controlsCharacters[(int)Keyboard.Button.Right] = (char)18;
            controlsCharacters[(int)Keyboard.Button.Up] = (char)19;
            controlsCharacters[(int)Keyboard.Button.Down] = (char)20;
            controlsCharacters[(int)Keyboard.Button.Home] = (char)2;
            controlsCharacters[(int)Keyboard.Button.End] = (char)3;
            controlsCharacters[(int)Keyboard.Button.LeftControl] = (char)29;
        }

        public static char GetCharacter(this Keyboard.Button button)
        {
            ThrowIfKeyboardButtonIsUnknown(button);
            return controlsCharacters[(int)button];
        }

        [Conditional("DEBUG")]
        private static void ThrowIfKeyboardButtonIsUnknown(Keyboard.Button button)
        {
            int index = (int)button;
            if (index < 0 || index >= controlsCharacters.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(button), button, $"Unknown keyboard button {button}");
            }
        }
    }
}