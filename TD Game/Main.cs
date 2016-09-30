using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TD_Game
{
    public class Main : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        bool hasStarted;

        Texture2D thing;
        Vector2 thingPos;

        List<Crab> crabs;
        List<BuildingTile> tiles;

        bool wait;

        BuildingTile tile;

        MouseState mouseState;
        MouseState oldState;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Fonts.Load(Content);
            Textures.Load(Content);
            thing = Content.Load<Texture2D>("img/thing");
        }

        private void Start()
        {
            IsMouseVisible = true;
            graphics.IsFullScreen = true;
            graphics.ApplyChanges();
            Camera.loadCamera(GraphicsDevice);
            crabs = new List<Crab>();
            tiles = new List<BuildingTile>();

            MapManager.LoadMaps();
            MapManager.currentMap = MapManager.maps[0];
            MapManager.map = MapManager.currentMap.texture;

            tile = new BuildingTile(new Vector2(4, 4));
        }

        protected override void Update(GameTime gameTime)
        {
            if (!hasStarted)
            {
                Start();
                hasStarted = true;
            }

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            KeyboardState keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();

            if (keyboardState.IsKeyDown(Keys.W))
            {
                Camera.Position -= new Vector2(0, 200) * deltaTime;
                Utils.ClampMin(ref Camera.Position.Y, 0);
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                Camera.Position += new Vector2(0, 200) * deltaTime;
                Utils.ClampMax(ref Camera.Position.Y, MapManager.currentMap.height * 80 - Camera.res.Y);
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                Camera.Position -= new Vector2(200, 0) * deltaTime;
                Utils.ClampMin(ref Camera.Position.X, 0);
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                Camera.Position += new Vector2(200, 0) * deltaTime;
                Utils.ClampMax(ref Camera.Position.X, MapManager.currentMap.width * 80 - Camera.res.X);
            }

            if (keyboardState.IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            if (keyboardState.IsKeyDown(Keys.Up))
            {
                thingPos.Y--;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                thingPos.Y++;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                thingPos.X--;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                thingPos.X++;
            }

            if (keyboardState.IsKeyDown(Keys.Q))
            {
                if (!wait)
                {
                    crabs.Add(new Crab(1, 1));
                    wait = true;
                }
            }
            else
            {
                wait = false;
            }

            if (mouseState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
            {
                bool isNew = true;
                Vector2 position = new Vector2((float)Math.Floor((mouseState.X + Camera.Position.X) / 80), (float)Math.Floor((mouseState.Y + Camera.Position.Y) / 80));
                BuildingTile clickedTile = new BuildingTile(new Vector2(-1, -1));
                foreach (BuildingTile tile in tiles)
                {
                    if (tile.position == position)
                    {
                        isNew = false;
                        clickedTile = tile;
                        break;
                    }
                }

                if (!isNew)
                {
                    clickedTile.Click();
                }
                else
                {
                    BuildingTile newTile = new BuildingTile(position);
                    tiles.Add(newTile);
                }
            }
            oldState = mouseState;

            foreach (Crab crab in crabs)
            {
                crab.Update();
            }

            foreach (BuildingTile tile in tiles)
            {
                tile.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.LinearClamp,
                DepthStencilState.None, RasterizerState.CullCounterClockwise, null, Camera.GetViewMatrix());
            spriteBatch.Draw(MapManager.map, new Vector2(0, 0));

            foreach (Crab crab in crabs)
            {
                if (!crab.isDead() && Camera.isVisible(crab.position))
                {
                    spriteBatch.Draw(Textures.crab, crab.position, crab.getFrame(), Color.White, MathHelper.ToRadians(crab.rotation), crab.origin, 1, SpriteEffects.None, 0);
                }
            }

            foreach (BuildingTile tile in tiles)
            {
                if (Camera.isVisible(tile.realPos))
                {
                    spriteBatch.Draw(Textures.tile, tile.realPos);
                }
            }

            spriteBatch.Draw(Textures.tile, tile.realPos);

            spriteBatch.Draw(thing, thingPos - new Vector2(10, 10));
            spriteBatch.End();

            spriteBatch.Begin();
            spriteBatch.DrawString(Fonts.Body, "Thing: " + (int)thingPos.X + ", " + (int)thingPos.Y, new Vector2(10, 10), Color.White);
            spriteBatch.DrawString(Fonts.Body, "Mouse: " + mouseState.X + ", " + mouseState.Y, new Vector2(10, 30), Color.White);
            spriteBatch.DrawString(Fonts.Body, "Camera: " + Camera.Position.X + ", " + Camera.Position.Y, new Vector2(10, 50), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}