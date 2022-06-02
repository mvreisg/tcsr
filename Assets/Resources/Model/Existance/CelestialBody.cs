using UnityEngine;

namespace Assets.Resources.Model.Existance
{
    public abstract class CelestialBody : Entity, ISpriteRenderer
    {
        private readonly SpriteRenderer _spriteRenderer;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public CelestialBody(Transform transform, SpriteRenderer spriteRenderer) : base(transform)
        {
            _spriteRenderer = spriteRenderer;
        }
    }
}