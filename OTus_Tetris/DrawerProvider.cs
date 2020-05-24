using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace OTus_Tetris
{
    static class DrawerProvider
    {
        private static IDrawer _drawer = new ConsoleDrawer();

        public static IDrawer Drawer
        {
            get
            {
                return _drawer;
            }
        }
    }
}
