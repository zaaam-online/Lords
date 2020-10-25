using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Lord
{
    [Serializable]
    public class Map
    {
        public Map() { }



        private int _mapHight = 0;
        private int _mapWidth = 0;
        private List<MapPosition> _mapPositions = new List<MapPosition>(200);

        [XmlAttribute]
        public int MapHight { get { return this._mapHight; } set { this._mapHight = value; } }

        [XmlAttribute]
        public int MapWidth { get { return this._mapWidth; } set { this._mapWidth = value; } }

        /// <summary>
        /// Contains all Map Positions 
        /// </summary>
        public List<MapPosition> MapPositions { get { return this._mapPositions; } set { this._mapPositions = value; } }
    }
}

