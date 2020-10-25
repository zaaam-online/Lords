using Lord;
using LordsOfEngland;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Lords.DemoObjects
{
    class Create
    {
        public static void CreateDemoXMLGameConfig(string filename)
        {
            GameConfiguration conf = new GameConfiguration();
            Tile tile = new Tile("xx", "xx", 0);
            Texture xx = new Texture("xx");
            Texture f0A = new Texture("f0A");
            Texture f0B = new Texture("f0B");
            Texture f4A = new Texture("f4A");
            Texture f4B = new Texture("f4B");
            Texture f10B = new Texture("f10B");
            Texture f10A = new Texture("f10A");
            Texture f10C = new Texture("f10C");
            Texture f6A = new Texture("f6A");

            Tile tile2 = new Tile("f0B", "f0B", 0);
            tile2.FT.Add(f0A);
            tile2.FT.Add(f0B);
            tile2.FT.Add(f4A);
            tile2.FT.Add(f4B);
            tile2.FT.Add(f10B);

            tile2.ST.Add(f0A);
            tile2.ST.Add(f0B);
            tile2.ST.Add(f6A);
            tile2.ST.Add(f10A);
            tile2.ST.Add(f10C);


            conf.TileConfiguration.Tiles.Add(tile);
            conf.TileConfiguration.Tiles.Add(tile2);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

           

        }

        public static void CreateCities(GameStatus status, List<City> cities)
        {
            Random rnd = new Random();
            int i = rnd.Next(0, CONSTANTS.MAP_TILES_RANDOM);
            MapPosition pos = status.Map.MapPositions[i];
            City london = new City();
            london.Name = "London";
            london.MapPosition = pos;
            cities.Add(london);

            i = rnd.Next(0, CONSTANTS.MAP_TILES_RANDOM);
            pos = status.Map.MapPositions[i];
            City aberdeen = new City();
            aberdeen.Name = "Aberdeen";
            aberdeen.MapPosition = pos;
            aberdeen.CityType = 2;
            aberdeen.Happiniess = 50;
            aberdeen.Residents = 999;
            cities.Add(aberdeen);

            i = rnd.Next(0, CONSTANTS.MAP_TILES_RANDOM);
            pos = status.Map.MapPositions[i];
            City birmingham = new City();
            birmingham.Name = "Birmingham";
            birmingham.MapPosition = pos;
            birmingham.CityType = 3;
            birmingham.Happiniess = 99;
            birmingham.Residents = 1450;
            cities.Add(birmingham);
        }

    }
}
