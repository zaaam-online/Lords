using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace LordsOfEngland
{
    [Serializable]
    public class TileConfiguration
    {
        public TileConfiguration() { }

        private int _tilewidth = 0;
        private int _tileheight = 0;
        private List<Tile> _tiles = new List<Tile>(50);

        [XmlAttribute]
        public int TileWidth { get { return this._tilewidth; } set { this._tilewidth = value; } }
        [XmlAttribute]
        public int TileHeight { get { return this._tileheight; } set { this._tileheight = value; } }

        public List<Tile> Tiles { get { return this._tiles; } set { this._tiles = value; } }
    }
}

