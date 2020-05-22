using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Timers;

namespace OTus_Tetris
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        static FigureGenerator generator;
        static Figure currentFigure;
        private static System.Timers.Timer aTimer;
        static private Object _lockObject = new object();

        static void Main(string[] args)
        {
            Field.SetWindowGameSize(Field.Width, Field.Height);
            
            generator = new FigureGenerator(Field.Width/2, 0, Drawer.DEFAULT_SYMBOL);
            currentFigure = generator.GetNewFigure();

            IDrawer drawer = new ConsoleDrawer2();
            Test(drawer);

            SetTimer();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Monitor.Enter(_lockObject);
                    var key = Console.ReadKey();
                    var result = HandleKey(currentFigure, key.Key);
                    ProcessResult(result, ref currentFigure);
                    Monitor.Exit(_lockObject);
                }
            }
           
        }
        private static void SetTimer()
        { 
            aTimer = new System.Timers.Timer(TIMER_INTERVAL);
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Elapsed += OnTimedEvent;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Directions.DOWN);
            ProcessResult(result, ref currentFigure);
            Monitor.Exit(_lockObject);
        }

        public static bool ProcessResult(Result result, ref Figure currentFigure)
        {
            if (result == Result.DOWN_BORDER_STRIKE || result == Result.HEAP_STRIKE)
            {
                Field.AddFigure(currentFigure.Points);
                Field.TryDeleteLine();
                
                if(currentFigure.IsOnTop())
                {
                    WriteGameOver();
                    aTimer.Elapsed -= OnTimedEvent;
                    return true;
                }
                else
                {
                    currentFigure = generator.GetNewFigure();
                    return false;
                }
            }
            else return false;
        }

        private static void WriteGameOver()
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 8, Console.WindowHeight / 2);
            Console.WriteLine("G A M E  O V E R");
        }

        private static void Test(IDrawer drawer)
        {
            DrawerProvider.Drawer.DrawPoint(4, 4);
        }
        private static Result HandleKey(Figure f, ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.RightArrow:
                    return f.TryMove(Directions.RIGHT);
                case ConsoleKey.LeftArrow:
                    return f.TryMove(Directions.LEFT);
                case ConsoleKey.DownArrow:
                    return f.TryMove(Directions.DOWN);
                case ConsoleKey.Spacebar:
                    return f.TryRotate();
            }
            return Result.SUCCESS;
        }
    }
}