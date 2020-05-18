using System;
using System.Drawing;
using System.Threading;

namespace OTus_Tetris
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.SetWindowSize(Field.WIDTH, Field.HEIGHT);
            Console.SetBufferSize(Field.WIDTH, Field.HEIGHT);

            Field.SetWidth(20);
            
            FigureGenerator generator = new FigureGenerator(20, 0, '*');


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