using System;

namespace OTus_Tetris
{
    public static class Drawer
    {
        public const char DEFAULT_SYMBOL = '*';

        public static void DrawPoint(int x, int y, char sym = DEFAULT_SYMBOL)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
            Console.SetCursorPosition(0, 0);
        }

        internal static void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }
    }
}