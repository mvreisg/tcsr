using UnityEngine;
using Assets.Rules.Control;

namespace Assets.Rules.Bio
{
    public class Bestmare : 
        IRule,
        IRenderable,
        ICollider,
        IPhysics,
        IMovable,
        IOrderListener,
        IAct
    {
        public event IMovable.MovableEventHandler Moved;
        public event IAct.ActEventHandler Acted;

        private readonly Transform _transform;
        private readonly XYZValue _speed;
        private readonly Orientation _orientation;
        private readonly Facing _facing;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly CapsuleCollider2D _capsuleCollider2D;
        private readonly SpriteRenderer _spriteRenderer;

        public Bestmare(Transform transform)
        {
            _transform = transform;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _speed = XYZValue.ZERO;
            _orientation = new Orientation();
            _facing = new Facing(Flags.POSITIVE);
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _capsuleCollider2D = transform.GetComponent<CapsuleCollider2D>();
        }

        public Transform Transform => _transform;

        public Facing Facing => _facing;

        public XYZValue Speed => _speed;

        public Orientation Orientation => _orientation;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public Collider2D Collider2D => _capsuleCollider2D;

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

        public void ListenOrder(OrderInfo info)
        {
            Act(info.Action);
        }

        public void Act(Action action)
        {
            switch (action)
            {
                default:
                    throw new UnityException($"unhandled state: {action}");
                case Action.TURN_FORWARD:
                    Facing.X = Flags.POSITIVE;
                    break;
                case Action.FORWARD:
                    Orientation.X = Flags.POSITIVE;
                    break;
                case Action.TURN_BACK:
                    Facing.X = Flags.NEGATIVE;
                    break;
                case Action.BACK:
                    Orientation.X = Flags.NEGATIVE;
                    break;
                case Action.STOP:
                    Orientation.X = Flags.ZERO;
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
            Flags xFlag = Orientation.X;
            float x;
            switch (xFlag)
            {
                default:
                    throw new UnityException($"unhandled state: {xFlag}");
                case Flags.NEGATIVE:
                    x = -1f;
                    (Renderer as SpriteRenderer).flipX = true;
                    break;
                case Flags.ZERO:
                    x = 0f;
                    break;
                case Flags.POSITIVE:
                    x = 1f;
                    (Renderer as SpriteRenderer).flipX = false;
                    break;
            }

            float sx = x * Speed.X;
            Transform.Translate(Time.deltaTime * new Vector3(sx, 0f, 0f));
            OnMoved(new MovementInfo(this, Transform.position));
        }

        public void FixedUpdate()
        {
            
        }

        public void OnActed(ActionInfo info)
        {
            Acted?.Invoke(info);
        }

        public void OnMoved(MovementInfo info)
        {
            Moved?.Invoke(info);
        }
    }
}