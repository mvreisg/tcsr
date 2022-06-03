using System.Collections.ObjectModel;
using UnityEngine;
using Assets.Resources.Model.Nature;

namespace Assets.Resources.Model.Bio
{
    public class Bestmare : Animal,
        IBoxCollider2D
    {
        public delegate void BestmareActionEventHandler(Action action);
        public event BestmareActionEventHandler Acted;

        private readonly BoxCollider2D _boxCollider2D;
        
        private Vector3 _target;

        public Bestmare(
            Transform transform, 
            XYZValue speed,
            Multiplier x,
            Multiplier y,
            Multiplier z,
            Vector3 force,
            Earth earth) : 
            base(transform, speed, x, y, z, force)
        {
            ReadOnlyCollection<LivingBeing> livingBeings = earth.LivingBeings;
            foreach (LivingBeing livingBeing in livingBeings)
            {
                if (livingBeing is Human)
                    livingBeing.Repositioned += ReceiveTargetPosition;
            }
            earth.Birth += ListenBornLivingBeing;
            earth.Death += UnListenDeadLivingBeing;
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public override void Do()
        {
            if (_target.x < Transform.position.x)
                X = Multiplier.NEGATIVE;
            else if (_target.x > Transform.position.x)
                X = Multiplier.POSITIVE;
            else
                X = Multiplier.ZERO;

            base.Do();

            switch (X)
            {
                default:
                    throw new UnityException($"unhandled state: {X}");
                case Multiplier.ZERO:
                    OnActed(Action.NONE);
                    break;
                case Multiplier.NEGATIVE:
                    OnActed(Action.BACK);
                    break;
                case Multiplier.POSITIVE:
                    OnActed(Action.FORWARD);
                    break;
            }
        }

        private void OnActed(Action action)
        {
            Acted?.Invoke(action);
        }

        private void ReceiveTargetPosition(Vector3 target)
        {
            if (_target.magnitude >= target.magnitude)
                return;
            _target = target;
        }

        private void ListenBornLivingBeing(LivingBeing livingBeing)
        {
            if (livingBeing is Human)
                livingBeing.Repositioned += ReceiveTargetPosition;
        }

        private void UnListenDeadLivingBeing(LivingBeing livingBeing)
        {
            livingBeing.Repositioned -= ReceiveTargetPosition;
        }
    }
}