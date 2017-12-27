using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ballgame.Entities;
using Microsoft.Xna.Framework;

namespace Ballgame.Levels
{
    class Level4 : Level
    {
        public override void GenerateBricks()
        {
            ///felső vízszintes
            for (float x = 200; x < (Main.Resolution.X) - 200; x += Brick.defaultBrickSize.X + 10)
            {

                Main.CurrentLevel.CreateBrick(new Point((int)x, 100), BrickType.DefaultBrick);

                Main.target++;
            }
            
            ///alsó vízszintes
            for (float x = 200; x < (Main.Resolution.X) - 200; x += Brick.defaultBrickSize.X + 10)
            {

                Main.CurrentLevel.CreateBrick(new Point((int)x, 400), BrickType.DefaultBrick);

                Main.target++;
            }





            //bal oldali függőleges
            for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {

                Main.CurrentLevel.CreateBrick(new Point(200, (int)y), BrickType.DefaultBrick);

                Main.target++;
            }
            ///jobb oldali függőleges
            for (float y = 100; y < 400; y += Brick.defaultBrickSize.Y + 10)
            {

                Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 240, (int)y), BrickType.DefaultBrick);

                Main.target++;
            }

   


        }
    }
}

