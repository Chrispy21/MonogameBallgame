using Ballgame.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballgame.Levels
{
    class Level3 : Level
    {
        /// <summary>
        /// Mindegyik LevelX.cs-be ezt a metódust kell beilleszteni
        /// </summary>
        public override void GenerateBricks()  
        {

          ///bal fentről kezdődő
            Main.CurrentLevel.CreateBrick(new Point(300,50), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(340, 80), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(370, 110), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(400, 140), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(430, 170), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(460, 200), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(490, 230), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(520, 260), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(550, 290), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(580, 320), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(610, 350), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(640, 380), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(670, 410), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(700, 440), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point(730, 470), BrickType.DefaultBrick);

            ///jpbb fentről kezdődő 
            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X)-300, 50), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 340, 80), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 370, 110), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 400, 140), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 430, 170), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 460, 200), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 490, 230), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 520, 260), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 550, 290), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 580, 320), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 610, 350), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 640, 380), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 670, 410), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 700, 440), BrickType.DefaultBrick);

            Main.CurrentLevel.CreateBrick(new Point((int)(Main.Resolution.X) - 730, 470), BrickType.DefaultBrick);


            Main.target++;
                    



        }

    }
}
