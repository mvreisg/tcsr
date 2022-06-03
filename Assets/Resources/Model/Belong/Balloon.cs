using UnityEngine;

namespace Assets.Resources.Model.Belong
{
    public class Balloon : Belonging,
        ISpriteRenderer,
        INoisier
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly AudioSource _audioSource;

        public Balloon(Transform transform, Vector3 force) : base(transform, force)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _audioSource = transform.GetComponent<AudioSource>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public AudioSource AudioSource => _audioSource;

        public override void Do()
        {
            base.Do();
        }
    }
}