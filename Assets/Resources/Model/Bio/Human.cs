using UnityEngine;

namespace Assets.Resources.Model.Bio
{
    public class Human : LivingBeing,
        IRigidbody2D,
        IEar,
        INoisier,
        IBoxCollider2D,
        ISpriteRenderer
    {
        private readonly Rigidbody2D _rigidbody2D;
        private Vector3 _force;
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly SpriteRenderer _spriteRenderer;

        public Human(Transform transform) : base(transform)
        {
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = Vector3.zero;
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public Vector3 Force => _force;

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public void FixedPhysics()
        {
            Debug.Log("HumanFixedPhysics...");
            //_rigidbody2D.AddForce(Force);
        }

        public override void Do()
        {
            Move();
        }

        public override void Stop()
        {
            base.Stop();
        }

        public override void TurnBack()
        {
            base.TurnBack();
            SpriteRenderer.flipX = true;
        }

        public override void TurnForward()
        {
            base.TurnForward();
            SpriteRenderer.flipX = false;
        }
    }
}