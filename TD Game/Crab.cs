using System;
using Microsoft.Xna.Framework;

namespace TD_Game
{
    class Crab
    {
        int hp;
        float speed;
        public Vector2 position;
        public float rotation;
        public Vector2 origin;
        Path path;

        int pathNode;
        int frame;
        int c;

        public Crab(int hp, float speed)
        {
            this.hp = hp;
            this.speed = speed;
            origin = new Vector2(Textures.crab.Width / 6, Textures.crab.Height / 2);
            path = MapManager.getPath();
            position = path.getPos(0);
            pathNode = 1;
        }

        public Rectangle getFrame()
        {
            if (frame == 0)
            {
                return new Rectangle(0, 0, 50, 44);
            }
            else if (frame == 1)
            {
                return new Rectangle(50, 0, 50, 44);
            }
            return new Rectangle(100, 0, 50, 44);
        }

        public void Update()
        {
            c++;
            if (c == 5)
            {
                frame++;
            }
            if (frame == 3)
            {
                frame = 0;
            }

            if (pathNode != 0)
            {
                moveTowards(path.getPos(pathNode));

                if (position.X == path.getPos(pathNode).X && position.Y == path.getPos(pathNode).Y)
                {
                    pathNode++;
                }

                if (pathNode == path.Length())
                {
                    pathNode = 0;
                }
            }
            else
            {
                hp = 0;
            }
        }

        public bool isDead()
        {
            return hp < 1;
        }

        private void moveTowards(Vector2 target)
        {
            float xDif = target.X - position.X;
            float yDif = target.Y - position.Y;

            if (speed > Math.Abs(xDif) && speed > Math.Abs(yDif))
            {
                position.X += xDif;
                position.Y += yDif;
                return;
            }

            if (xDif == 0)
            {
                if (yDif < 0)
                {
                    position.Y -= speed;
                    rotation = 180;
                    return;
                }
                position.Y += speed;
                rotation = 0;
            }
            else if (yDif == 0)
            {
                if (xDif < 0)
                {
                    position.X -= speed;
                    rotation = 90;
                    return;
                }
                position.X += speed;
                rotation = 270;
            }
        }
    }
}