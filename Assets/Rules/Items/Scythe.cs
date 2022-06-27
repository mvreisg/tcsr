using UnityEngine;
using Assets.Rules.Grids;
using Assets.Scripts;

namespace Assets.Rules.Items
{
    public class Scythe : 
        IRule,
        IMovable,
        IColliderable,
        IPhysics,
        IRenderable,
        IUsable
    {
        public event IMovable.MovableEventHandler Moved;
        public event IUsable.UsableEventHandler Used;

        private const float BACK_START_DEGREES = 45f;
        private const float FORWARD_START_DEGREES = -45f;
        private const float DELTA_DEGREES = 90f;

        private readonly Transform _transform;
        private readonly XYZValue _speed;
        private readonly Orientation _orientation;
        private readonly PolygonCollider2D _polygonCollider2D;
        private readonly Rigidbody2D _rigidbody2D;
        private readonly XYZValue _force;
        private readonly SpriteRenderer _spriteRenderer;

        private bool _using;
        private float _elapsedDegrees;
        private float _calculatedDegrees;
        private Flag _xFlag;
        private float _xMultiplier;
        private float _radius;

        public Scythe(Transform transform)
        {
            _transform = transform;
            _speed = XYZValue.ZERO;
            _orientation = new Orientation();
            _polygonCollider2D = transform.GetComponent<PolygonCollider2D>();
            _rigidbody2D = transform.GetComponent<Rigidbody2D>();
            _force = XYZValue.ZERO;
            _spriteRenderer = transform.GetComponent<SpriteRenderer>();
        }

        public Transform Transform => _transform;

        public XYZValue Speed => _speed;

        public Orientation Orientation => _orientation;

        public Collider2D Collider2D => _polygonCollider2D;

        public Rigidbody2D Rigidbody2D => _rigidbody2D;

        public XYZValue Force => _force;

        public Renderer Renderer => _spriteRenderer;

        public Item Type => Item.SCYTHE;

        public bool Using
        {
            get => _using;
            private set => _using = value;
        }

        public void Awake()
        {
            _elapsedDegrees = 0f;
            _xFlag = Flag.POSITIVE;
            _radius = 0.5f;
        }

        public void Start()
        {
            IRuleScript[] scripts = Transform.parent.GetComponentsInChildren<IRuleScript>();
            foreach(IRuleScript script in scripts)
            {
                IRule rule = script.Rule;
                if (rule is PlantationGrid)
                    Used += (rule as PlantationGrid).ListenScytheUse;
            }
        }

        public void Update()
        {
            Use();
        }

        public void Move()
        {
            float x = Mathf.Cos(_elapsedDegrees * Mathf.Deg2Rad);

            Transform.localPosition = new Vector3(
                _radius * x * _xMultiplier,
                _radius * -0.01f * _elapsedDegrees,
                Transform.position.z
            );

            _calculatedDegrees = 0f;
            if (_xFlag.Equals(Flag.NEGATIVE))
                _calculatedDegrees = BACK_START_DEGREES + _elapsedDegrees;

            if (_xFlag.Equals(Flag.POSITIVE))
                _calculatedDegrees = FORWARD_START_DEGREES - _elapsedDegrees;

            Transform.eulerAngles = new Vector3(
                0f,
                0f,
                _calculatedDegrees
            );

            _elapsedDegrees += Time.deltaTime * 200f;
            /*
            Debug.LogFormat(
                "{0} <= {1} - ({2}) - {3} - {4}", 
                _elapsedDegrees, 
                DELTA_DEGREES, 
                _calculatedDegrees, 
                Transform.eulerAngles,
                _xFlag
            );*/
            if (_elapsedDegrees >= DELTA_DEGREES)
            {
                _elapsedDegrees = 0f;
                Using = false;
                (Renderer as SpriteRenderer).enabled = false;
                Transform.localPosition = Vector3.zero;
                Transform.eulerAngles = Vector3.zero;
            }
            OnMoved();
        }

        public void FixedUpdate()
        {
            // Apply force here
        }

        public void Use()
        {
            if (!Using)
                return;
            Move();
            OnUsed();
        }

        public void OnUsed()
        {
            Used?.Invoke(new UsableInfo(this));
        }

        public void OnMoved()
        {
            Moved?.Invoke(new MovementInfo(this, Transform.position));
        }

        // Class originals

        public void ListenUse(UseInfo info)
        {
            IRule parent = Transform.parent.GetComponent<IRuleScript>().Rule;
            if (parent is not IUser)
                throw new UnityException("why is this object listening use?");
            if (!info.User.Equals(parent))
                return;
            if (Using)
                return;
            Using = true;
            (Renderer as SpriteRenderer).enabled = true;
        }

        public void ListenUser(ActionInfo info)
        {
            Flag x = info.Facing.X;
            if (x.Equals(Flag.NEGATIVE))
            {
                _xFlag = Flag.NEGATIVE;
                _xMultiplier = -1f;
                (Renderer as SpriteRenderer).flipX = true;
                return;
            }
            if (x.Equals(Flag.POSITIVE))
            {
                _xFlag = Flag.POSITIVE;
                _xMultiplier = 1f;
                (Renderer as SpriteRenderer).flipX = false;
                return;
            }
        }

        // Collisions

        public void OnCollisionEnter2D(Collision2D collision)
        {
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
            (rule as IAct).Acted += ListenUser;
        }

        public void OnTriggerEnter2D(Collider2D collider)
        {
            
        }
    }
}