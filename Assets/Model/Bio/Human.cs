using System.Collections.Generic;
using UnityEngine;
using Assets.Components;
using Assets.Model.Belong;

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
        IRenderable,
        IPicker,
        IUse
    {
        public event ILife.LifeStateHandler Born;
        public event ILife.LifeStateHandler Died;
        public event IAct.ActEventHandler Acted;
        public event IMovable.MovableEventHandler Moved;
        public event IPicker.PickEventHandler Picked;
        public event IUse.UseEventHandler Used;

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

        private readonly List<IUseable> _useables;
        private int _useableIndex;

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
            _useables = new List<IUseable>();
            _useableIndex = -1;
            Picked += ListenPicking;
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
                    X = Multiplier.ZERO;
                    break;
                case Action.BACK:
                    X = Multiplier.NEGATIVE;
                    break;
                case Action.FORWARD:
                    X = Multiplier.POSITIVE;
                    break;
                case Action.USE:
                    Use();
                    break;
            }
            OnActed(new ActionInfo<IAct>(this, action));
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

        public void Use()
        {
            OnUsed();
        }

        public void Pick(PickInfo pickInfo)
        {
            OnPicked(pickInfo);
        }

        public void FixedUpdate()
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

        public void OnActed(ActionInfo<IAct> actionInfo)
        {
            Acted?.Invoke(actionInfo);
        }

        public void OnMoved()
        {
            Moved?.Invoke(new MovementInfo(this, Transform.position));
        }

        public void OnPicked(PickInfo pickInfo)
        {
            Picked?.Invoke(pickInfo);
        }

        public void OnUsed()
        {
            Used?.Invoke(new UseInfo(_useables[_useableIndex]));
        }

        // Class originals

        public void ReceiveOrder(ActionInfo<IAct> actionInfo)
        {
            Act(actionInfo.Action);
        }

        public void ListenPicking(PickInfo pickInfo)
        {
            if (!pickInfo.Picker.Equals(this))
                return;

            IEntity picked = pickInfo.Picked;
            if (picked is IUseable)
                AddUseable(picked as IUseable);
        }

        private void AddUseable(IUseable useable)
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
            IEntityComponent component = collision.collider.GetComponent<IEntityComponent>();
            if (component == null)
                return;
            
            IEntity entity = component.Entity;
            if (entity is IUseable)
            {
                Pick(new PickInfo(this, entity));
                return;
            }
        }
    }
}