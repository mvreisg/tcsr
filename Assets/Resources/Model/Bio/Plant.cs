using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public abstract class Plant : LivingBeing,
        INoisier,
        ISpriteRenderer, 
        IBoxCollider2D, 
        IRigidbody2D
    {
        private readonly AudioSource _audioSource;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly BoxCollider2D _boxCollider2D;
        private Vector3 _force;
        private readonly Rigidbody2D _rigidbody2D;

        public Plant(Transform transform, Vector3 force) : base(transform)
        {
            _audioSource = transform.GetComponent<AudioSource>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
            _force = force;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
        }

        public AudioSource AudioSource => _audioSource;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public Vector3 Force => _force;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;
    }
}