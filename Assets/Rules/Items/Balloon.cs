using UnityEngine;

namespace Assets.Rules.Items
{
    public class Balloon :
        IRule,
        ISpawn,
        IPass,
        IPhysics,
        IRenderable
    {
        private readonly Transform _transform;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly SpriteRenderer _spriteRenderer;

        public event ISpawn.SpawnEventHandler Spawned;
        public event IPass.PassEventHandler Passed;

        public Balloon(Transform transform)
        {
            _transform = transform;
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force
        {
            get
            {
                float xMultiplier;
                if (Random.Range(0f, 1f) >= 0.5f)
                    xMultiplier = 1f;
                else
                    xMultiplier = -1f;

                return new XYZValue(
                    Random.Range(0.00075f, 0.001f) * xMultiplier,
                    Random.Range(0.0005f, 0.00075f),
                    0f
                );
            }    
        }

        public Renderer Renderer => _spriteRenderer;

        public void Awake()
        {
            (Renderer as SpriteRenderer).color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
        }

        public void Start()
        {
            Spawn();
        }

        public void Update()
        {
            
        }

        public void FixedUpdate()
        {
            Rigidbody2D.AddForce(
                Time.fixedDeltaTime * 
                new Vector3(
                    Force.X,
                    Force.Y,
                    Force.Z
                )
            );
        }

        public void Spawn()
        {
            OnSpawned(new SpawnInfo(this));
        }

        public void Pass()
        {
            OnPassed(new LateInfo(this));
        }

        public void OnSpawned(SpawnInfo info)
        {
            Spawned?.Invoke(info);
        }

        public void OnPassed(LateInfo info)
        {
            Passed?.Invoke(info);
        }
    }
}