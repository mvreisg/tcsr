using UnityEngine;

namespace Assets.Model.Belong
{
    public class Book :
        IModel,
        IPhysics,
        IUsable,
        IColliderable,
        IRenderable,
        INoisier
    {
        public event IUsable.UsableEventHandler Used;

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

        public void Awake()
        {
            
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
            if (!_using)
                return;

            Renderer.enabled = true;
            float x = Mathf.Cos(_degrees * Mathf.Deg2Rad);
            float y = Mathf.Sin(_degrees * Mathf.Deg2Rad);

            Transform.localPosition = new Vector3(x, y, Transform.localPosition.z);

            if (_degrees >= MAXIMUM_DEGREES)
            {
                _using = false;
                _degrees = START_DEGREES;
                Transform.localPosition = Vector3.zero;
                Renderer.enabled = false;
                OnUsed();
                return;
            }

            _degrees += Time.deltaTime * SPEED;
        }

        public void OnUsed()
        {
            Used?.Invoke(new UsableInfo(this));
        }

        // Class originals

        public void ListenPicking(PickInfo info)
        {
            if (!info.Picked.Equals(this))
                return;
            else
            {
                Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                Renderer.enabled = false;
                Collider2D.isTrigger = true;
                Transform.SetParent((info.Picker as IModel).Transform);
                Transform.localPosition = new Vector3(0f, 0f, Transform.parent.position.z);
            }
        }

        public void ListenRequestToUse(UserInfo useInfo)
        {
            if (!useInfo.Used.Equals(this))
                return;

            if (_using)
                return;
            
            _using = true;
        }
    }
}