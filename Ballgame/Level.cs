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
            /*
            if (this.Balls.Count > 1)
            {
                for (int i = this.Balls.Count - 1; i >= 0; i--)
                {
                    Ball Ball = this.Balls[i];
                    
                    
                }
            }*/


            

            
        }

        public void Draw(GameTime gameTime)
        {
            // A pályán lévő Entityk rajzolása
            foreach (Entity e in this.EntityList)
            {
                e.Draw(gameTime);
            }
        }

        /// <summary>
        /// Feltölti a pályát téglákkal
        /// </summary>
        public void GenerateBricks()
        {
            for (int x = 10; x < Main.Resolution.X -10; x += Brick.defaultBrickSize.X)
            {
                for (int y = 0; y < Main.Resolution.Y / 3; y += Brick.defaultBrickSize.Y)
                {
                    this.CreateBrick(new Point(x, y), BrickType.DefaultBrick);
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
            Ball ball = new Ball(position.X, position.Y, type);
            ball.Speed = new Vector2(Main.baseBallSpeed, Main.baseBallSpeed);
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
