using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame
{
    public enum CollisionResult { None = -1, Top, Left, Right, Bottom }

    public abstract class Entity
    {
        /// <summary>
        /// Az entity textúrája.
        /// </summary>
        public Texture2D Sprite { get; private set; }

        /// <summary>
        /// Az entity teste, amiben a pozíciója van eltárolva, valamint az ütközéshez kell.
        /// </summary>
        public Rectangle Body;

        protected Entity(int x, int y, Texture2D sprite)
        {
            this.Sprite = sprite;
            this.Body = new Rectangle(new Point(x, y), new Point(this.Sprite.Width, this.Sprite.Height));
        }

        public virtual void Draw(GameTime gameTime)
        {
            Main.SpriteBatch.Draw(this.Sprite, this.Body, Color.White);
        }

        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// Eltünteti az adott entity-t.
        /// </summary>
        public virtual void Destroy()
        {
            Main.CurrentLevel.DestroyEntity(this);
        }

        public CollisionResult GetIntersectionWith(Entity entity)
        {
            // Calculate half sizes
            float halfWidthA = this.Body.Width / 2.0f;
            float halfHeightA = this.Body.Height / 2.0f;
            float halfWidthB = entity.Body.Width / 2.0f;
            float halfHeightB = entity.Body.Height / 2.0f;

            // Calculate centers
            Vector2 centerA = new Vector2(this.Body.X + halfWidthA, this.Body.Y + halfHeightA);
            Vector2 centerB = new Vector2(entity.Body.X + halfWidthB, entity.Body.Y + halfHeightB);

            // Calculate current and minimum-non-intersecting distances between centers
            float distanceX = Math.Abs(centerA.X - centerB.X);
            float distanceY = Math.Abs(centerA.Y - centerB.Y);
            float minDistanceX = Math.Abs(halfWidthA + halfWidthB);
            float minDistanceY = Math.Abs(halfHeightA + halfHeightB);

            CollisionResult collisionResult = CollisionResult.None;

            if (Math.Abs(distanceX) <= minDistanceX && Math.Abs(distanceY) <= minDistanceY)
            {
                /* collision! */
                float wy = minDistanceX * distanceY;
                float hx = minDistanceY * distanceX;

                if (wy > hx)
                {
                    if (wy > -hx)
                    {
                        /* collision at the top */
                        collisionResult = CollisionResult.Bottom;
                    }
                    else
                    {
                        /* on the left */
                        collisionResult = CollisionResult.Left;
                    }
                }
                else
                {
                    if (wy > -hx)
                    {
                        /* on the right */
                        collisionResult = CollisionResult.Right;
                    }
                    else
                    {
                        /* at the bottom */
                        collisionResult = CollisionResult.Top;
                    }

                }
            }
            return collisionResult;
        }
    }
}
