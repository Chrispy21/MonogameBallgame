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
        public bool isFrozen;
        public bool scaleEffect;

        public Player(int x, int y, RacketType racketType)
            : base(x, y, Main.GetRacketSprite(racketType))
        {
            this.IsInputInverted = false;
            this.isFrozen = false;
        }

        public override void Update(GameTime gameTime)
        {
            // Az ütő mozgatása billentyűzettel
            KeyboardState keyboardState = Keyboard.GetState();

            // Ha nincs lefagyva a player
            if (!this.isFrozen)
            {
                // Arra az esetre, ha a player felvett egy trollface-t
                if (this.IsInputInverted)
                {
                    if (keyboardState.IsKeyDown(Keys.Left) && this.Body.X + this.Body.Width < Main.Resolution.X)
                    {
                        this.Speed.X = 20;

                    }

                    else if (keyboardState.IsKeyDown(Keys.Right) && this.Body.X > 0)
                    {
                        this.Speed.X = -20;
                    }

                    else
                    {
                        this.Speed.X = 0;
                    }
                }

                else
                {
                    if (keyboardState.IsKeyDown(Keys.Left) && this.Body.X > 0)
                    {
                        this.Speed.X = -20;

                    }

                    else if (keyboardState.IsKeyDown(Keys.Right) && this.Body.X + this.Body.Width < Main.Resolution.X)
                    {
                        this.Speed.X = 20;
                    }

                    else
                    {
                        this.Speed.X = 0;
                    }
                }
            }

            else
            {
                this.Speed.X = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (!scaleEffect)
            {
                Main.SpriteBatch.Draw(this.Sprite,
                     new Vector2(this.Body.X, this.Body.Y),
                     null,
                     Color.White,
                     0,
                     Vector2.Zero,
                     1.0f, // Ez az eredeti mérete az ütőnek
                     SpriteEffects.None,
                     0);
            }

            else
            {
                Main.SpriteBatch.Draw(this.Sprite,
                    new Vector2(this.Body.X, this.Body.Y),
                    null, Color.White, 0, Vector2.Zero, 1.2f,  /// Ez az 1,2 x nagyobbítja arányosan az ütőt 
                    SpriteEffects.None, 0);
            }
        }
    }
}
