using System;
using Microsoft.Xna.Framework.Input;

namespace Lords
{
    public static class Menu
    {
        private static MenuButton _menuButton;


        public static MenuButton menuButton { get => _menuButton; set => _menuButton = value; }
    }


    public static class StartGameMenu
    {
        private static MenuButton _menuButton;

        public static MenuButton menuButton { get => _menuButton; set => _menuButton = value; }

        // private static int _xsize = 200;
        // private static int _ysize = 50;
    }

    public class MenuButton {

        private static int _xpos = 0;
        private static int _ypos = 0;

         private static int _xsize = 200;
         private static int _ysize = 50;

        private static Size _size;
        private static Position _position;

        public static bool ButtonIsPressed(int x, int y)
        {

            if (x >= _xpos && x <= _xpos + _xsize && y >= _ypos && y <= _ypos + _ysize)
                return true;
            return false;
        }


        public static Size size { get => _size; set => _size = value; }
        public static Position position { get => _position; set => _position = value; }

        public static int Xpos { get => _xpos; set => _xpos = value; }
        public static int Ypos { get => _ypos; set => _ypos = value; }

        internal bool ButtonIspressed()
        {
            throw new NotImplementedException();
        }
    }

    public class Size {
        private static int _xsize = 200;
        private static int _ysize = 50;

        public static int Xpos { get => _xsize; set => _xsize = value; }
        public static int Ypos { get => _ysize; set => _ysize = value; }
    }

    public class Position
    {
        private static int _x = 0;
        private static int _y = 0;

        Position(int px, int py) {
            x = px;
            y = py;
        }


        public static int x { get => _x; set => _x = value; }
        public static int y { get => _y; set => _y = value; }
    }
}
