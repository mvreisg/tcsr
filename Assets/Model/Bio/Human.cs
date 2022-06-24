using System.Collections.Generic;
using UnityEngine;
using Assets.Components.Model;
using Assets.Model.Belong;

namespace Assets.Model.Bio
{
    public class Human :
        IModel,
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
        private readonly Multiplier _multiplier;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly AudioListener _audioListener;
        private readonly AudioSource _audioSource;
        private readonly PolygonCollider2D _polygonCollider2D;
        private readonly SpriteRenderer _spriteRenderer;

        private readonly List<IUsable> _useables;
        private int _useableIndex;

        public Human(Transform transform)
        {
            _transform = transform;
            _speed = XYZValue.ZERO;
            _multiplier = new Multiplier();
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _audioListener = transform.GetComponent<AudioListener>();
            _audioSource = transform.GetComponent<AudioSource>();
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _useables = new List<IUsable>();
            _useableIndex = -1;
            Picked += ListenPicking;
        }

        public Transform Transform => _transform;

        public XYZValue Speed => _speed;

        public Multiplier Multiplier => _multiplier;

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
                    Multiplier.X = Flag.ZERO;
                    break;
                case Action.BACK:
                    Multiplier.X = Flag.NEGATIVE;
                    break;
                case Action.FORWARD:
                    Multiplier.X = Flag.POSITIVE;
                    break;
                case Action.USE:
                    Use();
                    break;
            }
            OnActed(new ActionInfo(this, action));
        }

        public void Move()
        {
            Flag xFlag = Multiplier.X;
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
            Used?.Invoke(new UserInfo(this, _useables[_useableIndex]));
        }

        // Class originals

        public void ReceiveOrder(ActionInfo info)
        {
            Act(info.Action);
        }

        public void ListenPicking(PickInfo info)
        {
            if (!info.Picker.Equals(this))
                return;

            AddUseable(info.Picked);
        }

        private void AddUseable(IUsable useable)
        {
            if (_useables.Contains(useable))
                throw new UnityException("picking same item >:( (burro as mvreisg)");
            if (_useables.Count == 0)
                _useableIndex = 0;
            _useables.Add(useable);
            if (useable is Book)
            {
                Used += (useable as Book).ListenRequestToUse;
            }
        }

        // Collisions

        public void OnCollisionEnter2D(Collision2D collision)
        {
            IModelComponent component = collision.collider.GetComponent<IModelComponent>();
            if (component == null)
                return;
            
            IModel entity = component.Model;
            if (entity is IUsable)
            {
                Pick(new PickInfo(this, entity as IUsable));
                return;
            }
        }
    }
}