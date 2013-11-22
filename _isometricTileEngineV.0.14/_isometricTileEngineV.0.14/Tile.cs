using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace _isometricTileEngineV._0._14
{
    class Tile
    {
        static public Texture2D TileSetTexture;
        static public int TileWidth = 64;
        static public int TileHeight = 32;
        static public int TileStepX = 64;
        static public int TileStepY = 16;
        static public int OddRowXOffset = 32;


        static public Vector2 originPoint = new Vector2(19, 39);

        static public Rectangle GetSourceRectangle(int tileIndex)
        {
            int tileY = tileIndex / (TileSetTexture.Width / TileWidth);
            int tileX = tileIndex % (TileSetTexture.Width / TileWidth);

            return new Rectangle(tileX * TileWidth, tileY * TileHeight, TileWidth, TileHeight);
        }
    }
}
