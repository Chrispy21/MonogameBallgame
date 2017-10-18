using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ballgame.Entities;
using Ballgame.Controls;

namespace Ballgame
{
    public enum CollectibleType { Dislike, Like, Trollface };
    public enum BallType { Bowling };
    public enum RacketType { BlueGray };
    public enum BrickType { DefaultBrick };
    public enum ParticleType { DefaultBrick };

    public class Main : Game
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
        private Texture2D background;

        bool paused = false;
        Texture2D pausedTexture;
        Rectangle pausedRectangle;
        Button btnPlay, btnQuit;

        public static Vector2 Resolution
        {
            get
            {
                return new Vector2(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
            }
        }

        public static List<DelayedAction> DelayedActionList { get; private set; }

        public static Level CurrentLevel { get; private set; }


        //private static Rectangle mouseClipRect = new Rectangle();

        public Main()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        
        public static Texture2D GetParticleSprite(ParticleType type)
        {
            return particleSprites[(int)type];
        }

        protected override void Initialize()
        {
            DelayedActionList = new List<DelayedAction>();

            Graphics.IsFullScreen = false;
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 680;
            Graphics.SynchronizeWithVerticalRetrace = false;
            Graphics.ApplyChanges();

            this.IsMouseVisible = false;

            base.Initialize();
        }

        /// <summary>
        /// Itt kell betölteni mindent.
        /// </summary>
        protected override void LoadContent()
        {
            // Csinál egy új SpriteBatch-t, ami a textúrák kirajzolásához használható.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            collectibleSprites = new Texture2D[collectibleTypeCount];
            ballSprites = new Texture2D[ballTypeCount];
            racketSprites = new Texture2D[racketTypeCount];
            brickSprites = new Texture2D[brickTypeCount];
            particleSprites = new Texture2D[particleTypeCount];

            IsMouseVisible = true;
            pausedTexture = Content.Load<Texture2D>("Sprites/Background/PauseMenu");
            pausedRectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);
            btnPlay = new Button();
            btnPlay.Load(Content.Load<Texture2D>("Controls/btnResume"), new Vector2(523, 260));
            btnQuit = new Button();
            btnQuit.Load(Content.Load<Texture2D>("Controls/btnExit"), new Vector2(523, 360));

            string path;

            for (int i = 0; i < collectibleTypeCount; i++)
            {
                path = String.Format("Sprites/Collectibles/collectible_{0}", i);
                collectibleSprites[i] = this.Content.Load<Texture2D>(path);
            }

            for (int i = 0; i < ballTypeCount; i++)
            {
                path = String.Format("Sprites/Balls/ball_{0}", i);
                ballSprites[i] = this.Content.Load<Texture2D>(path);
            }

            for (int i = 0; i < racketTypeCount; i++)
            {
                path = String.Format("Sprites/Rackets/racket_{0}", i);
                racketSprites[i] = this.Content.Load<Texture2D>(path);
            }

            for (int i = 0; i < brickTypeCount; i++)
            {
                path = String.Format("Sprites/Bricks/brick_{0}", i);
                brickSprites[i] = this.Content.Load<Texture2D>(path);
            }

            for (int i = 0; i < particleTypeCount; i++)
            {
                path = String.Format("Sprites/Particles/particle_{0}", i);
                particleSprites[i] = this.Content.Load<Texture2D>(path);
            }
            background = Content.Load<Texture2D>("Sprites/Background/backg_0");
            this.StartGame();
            // TODO: this.Content.Load <- betöltés
        }
        
        private void StartGame()
        {
            CurrentLevel = new Level();
            CurrentLevel.GenerateBricks();
        }

        protected override void Update(GameTime gameTime)
        {         
            //CheckInput();

            CurrentLevel.Update(gameTime);

            // Timerek frissítése (ne nyúlj hozzá)
            for (int i = DelayedActionList.Count - 1; i >= 0; i--)
            {
                DelayedActionList[i].Update(gameTime.ElapsedGameTime.Milliseconds);
            }

            MouseState mouse = Mouse.GetState();
            if (!paused)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                {
                    paused = true;
                    btnPlay.isClicked = false;
                }


                //játék megállítása pause menu meghívása esetén
                //player.Update();
            }
            else if (paused)
            {
                if (btnPlay.isClicked)
                {
                    paused = false;
                }
                if (btnQuit.isClicked)
                {
                    Exit();
                }

                btnPlay.Update(mouse);
                btnQuit.Update(mouse);

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Kirajzol mindent.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Rectangle(0, 0, 1280, 768), Color.White);
            CurrentLevel.Draw(gameTime);

            if (paused)
            {
                SpriteBatch.Draw(pausedTexture, pausedRectangle, Color.White);
                btnPlay.Draw(SpriteBatch);
                btnQuit.Draw(SpriteBatch);
            }

            SpriteBatch.End();

            base.Draw(gameTime);           
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

        public static Texture2D GetRacketSprite(RacketType type)
        {
            return racketSprites[(int)type];
        }

        public static Texture2D GetCollectibleSprite(CollectibleType type)
        {
            return collectibleSprites[(int)type];
        }
    }
   
}
