using System;

namespace Ballgame
{
    class DelayedAction
    {
        public Action Action
        {
            get;
            private set;
        }
        public float Delay
        {
            get;
            private set;
        }
        public float TimeRemaining
        {
            get;
            private set;
        }
        public bool Repeat
        {
            get;
            private set;
        }

        public DelayedAction(Action action, float delay, bool repeat)
        {
            TimeRemaining = delay;
            Action = action;
            Delay = delay;
            Repeat = repeat;
        }

        public bool Update(float deltaTime)
        {
            TimeRemaining -= deltaTime;

            if (TimeRemaining <= 0)
            {
                Action();
                Game1.DelayedActionList.Remove(this);
                return false;
            }

            return true;
        }
    }

}
