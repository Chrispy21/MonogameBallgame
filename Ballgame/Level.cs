using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame.Entities
{
    public class Level
    {
        public List<Entity> EntityList { get; private set; }

        public Player Player { get; private set; }
        public List<Ball> Balls { get; private set; }
        public static Ball ball;
        public Level()
        {
            this.EntityList = new List<Entity>();
            this.Balls = new List<Ball>();
            this.Initialize();
        }

        private void Initialize()
        {
            // A játékos létrehozása
            this.Player = this.CreatePlayer(new Point(Main.Graphics.PreferredBackBufferWidth / 2, Main.Graphics.PreferredBackBufferHeight - 50), RacketType.BlueGray);

            // Az első labda
            this.Balls.Add(this.CreateBall(new Point(this.Player.Body.X, this.Player.Body.Y - 100), BallType.Bowling));
        }

        public void Update(GameTime gameTime)
        {
            // Frissítünk mindent a pályán
            for (int i = this.EntityList.Count - 1; i >= 0; i--)
            {
                this.EntityList[i].Update(gameTime);
            }





        }

        public void Draw(GameTime gameTime)
        {
            // A pályán lévő Entityk rajzolása
            foreach (Entity e in this.EntityList)
            {
                e.Draw(gameTime);
            }
        }
       //public static Random rnd = new Random();
      
        /// <summary>
        /// Feltölti a pályát téglákkal
        /// </summary>
        public void GenerateBricks()
        {
            //piramis csúcs
            /*
            for (float x = (Main.Resolution.X/3); x < (Main.Resolution.X /3)*2; x += Brick.defaultBrickSize.X+10)
            {
                for (float y2 =10; y2 < (Main.Resolution.Y /4)-90; y2 += Brick.defaultBrickSize.Y+10)
                {
                    this.CreateBrick(new Point((int)x,(int) y2), BrickType.DefaultBrick);
                    Main.target++;
                }
            }
            //bal oldal 2. szint

           for (float x = 340; x < (Main.Resolution.X / 2)*2-350; x += Brick.defaultBrickSize.X + 10)
           {
               for (float y2 = 100; y2 < (Main.Resolution.Y / 4) + 10; y2 += Brick.defaultBrickSize.Y + 10)
               {
                   this.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                   Main.target++;

               }
           }

            //jobb oldal 2. szint
           for (float x = (Main.Resolution.X / 2)+50 ; x < (Main.Resolution.X /2)*2 - 350; x += Brick.defaultBrickSize.X + 10)
           {
               for (float y2 = 100; y2 < (Main.Resolution.Y / 4) + 10; y2 += Brick.defaultBrickSize.Y + 10)
               {
                   this.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                   Main.target++;

               }
           }

            //bal oldal 3. szint
           for (float x = 175; x < (Main.Resolution.X / 2) - 200; x += Brick.defaultBrickSize.X + 10)
           {
               for (float y2 = 190; y2 < (Main.Resolution.Y / 4) + 110; y2 += Brick.defaultBrickSize.Y + 10)
               {
                   this.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                   Main.target++;

               }
           }
            //jobb oldali 3. szint
           for (float x = 165+Main.Resolution.X/2; x < ((Main.Resolution.X / 2) - 200)+Main.Resolution.X/2; x += Brick.defaultBrickSize.X + 10)
           {
               for (float y2 = 190; y2 < (Main.Resolution.Y / 4) + 110; y2 += Brick.defaultBrickSize.Y + 10)
               {
                   this.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                   Main.target++;

               }
           }
            //piramis alja
           for (float x = 175; x <((Main.Resolution.X / 2) - 200)+Main.Resolution.X/2; x += Brick.defaultBrickSize.X + 10)
           {
               for (float y2 = 280; y2 < (Main.Resolution.Y / 4) + 180; y2 += Brick.defaultBrickSize.Y + 10)
               {
                   this.CreateBrick(new Point((int)x, (int)y2), BrickType.DefaultBrick);
                   Main.target++;

               }
           }
            
            */
            for (float x = (Main.Resolution.X / 5) * 2; x < (Main.Resolution.X / 5) * 3; x += Brick.defaultBrickSize.X + 10)
            {
                for (int y = 0; y < (Main.Resolution.Y / 4) - 100; y += Brick.defaultBrickSize.Y + 10)
                {
                    this.CreateBrick(new Point((int)x, y), BrickType.DefaultBrick);
                    Main.target++;

                }
            }

            for (float x = (Main.Resolution.X / 5); x < (Main.Resolution.X / 5) * 2; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y = (Main.Resolution.Y / 4); y < (Main.Resolution.Y / 4) * 2 - 100; y += Brick.defaultBrickSize.Y + 10)
                {
                    this.CreateBrick(new Point((int)x, (int)y), BrickType.DefaultBrick);
                    Main.target++;
                }
            }


            for (float x = (Main.Resolution.X / 5) * 3; x < (Main.Resolution.X / 5) * 4; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y = (Main.Resolution.Y / 4); y < (Main.Resolution.Y / 4) * 2 - 100; y += Brick.defaultBrickSize.Y + 10)
                {
                    this.CreateBrick(new Point((int)x, (int)y), BrickType.DefaultBrick);
                    Main.target++;
                }
            }

            for (float x = (Main.Resolution.X / 5) * 2; x < (Main.Resolution.X / 5) * 3; x += Brick.defaultBrickSize.X + 10)
            {
                for (float y = (Main.Resolution.Y / 4) * 2; y < (Main.Resolution.Y / 4) * 3 - 100; y += Brick.defaultBrickSize.Y + 10)
                {
                    this.CreateBrick(new Point((int)x, (int)y), BrickType.DefaultBrick);
                    Main.target++;

                }
            }
       
        }

        /// <summary>
        /// Spawnol egy collectible-t.
        /// </summary>
        public void SpawnCollectible(CollectibleType type, Point position, float speed)
        {
            this.EntityList.Add(new Collectible(position.X, position.Y, type, speed));
        }

        /// <summary>
        /// Eltöröl egy Entity-t
        /// </summary>
        public void DestroyEntity(Entity entity)
        {
            if (entity != null && this.EntityList.Contains(entity))
            {
                this.EntityList.Remove(entity);
            }
            else
            {
                throw new Exception("Entity can't be destroyed, it doesn't exist.");
            }
        }
        
        /// <summary>
        /// Spawnol egy labdát.
        /// </summary>
        public Ball CreateBall(Point position, BallType type)
        {


            ball= new Ball(position.X, position.Y, type);
            ball.Speed = new Vector2(0);
            this.EntityList.Add(ball);
            return ball;
        }

        /// <summary>
        /// Spawnol egy téglát.
        /// </summary>
        public Brick CreateBrick(Point position, BrickType type, ParticleType particleType = ParticleType.DefaultBrick, byte hitsNeeded = 1)
        {
            Brick brick = new Brick(position.X, position.Y, type, particleType, hitsNeeded);
            this.EntityList.Add(brick);
            return brick;
        }

        /// <summary>
        /// Spawnol egy játékost.
        /// </summary>
        public Player CreatePlayer(Point position, RacketType racketType)
        {
            Player player = new Player(position.X-60, position.Y, racketType);
            this.EntityList.Add(player);
            return player;
        }

        



    }

}
