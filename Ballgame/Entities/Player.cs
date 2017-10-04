using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame.Entities
{
    public class Player:Entity
    {
        public int Lives;
        private bool isDead;
        public bool IsInputInverted;

        public Player(int x, int y, RacketType racketType) : base(x, y, Game1.GetRacketSprite(racketType))
        {
            this.Lives = 3;
            this.isDead = false;
            this.IsInputInverted = false;
        }

        public override void Update(GameTime gameTime)
        {
            // Moving the player's racket with the mouse
            MouseState mouseState = Mouse.GetState();
            if (!this.IsInputInverted)
            {
                // Normally
                this.Body.X = mouseState.X - this.Body.Width / 2;
            }
            else
            {
                // For when an input inverting collectible is picked up (e.g Trollface)
                this.Body.X = Game1.Resolution.Width - mouseState.X - this.Body.Width / 2;
            }

            // If the player has no lives left, kill it
            if (!this.isDead && this.Lives < 0)
            {
                this.Kill();
            }
        }

        private void Kill()
        {
            this.isDead = true;
        }
    }
}
