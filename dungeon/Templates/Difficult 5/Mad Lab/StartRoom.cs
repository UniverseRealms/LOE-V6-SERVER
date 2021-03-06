﻿using System;
using LoESoft.Dungeon.utils;
using RotMG.Common.Rasterizer;
using LoESoft.Dungeon.engine;

namespace LoESoft.Dungeon.templates.Difficult_5.Mad_Lab
{
    internal class StartRoom : FixedRoom
    {
        static readonly Rect template = new Rect(0, 96, 26, 128);

        public override RoomType Type { get { return RoomType.Start; } }

        public override int Width { get { return template.MaxX - template.X; } }

        public override int Height { get { return template.MaxY - template.Y; } }

        static readonly Tuple<Direction, int>[] connections = {
            Tuple.Create(Direction.North, 11)
        };

        public override Tuple<Direction, int>[] ConnectionPoints { get { return connections; } }

        public override void Rasterize(BitmapRasterizer<DungeonTile> rasterizer, Random rand)
        {
            rasterizer.Copy(LabTemplate.MapTemplate, template, Pos);
            LabTemplate.DrawSpiderWeb(rasterizer, Bounds, rand);
        }
    }
}