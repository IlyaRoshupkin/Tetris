using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    public abstract class Figure
    {

        protected Point[] points = new Point[4];

        public void Draw()
        {
            foreach (Point p in points) p.Draw();
        }

        public void Hide()
        {
            foreach (Point p in points) p.Hide();
        }

        public void Move(Directions directions)
        {
            foreach(Point p in points)
            {
                p.Move(directions);
            }
        }

        
        public abstract void Rotate();
    }
}
