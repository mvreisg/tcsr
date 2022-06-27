using UnityEngine;
using Assets.Rules.Items;
using Assets.Rules.Control;
using Assets.Scripts.Rules;

namespace Assets.Rules.Bio
{
    public class Human :
        IRule,
        IAct,
        IMovable,
        IPhysics,
        IColliderable,
        IEar,
        INoisier,
        IRenderable,
        IPicker,
        IUser
    {
        public event IAct.ActEventHandler Acted;
        public event IMovable.MovableEventHandler Moved;
        public event IPicker.PickerEventHandler Picked;
        public event IUser.UserEventHandler Used;

        private readonly Transform _transform;
        private readonly XYZValue _speed;
        private readonly Orientation _orientation;
        private readonly Facing _facing;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly PolygonCollider2D _polygonCollider2D;
        private readonly SpriteRenderer _spriteRenderer;

        private Item _holding;

        public Human(Transform transform)
        {
            _transform = transform;
            _speed = XYZValue.ZERO;
            _orientation = new Orientation();
            _facing = new Facing(Flag.POSITIVE);
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Facing Facing => _facing;

        public XYZValue Speed => _speed;

        public Orientation Orientation => _orientation;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public Collider2D Collider2D => _polygonCollider2D;

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
                case Action.IDLE:
                    break;
                case Action.STOP:
                    Orientation.X = Flag.ZERO;
                    break;
                case Action.TURN_BACK:
                    Facing.X = Flag.NEGATIVE;
                    break;
                case Action.BACK:
                    Orientation.X = Flag.NEGATIVE;
                    break;
                case Action.TURN_FORWARD:
                    Facing.X = Flag.POSITIVE;
                    break;
                case Action.FORWARD:
                    Orientation.X = Flag.POSITIVE;
                    break;
                case Action.USE:
                    Use();
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

        public void Use()
        {
            OnUsed();
        }

        public void Pick(PickInfo info)
        {
            OnPicked(info);
        }

        public void FixedUpdate()
        {
            
        }

        public void OnActed(ActionInfo info)
        {
            Acted?.Invoke(info);
        }

        public void OnMoved()
        {
            Moved?.Invoke(new MovementInfo(this, Transform.position));
        }

        public void OnPicked(PickInfo info)
        {
            Picked?.Invoke(info);
        }

        public void OnUsed()
        {
            Used?.Invoke(new UseInfo(this, _holding));
        }

        // Class originals

        public void ReceiveOrder(OrderInfo info)
        {
            Act(info.Action);
        }

        // Collisions

        public void OnCollisionEnter2D(Collision2D collision)
        {
            IRuleScript component = collision.collider.GetComponent<IRuleScript>();
            if (component is null)
                return;
            
            IRule rule = component.Rule;
            if (rule is not IUsable)
                return;

            IUsable usable = rule as IUsable;
            Pick(new PickInfo(this, usable));
        }
    }
}