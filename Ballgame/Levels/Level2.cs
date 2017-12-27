using Ballgame.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ballgame.Levels
{
    public class Level2 :Level
    {
        public override void GenerateBricks()
        {
            for (float x = (Main.Resolution.X / 5) * 3; x < (Main.Resolution.X / 5) * 4; x += Brick.defaultBrickSize.X + 10)
            {
                for (int y = 0; y < (Main.Resolution.Y / 4) - 100; y += Brick.defaultBrickSize.Y + 10)
                {
                    Main.CurrentLevel.CreateBrick(new Point((int)x, y), BrickType.DefaultBrick);

                    Main.target++;

                }
            }
            
            for (float x = (Main.Resolution.X / 5) * 2; x < (Main.Resolution.X / 5) * 3; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y2 = 10; y2 < (Main.Resolution.Y / 4) - 90; y2 += Brick.defaultBrickSize.Y + 10)
                {
                    Main.CurrentLevel.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                    Main.target++;

                }
            }
            //bal oldal 2. szint 
            for (float x = 350; x < (Main.Resolution.X / 2) - 50; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y2 = 100; y2 < (Main.Resolution.Y / 4) + 10; y2 += Brick.defaultBrickSize.Y + 10)
                {
                    Main.CurrentLevel.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                    Main.target++;

                }
            }

            //jobb oldal 2. szint
            for (float x = (Main.Resolution.X / 2) + 50; x < (Main.Resolution.X / 2) * 2 - 350; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y2 = 100; y2 < (Main.Resolution.Y / 4) + 10; y2 += Brick.defaultBrickSize.Y + 10)
                {
                    Main.CurrentLevel.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                    Main.target++;

                }
            }

            //bal oldal 3. szint
            for (float x = 175; x < (Main.Resolution.X / 2) - 200; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y2 = 190; y2 < (Main.Resolution.Y / 4) + 110; y2 += Brick.defaultBrickSize.Y + 10)
                {
                    Main.CurrentLevel.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                    Main.target++;

                }
            }
            //jobb oldali 3. szint
            for (float x = 175 + Main.Resolution.X / 2; x < ((Main.Resolution.X / 2) - 200) + Main.Resolution.X / 2; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y2 = 190; y2 < (Main.Resolution.Y / 4) + 110; y2 += Brick.defaultBrickSize.Y + 10)
                {
                    Main.CurrentLevel.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                    Main.target++;

                }
            }
            //piramis alja
            for (float x = 175; x < ((Main.Resolution.X / 2) - 200) + Main.Resolution.X / 2; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y2 = 280; y2 < (Main.Resolution.Y / 4) + 210; y2 += Brick.defaultBrickSize.Y + 10)
                {
                    Main.CurrentLevel.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                    Main.target++;

                }
            }
            
        }

    
}
}
