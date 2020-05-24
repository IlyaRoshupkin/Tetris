using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;          
        }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }

        public void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X, Y);
        }

        internal void Hide()
        {
            DrawerProvider.Drawer.HidePoint(X, Y);
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
