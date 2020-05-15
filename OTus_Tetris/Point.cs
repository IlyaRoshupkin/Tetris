using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    class Point
    {
        public int x;
        public int y;
        public char c;
        

        public Point(int x, int y, char c)
        {
            this.x = x;
            this.y = y;
            this.c = c;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(c);
        }
    }
}
