using Ballgame.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballgame.Levels
{
    public class Level1 : Level
    { // a setlevellel meg úgy is lehet majd állítani, de egyenlőre automatikusan ugrik a következőre
        //majd a Select Level menünél is a SetLevel-t kell használni akkor ezt innen ne töröld ki ,jó lesz infónak xddddoké

      

        /// <summary>
        /// Feltölti a pályát téglákkal
        /// </summary>
        public override void GenerateBricks()
        {


            for (float x = (Main.Resolution.X / 5) * 2; x < (Main.Resolution.X / 5) * 3; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y = 0 ; y < (Main.Resolution.Y / 4) - 100; y += Brick.defaultBrickSize.Y + 10)
                {

                    Level.CreateBrick(new Point((int)x, (int)y), BrickType.DefaultBrick);

                    Main.target++;
                }
            }



            for (float x = (Main.Resolution.X / 5); x < (Main.Resolution.X / 5) * 2; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y = (Main.Resolution.Y / 4); y < (Main.Resolution.Y / 4) * 2 - 100; y += Brick.defaultBrickSize.Y + 10)
                {

                    Level.CreateBrick(new Point((int)x, (int)y), BrickType.DefaultBrick);

                    Main.target++;
                }
            }


            for (float x = (Main.Resolution.X / 5) * 3; x < (Main.Resolution.X / 5) * 4; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y = (Main.Resolution.Y / 4); y < (Main.Resolution.Y / 4) * 2 - 100; y += Brick.defaultBrickSize.Y + 10)
                {

                    Level.CreateBrick(new Point((int)x, (int)y), BrickType.DefaultBrick);

                    Main.target++;
                }
            }

            for (float x = (Main.Resolution.X / 5) * 2; x < (Main.Resolution.X / 5) * 3; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y = (Main.Resolution.Y / 4) * 2; y < (Main.Resolution.Y / 4) * 3 - 100; y += Brick.defaultBrickSize.Y + 10)
                {

                    Level.CreateBrick(new Point((int)x, (int)y), BrickType.DefaultBrick);

                    Main.target++;
                }
            }
            

        }

    }


}

