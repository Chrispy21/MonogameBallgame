using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ballgame.Entities;

namespace Ballgame
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public enum CollectibleType { Dislike, Like, Trollface };
    public enum BallType { Bowling };
    public enum RacketType { BlueGray };
    public enum BrickType { DefaultBrick };
    public enum ParticleType { DefaultBrick };

    public class Game1 : Game
   {
        public static GraphicsDeviceManager Graphics { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }

        public const float baseBallSpeed = -5;

        public static Random rnd = new Random();

        private static int collectibleTypeCount = 3;
        private static int ballTypeCount = 1;
        private static int racketTypeCount = 1;
        private static int brickTypeCount = 1;
        private static int particleTypeCount = 1;

        private static Texture2D[] collectibleSprites;
        private static Texture2D[] ballSprites;
        private static Texture2D[] racketSprites;
        private static Texture2D[] brickSprites;
        private static Texture2D[] particleSprites;
        

        public static DisplayMode Resolution
        {
            get
            {
                return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
            }
        }
       
        static extern void ClipCursor(ref Rectangle rect);

        public static List<DelayedAction> DelayedActionList { get; private set; }

        public static Level CurrentLevel { get; private set; }

        private static Rectangle mouseClipRect = new Rectangle();

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

       

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        
        public static Texture2D GetParticleSprite(ParticleType type)
        {
            return particleSprites[(int)type];
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            DelayedActionList = new List<DelayedAction>();

            collectibleSprites = new Texture2D[collectibleTypeCount];
            ballSprites = new Texture2D[ballTypeCount];
            racketSprites = new Texture2D[racketTypeCount];
            brickSprites = new Texture2D[brickTypeCount];
            particleSprites = new Texture2D[particleTypeCount];


            Graphics.IsFullScreen = false;
            Graphics.PreferredBackBufferWidth = 800;
            Graphics.PreferredBackBufferHeight = 600;
            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.ApplyChanges();

            this.IsMouseVisible = false;

            base.Initialize();


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
           
            //labda képének megadása
            
            

            // TODO: use this.Content to load your game content here
        }
        
        private void StartGame()
        {
            CurrentLevel = new Level();
            CurrentLevel.GenerateBricks();

            //javítani
            // Clip mouse coordinates
            mouseClipRect.X = CurrentLevel.Player.Body.Width / 2;
            mouseClipRect.Y = 0;
            mouseClipRect.Size = new Point(Resolution.Width - CurrentLevel.Player.Body.Width / 2, Resolution.Height);
            //ClipCursor(ref mouseClipRect);
        }
        
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }



        public static Texture2D GetRacketSprite(RacketType type)
        {
            return racketSprites[(int)type];
        }


        public static Texture2D GetCollectibleSprite(CollectibleType type)
        {
            return collectibleSprites[(int)type];
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>

        protected override void Update(GameTime gameTime)
        {
            
            CheckInput();

            CurrentLevel.Update(gameTime);

            // Update delayed actions (timers)
            for (int i = DelayedActionList.Count - 1; i >= 0; i--)
            {
                DelayedActionList[i].Update(gameTime.ElapsedGameTime.Milliseconds);
            }
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        private void CheckInput()
        {
            KeyboardState keyboardState = Keyboard.GetState();

            // Close game on escape or the gamepad's back button
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || keyboardState.IsKeyDown(Keys.Escape))
                Exit();

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.Clear(Color.LightGray);

            SpriteBatch.Begin();
            CurrentLevel.Draw(gameTime);
            SpriteBatch.End();

            base.Draw(gameTime);

            
            // TODO: Add your drawing code here

            
        }
        public static void QueueAction(DelayedAction action)
        {
            DelayedActionList.Add(action);
        }

        public static Texture2D GetBrickSprite(BrickType type)
        {
            return brickSprites[(int)type];
        }

        public static Texture2D GetBallSprite(BallType type)
        {
            return ballSprites[(int)type];
        }
    }
   
}
