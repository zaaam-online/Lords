using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace LordsOfEngland
{
    public class Texture
    {
        public Texture() { }
        public Texture(string textureID)
        { this._textureID = textureID; }

        private string _textureID = string.Empty;
        [XmlAttribute]
        public string TTID { get { return this._textureID; } set { this._textureID = value; } }
    }
}

