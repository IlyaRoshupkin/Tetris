using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OTus_Tetris
{
    class Stick : Figure
    {
        
        public Stick(int x, int y)
        {
            Points[0] = new Point(x, y);
            Points[1] = new Point(x, y + 1);
            Points[2] = new Point(x, y + 2);
            Points[3] = new Point(x, y + 3);
            Draw();
        }
        

        public override void Rotate()
        {
            if (Points[0].X == Points[3].X)
            {
                SetHorizontally(Points);
            }
            else
            {
                SetVertically(Points);
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
