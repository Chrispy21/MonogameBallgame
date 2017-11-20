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
            SpriteBatch.DrawString(Main.MenuSprite, "Select Level", new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 30, 40), Color.WhiteSmoke, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
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
