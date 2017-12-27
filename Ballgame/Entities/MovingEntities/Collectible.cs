using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ballgame.Entities
{
    public class Collectible : MovingEntity
    {
        public CollectibleType Type { get; private set; }

        public Collectible(int x, int y, CollectibleType type, float speed) : base(x, y, Main.GetCollectibleSprite(type))
        {
            this.Type = type;
            this.Speed.X = 0;
            this.Speed.Y = 1;
            this.Velocity = speed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            // Megnézzük, hogy a player felvette-e
            if (Main.CurrentLevel.Player.Body.Intersects(this.Body))
            {
                this.OnPickup();
            }

            // Töröljük, ha leesik
            if (this.Body.Y >= Main.Resolution.Y + this.Body.Height)
            {
                this.Destroy();
            }

        }

        /// <summary>
        /// Akkor hívódik meg, ha felveszi a játékost.
        /// </summary>
        private void OnPickup()
        {
            switch (this.Type)
            {
                case CollectibleType.Dislike:
                    foreach (Ball b in Main.CurrentLevel.EntityList.FindAll(x => x is Ball))
                    {
                        b.Speed *= 1.2f;
                    }
                    break;

                case CollectibleType.Iceball:

                    Main.CurrentLevel.Player.isFrozen = true;

                    // 2 másodperc múlva állítsa vissza
                    Main.QueueAction(new DelayedAction(
                        () =>
                        {
                            Main.CurrentLevel.Player.isFrozen = false;
                        },
                        2000,
                        false));

                    break;
                case CollectibleType.Like:
                    foreach (Ball b in Main.CurrentLevel.EntityList.FindAll(x => x is Ball))
                    {
                        b.Speed *= 0.8f;
                    }
                    break;

                case CollectibleType.Trollface:
                    // Irányítás megfordítása
                    Main.CurrentLevel.Player.IsInputInverted = true;

                    // 4 másodperc múlva állítsa vissza
                    Main.QueueAction(new DelayedAction(
                        () => Main.CurrentLevel.Player.IsInputInverted = false,
                        4000,
                        false));
                    break;

                case CollectibleType.Hp: Main.hp++;
                    break;

                case CollectibleType.Racket:  /// <--- az ütő meghosszabítása
                    Main.CurrentLevel.Player.scaleEffect = true;

                    // 10 másodperc múlva állítsa vissza
                    Main.QueueAction(new DelayedAction(
                    () => Main.CurrentLevel.Player.scaleEffect = false,
                    10000,
                    false));
                    break;
            }
            this.Destroy();
        }
    }
}
