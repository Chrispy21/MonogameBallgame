using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame
{
    public abstract class Entity
    {
        /// <summary>
        /// The sprite of the entity.
        /// </summary>
        public Texture2D Sprite { get; private set; }

        /// <summary>
        /// The body rectangle of the entity, which holds it's position and is used as a collision box.
        /// </summary>
        public Rectangle Body;

        protected Entity(int x, int y, Texture2D sprite)
        {
            this.Sprite = sprite;
            this.Body = new Rectangle(new Point(x, y), new Point(this.Sprite.Width, this.Sprite.Height));
        }

        public virtual void Draw(GameTime gameTime)
        {
            Game1.SpriteBatch.Draw(this.Sprite, this.Body, Color.White);
        }

        /// <summary>
        /// Called when the game updates itself and if this entity is also part of the main entity pool.
        /// </summary>
        /// <param name="gameTime"></param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Removes the entity from the level's entity pool.
        /// </summary>
        protected virtual void Destroy()
        {
            Game1.CurrentLevel.DestroyEntity(this);
        }
    }
}
