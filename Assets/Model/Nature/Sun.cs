using UnityEngine;

namespace Assets.Model.Nature
{
    public class Sun : Entity,
        ISpriteRenderer
    {
        private readonly SpriteRenderer _spriteRenderer;

        public Sun(Transform transform) : base(transform)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public override void Do()
        {
            Debug.Log("Sun...");
        }
    }
}