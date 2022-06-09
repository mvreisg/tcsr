using UnityEngine;

namespace Assets.Model.Belong
{
    public class Candle : Entity,
        ISpriteRenderer,
        INoisier,
        IBoxCollider2D
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly AudioSource _audioSource;
        private readonly BoxCollider2D _boxCollider2D;

        public Candle(Transform transform) : base(transform)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _audioSource = transform.GetComponent<AudioSource>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public AudioSource AudioSource => _audioSource;

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public override void Do()
        {

        }
    }
}