using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    public class Point
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

        internal void Hide()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void Move(Directions directions)
        {
            switch (directions)
            {
                case (Directions.DOWN):
                {
                        y++;
                        break;
                }
                case (Directions.LEFT):
                    {
                        x--;
                        break;
                    }
                case (Directions.RIGHT):
                    {
                        x++;
                        break;
                    }
            }
        }
    }
}
