﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    class Squad : Figure
    {
        public Squad(int x, int y)
        {
            Points[0] = new Point(x, y);
            Points[1] = new Point(x + 1, y);
            Points[2] = new Point(x, y + 1);
            Points[3] = new Point(x+1, y+1);
            Draw();
        }

        public override void Rotate() { }
    }
}
