using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ballgame.Entities;

namespace Ballgame.Entities
{
    public class Player : MovingEntity
    {
        public enum BallType { Bowling };
        public bool IsInputInverted;
        public int Lives;

        public Player(int x, int y, RacketType racketType) : base(x, y, Main.GetRacketSprite(racketType))
        {
            this.IsInputInverted = false;
        }

        public override void Update(GameTime gameTime)
        {
            // Az ütő mozgatása billentyűzettel
            KeyboardState keyboardState = Keyboard.GetState();

            // Arra az esetre, ha a player felvett egy trollface-t
            //Javítani
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
            
            base.Update(gameTime);
        }
    }
}
