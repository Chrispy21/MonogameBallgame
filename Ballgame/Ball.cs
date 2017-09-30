using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ballgame
{
    class Ball:MovingEntity
    {
        public Ball(int x, int y, BallType type) : base(x, y, Game1.GetBallSprite(type)) { }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            this.HandleCollisions();

            // Check if the ball fell down
            if (this.Body.Y >= Game1.Resolution.Height + this.Body.Height)
            {
                this.Destroy();
            }

            this.Speed *= 1.0001f;
        }

        /// <summary>
        /// Handles collisions with other entities.
        /// </summary>
        private void HandleCollisions()
        {
            // Check for brick-ball collision
            if (Game1.CurrentLevel.EntityList.Find(b => b is Brick && this.Body.Intersects(b.Body)) != null)
            {
                this.Speed.Y *= -1;
            }

            // Check for racket-ball collision
            if (Game1.CurrentLevel.Player.Body.Intersects(this.Body))
            {
                this.Speed.Y *= -1;
            }

            // Prevent ball from going out of the screen
            if (this.Body.X <= 0 || this.Body.X + this.Body.Width >= Main.Resolution.Width)
            {
                this.Speed.X *= -1;
            }
            if (this.Body.Y <= 0)
            {
                this.Speed.Y *= -1;
            }
        }
    }
}
