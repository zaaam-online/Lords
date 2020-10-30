using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lord
{
    public class City
    {
        private string _name = string.Empty;
        private MapPosition _pmos = null;
        private int _cityType = 0;
        private int _fields = 3;
        private int _residents = 1200;
        private int _happiniess = 100;

        public City()
        { }

        public City(string name, MapPosition mapPosition, int cityType,int fields, int happieness, int residents) {
            this.Name = name;
            this.MapPosition = mapPosition;
            this.CityType = cityType;
            this.Fields = fields;
            this.Happiniess = happieness;
            this.Residents = residents;
        }


        public string Name { get => _name; set => _name = value; }
        public MapPosition MapPosition { get => _pmos; set => _pmos = value; }
        public int CityType { get => _cityType; set => _cityType = value; }
        public int Fields { get => _fields; set => _fields = value; }
        public int Residents { get => _residents; set => _residents = value; }
        public int Happiniess { get => _happiniess; set => _happiniess = value; }
    }
}
