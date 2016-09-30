using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TD_Game
{
    public static class Camera
    {
        public static Vector2 Position;
        public static float Zoom;
        public static Vector2 Origin;
        public static Vector2 res;

        public static void loadCamera(GraphicsDevice g)
        {
            Zoom = 1f;
            Origin = new Vector2(g.Viewport.Width / 2f, g.Viewport.Height / 2f);
            Position = Vector2.Zero;
            res = new Vector2(g.Viewport.Width, g.Viewport.Height);

        }

        public static Matrix GetViewMatrix()
        {
            return
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) *
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }

        public static bool isVisible(Vector2 pos)
        {
            return pos.X + 50 > Position.X && pos.X - 50 < Position.X + res.X &&
                pos.Y + 50 > Position.Y && pos.Y - 50 < Position.Y + res.Y;
        }
    }
}