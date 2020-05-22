using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }

        public Point(int x, int y, char c)
        {
            X = x;
            Y = y;
            C = c;
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
            C = point.C;
        }

        public void Draw()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(C);
            Console.SetCursorPosition(0, 0);
        }

        internal void Hide()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }

        public void Move(Directions directions)
        {
            switch (directions)
            {
                case (Directions.UP):
                {
                        Y--;
                        break;
                }
                case (Directions.DOWN):
                {
                        Y++;
                        break;
                }
                case (Directions.LEFT):
                {
                        X--;
                        break;
                }
                case (Directions.RIGHT):
                {
                        X++;
                        break;
                }
            }
        }
    }
}
