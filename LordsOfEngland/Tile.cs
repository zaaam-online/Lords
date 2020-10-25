using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LordsOfEngland
{
    [Serializable]
    public class Tile
    {
        public Tile() { }

        public Tile(string path, string tileID, int dependencyID)
        {
            this._tilepath = path;
            this._dependencyID = dependencyID;
            this._tileID = tileID;

        }

        private int _dependencyID;
        [XmlAttribute]
        public int DID { get { return this._dependencyID; } set { this._dependencyID = value; } }



        private string _tilepath = string.Empty;
        [XmlAttribute]
        public string TilePath { get { return this._tilepath; } set { this._tilepath = value; } }

        private string _tileID = string.Empty;
        [XmlAttribute]
        public string TileID { get { return this._tileID; } set { this._tileID = value; } }


        private List<Texture> _tilefollowTextures = new List<Texture>(2);
        private List<Texture> _tilesubTextures = new List<Texture>(2);
        public List<Texture> FT { get { return this._tilefollowTextures; } set { this._tilefollowTextures = value; } }
        public List<Texture> ST { get { return this._tilesubTextures; } set { this._tilesubTextures = value; } }
    }
}

