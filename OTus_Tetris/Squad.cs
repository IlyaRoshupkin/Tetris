using System;
using System.Collections.Generic;
using System.Text;

namespace OTus_Tetris
{
    class Squad
    {
        string blocks;
        int size;
        int x; int y;
        string[][] fig;

        public Squad(int size, int x, int y, string blocks)
        {
            this.blocks = blocks;
            this.size = size;
            fig = new string[size][];
            for (int i = 0; i < fig.Length; i++)
            {
                fig[i] = new string[size];
                for (int j = 0; j < fig[i].Length; j++)
                {
                    fig[i][j] = blocks;
                }
            }
            this.x = x; this.y = y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);

            int counts = 0;
            foreach (string[] arr in fig)
            {
                foreach (string sq in arr)
                {
                    Console.Write(sq);
                    counts++;
                    if (counts == size)
                    {
                        counts = 0;
                        Console.SetCursorPosition(x, ++y);
                    }
                }
            }
        }
    }
}
