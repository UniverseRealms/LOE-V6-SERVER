﻿using dungeon.utils;

namespace dungeon.templates.Difficult_1.Pirate_Cave
{
    internal class Background : MapRender
    {
        public override void Rasterize()
        {
            var tile = new DungeonTile
            {
                TileType = PirateCaveTemplate.ShallowWater
            };

            Rasterizer.Clear(tile);
        }
    }
}