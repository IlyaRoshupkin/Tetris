using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    static class Field
    {
        private static int _width = 40;
        public const int HEIGHT = 30;

        public static int GetValue()
        {
            return _width;
        }

        public static void SetWidth(int value)
        {
            _width = value;
            Console.SetWindowSize(_width, Field.HEIGHT);
            Console.SetBufferSize(_width, Field.HEIGHT);
        }
    }
}
