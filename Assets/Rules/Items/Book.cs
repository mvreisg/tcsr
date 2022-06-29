using UnityEngine;
using Assets.Scripts;

namespace Assets.Rules.Items
{
    public class Book :
        IRule,
        ICollider,
        ICollision,
        ICollisionListener,
        ITrigger,
        ITriggerListener,
        IPhysics,
        IRenderable,
        INoisier,
        IUseListener,
        IUsable
    {
        public event ICollision.CollisionEventHandler CollisionEntered;
        public event ICollision.CollisionEventHandler CollisionExited;
        public event ITrigger.TriggerEventHandler TriggerEntered;
        public event ITrigger.TriggerEventHandler TriggerExited;
        public event IUsable.UsableEventHandler BeingUsed;
        public event IUsable.UsableEventHandler WasUsed;

        private const float START_DEGREES = 90f;
        private const float MAXIMUM_DEGREES = 450f;
        private const float SPEED = 500f;

        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly AudioSource _audioSource;

        private bool _using;
        private float _degrees;

        public Book(Transform transform)
        {
            _transform = transform;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _boxCollider2D = transform.GetComponent<BoxCollider2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
            _audioSource = transform.GetComponent<AudioSource>();
            _degrees = START_DEGREES;
        }

        public Transform Transform => _transform;

        public Collider2D Collider2D => _boxCollider2D;

        public Renderer Renderer => _spriteRenderer;

        public AudioSource AudioSource => _audioSource;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public ItemTypes Type => ItemTypes.BOOK;

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

            Renderer.enabled = true;
            float x = Mathf.Cos(_degrees * Mathf.Deg2Rad);
            float y = Mathf.Sin(_degrees * Mathf.Deg2Rad);

            Transform.localPosition = new Vector3(x, y, Transform.localPosition.z);

            OnBeingUsed(new UsableInfo(this));

            if (_degrees >= MAXIMUM_DEGREES)
            {
                Using = false;
                _degrees = START_DEGREES;
                Transform.localPosition = Vector3.zero;
                Renderer.enabled = false;
                OnWasUsed(new UsableInfo(this));
                return;
            }
            _degrees += Time.deltaTime * SPEED;
        }

        public void OnBeingUsed(UsableInfo info)
        {
            BeingUsed?.Invoke(info);
        }

        public void OnWasUsed(UsableInfo info)
        {
            WasUsed?.Invoke(info);
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
            Collider2D.isTrigger = true;
            Rigidbody2D.isKinematic = true;
        }

        public void ListenCollisionExited(CollisionInfo info)
        {

        }

        public void ListenTriggerEntered(TriggerInfo info)
        {
            
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
        }
    }
}