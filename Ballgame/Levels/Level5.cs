using Ballgame.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballgame.Levels
{
    class Level5:Level
    {
        public override void GenerateBricks()
        {


                for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
                {
                    Level.CreateBrick(new Point(200, (int)y), BrickType.DefaultBrick);

                    Main.target++;
                }
            for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {
                Level.CreateBrick(new Point(400, (int)y), BrickType.DefaultBrick);

                Main.target++;
            }
            for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {
                Level.CreateBrick(new Point(600, (int)y), BrickType.DefaultBrick);

                Main.target++;
            }
            for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {
                Level.CreateBrick(new Point(800, (int)y), BrickType.DefaultBrick);

                Main.target++;
            }
            for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {
                Level.CreateBrick(new Point(1000, (int)y), BrickType.DefaultBrick);

                Main.target++;
            }

        }

    }
}
