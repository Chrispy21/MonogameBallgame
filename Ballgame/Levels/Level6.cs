using Ballgame.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballgame.Levels
{
    class Level6 : Level
    {
        public override void GenerateBricks()
        {

            for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {
                Main.CurrentLevel.CreateBrick(new Point(200, (int)y), BrickType.DefaultBrick);

                Main.target++;
            }

            //R betű elemei pocak és láb

            Main.CurrentLevel.CreateBrick(new Point(280, 100), BrickType.DefaultBrick);
            Main.target++;
            Main.CurrentLevel.CreateBrick(new Point(340, 130), BrickType.DefaultBrick);
            Main.target++;
            Main.CurrentLevel.CreateBrick(new Point(380, 160), BrickType.DefaultBrick); Main.target++;
            Main.CurrentLevel.CreateBrick(new Point(380, 190), BrickType.DefaultBrick); Main.target++;

            Main.CurrentLevel.CreateBrick(new Point(340, 220), BrickType.DefaultBrick); Main.target++;

            Main.CurrentLevel.CreateBrick(new Point(280, 250), BrickType.DefaultBrick); Main.target++;

            Main.CurrentLevel.CreateBrick(new Point(340, 280), BrickType.DefaultBrick); Main.target++;

            Main.CurrentLevel.CreateBrick(new Point(370, 310), BrickType.DefaultBrick); Main.target++;

            Main.CurrentLevel.CreateBrick(new Point(400,340), BrickType.DefaultBrick); Main.target++;
            Main.CurrentLevel.CreateBrick(new Point(430, 370), BrickType.DefaultBrick); Main.target++;


            for (float x = (440 + (Brick.defaultBrickSize.X) * 2); x < 760; x += Brick.defaultBrickSize.X + 10)
            {
                Main.CurrentLevel.CreateBrick(new Point((int)x, 100), BrickType.DefaultBrick);

                Main.target++;
            }
            for (float x = (440 + (Brick.defaultBrickSize.X) * 2); x < 760; x += Brick.defaultBrickSize.X + 10)
            {
                Main.CurrentLevel.CreateBrick(new Point((int)x, 190), BrickType.DefaultBrick);

                Main.target++;
            }

            for (float y = 130 ; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {
                Main.CurrentLevel.CreateBrick(new Point((int)(440 + (Brick.defaultBrickSize.X)*2),(int)y), BrickType.DefaultBrick);

                Main.target++;
            }


            for (float x = (700 + (Brick.defaultBrickSize.X) * 2); x < 1000; x += Brick.defaultBrickSize.X + 10)
            {
                Main.CurrentLevel.CreateBrick(new Point((int)x, 100), BrickType.DefaultBrick);
                Main.target++;

            }

            for (float y = 130; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {
                Main.CurrentLevel.CreateBrick(new Point((int)(770 + (Brick.defaultBrickSize.X) * 2), (int)y), BrickType.DefaultBrick);

                Main.target++;
            }


        }


    }
}
