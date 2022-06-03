using UnityEngine;

namespace Assets.Resources.Model.Belong
{
    public class Book : Belonging,
        ITransform,
        ISpriteRenderer,
        INoisier,
        IBoxCollider2D
    {
        private readonly XYZValue _speed;
        private Multiplier _x;
        private Multiplier _y;
        private Multiplier _z;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly AudioSource _audioSource;
        private readonly BoxCollider2D _boxCollider2D;

        public Book(
            Transform transform, 
            Vector3 force, 
            XYZValue speed,
            Multiplier x,
            Multiplier y,
            Multiplier z) : 
            base(transform, force)
        {
            _speed = speed;
            _x = x;
            _y = y;
            _z = z;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _audioSource = transform.GetComponent<AudioSource>();
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
        }

        public XYZValue Speed => _speed;

        public Multiplier X
        {
            get => _x;
            set => _x = value;
        }

        public Multiplier Y
        {
            get => _y;
            set => _y = value;
        }

        public Multiplier Z
        {
            get => _z;
            set => _z = value;
        }

        public SpriteRenderer SpriteRenderer => _spriteRenderer;

        public AudioSource AudioSource => _audioSource;

        public BoxCollider2D BoxCollider2D => _boxCollider2D;

        public void Move()
        {
            Debug.Log("Book movement here");
        }

        public override void Do()
        {
            base.Do();
            Move();
        }
    }
}