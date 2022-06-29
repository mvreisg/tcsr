using UnityEngine;
using Assets.Scripts;

namespace Assets.Rules.Items
{
    public class Scythe : 
        IRule,
        IActListener,
        ICollider,
        ICollision,
        ICollisionListener,
        ITrigger,
        ITriggerListener,
        IPhysics,
        IRenderable,
        IUseListener,
        IUsable
    {
        public event ICollision.CollisionEventHandler CollisionEntered;
        public event ICollision.CollisionEventHandler CollisionExited;
        public event ITrigger.TriggerEventHandler TriggerEntered;
        public event ITrigger.TriggerEventHandler TriggerExited;
        public event IUsable.UsableEventHandler BeingUsed;
        public event IUsable.UsableEventHandler WasUsed;

        private const float BACK_START_DEGREES = 45f;
        private const float FORWARD_START_DEGREES = -45f;
        private const float DELTA_DEGREES = 90f;

        private readonly Transform _transform;
        private readonly PolygonCollider2D _polygonCollider2D;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly SpriteRenderer _spriteRenderer;

        private bool _using;
        private float _elapsedDegrees;
        private float _calculatedDegrees;
        private Flags _xFlag;
        private float _xMultiplier;
        private float _radius;

        public Scythe(Transform transform)
        {
            _transform = transform;
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Collider2D Collider2D => _polygonCollider2D;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public Renderer Renderer => _spriteRenderer;

        public ItemTypes Type => ItemTypes.SCYTHE;

        public bool Using
        {
            get => _using;
            private set => _using = value;
        }

        public void Awake()
        {
            CollisionEntered += ListenCollisionEntered;
            CollisionExited += ListenCollisionExited;
            TriggerEntered += ListenTriggerEntered;
            TriggerExited += ListenTriggerExited;
            _elapsedDegrees = 0f;
            _xFlag = Flags.POSITIVE;
            _radius = 0.5f;
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            Use();
        }

        public void FixedUpdate()
        {
            
        }

        public void Use()
        {
            if (!Using)
                return;

            float x = Mathf.Cos(_elapsedDegrees * Mathf.Deg2Rad);

            Transform.localPosition = new Vector3(
                _radius * x * _xMultiplier,
                _radius * -0.01f * _elapsedDegrees,
                Transform.position.z
            );

            _calculatedDegrees = 0f;
            if (_xFlag.Equals(Flags.NEGATIVE))
                _calculatedDegrees = BACK_START_DEGREES + _elapsedDegrees;

            if (_xFlag.Equals(Flags.POSITIVE))
                _calculatedDegrees = FORWARD_START_DEGREES - _elapsedDegrees;

            Transform.eulerAngles = new Vector3(
                0f,
                0f,
                _calculatedDegrees
            );

            OnBeingUsed(new UsableInfo(this));

            _elapsedDegrees += Time.deltaTime * 200f;
            if (_elapsedDegrees >= DELTA_DEGREES)
            {
                _elapsedDegrees = 0f;
                Using = false;
                (Renderer as SpriteRenderer).enabled = false;
                Transform.localPosition = Vector3.zero;
                Transform.eulerAngles = Vector3.zero;
                OnWasUsed(new UsableInfo(this));
            }
        }

        public void OnCollisionEnter2D(Collision2D collision)
        {
            CollisionEntered?.Invoke(new CollisionInfo(this, collision));
        }

        public void OnCollisionExit2D(Collision2D collision)
        {
            CollisionExited?.Invoke(new CollisionInfo(this, collision));
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            TriggerEntered?.Invoke(new TriggerInfo(this, collider));
        }

        public void OnTriggerExit2D(Collider2D collider)
        {
            TriggerExited?.Invoke(new TriggerInfo(this, collider));
        }

        public void OnBeingUsed(UsableInfo info)
        {
            BeingUsed?.Invoke(info);
        }

        public void OnWasUsed(UsableInfo info)
        {
            WasUsed?.Invoke(info);
        }

        public void ListenCollisionEntered(CollisionInfo info)
        {
            Collision2D collision = info.Collision;
            IRuleScript script = collision.transform.GetComponent<IRuleScript>();
            if (script is null)
                return;
            IRule rule = script.Rule;
            if (rule is not IPicker)
                return;
            Transform.SetParent(rule.Transform);
            Transform.localPosition = Vector3.zero;
            (Renderer as SpriteRenderer).enabled = false;
            Rigidbody2D.isKinematic = true;
            Collider2D.isTrigger = true;
            if (rule is not IAct)
                return;
            (rule as IAct).Acted += ListenAct;
        }

        public void ListenCollisionExited(CollisionInfo info)
        {

        }

        public void ListenTriggerEntered(TriggerInfo info)
        {
            IRuleScript script = info.Collider.transform.GetComponent<IRuleScript>();
            if (script is null)
                return;
            IRule rule = script.Rule;
            if (rule is not IUsableListener)
                return;
            BeingUsed += (rule as IUsableListener).ListenUsableWhileBeingUsed;
        }

        public void ListenTriggerExited(TriggerInfo info)
        {
            
        }

        public void ListenUse(UseInfo info)
        {
            IRule parent = Transform.parent.GetComponent<IRuleScript>().Rule;
            if (parent is not IUse)
                throw new UnityException("why is this object listening use?");
            if (!info.User.Equals(parent))
                return;
            if (Using)
                return;
            Using = true;
            (Renderer as SpriteRenderer).enabled = true;
        }

        public void ListenAct(ActionInfo info)
        {
            Flags x = info.Facing.X;
            if (x.Equals(Flags.NEGATIVE))
            {
                _xFlag = Flags.NEGATIVE;
                _xMultiplier = -1f;
                (Renderer as SpriteRenderer).flipX = true;
                return;
            }
            if (x.Equals(Flags.POSITIVE))
            {
                _xFlag = Flags.POSITIVE;
                _xMultiplier = 1f;
                (Renderer as SpriteRenderer).flipX = false;
                return;
            }
        }
    }
}