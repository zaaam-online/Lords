using LordsOfEngland;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Lord
{


    public class GameStatus
    {
        private Coord _mapPosition = null;
        private GameConfiguration _configuration = null;
        private SpriteFont _font = null;
        private Map _map = null;

        //Zoomfactor enables Gridview 50 is Normal
        private int _zoomfaktor = CONSTANTS.ZOOM_FACTOR;
        private List<IDrawAbleObject> _objects = null;
        public List<IDrawAbleObject> DrawObjects { get { return this._objects; } set { this._objects = value; } }

        public int ZoomFactor { get { return _zoomfaktor; } set { _zoomfaktor = value; } }

        public GameStatus(bool newmap, ContentManager Content)
        {
            _configuration = Content.Load<GameConfiguration>(@"File");
            _mapPosition = new Coord();
            _objects = new List<IDrawAbleObject>();
            _map = MapCreator.CreateRandomMap(_configuration);
        }

        public Coord MapPosition { get { return _mapPosition; } set { _mapPosition = value; } }
        public GameConfiguration Configuration { get { return _configuration; } set { _configuration = value; } }
        public Map Map { get { return _map; } set { _map = value; } }
        public SpriteFont Font { get { return _font; } set { _font = value; } }
    }
}
