using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame
{
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

        public abstract void Update(GameTime gameTime);

        
        /// <summary>
        /// Eltünteti az adott entity-t.
        /// </summary>
        public virtual void Destroy()
        {
            Main.CurrentLevel.DestroyEntity(this);
        }
    }
}
