using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public abstract class CelestialBody : Entity, 
        ISpriteRenderer
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Day _day;

        public CelestialBody(Transform transform, Day day) : base(transform)
        {
            _day = day;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;
        public Day Day => _day;

        public override void Do()
        {
            Day.Do();
        }
    }
}