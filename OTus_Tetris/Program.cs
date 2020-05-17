using System;
using System.Drawing;
using System.Threading;

namespace OTus_Tetris
{
    class Program
    {

       
        static void Main(string[] args)
        {
            Console.SetWindowSize(40, 30);
            Console.SetBufferSize(40, 30);

            Figure st = new Stick(10, 10, '*');
            st.Draw();

            Thread.Sleep(500);
            st.Hide();
            st.Rotate();
            st.Draw();

            Thread.Sleep(500);
            st.Hide();
            st.Move(Directions.LEFT);
            st.Draw();

            Thread.Sleep(1500);
            st.Hide();
            st.Rotate();
            st.Draw();

            Thread.Sleep(1500);
            st.Hide();
            st.Move(Directions.RIGHT);
            st.Draw();

            Thread.Sleep(500);
            st.Hide();
            st.Rotate();
            st.Draw();

            Thread.Sleep(500);
            st.Hide();
            st.Move(Directions.LEFT);
            st.Draw();

            Thread.Sleep(1500);
            st.Hide();
            st.Rotate();
            st.Draw();

            Thread.Sleep(1500);
            st.Hide();
            st.Move(Directions.RIGHT);
            st.Draw();

            Console.ReadLine();
        }
       
    }
}
