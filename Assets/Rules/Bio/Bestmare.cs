using UnityEngine;
using Assets.Rules.Control;

namespace Assets.Rules.Bio
{
    public class Bestmare : 
        IRule,
        IAct,
        IMovable,
        IPhysics,
        IColliderable,
        IEar,
        INoisier,
        IRenderable
    {
        public event IAct.ActEventHandler Acted;
        public event IMovable.MovableEventHandler Moved;

        private readonly Transform _transform;
        private readonly XYZValue _speed;
        private readonly Orientation _orientation;
        private readonly Facing _facing;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly CapsuleCollider2D _capsuleCollider2D;
        private readonly SpriteRenderer _spriteRenderer;

        public Bestmare(Transform transform)
        {
            _transform = transform;
            _speed = XYZValue.ZERO;
            _orientation = new Orientation();
            _facing = new Facing(Flag.POSITIVE);
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
            _capsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Facing Facing => _facing;

        public XYZValue Speed => _speed;

        public Orientation Orientation => _orientation;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public Collider2D Collider2D => _capsuleCollider2D;

        public AudioListener AudioListener => _audioListener;

        public AudioSource AudioSource => _audioSource;

        public Renderer Renderer => _spriteRenderer;

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            Move();
        }

        public void Act(Action action)
        {
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.TURN_FORWARD:
                    Facing.X = Flag.POSITIVE;
                    break;
                case Action.FORWARD:
                    Orientation.X = Flag.POSITIVE;
                    break;
                case Action.TURN_BACK:
                    Facing.X = Flag.NEGATIVE;
                    break;
                case Action.BACK:
                    Orientation.X = Flag.NEGATIVE;
                    break;
                case Action.STOP:
                    Orientation.X = Flag.ZERO;
                    break;
                case Action.IDLE:
                    break;
                case Action.USE:
                    break;
            }
            OnActed(new ActionInfo(this, action, Facing));
        }

        public void Move()
        {
            Flag xFlag = Orientation.X;
            float x;
            switch (xFlag)
            {
                default:
                    throw new UnityException($"unhandled state: {xFlag}");
                case Flag.NEGATIVE:
                    x = -1f;
                    (Renderer as SpriteRenderer).flipX = true;
                    break;
                case Flag.ZERO:
                    x = 0f;
                    break;
                case Flag.POSITIVE:
                    x = 1f;
                    (Renderer as SpriteRenderer).flipX = false;
                    break;
            }

            float sx = x * Speed.X;
            Transform.Translate(Time.deltaTime * new Vector3(sx, 0f, 0f));
            OnMoved();
        }

        public void FixedUpdate()
        {
            throw new UnityException();
        }

        public void OnActed(ActionInfo info)
        {
            Acted?.Invoke(info);
        }

        public void OnMoved()
        {
            Moved?.Invoke(new MovementInfo(this, Transform.position));
        }

        // Class originals

        public void ReceiveOrder(OrderInfo info)
        {
            Act(info.Action);
        }
    }
}