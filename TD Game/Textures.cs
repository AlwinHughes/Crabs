using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TD_Game
{
   public static class Textures
    {
        public static Texture2D crab;

        public static Texture2D map;

        public static Texture2D tile;

        public static void Load(ContentManager content)
        {
            crab = content.Load<Texture2D>("img/crab");

            map = content.Load<Texture2D>("img/map");

            tile = content.Load<Texture2D>("img/buildingTile");
        }
    }
}