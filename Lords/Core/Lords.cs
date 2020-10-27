using Lords;
using Lords.DemoObjects;
using Lords.Intro;
using LordsOfEngland;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;


namespace Lord
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Lords : Microsoft.Xna.Framework.Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //creating a texture dicitonary , only to initialize textures one
        private Dictionary<string, Texture2D> _textures = null;
        private GameStatus _status = null;
        private CityMenu _cityMenu = null;
        private List<City> _cities = new List<City>(5);

        private Intro _intro = null;
        bool _showIntro = true;


        private int _round = 1645;
        private bool _counterprotect = false;

        //SpriteFont _playername = _playername = Content.Load<SpriteFont>("Lords");

        // Functional
        private DrawMouse _mouse = null;


        private bool _showcityMenu = false;
        private City _activeCity = null;

        public Lords()
        {
            Content.RootDirectory = CONSTANTS.CONTENTROOT;


            _graphics = new GraphicsDeviceManager(this);

    


            // Initialises all stat Params for the Game
            _status = new GameStatus(true, Content);


            // TextBox box = new TextBox(30, 30, 200, 20);
            // _status.DrawObjects.Add(box);
            Create.CreateCities(_status, _cities);
        }




        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = false;

            _graphics.PreferredBackBufferWidth = CONSTANTS.WINDOWWIDTH;
            _graphics.PreferredBackBufferHeight = CONSTANTS.WINDOWHEIGHT;
            _graphics.IsFullScreen = CONSTANTS.WINDOWFULLSCREEN;
            _graphics.ApplyChanges();
            base.Initialize();
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            foreach (var a in _status.DrawObjects)
            {
                a.InitTextures(Content);
            }

         
             _intro = new Intro(Content);

            _status.Font = Content.Load<SpriteFont>(CONSTANTS.SPRITE_FONT_DEFAULT);
            _cityMenu = new CityMenu(CONSTANTS.WINDOWWIDTH / 2, CONSTANTS.WINDOWHEIGHT / 2, Content);

            List<Tile> tiles = _status.Configuration.TileConfiguration.Tiles;
            _textures = new Dictionary<string, Texture2D>(tiles.Count);
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            if (_mouse == null)
            { _mouse = new DrawMouse(this.Content, CONSTANTS.XSPACE, CONSTANTS.YSPACE); }
            foreach (Tile tile in tiles)
            {
                _textures.Add(tile.TileID, Content.Load<Texture2D>(CONSTANTS.FLD_TILE + tile.TilePath));
            }

            _textures.Add(CONSTANTS.TXT_YEAR_MENU, Content.Load<Texture2D>(CONSTANTS.PATH_TXT_YEAR_MENU));
            _textures.Add(CONSTANTS.TXT_CITY, Content.Load<Texture2D>(CONSTANTS.PATH_TXT_CITY));


        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            _spriteBatch.Begin();

            if (_intro.Showintro)
                _intro.DrawIntro(_spriteBatch);
            else
            {


                _spriteBatch.Draw(_textures[CONSTANTS.TXT_YEAR_MENU], new Vector2(0, 0), Color.White);
                _spriteBatch.DrawString(_status.Font, "Year:" + _round.ToString(), new Vector2(10, 15), Color.Red);

                DrawMap(gameTime);


                if (_showcityMenu && _activeCity != null)
                {
                    _cityMenu.DrawCityMenu(_spriteBatch, _activeCity);
                    _showcityMenu = _cityMenu.ShowCityMenu();
                }



                Microsoft.Xna.Framework.Input.ButtonState state = Mouse.GetState().RightButton;
                if (state == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    MapPosition pos = _mouse.GetMouseMapPosition(_status);
                    if (pos != null)
                    {
                        this.Window.Title = "Pressed" + pos.TID + "POS X" + pos.XPos + ".POS Y" + pos.YPos;

                        City cit = _cities.Find(o => o.MapPosition.XPos == pos.XPos && o.MapPosition.YPos == pos.YPos);
                        if (cit != null)
                        {
                            this.Window.Title = cit.Name;
                            _activeCity = cit;
                            _showcityMenu = true;
                        }
                    }
                }

                state = Mouse.GetState().LeftButton;

                if (state == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {

                    if (Menu.MenuIspressed() == true && !_counterprotect)
                    {
                        //todo Protect Counting up with - mouse State Year Combination
                        _round++;
                        _counterprotect = true;
                    }
                }


                //prevent Years from Counting UP
                if (state == Microsoft.Xna.Framework.Input.ButtonState.Released)
                {
                    _counterprotect = false;
                }


                _mouse.DrawTheMouse(_spriteBatch, GraphicsDevice, _status);
            }
            
            _spriteBatch.End();
        }

        private void DrawMap(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            base.Draw(gameTime);

            //How many Tiles are possible to render ?
            decimal showxTiles = Convert.ToDecimal(GraphicsDevice.Viewport.Width) / _status.ZoomFactor;
            decimal showyTiles = Convert.ToDecimal(GraphicsDevice.Viewport.Height) / _status.ZoomFactor;

            for (decimal y = 0; y < showyTiles; y++)
            {
                for (decimal x = 0; x < showxTiles; x++)
                {

                    int xpos = Convert.ToInt32(x * _status.ZoomFactor);
                    int ypos = Convert.ToInt32(y * _status.ZoomFactor);

                    //what is the current Map Position ?
                    MapPosition pos = _status.Map.MapPositions.Find(o => o.XPos == x + _status.MapPosition.X && o.YPos == y + _status.MapPosition.Y);

                    try
                    {
                        if (pos != null)
                        {
                            //draw corresponding textures
                            _spriteBatch.Draw(_textures[pos.TID], new Vector2(xpos + CONSTANTS.XSPACE, ypos + CONSTANTS.YSPACE), Color.White);

                            //is an Object on The Map
                            City cit = _cities.Find(o => o.MapPosition.XPos == pos.XPos && o.MapPosition.YPos == pos.YPos);
                            if (cit != null)
                            {
                                _spriteBatch.Draw(_textures[CONSTANTS.TXT_CITY], new Vector2(xpos + CONSTANTS.XSPACE, ypos + CONSTANTS.YSPACE), Color.White);
                            }

                        }
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }
    }
}

