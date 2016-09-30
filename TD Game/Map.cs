using Microsoft.Xna.Framework.Graphics;

namespace TD_Game
{
    public class Map
    {
        public int index;
        public Texture2D texture;
        public int width;
        public int height;

        public Path[] paths;
        public Map(int index,Texture2D texture, int width, int height, Path[] paths)
        {
            this.index = index;
            this.texture = texture;
            this.width = width;
            this.height = height;
            this.paths = paths;
        }  
    }
}