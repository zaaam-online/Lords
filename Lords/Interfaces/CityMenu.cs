using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lord
{
    public class CityMenu
    {
        int _xpos = 0;
        int _ypos = 0;
        int _width = 400;
        int _height = 300;
        int _cancelsize = 40;

        public bool _showFieldsWindow = false;

        SpriteFont _cityMenufont = null;
        Texture2D _menuTexture = null;


        public enum Window
        {
            General,
            Fields,
            Labor
        }

        public CityMenu(int xpos, int ypos, ContentManager contentmanager)
        {
            _cityMenufont = contentmanager.Load<SpriteFont>(CONSTANTS.SPRITE_FONT_DEFAULT);
            _menuTexture = contentmanager.Load<Texture2D>(CONSTANTS.PATH_TXT_CITY_MENU);
            _xpos = xpos;
            _ypos = ypos;
        }

        public void DrawCityMenu(SpriteBatch batch, City city)
        {
            batch.Draw(_menuTexture, new Vector2(_xpos, _ypos), Color.White);
            batch.DrawString(_cityMenufont, "WELCOME TO :" + city.Name.ToString(), new Vector2(_xpos+5, _ypos+15 ), Color.Red);
            batch.DrawString(_cityMenufont, "Fields :" + city.Fields.ToString(), new Vector2(_xpos + 5, _ypos + 45), Color.Black);
            batch.DrawString(_cityMenufont, "Happiness:" + city.Happiniess.ToString(), new Vector2(_xpos + 5, _ypos + 75), Color.Black);
            batch.DrawString(_cityMenufont, "Residents :" + city.Residents.ToString(), new Vector2(_xpos + 5, _ypos + 105), Color.Black);
            batch.DrawString(_cityMenufont, "CityType :" + city.CityType.ToString(), new Vector2(_xpos + 5, _ypos + 135), Color.Black);
        }

        public void Draw2CityMenu(SpriteBatch batch, City city)
        {
            batch.Draw(_menuTexture, new Vector2(_xpos, _ypos), Color.White);
            batch.DrawString(_cityMenufont, "WELCOME TO :" + city.Name.ToString(), new Vector2(_xpos + 5, _ypos + 15), Color.Red);
            batch.DrawString(_cityMenufont, "Fields :" + city.Fields.ToString(), new Vector2(_xpos + 5, _ypos + 45), Color.Black);
   
        }

        public void ShowWindow()
        {


        }

        public bool ShowCityMenu()
        {

            Microsoft.Xna.Framework.Input.ButtonState state = Mouse.GetState().LeftButton;
            Microsoft.Xna.Framework.Input.ButtonState rightState = Mouse.GetState().RightButton;
            if (state == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                int mx = Mouse.GetState().X;
                int my = Mouse.GetState().Y;

                //cancel is 27 pix right corner / substract
                int rangex1 = _xpos + _width;
                int rangey = _ypos ;
                if (mx <= rangex1 && mx >= rangex1 - _cancelsize && my <= rangey+ _cancelsize && my >= rangey)
                    return false;

                if (rightState == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                    _showFieldsWindow = true;
            }
            return true;   
        }
    }
}
