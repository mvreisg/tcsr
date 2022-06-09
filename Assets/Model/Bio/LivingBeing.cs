using System.Collections.Generic;
using UnityEngine;
using Assets.Model.Controllers;

namespace Assets.Model.Bio
{
    public abstract class LivingBeing : Entity
    {
        private readonly List<Entity> _belongings;

        public LivingBeing(Transform transform) : base(transform)
        {
            _belongings = new List<Entity>();
        }

        public void ListenPlayerAction(Action action)
        {
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.IDLE:
                    break;
                case Action.STOP:
                    Stop();
                    break;
                case Action.BACK:
                    TurnBack();
                    break;
                case Action.FORWARD:
                    TurnForward();
                    break;
                case Action.USE:
                    break;
            }
        }

        public virtual void Stop()
        {
            X = Multiplier.ZERO;
        }

        public virtual void TurnBack()
        {
            X = Multiplier.NEGATIVE;
        }

        public virtual void TurnForward()
        {
            X = Multiplier.POSITIVE;
        }
    }
}