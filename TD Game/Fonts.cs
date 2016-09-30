using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TD_Game
{
    public static class Fonts
    {
        public static SpriteFont Title;
        public static SpriteFont Body;

        internal static void Load(ContentManager content)
        {
            Title = content.Load<SpriteFont>("font/Title");
            Body = content.Load<SpriteFont>("font/Body");
        }
    }
}