using UnityEngine;

namespace Assets.Model.Nature
{
    public class Fire : 
        IEntity,
        IRenderable
    {
        private readonly Transform _transform;
        private readonly SpriteRenderer _spriteRenderer;

        public Fire(Transform transform)
        {
            _transform = transform;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Renderer Renderer => _spriteRenderer;

        public void Exist()
        {
            throw new UnityException();
        }
    }
}