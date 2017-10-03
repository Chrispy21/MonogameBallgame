using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame
{
    class Collectible:MovingEntity
    {
        public CollectibleType Type { get; private set; }

        public Collectible(int x, int y, CollectibleType type, float speed) : base(x, y, Game1.GetCollectibleSprite(type))
        {
            this.Type = type;
            this.Speed.X = 0;
            this.Speed.Y = speed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Check for pickup
            if (Game1.CurrentLevel.Player.Body.Intersects(this.Body))
            {
                this.OnPickup();
            }

            // Remove the collectible if it's out of screen
            if (this.Body.Y >= Game1.Resolution.Height + this.Body.Height)
            {
                this.Destroy();
            }

        }

        /// <summary>
        /// Gets called when the collectible is picked up.
        /// </summary>
        private void OnPickup()
        {
            switch (this.Type)
            {
                case CollectibleType.Dislike:
                    foreach (Ball b in Game1.CurrentLevel.EntityList.FindAll(x => x is Ball))
                    {
                        b.Speed *= 1.2f;
                    }
                    break;

                case CollectibleType.Like:
                    foreach (Ball b in Game1.CurrentLevel.EntityList.FindAll(x => x is Ball))
                    {
                        b.Speed *= 0.8f;
                    }
                    break;

                case CollectibleType.Trollface:
                    Game1.CurrentLevel.Player.IsInputInverted = true;
                    Game1.QueueAction(new DelayedAction(
                        () => Game1.CurrentLevel.Player.IsInputInverted = false,
                        4000,
                        false));
                    break;
            }

            this.Destroy();
        }
    }
}
