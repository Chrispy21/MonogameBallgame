using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ballgame.States
{
    public abstract class State
    {
        protected ContentManager _content;
        protected GraphicsDevice _graphicsDevice;
        protected Main _game;

        public abstract void Draw(GameTime gameTime, SpriteBatch SpriteBatch);
        public abstract void PostUpdate(GameTime gameTime);

        public State(Main game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _content = content;
        }

        public abstract void Update(GameTime gameTime);
    }
}
