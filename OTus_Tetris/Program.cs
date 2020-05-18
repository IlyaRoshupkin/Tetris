using System;
using System.Drawing;
using System.Threading;

namespace OTus_Tetris
{
    class Program
    {


        static void Main(string[] args)
        {
            SetWindowGameSize(Field.Width, Field.Height);
        
            Field.Width = 100;
            Field.Height = 70;

            var generator = new FigureGenerator(20, 20, ')');
            Figure currentFigure = generator.GetNewFigure();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey();
                    WorksWithKey(currentFigure, key);
                }
            }
        }

        private static void SetWindowGameSize(int width, int height)
        {
            Console.SetWindowSize(width, height);
            Console.SetBufferSize(width, height);
        }

        private static void WorksWithKey(Figure currentFigure, ConsoleKeyInfo key)
        {
            switch (key.Key)
            {
                case ConsoleKey.RightArrow:
                    {
                        currentFigure.TryMove(Directions.RIGHT);
                        break;
                    }
                case ConsoleKey.LeftArrow:
                    {
                        currentFigure.TryMove(Directions.LEFT);
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        currentFigure.TryMove(Directions.DOWN);
                        break;
                    }
                case ConsoleKey.Spacebar:
                    {
                        currentFigure.TryRotate();
                        break;
                    }
            }
        }
    }
}