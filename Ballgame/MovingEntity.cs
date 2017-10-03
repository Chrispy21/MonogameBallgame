using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Ballgame
{
   
        public abstract class MovingEntity : Entity
        {
            /// <summary>
            /// The speed of the entity.
            /// </summary>
            public Vector2 Speed;

            protected MovingEntity(int x, int y, Texture2D sprite)
                : base(x, y, sprite)
            {
                this.Speed = new Vector2(0, 0);
            }

            public override void Update(GameTime gameTime)
            {
                this.Move();
            }

            private void Move()
            {
                this.Body.X += (int)this.Speed.X;
                this.Body.Y += (int)this.Speed.Y;
            }
        }
    }

