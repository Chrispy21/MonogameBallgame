using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ballgame.Entities
{
    public class Ball : MovingEntity
    {
        //public static int touch;
        public Ball(int x, int y, BallType type) : base(x, y, Main.GetBallSprite(type)) { }
        public bool pluszBall = false;
        public static bool IsDestroy = true;
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
                       
            // Ellenőrzi, hogy háromszor leesett a labda
            // a "labda" játkos élete 

            if (this.Body.Y >= Main.Resolution.Y - 80 + this.Body.Height)
            {
                this.Speed.Y *= -1;
                Main.hp--;             
            }
            this.Speed *= 1.0001f;
        }

       

        /// <summary>
        /// Az ütközéseket kezeli más Entitykkel.
        /// </summary>
        private void HandleCollisions()
        {
            
            // Ellenőrzi a tégla és a labda ütközését
            if (Main.CurrentLevel.EntityList.Find(b => b is Brick && this.Body.Intersects(b.Body)) != null)
            {
                Main.score += 10;
                this.Speed.Y *=-1;
                //this.Speed.X *= -1;
            }
          
                // Ellenőrzi az ütő és a labda ütközését.
                if (Main.CurrentLevel.Player.Body.Intersects(this.Body))
                {
                    this.Speed.Y *= -1;
                   
                }
            
            // Megakadályozza, hogy a labda kimenjen a képernyőről.
            if (this.Body.X <= 0 || this.Body.X + this.Body.Width >= Main.Resolution.X)
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
