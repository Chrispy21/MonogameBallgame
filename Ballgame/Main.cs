using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Ballgame.Entities;
using Ballgame.Controls;
using Ballgame.States;
using Ballgame.Levels;
namespace Ballgame
{
    public enum CollectibleType { Dislike, Like, Trollface, Iceball, Hp, Racket, Ball };
    public enum BallType { Bowling };
    public enum RacketType { BlueGray, LongRacket };
    public enum BrickType { DefaultBrick };
    public enum ParticleType { DefaultBrick };

    public class Main : Game
    {
        public static Random rnd = new Random();
        public static GraphicsDeviceManager Graphics { get; private set; }
        public static SpriteBatch SpriteBatch { get; private set; }
        public static List<DelayedAction> DelayedActionList { get; private set; }
        public static Level CurrentLevel { get; private set; }

        public static SpriteFont Healt;
        public static SpriteFont Score;
        public static SpriteFont targets;
        public static SpriteFont Start;
        public static SpriteFont MenuSprite;
        public static SpriteFont nextLevelSprite;

        public const float baseBallSpeed = -5;
        private static int collectibleTypeCount = 7;

        private static int ballTypeCount = 1;
        private static int racketTypeCount = 2;
        private static int brickTypeCount = 1;
        private static int particleTypeCount = 1;

        private static Texture2D[] collectibleSprites;
        private static Texture2D[] ballSprites;
        private static Texture2D[] racketSprites;
        private static Texture2D[] brickSprites;
        private static Texture2D[] particleSprites;
        public static Texture2D background;
        public static Texture2D backgroundmenu;
        public static Texture2D descriptionText;
        public static Texture2D bottomBar;
        public static Texture2D options;
        public static Texture2D description;
        public static Texture2D selectLevel;
        public static Texture2D spacestart;
        public static Texture2D leftText;
        public static Texture2D rightText;
        public static Texture2D startText;
        public static Texture2D gameoverTexture;
        public static Texture2D nextlevelTexture;

        public static int score = 0;
        public static int target = 0;
        public static int hp = 30;
        private int spaceClick = 0;

        private State _currentState;
        public State _nextState;

        public MenuState menuState;

        //billentyűk
        public static Keys moveLeft = Keys.Left;
        public static Keys moveRight = Keys.Right;
        public static Keys startBall = Keys.Space;

        bool nextLevel = false;
        bool paused = false;
        bool quit = false;
        public static bool space = true;

        public static Texture2D pausedTexture;

        Button btnPlay;
        Button btnQuit;
        Button btnRestart;

        Rectangle pausedRectangle;
        Rectangle gameoverRectangle;
        Rectangle hpRectangle;
        Rectangle nextLevelRectangle;

        // Pályák sorrendje

        /// <summary>
        /// //HA CSINÁLTÁL EGY LEVELX SZÁMÚ PÁLYÁT AKKOR IDE KELL BEÍRNOD AHOGY A MINTA MUTATJA typeof(LevelX)
        /// </summary>
        public static List<Type> LevelList = new List<Type>
        {
            typeof(Level1),
            typeof(Level2),
            typeof(Level3),
            typeof(Level4),
            typeof(Level5),
            typeof(Level6)



        };

        public static int CurrentLevelIndex = 0;


        //Player player;

        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public static Vector2 Resolution
        {
            get
            {
                return new Vector2(Graphics.PreferredBackBufferWidth, Graphics.PreferredBackBufferHeight);
            }
        }

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

            this.IsMouseVisible = true;

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

            gameoverTexture = Content.Load<Texture2D>("Sprites/Background/gameovermenu");
            pausedTexture = Content.Load<Texture2D>("Sprites/Background/pausemenu");
            pausedRectangle = new Rectangle(0, 0, pausedTexture.Width, pausedTexture.Height);
            btnPlay = new Button();
            btnPlay.Load(Content.Load<Texture2D>("Controls/btnResume"), new Vector2(523, 260));
            btnQuit = new Button();
            btnQuit.Load(Content.Load<Texture2D>("Controls/btnExit"), new Vector2(523, 360));
            options = Content.Load<Texture2D>("PngTexts/options");
            description = Content.Load<Texture2D>("PngTexts/description");
            selectLevel = Content.Load<Texture2D>("PngTexts/selectlevel");
            bottomBar = Content.Load<Texture2D>("Sprites/Background/Bottombar");
            spacestart = Content.Load<Texture2D>("PngTexts/Spacethingy");
            leftText = Content.Load<Texture2D>("PngTexts/left");
            rightText = Content.Load<Texture2D>("PngTexts/right");
            startText = Content.Load<Texture2D>("PngTexts/start");
            nextlevelTexture = Content.Load<Texture2D>("Sprites/Background/OldPauseMenu");
            //quitTexture = Content.Load<Texture2D>("Sprites/Background/gameover");
            nextLevelRectangle = new Rectangle(0, 0, nextlevelTexture.Width, nextlevelTexture.Height);
            gameoverRectangle = new Rectangle(0, 0, gameoverTexture.Width, gameoverTexture.Height);
            btnRestart = new Button();
            btnRestart.Load(Content.Load<Texture2D>("Controls/btnRestart"), new Vector2(523, 260));
            Healt = Content.Load<SpriteFont>("hp");
            hpRectangle = new Rectangle(0, 0, Healt.Texture.Width, Healt.Texture.Height);
            Score = Content.Load<SpriteFont>("score");
            targets = Content.Load<SpriteFont>("targets");
            Start = Content.Load<SpriteFont>("start");
            MenuSprite = Content.Load<SpriteFont>("menusprite");
            nextLevelSprite = Content.Load<SpriteFont>("nextLevel");

            string path;

            _currentState = new MenuState(this, Graphics.GraphicsDevice, Content);
            this.menuState = _currentState as MenuState;

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
            backgroundmenu = Content.Load<Texture2D>("Sprites/Background/backg_1");
            descriptionText = Content.Load<Texture2D>("Sprites/Background/Description");
            this.StartGame();
            // TODO: this.Content.Load <- betöltés
        }

        public void StartGame()
        {
            this.SetLevel(typeof(Level1)); //<----mindig így állítsátok be a level-t
            CurrentLevel.GenerateBricks();
        }


        protected override void Update(GameTime gameTime)
        {

            if (_nextState != null)
            {
                _currentState = _nextState;

                _nextState = null;
            }

            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            if (spaceClick <= 0)
            {
                if (Keyboard.GetState().IsKeyDown(Main.startBall))
                {
                    Level.ball.Speed = new Vector2(Main.baseBallSpeed);
                    space = false;
                    spaceClick++;

                }
            }
            //CheckInput();
            // Timerek frissítése (ne nyúlj hozzá)
            for (int i = DelayedActionList.Count - 1; i >= 0; i--)
            {
                DelayedActionList[i].Update(gameTime.ElapsedGameTime.Milliseconds);
            }



            MouseState mouse = Mouse.GetState();
            if (this._currentState is GameState)
            {
                if (!paused)
                {
                    if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    {
                        paused = true;
                        btnPlay.isClicked = false;
                        Level.ball.Speed = new Vector2(0);
                        CurrentLevel.Player.isFrozen = true;
                    }


                    //játék megállítása pause menu meghívása esetén
                    //player.Update();
                }
                else if (paused)
                {

                    if (btnPlay.isClicked || Keyboard.GetState().IsKeyDown(Keys.Enter))
                    {

                        Level.ball.Speed = new Vector2(Main.baseBallSpeed);
                        CurrentLevel.Player.isFrozen = false;
                        paused = false;
                    }
                    if (btnQuit.isClicked)
                    {

                        Level.ball.Speed = new Vector2(0);
                        CurrentLevel.Player.isFrozen = false;
                        this._nextState = this.menuState;
                        paused = false;
                        Ball.Kill();
                    }
                    /*else if (paused)
                    {
                        paused = true;
                        Level.ball.Speed = new Vector2(Main.baseBallSpeed);
                        CurrentLevel.Player.isFrozen = false;
                    }
                    Level.ball.Speed = new Vector2(0);
                    //CurrentLevel.Player.isFrozen = false;*/

                    btnPlay.Update(mouse);
                    btnQuit.Update(mouse);

                }
                //Restart menü
            }


            if (!quit && hp <= 0)
            {

                quit = true;
                btnRestart.isClicked = false;
                Ball.Kill();
                Level.ball.Speed = new Vector2(0);
                //játék megállítása pause menu meghívása esetén
                //player.Update();
            }
            else if (quit)
            {

                if (btnRestart.isClicked)
                {
                    spaceClick = 0;
                    target = 0;
                    score *= 0;
                    hp = 3;
                    space = true;
                    quit = false;
                    StartGame();
                    //Ball.touch = 0;

                }
                if (btnQuit.isClicked)
                {
                    Exit();
                    

                }

                btnRestart.Update(mouse);
                btnQuit.Update(mouse);

            }
            if (target == 0 && hp != 0 && quit == false)
            {
                Level.ball.Speed = new Vector2(0);
                CurrentLevel.Player.isFrozen = false;
                nextLevel = true;


                if (Keyboard.GetState().IsKeyDown(Keys.N))
                {
                    spaceClick = 0;
                    target = 0;
                    score *= 0;
                    hp = 3;
                    space = true;
                    nextLevel = false;
                    if (CurrentLevel.EntityList.Count(x => x is Brick) <= 0)
                    {
                        if (CurrentLevelIndex + 1 < LevelList.Count)
                        {

                            this.SetLevel(LevelList[CurrentLevelIndex + 1]);
                            //Level.ball.Speed = new Vector2(Main.baseBallSpeed);
                        }
                        else
                        {
                            this.SetLevel(LevelList[0]);
                        }
                    }
                }

            }

            // Ha nincs több tégla, ugrás a következő pályára (ha nincs következő, akkor a legelsőre)



            base.Update(gameTime);
        }

        /// <summary>
        /// Kirajzol mindent.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            SpriteBatch.Begin();
            SpriteBatch.Draw(backgroundmenu, new Rectangle(0, 0, 1280, 768), Color.White);
            /*
            SpriteBatch.DrawString(Healt, "HP: " + hp, new Vector2(10, 650), Color.Aqua);
            SpriteBatch.DrawString(Score, "Score: " + score, new Vector2(1000, 650), Color.DarkOliveGreen);
            SpriteBatch.DrawString(targets, "Targets: " + target, new Vector2(500, 650),  Color.WhiteSmoke );
            */
            //Nem mind1 a sorrend!
            //if-be elindul a játék végtelen élettel ütő nélkül.

            _currentState.Draw(gameTime, SpriteBatch);
            if (quit)
            {
                SpriteBatch.Draw(gameoverTexture, gameoverRectangle, Color.White);
                btnRestart.Draw(SpriteBatch);
                btnQuit.Draw(SpriteBatch);

            }

            if (nextLevel)
            {
                SpriteBatch.Draw(nextlevelTexture, nextLevelRectangle, Color.White);
                //SpriteBatch.DrawString(nextLevelSprite, "Nyomj egy N betűt", new Vector2(300, 450), Color.Aqua);
            }

            if (paused)
            {
                SpriteBatch.Draw(pausedTexture, pausedRectangle, Color.White);
                btnPlay.Draw(SpriteBatch);
                btnQuit.Draw(SpriteBatch);
            }

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        public void SetLevel(Type levelType)
        {
            if (levelType.BaseType == typeof(Level))
            {
                CurrentLevel = (Level)Activator.CreateInstance(levelType);
                CurrentLevel.GenerateBricks();
                CurrentLevelIndex = LevelList.IndexOf(levelType);
            }
            else
            {
                throw new ArgumentException("SetLevel: Egy level típust kell megadni.");
            }
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
