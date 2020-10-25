using System;


namespace LordsOfEngland
{
    [Serializable]
    public class GameConfiguration
    {
        public GameConfiguration() { }


        private TileConfiguration _tileConfiguration = new TileConfiguration();

        public TileConfiguration TileConfiguration { get { return this._tileConfiguration; } set { this._tileConfiguration = value; } }

    }
}

