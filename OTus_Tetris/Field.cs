using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    static class Field
    {
        public static int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
                SetWindowGameSize(_width, Field.Height);
            }
        }
        public static int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                SetWindowGameSize(Field.Width, _height);
            }
        }

        public static void SetWindowGameSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }
        private static int _width = 40;
        private static int _height = 30;
    }
}
