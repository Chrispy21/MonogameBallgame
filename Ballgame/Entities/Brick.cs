using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace Ballgame.Entities
{
    public class Brick:Entity
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Gets or sets the maximum number of particles that bricks can emit when broken.
        /// </summary>
        private static int maxParticles = 16;

        /// <summary>
        /// Hits needed for the brick to break.
        /// </summary>
        private byte hitsNeeded { get; set; }

        /// <summary>
        /// Gets or sets how many times this brick has been hit.
        /// </summary>
        private byte hits { get; set; }

        /// <summary>
        /// The type of the particle that the brick will emit when broken.
        /// </summary>
        private ParticleType ParticleType { get; set; }

        public static Point defaultBrickSize = new Point(60, 20);

        public Brick(int x, int y, BrickType type, ParticleType particleType, byte hitsNeeded) : base(x, y, Game1.GetBrickSprite(type))
        {
            this.hitsNeeded = hitsNeeded;
            this.ParticleType = particleType;
            this.hits = 0;
        }

        /// <summary>
        /// Gets called when this brick is hit.
        /// </summary>
        /// <param name="ball">The ball which hit the brick.</param>
        private void OnHit(Ball ball)
        {
            this.hits++;

            if (this.hits >= this.hitsNeeded)
            {
                this.OnBreak();
            }
        }

        /// <summary>
        /// Gets called when this brick breaks.
        /// </summary>
        private void OnBreak()
        {
            // Spawning a collectible with a chance
            int chance = rnd.Next(0, 101);
            if (chance <= 30)
            {
                Game1.CurrentLevel.SpawnCollectible((CollectibleType)rnd.Next(0, 3), new Point(this.Body.X, this.Body.Y), 4);
            }
            this.Destroy();
        }

        public override void Update(GameTime gameTime)
        {
            Entity ball = Game1.CurrentLevel.EntityList.Find(x => x is Ball && this.Body.Intersects(x.Body));
            if (ball != null)
            {
                this.OnHit(ball as Ball);
            }
        }

        protected override void Destroy()
        {
            base.Destroy();

            for (int i = 0; i < Game1.rnd.Next(8, maxParticles + 1); i++)
            {
                Game1.CurrentLevel.EntityList.Add(new BrickParticle(this.Body.X + this.Body.Width / 2, this.Body.Y + this.Body.Height / 2, Game1.GetParticleSprite(ParticleType)));
            }
        }
    }
}
