using Ballgame.Entities;
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
    public class GameState : State
    {
        public Player player;


        public GameState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch SpriteBatch)
        {
            //Main.CurrentLevel.Draw(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            //Main.CurrentLevel.Update(gameTime);
        }
    }
}
