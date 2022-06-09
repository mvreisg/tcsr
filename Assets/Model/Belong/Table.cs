using UnityEngine;

namespace Assets.Model.Belong
{
    public class Table : Entity,
        ISpriteRenderer,
        INoisier,
        IPolygonCollider2D
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly AudioSource _audioSource;
        private readonly PolygonCollider2D _polygonCollider2D;

        public Table(Transform transform) : base(transform)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _audioSource = transform.GetComponent<AudioSource>();
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public AudioSource AudioSource => _audioSource;

        public PolygonCollider2D PolygonCollider2D => _polygonCollider2D;

        public override void Do()
        {

        }
    }
}