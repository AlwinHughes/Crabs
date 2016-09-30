using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD_Game
{
    class BuildingTile
    {
       public Vector2 position;
       public Vector2 realPos;

        public BuildingTile(Vector2 position)
        {
            this.position = position;
            realPos = position * 80;
        }

        public void Update()
        {

        }

        public void Click()
        {

        }
    }
}
