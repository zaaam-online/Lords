using Microsoft.Xna.Framework.Input;

namespace Lords
{
    public static class Menu
    {

        private static int _xpos = 0;
        private static int _ypos = 0;
        private static int _xsize = 200;
        private static int _ysize = 50;

        public static bool MenuIspressed()
        {
            Microsoft.Xna.Framework.Input.ButtonState state = Mouse.GetState().LeftButton;
            int mx = Mouse.GetState().X;
            int my = Mouse.GetState().Y;
            if (mx >= _xpos && mx <= _xpos + _xsize && my >= _ypos && my <= _ypos + _ysize)
                return true;

            return false;
        }

        public static int Xpos { get => _xpos; set => _xpos = value; }
        public static int Ypos { get => _ypos; set => _ypos = value; }
    }


    public static class StartGameMenu
    {

        private static int _xpos = 200;
        private static int _ypos = 0;
        private static int _xsize = 200;
        private static int _ysize = 50;

        public static bool MenuIspressed()
        {
            Microsoft.Xna.Framework.Input.ButtonState state = Mouse.GetState().LeftButton;
            int mx = Mouse.GetState().X;
            int my = Mouse.GetState().Y;
            if (mx >= _xpos && mx <= _xpos + _xsize && my >= _ypos && my <= _ypos + _ysize)
                return true;

            return false;
        }

        public static int Xpos { get => _xpos; set => _xpos = value; }
        public static int Ypos { get => _ypos; set => _ypos = value; }
    }
}
