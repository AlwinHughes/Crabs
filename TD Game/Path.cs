using Microsoft.Xna.Framework;

namespace TD_Game
{
    public class Path
    {
        int[,] data;

        public Path(int[,] data)
        {
            this.data = data;
        }

        public Vector2 getPos(int pathNode)
        {
            return new Vector2(data[pathNode,0],data[pathNode,1]);
        }

        public int Length()
        {
            return data.Length / 2;
        }
    }
}