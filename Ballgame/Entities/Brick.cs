using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ballgame.Entities
{
    public class Brick : Entity
    {
        private static Random rnd = new Random();

        /// <summary>
        /// Maximum ennyi részecskére robban szét a tégla.
        /// </summary>
        private static int maxParticles = 16;

        /// <summary>
        /// Ennyi ütés kell a téglának, hogy kitörjön.
        /// </summary>
        private byte hitsNeeded { get; set; }

        /// <summary>
        /// Ennyiszer ütötte meg a labda a téglát.
        /// </summary>
        private byte hits { get; set; }

        /// <summary>
        /// A részecske sorszáma, ami ebből a téglából jön széttöréskor. (Main.cs)
        /// </summary>
        private ParticleType ParticleType { get; set; }

        public static Point defaultBrickSize = new Point(60, 20);

        public Brick(int x, int y, BrickType type, ParticleType particleType, byte hitsNeeded) : base(x, y, Main.GetBrickSprite(type))
        {
            this.hitsNeeded = hitsNeeded;
            this.ParticleType = particleType;
            this.hits = 0;
        }

        /// <summary>
        /// Akkor hívódik meg amikor a téglát megüti a labda.
        /// </summary>
        private void OnHit(Ball ball)
        {
            this.hits++;

            if (this.hits >= this.hitsNeeded)
            {
                this.OnBreak();
            }
        }

        /// <summary>
        /// Akkor fut le, amikor a tégla széttörik.
        /// </summary>
        private void OnBreak()
        {
            // Az esélye annak, hogy egy collectible-t fog dobni
            int chance = rnd.Next(0, 101);

            // chance <= 15: 15% esély
            if (chance <= 33)
            {
                Main.CurrentLevel.SpawnCollectible((CollectibleType)rnd.Next(0, Enum.GetValues(typeof(CollectibleType)).Length), new Point(this.Body.X, this.Body.Y), 4);
            }
            this.Destroy();
        }

        public override void Update(GameTime gameTime)
        {
            Entity ball = Main.CurrentLevel.EntityList.Find(x => x is Ball && this.Body.Intersects(x.Body));
            if (ball != null)
            {
                this.OnHit(ball as Ball);
            }
        }

        public override void Destroy()
        {
            base.Destroy();

            for (int i = 0; i < Main.rnd.Next(maxParticles / 2, maxParticles + 1); i++)
            {
                Main.CurrentLevel.EntityList.Add(new BrickParticle(this.Body.X + this.Body.Width / 2, this.Body.Y + this.Body.Height / 2, Main.GetParticleSprite(ParticleType)));
            }
        }
    }
}
