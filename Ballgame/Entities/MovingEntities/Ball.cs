using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ballgame.Entities
{
    public class Ball : MovingEntity
    {
        public bool pluszBall = false;
        public static bool IsDestroy = true;
        //public static int touch;

        public static float maxBounceAngle = 60f;

        private static int cooldownTime = 100;
        private bool paddleCooldown;

        public Ball(int x, int y, BallType type) : base(x, y, Main.GetBallSprite(type))
        {
            this.paddleCooldown = false;
        }

        public static void Kill()
        {
            for (int i = Main.CurrentLevel.EntityList.Count - 1; i >= 0; i--)
            {
                if (IsDestroy)
                {
                    Main.CurrentLevel.EntityList[i].Destroy();
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            this.HandleCollisions();

            // Ellenőrzi, hogy háromszor leesett-e a labda
            // a "labda" játkos élete 

            if (this.Body.Y >= Main.Resolution.Y - 80 + this.Body.Height)
            {
                this.Speed.Y *= -1;
                Main.hp--;
            }
            this.Velocity *= 1.0001f;
        }



        /// <summary>
        /// Az ütközéseket kezeli más Entitykkel.
        /// </summary>
        private void HandleCollisions()
        {
            // Megakadályozza, hogy a labda kimenjen a képernyőről.
            if (this.Body.X + this.Body.Width >= Main.Resolution.X)
            {
                this.Speed.X *= -1;
                this.Body.X = (int)(Main.Resolution.X - this.Body.Width);
            }
            else if (this.Body.X <= 0)
            {
                this.Speed.X *= -1;
                this.Body.X = 0;
            }
            if (this.Body.Y <= 0)
            {
                this.Speed.Y *= -1;
                this.Body.Y = 0;
            }

            foreach (Brick b in Main.CurrentLevel.EntityList.FindAll(x => x is Brick))
            {
                CollisionResult rslt = this.GetIntersectionWith(b);
                if (rslt != CollisionResult.None)
                {
                    if (rslt == CollisionResult.Top || rslt == CollisionResult.Bottom)
                    {
                        this.Speed.Y *= -1;
                    }
                    else
                    {
                        this.Speed.X *= -1;
                    }

                    Main.score += 10;

                    break;
                }
            }

            CollisionResult result = this.GetIntersectionWith(Main.CurrentLevel.Player);

            if (result != CollisionResult.None && !this.paddleCooldown)
            {
                Player p = Main.CurrentLevel.Player;

                if(result == CollisionResult.Top || result == CollisionResult.Bottom)
                {
                    float third = p.Body.X + p.Body.Width / 3;
                    if (this.Body.X < third)
                    {
                        this.Speed = Vector2.Reflect(this.Speed, new Vector2(-0.196f, -0.981f));
                    }
                    else if (this.Body.X < 2 * third)
                    {
                        this.Speed = Vector2.Reflect(this.Speed, new Vector2(0, -1));
                    }
                    else
                    {
                        this.Speed = Vector2.Reflect(this.Speed, new Vector2(0.196f, -0.981f));
                    }

                }
                else if(result == CollisionResult.Left || result == CollisionResult.Right)
                {
                    float third = p.Body.Y + p.Body.Height / 3;
                    if (this.Body.Y < third)
                    {
                        this.Speed = Vector2.Reflect(this.Speed, new Vector2(-0.981f, 0.196f));
                    }
                    else if (this.Body.Y < 2 * third)
                    {
                        this.Speed = Vector2.Reflect(this.Speed, new Vector2(-1, 0));
                    }
                    else
                    {
                        this.Speed = Vector2.Reflect(this.Speed, new Vector2(-0.981f, -0.196f));
                    }
                }

                this.SetCooldown();
            }
        }

        private void SetCooldown()
        {
            if(!this.paddleCooldown)
            {
                this.paddleCooldown = true;
                Main.QueueAction(new DelayedAction(
                () => this.paddleCooldown = false,
                cooldownTime,
                false));
            }
        }
    }
}
