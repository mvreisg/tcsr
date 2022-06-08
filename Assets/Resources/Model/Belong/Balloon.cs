using UnityEngine;

namespace Assets.Resources.Model.Belong
{
    public class Balloon : Entity,
        ISpriteRenderer,
        INoisier
    {
        private readonly SpriteRenderer _spriteRenderer;
        private readonly AudioSource _audioSource;
        
        public Balloon(Transform transform) : base(transform)
        {
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _audioSource = transform.GetComponent<AudioSource>();
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public AudioSource AudioSource => _audioSource;

        public override void Do()
        {
            Debug.Log("Balloon...");
        }
    }
}