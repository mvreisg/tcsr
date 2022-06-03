using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public abstract class Plant : LivingBeing,
        INoisier,
        ISpriteRenderer
    {
        private readonly AudioSource _audioSource;
        private readonly SpriteRenderer _spriteRenderer;

        public Plant(Transform transform, Vector3 force) : base(transform, force)
        {
            _audioSource = transform.GetComponent<AudioSource>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public AudioSource AudioSource => _audioSource;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public override void Do()
        {
            base.Do();
        }
    }
}