using LordsOfEngland;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lord
{
    public class MapCreator
    {


        public static Map CreateRandomMap(GameConfiguration config)
        {
            List<LordsOfEngland.Tile> tiles = config.TileConfiguration.Tiles;

            Random rnd = new Random();
            int random = rnd.Next(0, tiles.Count - 1);
            Tile current = tiles[4];

            Map map = new Map();
            map.MapHight = CONSTANTS.MAP_TILES_X;
            map.MapWidth = CONSTANTS.MAP_TILES_Y;
            Stopwatch watch = new Stopwatch();
            watch.Start();

            for (int y = 0; y < map.MapHight; y++)
            {
                for (int x = 0; x < map.MapWidth; x++)
                {
                    if (y == 0)
                    {
                        random = rnd.Next(current.FT.Count);
                        Texture texture = current.FT[random];
                        Tile nextile = tiles.Find(o => o.TileID == texture.TTID);
                        map.MapPositions.Add(new MapPosition(x, y, current.TileID));
                        current = nextile;
                    }
                    else
                    {
                        List<string> possibletiles = new List<string>(2);
                        Tile lastabove = tiles.Find(n => n.TileID == (map.MapPositions.Find(o => (o.XPos == x && o.YPos == y - 1)).TID));
                        Tile lastleft = null;
                        if (x > 0)
                        {
                            lastleft = tiles.Find(n => n.TileID == (map.MapPositions.Find(o => (o.XPos == x - 1 && o.YPos == y)).TID));
                        }
                        foreach (var o in lastabove.ST)
                        {
                            if (lastleft != null)
                            {
                                if (lastleft.FT.Exists(a => a.TTID == o.TTID))
                                {
                                    possibletiles.Add(o.TTID);
                                    continue;
                                }
                            }
                            else
                                possibletiles.Add(o.TTID);
                        }

                        try
                        {
                            random = rnd.Next(possibletiles.Count);
                            map.MapPositions.Add(new MapPosition(x, y, possibletiles[random]));
                        }
                        catch (Exception)
                        {
                            map.MapPositions.Add(new MapPosition(x, y, "xx"));
                        }
                    }
                }
            }
            // Save the Map to the File
            //Map.SaveConfig(map);
            return map;
        }
    }
}

