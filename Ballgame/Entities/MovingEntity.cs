using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ballgame.Entities
{
    public abstract class MovingEntity : Entity
    {
        /// <summary>
        /// Az entity sebessége
        /// </summary>
        public Vector2 Speed;
        public float Velocity;

        protected MovingEntity(int x, int y, Texture2D sprite)
            : base(x, y, sprite)
        {
            this.Speed = new Vector2(0, 0);
            this.Velocity = 1;
        }

        public override void Update(GameTime gameTime)
        {
            this.Move();
        }

        private void Move()
        {
            this.Body.X += (int)(this.Velocity * this.Speed.X);
            this.Body.Y += (int)(this.Velocity * this.Speed.Y);
        }
    }
}

