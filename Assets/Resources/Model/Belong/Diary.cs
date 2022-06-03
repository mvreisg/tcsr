using UnityEngine;

namespace Assets.Resources.Model.Belong
{
    public class Diary : Belonging,
        ISpriteRenderer,
        ILight,
        IBoxCollider2D
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly Light _light;
        private readonly BoxCollider2D _boxCollider2D;

        public Diary(Transform transform, Vector3 force, float intensity) : base(transform, force)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _light = transform.GetComponent<Light>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
            Intensity = intensity;
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public Light Light => _light;

        public float Intensity
        {
            get => _light.intensity;
            set => _light.intensity = value;
        }

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public override void Do()
        {
            base.Do();
        }
    }
}