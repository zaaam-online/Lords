using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Lord
{
    public class DrawMouse
    {
        private Texture2D _cursorhand = null;
        private Texture2D _cursorpressed = null;
        private Texture2D _cursorpointing = null;

        private int _movedxpos = 0;
        private int _movedypos = 0;

        private int _movedTotalx = 0;
        private int _movedTotaly = 0;

        private int _xspace = 0;
        private int _yspace = 0;

        private MapPosition _currentPosition = null;

        public MapPosition CurrentPosition { get => _currentPosition; set => _currentPosition = value; }

        public DrawMouse(ContentManager content, int xposspace, int yposspace)
        {
            this._xspace = xposspace;
            this._yspace = yposspace;
            _cursorhand = content.Load<Texture2D>(@"hand\full-hand");
            _cursorpressed = content.Load<Texture2D>(@"hand\grab-fnr");
            _cursorpointing = content.Load<Texture2D>(@"hand\hand-fnr");
        }

        public void DrawTheMouse(SpriteBatch batch, GraphicsDevice device, GameStatus status)
        {
            //  int tilesize = status.ZoomFactor;


            Microsoft.Xna.Framework.Input.ButtonState state = Mouse.GetState().LeftButton;

            int mx = Mouse.GetState().X;
            int my = Mouse.GetState().Y;

            if (state == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                ResetPositions();
            }

            if (state == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                decimal showxTiles = Convert.ToDecimal(device.Viewport.Width) / status.ZoomFactor;
                decimal showyTiles = Convert.ToDecimal(device.Viewport.Height) / status.ZoomFactor;

                // renders black Tiles at the End / right
                int maxheigt = status.Map.MapHight - (int)showyTiles + 2;
                int maxwidth = status.Map.MapWidth - (int)showxTiles + 2;


                if (_movedxpos != 0)
                {
                    _movedTotalx = (Mouse.GetState().X - _movedxpos) + _movedTotalx;
                    if (_movedTotalx > status.ZoomFactor || _movedTotalx * -1 > status.ZoomFactor)
                    {
                        status.MapPosition.X = status.MapPosition.X - (_movedTotalx / status.ZoomFactor);
                        _movedTotalx = 0;
                        if (status.MapPosition.X < 0)
                            status.MapPosition.X = 0;
                        else if (status.MapPosition.X > maxwidth)
                            status.MapPosition.X = (int)maxwidth;
                    }
                }
                if (_movedypos != 0)
                {
                    _movedTotaly = (Mouse.GetState().Y - _movedypos) + _movedTotaly;
                    if (_movedTotaly > status.ZoomFactor || _movedTotaly * -1 > status.ZoomFactor)
                    {
                        status.MapPosition.Y = status.MapPosition.Y - (_movedTotaly / status.ZoomFactor);
                        _movedTotaly = 0;
                        if (status.MapPosition.Y < 0)
                            status.MapPosition.Y = 0;
                        else if (status.MapPosition.Y > maxheigt)
                            status.MapPosition.Y = (int)maxheigt;
                    }
                }

                _movedxpos = Mouse.GetState().X;
                _movedypos = Mouse.GetState().Y;

                batch.Draw(_cursorpressed, new Vector2(mx, my), Color.White);

            }
            else
            {
                batch.Draw(_cursorhand, new Vector2(mx, my), Color.White);
            }


            state = Mouse.GetState().RightButton;
            if (state == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                batch.Draw(_cursorpointing, new Vector2(mx, my), Color.White);
            }
        }

        public MapPosition GetMouseMapPosition(GameStatus status)
        {

            int mx = Mouse.GetState().X - _xspace;
            int my = Mouse.GetState().Y - _yspace;

            MapPosition pos = new MapPosition();
            int mapx = 0;
            int mapy = 0;
            if (mx > 0 && my > 0)
            {
                mapx = (mx / status.ZoomFactor);
                mapy = (my / status.ZoomFactor);
                _currentPosition = status.Map.MapPositions.Find(o => o.XPos == (mapx + status.MapPosition.X) && o.YPos == (mapy + status.MapPosition.Y));
                return _currentPosition;
            }

            return null;

        }

        private static void CalcDisplayTiles(GraphicsDevice device, int tilesize, out decimal showxTiles, out decimal showyTiles)
        {
            showxTiles = Convert.ToDecimal(device.Viewport.Width) / tilesize;
            showyTiles = Convert.ToDecimal(device.Viewport.Height) / tilesize;
        }

        private void ResetPositions()
        {
            _movedxpos = 0;
            _movedypos = 0;
            _movedTotalx = 0;
            _movedTotaly = 0;
        }
    }
}
