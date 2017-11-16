using Ballgame.Controls;
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
    public class MenuState : State
    {
        private List<Component> _components;
        public List<Component> _backbutton;

        public MenuState(Main game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            var buttonTexture = _content.Load<Texture2D>("Controls/button_0");
            var buttonFont = _content.Load<SpriteFont>("MenuFont");

            var newGameButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 118, (Main.Graphics.PreferredBackBufferHeight / 2)-120),
                Text = "New Game",
            };

            newGameButton.Click += newGameButton_Click;

            var selectLevelGameButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth/2)-118, (Main.Graphics.PreferredBackBufferHeight / 2)-60),
                Text = "Select Level",
            };

            selectLevelGameButton.Click += selectLevelGameButton_Click;

            var descriptionGameButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 118, Main.Graphics.PreferredBackBufferHeight / 2),
                Text = "Description",
            };

            descriptionGameButton.Click += DescriptionGameButton_Click;

            var optionsGameButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 118, (Main.Graphics.PreferredBackBufferHeight / 2)+60),
                Text = "Options",
            };

            optionsGameButton.Click += OptionsGameButton_Click;

            var quitGameButton = new ButtonMenu(buttonTexture, buttonFont)
            {
                Position = new Vector2((Main.Graphics.PreferredBackBufferWidth / 2) - 118, (Main.Graphics.PreferredBackBufferHeight / 2)+120),
                Text = "Quit Game",
            };

            quitGameButton.Click += quitGameButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                selectLevelGameButton,
                quitGameButton,
                descriptionGameButton,
                optionsGameButton,
            };            
        }
        
        public override void Draw(GameTime gameTime, SpriteBatch SpriteBatch)
        {
            foreach (var component in _components)
                component.Draw(gameTime, SpriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
                component.Update(gameTime);
        }

        public override void PostUpdate(GameTime gameTime)
        {
            //Sprite-ok eltüntetése, ha nem kell nekünk
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _content));
        }

        private void selectLevelGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new SelectLevelState(_game, _graphicsDevice, _content));
        }

        private void quitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void DescriptionGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new DescriptionState(_game, _graphicsDevice, _content));
        }

        private void OptionsGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new OptionsState(_game, _graphicsDevice, _content));
        }
    }
}
