using Microsoft.Xna.Framework.Graphics;

namespace TD_Game
{
    public static class MapManager
    {
        public static Map currentMap;
        public static Map[] maps;

        public static Texture2D map;

        static int c;

        public static void LoadMaps()
        {
            Path map1Path = new Path(new int[,] { { -40, 280 }, { 280, 280 }, { 280, 120 }, { 600, 120 }, { 600, 280 }, { 760, 280 }, { 760, 120 }, { 920, 120 }, { 920, 760 }, { 760, 760 }, { 760, 840 }, { 600, 840 }, { 600, 760 }, { 440, 760 }, { 440, 840 }, { 200, 840 } });
            Path map1Path2 = new Path(new int[,] { { -40, 280 }, { 280, 280 }, { 280, 440 }, { 600, 440 }, { 600, 280 }, { 760, 280 }, { 760, 120 }, { 920, 120 }, { 920, 760 }, { 760, 760 }, { 760, 840 }, { 600, 840 }, { 600, 760 }, { 440, 760 }, { 440, 840 }, { 200, 840 } });

            maps = new Map[1] { new Map(0,Textures.map,13,13,new Path[2] { map1Path,map1Path2}) };
            c = 0;
        }

        public static Path getPath()
        {
            Path p = new Path(new int[,] { { 0,0} });
            if (currentMap.index == 0)
            {
                p = currentMap.paths[c];
                c++;
                if (c == 2)
                {
                    c = 0;
                }
            }
            return p;
        }
    }
}