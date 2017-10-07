using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame.Entities
{
    public class Player : MovingEntity
    {
        public int Lives;
        private bool isDead;
        public bool IsInputInverted;

        public Player(int x, int y, RacketType racketType) : base(x, y, Main.GetRacketSprite(racketType))
        {
            this.Lives = 3;
            this.isDead = false;
            this.IsInputInverted = false;
        }

        public override void Update(GameTime gameTime)
        {
            // Az ütő mozgatása billentyűzettel
            KeyboardState keyboardState = Keyboard.GetState();

            // Arra az esetre, ha a player felvett egy trollface-t
            int modifier = this.IsInputInverted ? -1 : 1;
            if (keyboardState.IsKeyDown(Keys.Left) && this.Body.X > 0)
            {
                this.Speed.X = -20 * modifier;
            }
            else if (keyboardState.IsKeyDown(Keys.Right) && this.Body.X + this.Body.Width < Main.Graphics.PreferredBackBufferWidth)
            {
                this.Speed.X = 20 * modifier;
            }
            else
            {
                this.Speed.X = 0;
            }

            // Ha a player-nek nincs több élete, akkor vége
            if (!this.isDead && this.Lives < 0)
            {
                this.Kill();
            }

            base.Update(gameTime);
        }

        private void Kill()
        {
            this.isDead = true;

            // ELTŰNTET MINDENT, NEM BIZTONSÁGOS
            for (int i = Main.CurrentLevel.EntityList.Count - 1; i >= 0; i--)
            {
                Main.CurrentLevel.EntityList[i].Destroy();
            }
        }
    }
}
