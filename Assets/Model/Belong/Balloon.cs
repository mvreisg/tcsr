using UnityEngine;

namespace Assets.Model.Belong
{
    public class Balloon :
        IEntity,
        IForce,
        IRenderable
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly SpriteRenderer _spriteRenderer;

        public Balloon(Transform transform)
        {
            _transform = transform;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public Vector3 Force
        {
            get
            {
                float x = Random.Range(0f, 1f);
                if (x >= .5f)
                    return new Vector3(0.000001f, 0.000001f, 0f);
                else
                    return new Vector3(-0.000001f, 0.000001f, 0f);
            }    
        }

        public Renderer Renderer => _spriteRenderer;

        public void Exist()
        {
            
        }

        public void FixedPhysics()
        {
            Rigidbody2D.AddForce(Force, ForceMode2D.Impulse);
        }
    }
}