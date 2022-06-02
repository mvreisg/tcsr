using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public abstract class CelestialBody : Entity, ISpriteRenderer
    {
        private readonly SpriteRenderer _spriteRenderer;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public CelestialBody(Transform transform) : base(transform)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }
    }
}