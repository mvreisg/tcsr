using UnityEngine;

namespace Assets.Resources.Model
{
    public class Balloon : Entity
    {
        private float _timeToAlterXMultiplier;

        private float TimeToAlterXMultiplier => Random.Range(1.23f, 2.23f);

        public Balloon(Transform transform, Multiplier x, Multiplier y, Multiplier z, XYZValue speed) : base(transform, x, y, z, speed)
        {
            _timeToAlterXMultiplier = TimeToAlterXMultiplier;
        }

        public void ConsumeTime()
        {
            _timeToAlterXMultiplier -= Time.deltaTime;
            if (_timeToAlterXMultiplier > 0f)
                return;
            
            _timeToAlterXMultiplier = TimeToAlterXMultiplier;
            switch (X)
            {
                case Multiplier.POSITIVE:
                    X = Multiplier.NEGATIVE;
                    break;
                case Multiplier.ZERO:
                case Multiplier.NEGATIVE:
                    X = Multiplier.POSITIVE;
                    break;
            }
        }
    }
}