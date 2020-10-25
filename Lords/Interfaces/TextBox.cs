using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lord
{
    class TextBox : IDrawAbleObject
    {

        private int _x = 0;
        private int _y = 0;
        private int _size = 0;
        private int _height = 0;

        public TextBox(int x, int y, int size, int height)
        {
            _x = x;
            _y = y;
            _size = size;
            _height = height;
            _textbox = new Rectangle(_x, _y, _size, _height);
        }

        private Rectangle _textbox;
        KeyboardState _oldstate;
        string _playertext = string.Empty;
        Texture2D _boxtexture = null;

        public void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch batch, GameStatus status)
        {
            char _blah;
            bool go = GameHelper.TryConvertKeyboardInput(Keyboard.GetState(), _oldstate, out _blah);
            _oldstate = Keyboard.GetState();
            batch.Draw(_boxtexture, _textbox, Color.White);
            if (go)
            {
                _playertext += _blah;

            }
            batch.DrawString(status.Font, _playertext, new Vector2(30, 30), Color.Black);
        }

        public void InitTextures(ContentManager content)
        {
            // throw new System.NotImplementedException();
        }

        //public void InitTextures(GraphicsDevice device)
        //{
        //    _boxtexture = new Texture2D(device, 1, 1, false, SurfaceFormat.Color);
        //    _boxtexture.SetData<Color>(new Color[] { Color.White });
        //    // is Free Font http://xbox.create.msdn.com/en-US/education/catalog/utility/font_pack
        //}
    }
}
