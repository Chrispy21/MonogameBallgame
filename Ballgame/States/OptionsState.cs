using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        private bool assigning = false;
        private ButtonMenu clickedKey;

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
                Text = Main.moveLeft.ToString(),
            };
            LeftButton.Click += LeftButton_Click;

            RightButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 18, 300),
                Text = Main.moveRight.ToString(),
            };
            RightButton.Click += RightButton_Click;

            StartButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 18, 400),
                Text = Main.startBall.ToString(),
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
            SpriteBatch.Draw(Main.options, new Rectangle(515, 0, 250, 40), Color.White);
            SpriteBatch.Draw(Main.leftText, new Rectangle(455, 210, 110, 35), Color.White);
            SpriteBatch.Draw(Main.rightText, new Rectangle(455, 310, 110, 35), Color.White);
            SpriteBatch.Draw(Main.startText, new Rectangle(455, 410, 110, 35), Color.White);
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

            KeyboardState ks = Keyboard.GetState();
            Keys[] pressedKeys = ks.GetPressedKeys();
            if(pressedKeys.Length > 0)
            {
                if (clickedKey == LeftButton)
                {
                    Main.moveLeft = pressedKeys[0];
                    LeftButton.Text = Main.moveLeft.ToString();
                }
                else if (clickedKey == RightButton)
                {
                    Main.moveRight = pressedKeys[0];
                    RightButton.Text = Main.moveRight.ToString();
                }
                else if (clickedKey == StartButton)
                {
                    Main.startBall = pressedKeys[0];
                    StartButton.Text = Main.startBall.ToString();
                }
                assigning = false;
            }
            if(!assigning)
            {
                clickedKey = null;
            }

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _game._nextState = _game.menuState;
        }

        private void LeftButton_Click(object sender, EventArgs e)
        {
            //Keybindings beállítása balra
            //Mainben kell létrehozni
            clickedKey = LeftButton;
            assigning = true;
            LeftButton.Text = "Press a key";
        }

        private void RightButton_Click(object sender, EventArgs e)
        {
            //Keybindings beállítása jobbra
            //Mainben kell létrehozni
            clickedKey = RightButton;
            assigning = true;
            RightButton.Text = "Press a key";
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            //Keybindings beállítása elindításhoz
            //Mainben kell létrehozni
            clickedKey = StartButton;
            assigning = true;
            StartButton.Text = "Press a key";
        }       
    }
}
