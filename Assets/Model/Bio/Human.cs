using UnityEngine;

namespace Assets.Model.Bio
{
    public class Human :
        IEntity,
        ILife,
        IAct,
        IMovable,
        IForce,
        IColliderable,
        IEar,
        INoisier,
        IRenderable
    {
        public event ILife.LifeStateHandler Born;
        public event ILife.LifeStateHandler Died;
        public event IAct.ActEventHandler Acted;
        public event IMovable.MovableEventHandler Moved;

        private readonly Transform _transform;
        private BioState _lifeState;
        private readonly XYZValue _speed;
        private Multiplier _x;
        private Multiplier _y;
        private Multiplier _z;
        private readonly Rigidbody2D _rigidbody2D;
        private Vector3 _force;
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly PolygonCollider2D _polygonCollider2D;
        private readonly SpriteRenderer _spriteRenderer;

        public Human(Transform transform)
        {
            _transform = transform;
            _speed = XYZValue.ZERO;
            _x = Multiplier.ZERO;
            _y = Multiplier.ZERO;
            _z = Multiplier.ZERO;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = Vector3.zero;
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public BioState BioState
        {
            get => _lifeState;
            set => _lifeState = value;
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

        public Transform Transform => _transform;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public Vector3 Force => throw new System.NotImplementedException();

        public Collider2D Collider2D => _polygonCollider2D;

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public Renderer Renderer => _spriteRenderer;

        public void Exist()
        {
            throw new UnityException();
        }

        public void Move()
        {
            throw new UnityException();
        }

        public void FixedPhysics()
        {
            throw new UnityException();
        }

        public void OnBorn()
        {
            throw new UnityException();
        }

        public void OnDied()
        {
            throw new UnityException();
        }

        public void OnActed(Action action)
        {
            throw new UnityException();
        }

        public void OnMoved()
        {
            throw new UnityException();
        }
    }
}