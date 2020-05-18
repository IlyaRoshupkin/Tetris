using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    public abstract class Figure
    {
        public const int LENGHT = 4;
        protected Point[] points = new Point[LENGHT];

        public void Draw()
        {
            foreach (Point p in points) p.Draw();
        }

        public void Hide()
        {
            foreach (Point p in points) p.Hide();
        }
        
        internal void TryMove(Directions dir)
        {
            Hide();
            var clone = Clone();
            Move(clone, dir);

            if (VerifyPosition(clone))
            {
                points = clone;
            }

            Draw();
        }

        protected bool VerifyPosition(Point[] clone)
        {
            foreach (var p in clone)
            {
                if (p.X < 0 || p.X >= Field.Width ||
                    p.Y < 0 || p.Y >= Field.Height)
                    return false;
            }
                return true;
        }

        protected Point[] Clone()
        {
            var newPoints = new Point[LENGHT];
            for(int i =0; i < newPoints.Length; i++)
            {
                newPoints[i] = new Point(points[i]);
            }
            return newPoints;
        }

        private void Move(Point[] pList, Directions dir)
        {
            foreach(var p in pList)
            {
                p.Move(dir);
            }
        }
        

        
        public abstract void TryRotate();

        
    }
}
