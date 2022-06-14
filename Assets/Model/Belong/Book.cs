using UnityEngine;

namespace Assets.Model.Belong
{
    public class Book :
        IEntity,
        IForce,
        IUseable,
        IColliderable,
        IRenderable,
        INoisier
    {
        public event IUseable.UseableEventHandler Used;

        private const float START_DEGREES = 90f;
        private const float MAXIMUM_DEGREES = 450f;
        private const float SPEED = 500f;

        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody2D;
        private Vector3 _force;
        private readonly BoxCollider2D _boxCollider2D;
        private readonly SpriteRenderer _spriteRenderer;
        private readonly AudioSource _audioSource;

        private bool _using;
        private float _degrees;

        public Book(Transform transform)
        {
            _transform = transform;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = Vector3.zero;
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

        public Vector3 Force => _force;

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            FixedUse();
        }

        public void FixedUse()
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

            _degrees += Time.fixedDeltaTime * SPEED;
        }

        public void OnUsed()
        {
            Used?.Invoke(new UseableInfo(this));
        }

        // Class originals

        public void ListenPicking(PickInfo pickInfo)
        {
            IEntity picker;
            if (pickInfo.Picker is IEntity)
                picker = pickInfo.Picker;
            else
                return;

            if (!pickInfo.Picked.Equals(this))
                return;
            else
            {
                Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;
                Renderer.enabled = false;
                Collider2D.isTrigger = true;
                Transform.SetParent(picker.Transform);
                Transform.localPosition = new Vector3(0f, 0f, Transform.parent.position.z);
            }
        }

        public void ListenRequestToUse(UseInfo useInfo)
        {
            if (!useInfo.Used.Equals(this))
                return;

            if (_using)
                return;
            
            _using = true;
        }
    }
}