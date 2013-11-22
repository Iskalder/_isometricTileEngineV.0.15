using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _isometricTileEngineV._0._14
{

    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TileMap myMap = new TileMap();
        int squaresAcross = 14;
        int squaresDown = 35;
        int baseOffsetX = -32;
        int baseOffsetY = -64;
        //float heightRowDepthMod = 0.00001f;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }


        protected override void Initialize()
        {

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            Tile.TileSetTexture = Content.Load<Texture2D>("grus stig");

            Tile.TileSetTexture = Content.Load<Texture2D>("Tile 8");

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            #region Camera control

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Left))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X - 2, 0,
                    (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            }

            if (ks.IsKeyDown(Keys.Right))
            {
                Camera.Location.X = MathHelper.Clamp(Camera.Location.X + 2, 0,
                    (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            }

            if (ks.IsKeyDown(Keys.Up))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y - 2, 0,
                    (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            }

            if (ks.IsKeyDown(Keys.Down))
            {
                Camera.Location.Y = MathHelper.Clamp(Camera.Location.Y + 2, 0,
                    (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            }

            #endregion camera


            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            Vector2 firstSquare = new Vector2(Camera.Location.X / Tile.TileStepX, Camera.Location.Y / Tile.TileStepY);
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Camera.Location.X % Tile.TileStepX, Camera.Location.Y % Tile.TileStepY);
            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            float maxdepth = ((myMap.MapWidth + 1) * ((myMap.MapHeight + 1) * Tile.TileWidth)) / 10;
            // float depthOffset;


           



                for (int y = 0; y < squaresDown; y++)
                {
                    int rowOffset = 0;
                    if ((firstY + y) % 2 == 1)
                        rowOffset = Tile.OddRowXOffset;

                    for (int x = 0; x < squaresAcross; x++)
                    {
                        int mapx = (firstX + x);
                        int mapy = (firstY + y);
                        //depthOffset = 0.7f - ((mapx + (mapy * Tile.TileWidth)) / maxdepth);

                        foreach (int tileID in myMap.Rows[mapy].Columns[mapx].BaseTiles)
                        {
                            spriteBatch.Draw(

                                Tile.TileSetTexture,
                                new Rectangle(
                                    (x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX,
                                    (y * Tile.TileStepY) - offsetY + baseOffsetY,
                                    Tile.TileWidth, Tile.TileHeight),
                                Tile.GetSourceRectangle(tileID),
                                Color.White,
                                0.0f,
                                Vector2.Zero,
                                SpriteEffects.None,
                                1.0f);
                        }

                 }

                }


                //spriteBatch.DrawString(pericles6, (x + firstX).ToString() + ", " + (y + firstY).ToString(),
                //    new Vector2((x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX + 24,
                //        (y * Tile.TileStepY) - offsetY + baseOffsetY + 48), Color.White, 0f, Vector2.Zero,
                //        1.0f, SpriteEffects.None, 0.0f);


                spriteBatch.End();

                base.Draw(gameTime);
            }
        }
    }

