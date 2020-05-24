using Microsoft.VisualBasic;
using System;
using System.Globalization;

namespace OTus_Tetris
{
    static class Field
    {
        private static int _width = 20;
        private static int _height = 40;
        private static bool[][] _heap;

        public static int Width
        {
            get
            {
                return _width;
            }
        }
        public static int Height
        {
            get
            {
                return _height;
            }
        }

        public static void SetWindowGameSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        internal static void TryDeleteLine()
        {
            for (int i = 0; i < Height; i++)
            {
                int counter = 0;
                for (int j = 0; j < Width; j++)
                {
                    if (_heap[i][j]) counter++;
                }
                if (counter == Field.Width)
                {
                    DeleteLine(i);
                    Redraw();
                }
            }
        }

        private static void Redraw()
        {
            for(int j = 0; j < Height; j++)
            {
                for(int i = 0; i < Width; i++)
                {
                    if (_heap[j][i])
                        DrawerProvider.Drawer.DrawPoint(i, j);
                    else
                        DrawerProvider.Drawer.HidePoint(i, j);
                }
            }
        }

        internal static void DeleteLine(int line)
        {
            for(int j = line; j >= 0; j--)
            {
                for(int i = 0; i < Width; i++)
                {
                    if (i == 0)
                        _heap[j][i] = false;
                    else
                        _heap[j][i] = _heap[j - 1][i];
                }
            }
        }

        static Field()
        {
            _heap = new bool[Height][];
            for(int i = 0; i < Height; i++)
            {
                _heap[i] = new bool[Width];
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        public static void AddFigure(Point[] points)
        {
            foreach(var p in points)
            {
                _heap[p.Y][p.X] = true;
            }
        }
    }
}
