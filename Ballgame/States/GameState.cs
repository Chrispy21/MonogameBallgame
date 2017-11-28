using Ballgame.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
            SpriteBatch.Draw(Main.background, new Rectangle(0, 0, 1280, 768), Color.White);
            SpriteBatch.Draw(Main.bottomBar, new Rectangle(0, 642, 1280, 35), Color.White);
            Main.CurrentLevel.Draw(gameTime);
            SpriteBatch.DrawString(Main.Healt, Main.hp.ToString(), new Vector2(210, 653), Color.Red);
            SpriteBatch.DrawString(Main.Score,  Main.score.ToString(), new Vector2(1245, 653), Color.Yellow);
            SpriteBatch.DrawString(Main.targets,  Main.target.ToString(), new Vector2(685, 653), Color.Brown);
            if (Main.space)
            {
                SpriteBatch.Draw(Main.spacestart, new Rectangle(0, 0, 1280, 768), Color.White);
            }
        }

        public override void PostUpdate(GameTime gameTime)
        {
            
        }

        public override void Update(GameTime gameTime)
        {
            Main.CurrentLevel.Update(gameTime);
        }
    }
}
