using UnityEngine;
using Assets.Rules.Control;
using Assets.Scripts;

namespace Assets.Rules.Bio
{
    public class Human :
        IRule,
        IRenderable,
        IOrderListener,
        IAct,
        ICollider,
        ICollision,
        ICollisionListener,
        IPhysics,
        IMovable,
        IPicker,
        IUse
    {
        public event IAct.ActEventHandler Acted;
        public event ICollision.CollisionEventHandler CollisionEntered;
        public event ICollision.CollisionEventHandler CollisionExited;
        public event IMovable.MovableEventHandler Moved;
        public event IPicker.PickerEventHandler Picked;
        public event IUse.UseEventHandler Used;

        private readonly Transform _transform;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly XYZValue _speed;
        private readonly Orientation _orientation;
        private readonly Facing _facing;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly PolygonCollider2D _polygonCollider2D;

        private Items.ItemTypes _holding;

        public Human(Transform transform)
        {
            _transform = transform;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _speed = XYZValue.ZERO;
            _orientation = new Orientation();
            _facing = new Facing(Flags.POSITIVE);
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
        }

        public Transform Transform => _transform;

        public Facing Facing => _facing;

        public XYZValue Speed => _speed;

        public Orientation Orientation => _orientation;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public Collider2D Collider2D => _polygonCollider2D;

        public Renderer Renderer => _spriteRenderer;

        public void Awake()
        {
            CollisionEntered += ListenCollisionEntered;
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            Move();
        }

        public void FixedUpdate()
        {

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
                    Orientation.X = Flags.ZERO;
                    break;
                case Action.TURN_BACK:
                    Facing.X = Flags.NEGATIVE;
                    break;
                case Action.BACK:
                    Orientation.X = Flags.NEGATIVE;
                    break;
                case Action.TURN_FORWARD:
                    Facing.X = Flags.POSITIVE;
                    break;
                case Action.FORWARD:
                    Orientation.X = Flags.POSITIVE;
                    break;
                case Action.USE:
                    Use();
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

        public void Use()
        {
            OnUsed(new UseInfo(this));
        }

        public void Pick(PickInfo info)
        {
            OnPicked(info);
        }

        public void ListenOrder(OrderInfo info)
        {
            Act(info.Action);
        }

        public void ListenCollisionEntered(CollisionInfo info)
        {
            Collision2D collision = info.Collision;
            IRuleScript component = collision.collider.GetComponent<IRuleScript>();
            if (component is null)
                return;

            IRule rule = component.Rule;
            if (rule is not IUsable)
                return;

            IUsable usable = rule as IUsable;
            Pick(new PickInfo(this, usable));
        }

        public void ListenCollisionExited(CollisionInfo info)
        {
            
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionEntered?.Invoke(new CollisionInfo(this, collision));
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            CollisionExited?.Invoke(new CollisionInfo(this, collision));
        }

        public void OnActed(ActionInfo info)
        {
            Acted?.Invoke(info);
        }

        public void OnMoved(MovementInfo info)
        {
            Moved?.Invoke(info);
        }

        public void OnPicked(PickInfo info)
        {
            Picked?.Invoke(info);
        }

        public void OnUsed(UseInfo info)
        {
            Used?.Invoke(info);
        }
    }
}