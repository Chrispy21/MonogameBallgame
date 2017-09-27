using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game //github test
    {
        //(github teszt)

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

       
        Texture2D racket;

        public int racketx=400;
        public int rackety=300;

        Texture2D ball;

        public int ballx;
        public int bally;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();
            


            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //labda képének megadása
            ball = Content.Load<Texture2D>("Images/ball");
            //ütő képének megadása
            racket = Content.Load<Texture2D>("Images/racket");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Left))
            {
                racketx -=100;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                racketx += 100;
            }
           
           

            if (racketx < 0)
            {
                racketx = 0;
            }
            else if (racketx + racket.Width > graphics.PreferredBackBufferWidth)
            {
                racketx = graphics.PreferredBackBufferWidth - racket.Width;
            }
           
           

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //minden kirajzolást ide
            spriteBatch.Begin();

           
            spriteBatch.Draw(ball, new Vector2(ballx, bally), Color.White);
            spriteBatch.Draw(racket, new Vector2(racketx, rackety), Color.White);



            spriteBatch.End();//és ez fölé

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
   
}
