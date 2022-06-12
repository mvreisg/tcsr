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

        public Transform Transform => _transform;

        public BioState BioState => BioState.ALIVE;

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

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public Vector3 Force => _force;

        public Collider2D Collider2D => _polygonCollider2D;

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public Renderer Renderer => _spriteRenderer;

        public void Exist()
        {
            Move();
        }

        public void Act(Action action)
        {
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.IDLE:
                    break;
                case Action.STOP:
                    X = Multiplier.ZERO;
                    break;
                case Action.BACK:
                    X = Multiplier.NEGATIVE;
                    break;
                case Action.FORWARD:
                    X = Multiplier.POSITIVE;
                    break;
                case Action.USE:
                    break;
            }
            OnActed(new ActionInfo(this, action));
        }

        public void Move()
        {
            float x;
            switch (X)
            {
                default:
                    throw new UnityException($"unhandled state: {X}");
                case Multiplier.NEGATIVE:
                    x = -1f;
                    (Renderer as SpriteRenderer).flipX = true;
                    break;
                case Multiplier.ZERO:
                    x = 0f;
                    break;
                case Multiplier.POSITIVE:
                    x = 1f;
                    (Renderer as SpriteRenderer).flipX = false;
                    break;
            }

            float sx = x * Speed.X;
            Transform.Translate(Time.deltaTime * new Vector3(sx, 0f, 0f));
            OnMoved();
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

        public void OnActed(ActionInfo actionInfo)
        {
            Acted?.Invoke(actionInfo);
        }

        public void OnMoved()
        {
            Moved?.Invoke(Transform.position);
        }

        // Class originals

        public void ReceiveOrder(ActionInfo actionInfo)
        {
            Act(actionInfo.Action);
        }
    }
}