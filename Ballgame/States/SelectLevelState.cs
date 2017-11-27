using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ballgame.Controls;

namespace Ballgame.States
{
    public class SelectLevelState : State
    {
        Texture2D buttonTexture;
        SpriteFont buttonFont;

        ButtonMenu backButton;

        public SelectLevelState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            buttonTexture = content.Load<Texture2D>("Controls/button_0");
            buttonFont = content.Load<SpriteFont>("MenuFont");

            backButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(30, 600),
                Text = "Back",
            };

            backButton.Click += BackButton_Click;
        }

        public override void Draw(GameTime gameTime, SpriteBatch SpriteBatch)
        {
            backButton.Draw(gameTime, SpriteBatch);
            //Select Level kiíratása betűméret változtatásával
            SpriteBatch.Draw(Main.selectLevel, new Rectangle(500, 0, 280, 50), Color.White);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            backButton.Update(gameTime);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _game._nextState = _game.menuState;
        }
    }
}
