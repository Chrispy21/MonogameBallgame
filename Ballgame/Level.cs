using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame
{
    class Level
    {
        public List<Entity> EntityList { get; private set; }

        public Player Player { get; private set; }

        public Level()
        {
            this.EntityList = new List<Entity>();
            this.Initialize();
        }

        private void Initialize()
        {
            // Initialize the player's racket
            Player = this.CreatePlayer(new Point(Game1.Resolution.Width / 2, Game1.Resolution.Height - 100), RacketType.BlueGray);

            // Spawn the first ball
            this.CreateBall(new Point(this.Player.Body.X, this.Player.Body.Y - 100), BallType.Bowling);
        }

        public void Update(GameTime gameTime)
        {
            // Update entities
            for (int i = this.EntityList.Count - 1; i >= 0; i--)
            {
                this.EntityList[i].Update(gameTime);
            }

            if (this.EntityList.Count(x => x is Ball) <= 0)
            {
                this.Player.Lives--;
            }
        }

        public void Draw(GameTime gameTime)
        {
            // Draw all entities on this level
            foreach (Entity e in this.EntityList)
            {
                e.Draw(gameTime);
            }
        }

        /// <summary>
        /// Fills the level with bricks.
        /// </summary>
        public void GenerateBricks()
        {
            for (int x = 0; x < Game1.Resolution.Width; x += Brick.defaultBrickSize.X)
            {
                for (int y = 0; y < Game1.Resolution.Height / 2; y += Brick.defaultBrickSize.Y)
                {
                    this.CreateBrick(new Point(x, y), BrickType.DefaultBrick);
                }
            }
        }

        /// <summary>
        /// Spawns a collectible.
        /// </summary>
        /// <param name="type">The type of the collectible.</param>
        /// <param name="position">The position where the collectible should spawn to.</param>
        /// <param name="speed">The default fall speed of the collectible.</param>
        public void SpawnCollectible(CollectibleType type, Point position, float speed)
        {
            this.EntityList.Add(new Collectible(position.X, position.Y, type, speed));
        }

        /// <summary>
        /// Removes an entity from the entity list.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
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
        /// Spawns a new ball.
        /// </summary>
        /// <param name="position">The position where the ball should be created.</param>
        /// <returns>The created ball.</returns>
        public Ball CreateBall(Point position, BallType type)
        {
            Ball ball = new Ball(position.X, position.Y, type);
            ball.Speed = new Vector2(Game1.baseBallSpeed, Game1.baseBallSpeed);
            this.EntityList.Add(ball);
            return ball;
        }

        /// <summary>
        /// Instantiates a brick.
        /// </summary>
        /// <param name="position">The position of the brick.</param>
        /// <param name="type">The type of the brick.</param>
        /// <param name="particleType">The particle type of the brick.</param>
        /// <param name="hitsNeeded">Hits needed for the brick to break.</param>
        /// <returns>The created brick.</returns>
        public Brick CreateBrick(Point position, BrickType type, ParticleType particleType = ParticleType.DefaultBrick, byte hitsNeeded = 1)
        {
            Brick brick = new Brick(position.X, position.Y, type, particleType, hitsNeeded);
            this.EntityList.Add(brick);
            return brick;
        }

        /// <summary>
        /// Instantiates a player.
        /// </summary>
        /// <param name="position">The position of the player.</param>
        /// <param name="racketType">The type of the racket for the player.</param>
        /// <returns>The created player.</returns>
        public Player CreatePlayer(Point position, RacketType racketType)
        {
            Player player = new Player(position.X, position.Y, racketType);
            this.EntityList.Add(player);
            return player;
        }
    }

}
