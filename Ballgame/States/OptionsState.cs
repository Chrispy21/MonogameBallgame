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
    class OptionsState : State
    {
        Texture2D buttonTexture;
        SpriteFont buttonFont;

        ButtonMenu backButton;
        ButtonMenu LeftButton;
        ButtonMenu RightButton;
        ButtonMenu StartButton;

        public OptionsState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            buttonTexture = content.Load<Texture2D>("Controls/button_0");
            buttonFont = content.Load<SpriteFont>("MenuFont");

            backButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(30, 600),
                Text = "Back",
            };
            backButton.Click += BackButton_Click;

            LeftButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 18, 200),
                Text = "Back",
            };
            LeftButton.Click += LeftButton_Click;

            RightButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 18, 300),
                Text = "Back",
            };
            RightButton.Click += RightButton_Click;

            StartButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 18, 400),
                Text = "Back",
            };
            StartButton.Click += StartButton_Click;
        }

        public override void Draw(GameTime gameTime, SpriteBatch SpriteBatch)
        {
            backButton.Draw(gameTime, SpriteBatch);
            LeftButton.Draw(gameTime, SpriteBatch);
            RightButton.Draw(gameTime, SpriteBatch);
            StartButton.Draw(gameTime, SpriteBatch);
            //Options kiíratása betűméret változtatásával 
            SpriteBatch.DrawString(Main.MenuSprite, "Options", new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 30, 40), Color.WhiteSmoke, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
            SpriteBatch.DrawString(Main.MenuSprite, "Left", new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 110, 200), Color.WhiteSmoke, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
            SpriteBatch.DrawString(Main.MenuSprite, "Right", new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 110, 300), Color.WhiteSmoke, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
            SpriteBatch.DrawString(Main.MenuSprite, "Start", new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 110, 400), Color.WhiteSmoke, 0, Vector2.Zero, 2, SpriteEffects.None, 0);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            backButton.Update(gameTime);
            LeftButton.Update(gameTime);
            RightButton.Update(gameTime);
            StartButton.Update(gameTime);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _game._nextState = _game.menuState;
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            //Keybindings beállítása balra
            //Mainben kell létrehozni
            
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            //Keybindings beállítása jobbra
            //Mainben kell létrehozni
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //Keybindings beállítása elindításhoz
            //Mainben kell létrehozni
        }       
    }
}
