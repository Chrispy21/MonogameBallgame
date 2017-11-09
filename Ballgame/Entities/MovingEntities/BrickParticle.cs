using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Ballgame.Entities
{
    public class BrickParticle:MovingEntity
    {
        public float Size { get; private set; }
        private float rotation;
        public static float baseParticleSpeed = 8;
        private static float baseScale = 0.8f;

        public BrickParticle(int x, int y, Texture2D sprite) : base(x, y, sprite)
        {
            double angle = Main.rnd.Next(361);
            this.Speed = new Vector2(
                baseParticleSpeed * (float)Math.Cos(angle),
                baseParticleSpeed * (float)Math.Sin(angle));

            this.rotation = Main.rnd.Next(0, 360);

            this.Size = baseScale;
        }

        public override void Draw(GameTime gameTime)
        {
            Main.SpriteBatch.Draw(this.Sprite, new Vector2(this.Body.X, this.Body.Y), null, Color.White, this.rotation, Vector2.Zero, this.Size, SpriteEffects.None, 0f);
            if (this.Size > 0f)
            {
                this.Size -= 0.025f;
                this.rotation += 0.025f;
            }
        }
    }

}
