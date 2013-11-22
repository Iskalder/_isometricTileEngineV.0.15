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
    

        class MapRow
        {
            public List<MapCell> Columns = new List<MapCell>();
        }

        class TileMap
        {
            public List<MapRow> Rows = new List<MapRow>();
            public int MapWidth = 50;
            public int MapHeight = 50;

            public TileMap()
            {
                for (int y = 0; y < MapHeight; y++)
                {
                    MapRow thisRow = new MapRow();
                    for (int x = 0; x < MapWidth; x++)
                    {
                        thisRow.Columns.Add(new MapCell(0));
                    }
                    Rows.Add(thisRow);
                }

                // Create Sample Map Data


                //Rows[3].Columns[5].AddBaseTile(30);

                //Rows[4].Columns[6].AddBaseTile(104);
                // End Create Sample Map Data
            }
        }
    }

