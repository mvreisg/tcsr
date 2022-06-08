using UnityEngine;

namespace Assets.Resources.Model.Nature
{
    public class Fire : Entity,
        ISpriteRenderer
    {
        private readonly SpriteRenderer _spriteRenderer;

        public Fire(Transform transform) : base(transform)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public override void Do()
        {
            Debug.Log("Fire...");
        }
    }
}