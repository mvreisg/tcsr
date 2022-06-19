using UnityEngine;

namespace Assets.Model.Belong
{
    public class Balloon :
        IModel,
        IPhysics,
        IRenderable
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly SpriteRenderer _spriteRenderer;

        public Balloon(Transform transform)
        {
            _transform = transform;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Acceleration
        {
            get
            {
                float xMultiplier;
                if (Random.Range(0f, 1f) >= 0.5f)
                    xMultiplier = 1f;
                else
                    xMultiplier = -1f;

                return new XYZValue(
                    Random.Range(0.00005f, 0.000075f) * xMultiplier,
                    Random.Range(0.00005f, 0.000075f),
                    0f
                );
            }    
        }

        public Renderer Renderer => _spriteRenderer;

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            Rigidbody2D.AddForce(
                new Vector3(
                    Time.fixedDeltaTime * Acceleration.X,
                    Time.fixedDeltaTime * Acceleration.Y,
                    Time.fixedDeltaTime * Acceleration.Z
                )
            );
        }
    }
}