using UnityEngine;

namespace Assets.Resources.Model.Belong
{
    public class Candle : Belonging,
        ISpriteRenderer,
        ILight,
        INoisier,
        IBoxCollider2D
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Light _light;
        private readonly AudioSource _audioSource;
        private readonly BoxCollider2D _boxCollider2D;

        public Candle(Transform transform, Vector3 force) : base(transform, force)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _light = transform.GetComponent<Light>();
            _audioSource = transform.GetComponent<AudioSource>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Light Light => _light;

        public AudioSource AudioSource => _audioSource;

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public override void Do()
        {
            base.Do();
        }
    }
}