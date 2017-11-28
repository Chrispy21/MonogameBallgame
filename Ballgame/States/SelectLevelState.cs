using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Ballgame.Controls;
using Ballgame.Levels;

namespace Ballgame.States
{
    public class SelectLevelState : State
    {
        Texture2D buttonTexture;
        Texture2D level1Texture;
        Texture2D level2Texture;
        Texture2D level3Texture;
        SpriteFont buttonFont;

        ButtonMenu backButton;
        ButtonMenu level1Button;
        ButtonMenu level2Button;
        ButtonMenu level3Button;

        public SelectLevelState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            buttonTexture = content.Load<Texture2D>("Controls/button_0");
            buttonFont = content.Load<SpriteFont>("MenuFont");
            level1Texture = content.Load<Texture2D>("Levels/level1");
            level2Texture = content.Load<Texture2D>("Levels/level2");
            level3Texture = content.Load<Texture2D>("Levels/level3");

            backButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(30, 600),
                Text = "Back",
            };

            backButton.Click += BackButton_Click;

            level1Button = new ButtonMenu(level1Texture, buttonFont)
            {
                Position = new Vector2(100, 200),
                Text = null,
            };
            level1Button.Click += Level1Button_Click;

            level2Button = new ButtonMenu(level2Texture, buttonFont)
            {
                Position = new Vector2(400, 200),
                Text = null,
            };
            level2Button.Click += Level2Button_Click;

            level3Button = new ButtonMenu(level3Texture, buttonFont)
            {
                Position = new Vector2(700, 200),
                Text = null,
            };
            level3Button.Click += Level3Button_Click;
        }

        private void Level3Button_Click(object sender, EventArgs e)
        {
            Main.SetLevel(typeof(Level3));
            Main.CurrentLevel.GenerateBricks();
        }

        private void Level2Button_Click(object sender, EventArgs e)
        {
            Main.SetLevel(Main.LevelList[Main.CurrentLevelIndex +2]);
        }

        private void Level1Button_Click(object sender, EventArgs e)
        {
            Main.SetLevel(typeof(Level1));
            Main.CurrentLevel.GenerateBricks();
        }

        public override void Draw(GameTime gameTime, SpriteBatch SpriteBatch)
        {
            backButton.Draw(gameTime, SpriteBatch);
            level1Button.Draw(gameTime, SpriteBatch);
            level2Button.Draw(gameTime, SpriteBatch);
            level3Button.Draw(gameTime, SpriteBatch);
            //Select Level kiíratása betűméret változtatásával
            SpriteBatch.Draw(Main.selectLevel, new Rectangle(500, 0, 280, 50), Color.White);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            backButton.Update(gameTime);
            level1Button.Update(gameTime);
            level2Button.Update(gameTime);
            level3Button.Update(gameTime);
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _game._nextState = _game.menuState;
        }
    }
}
