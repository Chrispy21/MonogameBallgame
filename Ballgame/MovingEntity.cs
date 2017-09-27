using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Ballgame
{
    class MovingEntity:Game1
    {
        public double Speed;

        private double speedx;
        private double speedy;
        private Racket racket;
        private Texture2D racket1;

        public double SpeedX
        {
            get
            {
                return speedx;
            }
            set
            {
                if(Math.Abs(value) !=1 && value!=0)
                {
                    throw new Exception("Az iránybéli sebesség csak 1,-1 vagy 0 lehet ");
                }
                this.speedx = value;
            }
        }


        public double SpeedY
        {
            get
            {
                return speedy;
            }
            set
            {
                if(Math.Abs(value)!=1 && value !=0)
                {
                    throw new Exception("Az iránybéli sebesség nem lehet csak 1,-1,0");
                }
                this.speedy = value;
            }
        }
        
        public MovingEntity(double x, double y, Texture2D racket1, int racketX, int racketY) : this(x, y, racket1)
        {
            this.racketx = racketX;
            this.rackety = racketY;
        }

        public MovingEntity(double x, double y, Texture2D racket1) : base(x, y)
        {
            this.racket1 = racket1;
        }
    }
}
