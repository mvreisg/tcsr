using UnityEngine;

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
            Vector3 force) : 
            base(transform, speed, x, y, z, force)
        {
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

        public void ListenHumanReposition(Vector3 position)
        {
            if (_target.magnitude >= position.magnitude)
                return;
            _target = position;
        }

        public void ListenHumanBirth(LivingBeing living)
        {
            if (living is Human)
                living.Repositioned += ListenHumanReposition;
        }

        public void ListenHumanDeath(LivingBeing dead)
        {
            if (dead is Human)
                dead.Repositioned -= ListenHumanReposition;
        }
    }
}