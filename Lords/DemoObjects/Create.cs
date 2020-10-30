using Lord;
using LordsOfEngland;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;
using System.Text;
using System.Runtime.Serialization.Json;

namespace Lords.DemoObjects
{
    class Create
    {
        public static void CreateDemoXMLGameConfig(string filename)
        {
            GameConfiguration conf = new GameConfiguration();

            Tile tile = new Tile("xx", "xx", 0);
            Tile tile2 = new Tile("f0B", "f0B", 0);

            Texture xx = new Texture("xx");
            Texture f0A = new Texture("f0A");
            Texture f0B = new Texture("f0B");
            Texture f4A = new Texture("f4A");
            Texture f4B = new Texture("f4B");
            Texture f10B = new Texture("f10B");
            Texture f10A = new Texture("f10A");
            Texture f10C = new Texture("f10C");
            Texture f6A = new Texture("f6A");

            
            List<Texture> listOfFollowTextutes = new List<Texture>()
            {
                f0A,
                f0B,
                f4A,
                f4B,
                f10B

            };

            List<Texture> listOfSubTextutes = new List<Texture>()
            {
                f0A,
                f0B,
                f6A,
                f10A,
                f10C

            };

            tile2.FT.AddRange(listOfFollowTextutes);
            tile2.FT.AddRange(listOfSubTextutes);

            conf.TileConfiguration.Tiles.Add(tile);
            conf.TileConfiguration.Tiles.Add(tile2);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;

           

        }


        public static void CreateCities(GameStatus status, List<Lord.City> cities)
        {
            RandomPosition pos = new RandomPosition(status);

            Lord.City london = new Lord.City("London", pos.randomize(status), 2, 0, 50, 999);
            cities.Add(london);

            Lord.City aberdeen = new Lord.City("Aberdeen", pos.randomize(status), 2, 0, 50, 999);
            cities.Add(aberdeen);

            Lord.City birmingham = new Lord.City("Birmingham", pos.randomize(status), 3, 0, 99, 1450);
            cities.Add(birmingham);

            Lord.City beispiel = new Lord.City("Beispiel", pos.randomize(status), 3, 0, 99, 1450);
            cities.Add(beispiel);
        }

    }

    public class RandomPosition {
        public RandomPosition(GameStatus status) {
            randomize(status);
        }
        public MapPosition randomize(GameStatus status) {
            Random rnd = new Random();
            int i = rnd.Next(0, CONSTANTS.MAP_TILES_RANDOM);
            return status.Map.MapPositions[i];
        }
    }
}
