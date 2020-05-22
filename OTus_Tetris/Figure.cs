using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace OTus_Tetris
{
    public abstract class Figure
    {
        public const int LENGHT = 4;
        public Point[] Points = new Point[LENGHT];
        

        public void Draw()
        {
            foreach (Point p in Points) p.Draw();
        }

        public void Hide()
        {
            foreach (Point p in Points) p.Hide();
        }

        internal Result TryRotate()
        {
            Hide();

            Rotate();

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
            {
                Rotate();
            }

            Draw();
            return result;
        }

        public abstract void Rotate();

        internal Result TryMove(Directions dir)
        {
            Hide();
            
            Move(dir);

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
            {
                Move(Reverse(dir));
            }

            Draw();
            return result;
        }

        private Directions Reverse(Directions dir)
        {
            switch (dir)
            {
                case Directions.LEFT: return Directions.RIGHT;
                case Directions.RIGHT: return Directions.LEFT;
               case Directions.DOWN: return Directions.UP;
                default: return Directions.DOWN;
            }
        }

        public Result VerifyPosition()
        {
            foreach (var p in Points)
            {
                if (p.X < 0 || p.X >= Field.Width ||
                    p.Y < 0)
                {
                    return Result.BORDER_STRIKE;
                }
                if (p.Y >= Field.Height)
                {
                    return Result.DOWN_BORDER_STRIKE;
                }
                if (Field.CheckStrike(p))
                {
                    return Result.HEAP_STRIKE;
                }
            }
                return Result.SUCCESS;
        }

       

        private void Move(Directions dir)
        {
            foreach(var p in Points)
            {
                p.Move(dir);
            }
        }
        
        

        internal bool IsOnTop()
        {
            return Points[0].Y == 0;
        }
    }
}
