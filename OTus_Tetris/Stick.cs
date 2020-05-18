using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OTus_Tetris
{
    class Stick : Figure
    {
        
        public Stick(int x, int y,char sym)
        {
            points[0] = new Point(x, y, sym);
            points[1] = new Point(x, y + 1, sym);
            points[2] = new Point(x, y + 2, sym);
            points[3] = new Point(x, y + 3, sym);
            Draw();
        }
        public override void TryRotate()
        {
            Hide();
            var clone = Clone();
            Rotate(clone);

            if (VerifyPosition(clone))
            {
                points = clone;
            }

            Draw();
        }

        public void Rotate(Point[] PList)
        {
            if (PList[0].X == PList[3].X)
            {
                SetHorizontally(PList);
            }
            else
            {
                SetVertically(PList);
            }
        }

        private void SetVertically(Point[] PList)
        {
            for(int i = 0; i < PList.Length; i++)
            {
                PList[i].X -= i;
                PList[i].Y += i;
            }
        }

        private void SetHorizontally(Point[] PList)
        {
            for(int i = 0; i < PList.Length; i ++)
            {
                PList[i].X += i;
                PList[i].Y -= i;
            }
            
        }
    }
}
