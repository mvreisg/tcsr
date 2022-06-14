using UnityEngine;

namespace Assets.Model.Nature
{
    public class Sun : 
        IEntity,
        IRenderable
    {
        private readonly Transform _transform;
        private readonly SpriteRenderer _spriteRenderer;

        public Sun(Transform transform)
        {
            _transform = transform;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Renderer Renderer => _spriteRenderer;

        public void Update()
        {
            
        }
    }
}