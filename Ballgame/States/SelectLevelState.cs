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
using Ballgame.Entities;
using Ballgame.States;

namespace Ballgame.States
{
    public class SelectLevelState : State
    {
        Texture2D buttonTexture;
        SpriteFont buttonFont;

        ButtonMenu backButton;
        ButtonMenu Level1Button;
        ButtonMenu Level2Button;
        ButtonMenu Level3Button;
        ButtonMenu Level4Button;
        ButtonMenu Level5Button;
        ButtonMenu Level6Button;
        ButtonMenu RandomLevelButton;

        Random rnd = new Random();

        public SelectLevelState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            buttonTexture = content.Load<Texture2D>("Controls/button_0");
            buttonFont = content.Load<SpriteFont>("MenuFont");



            Level1Button = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(100, 250),
                Text = "Level1",
            };
            Level1Button.Click += Level1Button_Click;

            Level2Button = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(400, 250),
                Text = "Level2",
            };
            Level2Button.Click += Level2Button_Click;

            Level3Button = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(700, 250),
                Text = "Level3",
            };
            Level3Button.Click += Level3Button_Click;

            Level4Button = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(100, 500),
                Text = "Level4",
            };
            Level4Button.Click += Level4Button_Click;

            Level5Button = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(400, 500),

                Text = "Level5",
            };
            Level5Button.Click += Level5Button_Click;
            Level6Button = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(700, 500),
                Text = "Level6",
            };
            Level6Button.Click += Level6Button_Click;



            backButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(30, 600),
                Text = "Back",
            };

            backButton.Click += BackButton_Click;
            
            RandomLevelButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2(1000, 600),
                Text = "Rnd",
            };
            RandomLevelButton.Click += RandomLevel_Click;
            
        }

        public override void Draw(GameTime gameTime, SpriteBatch SpriteBatch)
        {
            backButton.Draw(gameTime, SpriteBatch);
            Level1Button.Draw(gameTime, SpriteBatch);
            Level2Button.Draw(gameTime, SpriteBatch);
            Level3Button.Draw(gameTime, SpriteBatch);
            Level4Button.Draw(gameTime, SpriteBatch);
            Level5Button.Draw(gameTime, SpriteBatch);
            Level6Button.Draw(gameTime, SpriteBatch);
            RandomLevelButton.Draw(gameTime, SpriteBatch);
            //Select Level kiíratása betűméret változtatásával
            SpriteBatch.Draw(Main.selectLevel, new Rectangle(500, 0, 280, 50), Color.White);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            backButton.Update(gameTime);
            Level1Button.Update(gameTime);
            Level2Button.Update(gameTime);
            Level3Button.Update(gameTime);
            Level4Button.Update(gameTime);
            Level5Button.Update(gameTime);
            Level6Button.Update(gameTime);
            RandomLevelButton.Update(gameTime);

            

        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            _game._nextState = _game.menuState;
        }

        private void Level1Button_Click(object sender, EventArgs e)
        {

            _game.SetLevel(Main.LevelList[0]);
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
          
        }

        private void Level2Button_Click(object sender, EventArgs e)
        {

            _game.SetLevel(Main.LevelList[1]);
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            
        }
        private void Level3Button_Click(object sender, EventArgs e)
        {

            _game.SetLevel(Main.LevelList[2]);
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            
        }
        private void Level4Button_Click(object sender, EventArgs e)
        {

            _game.SetLevel(Main.LevelList[3]);
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        
        }
        private void Level5Button_Click(object sender, EventArgs e)
        {

            _game.SetLevel(Main.LevelList[4]);
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            _game.StartGame();
        }
        private void Level6Button_Click(object sender, EventArgs e)
        {

            _game.SetLevel(Main.LevelList[5]);
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            
        }

         private void RandomLevel_Click(object sender, EventArgs e)
         {

             _game.SetLevel(Main.LevelList[rnd.Next(0,5)]);
             _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
            

        }

    }
}
