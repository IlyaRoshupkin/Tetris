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
        }

        public override void Rotate()
        {
            if (points[0].x == points[3].x)
            {
                SetHorizontally();
            }
            else
            {
                SetVertically();
            }
        }

        private void SetVertically()
        {
            for(int i = 0; i < points.Length; i++)
            {
                points[i].x -= i;
                points[i].y += i;
            }
        }

        private void SetHorizontally()
        {
            for(int i = 0; i < points.Length; i ++)
            {
                points[i].x += i;
                points[i].y -= i;
            }
            
        }
    }
}
