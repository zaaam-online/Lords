using System.Xml.Serialization;

namespace Lord
{
    public class MapPosition
    {
        /// <summary>
        /// This a a single Map / Entry - Position
        /// in the Future i load Objekt into a Map Position like a Road / Army etc
        /// </summary>
        public MapPosition() { }

        public MapPosition(int x, int y, string iD) { this._tileID = iD; this._xPosition = x; this._yPosition = y; }

        private int _xPosition = 0;
        private int _yPosition = 0;
        private string _tileID = string.Empty;

        [XmlAttribute]
        public int XPos { get { return this._xPosition; } set { this._xPosition = value; } }

        [XmlAttribute]
        public int YPos { get { return this._yPosition; } set { this._yPosition = value; } }

        [XmlAttribute]
        public string TID { get { return this._tileID; } set { this._tileID = value; } }
    }
}

