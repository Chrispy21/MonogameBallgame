using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ballgame.Controls;

namespace Ballgame.States
{
    public class DescriptionState : State
    {
        Texture2D buttonTexture;
        SpriteFont buttonFont;

        ButtonMenu backButton;

        public DescriptionState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
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
            //Kép betöltése (jelenleg anonymous szöveg DE az kép)
            SpriteBatch.Draw(Main.descriptionText, new Rectangle(0, 0, 1280, 768), Color.White);
            //Description kiíratása betűméret változtatásával 
            SpriteBatch.Draw(Main.description, new Rectangle(500, 0, 280, 50), Color.White);

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
