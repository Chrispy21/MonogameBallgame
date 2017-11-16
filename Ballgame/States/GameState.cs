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
            Main.CurrentLevel.Draw(gameTime);
            SpriteBatch.DrawString(Main.Healt, "Health Points: " + Main.hp, new Vector2(10, 650), Color.Aqua);
            SpriteBatch.DrawString(Main.Score, "Score: " + Main.score, new Vector2(1000, 650), Color.DarkOliveGreen);
            SpriteBatch.DrawString(Main.targets, "Targets: " + Main.target, new Vector2(500, 650), Color.WhiteSmoke);
            if (Main.space)
            {
                SpriteBatch.DrawString(Main.Start, "Press Space to Start", new Vector2((Main.Graphics.PreferredBackBufferWidth / 2)-240, Main.Graphics.PreferredBackBufferHeight / 2), Color.White);
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
