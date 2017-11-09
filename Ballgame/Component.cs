using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ballgame
{
    public abstract class Component
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch SpriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
