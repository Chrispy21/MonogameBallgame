using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame
{

    

    class Racket : MovingEntity
    {
        Texture2D racket;

        public int racketX;
        public int racketY;
        GraphicsDeviceManager graphics;


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                racketX -= 100;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                racketX += 100;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                racketY -= 100;
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                racketY += 100;
            }

            if (racketX < 0)
            {
                racketX = 0;
            }
            else if (racketX + racket.Width > graphics.PreferredBackBufferWidth)
            {
                racketX = graphics.PreferredBackBufferWidth - racket.Width;
            }
            if (racketY < 0)
            {
                racketY = 0;
            }
            else if (racketY + racket.Height > graphics.PreferredBackBufferHeight)
            {
                racketY = graphics.PreferredBackBufferHeight - racket.Height;
            }
            base.Update(gameTime);
        }

        public Racket(double x, double y,Texture2D racket, int racketX,int racketY) : base(x, y,racket,racketX,racketY)
        {
            this.racketX = racketX;
            this.racketY = racketY;
        }
    }
}
