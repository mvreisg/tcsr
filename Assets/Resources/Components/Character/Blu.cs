using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Components.Belongings;
using Assets.Resources.Components.GUI.Use;
using Assets.Resources.Pure;

namespace Assets.Resources.Components.Character
{
    public class Blu : MonoBehaviour, IMovable
    {
        public event IMovable.MovableEventHandler Moved;

        public bool CanMoveX { get; private set; }

        public bool CanMoveY { get; private set; }

        public bool CanMoveZ { get; private set; }

        public IMovable.X IsX { get; private set; }

        public IMovable.Y IsY => IMovable.Y.ZERO;

        public IMovable.Z IsZ => IMovable.Z.ZERO;

        public float SpeedX => 2.25f;

        public float SpeedY => 3f;

        public float SpeedZ => 0f;

        private GUIMovePressed _guiPressed;

        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody2D;

        private bool _onDiagonal;

        private const float ON_DIAGONAL_UP_FORCE = 10f;

        private bool FlipSpriteOnXAxis
        {
            set => _spriteRenderer.flipX = value;
        }

        public delegate void UsableEventHandler(IUsable usable);

        public event UsableEventHandler SelectUsable;

        private readonly Dictionary<IUsable.Type, IUsable> _belongings = new Dictionary<IUsable.Type, IUsable>();

        private void Awake()
        {
            IsX = IMovable.X.ZERO;
            CanMoveX = true;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            GetComponent<InatePower>().Get += Getted;
            GameObject.FindGameObjectWithTag(Tag.BOOK).GetComponent<IUsable>().Get += Getted;
            FindObjectOfType<BackButtonEventTrigger>().Pressed += ClickedPressed;
            FindObjectOfType<ForwardButtonEventTrigger>().Pressed += ClickedPressed;
        }

        private void ClickedPressed(GUIMovePressed guiPressed)
        {
            _guiPressed = guiPressed;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            float x = Input.GetAxisRaw("Horizontal");

            if (x < 0f)
                IsX = IMovable.X.NEGATIVE;
            else if (x > 0f)
                IsX = IMovable.X.POSITIVE;
            else
                IsX = IMovable.X.ZERO;

            if (Equals(IsX, IMovable.X.ZERO))
            {
                switch (_guiPressed)
                {
                    case GUIMovePressed.NOTHING:
                        IsX = IMovable.X.ZERO;
                        break;
                    case GUIMovePressed.BACK:
                        IsX = IMovable.X.NEGATIVE;
                        break;
                    case GUIMovePressed.FORWARD:
                        IsX = IMovable.X.POSITIVE;
                        break;
                    default:
                        throw new UnityException($"unhandled state: {_guiPressed}");
                }
            }

            switch (IsX)
            {
                case IMovable.X.ZERO:
                    x = 0f;
                    break;
                case IMovable.X.NEGATIVE:
                    FlipSpriteOnXAxis = true;
                    x = -1f;
                    break;
                case IMovable.X.POSITIVE:
                    FlipSpriteOnXAxis = false;
                    x = 1f;
                    break;
                default:
                    throw new UnityException($"unhandled state: {IsX}");
            }
            transform.Translate(Time.deltaTime * new Vector3(x * SpeedX, 0f, 0f));
            AddForce();
            OnMoved(transform.position);
        }

        private void AddForce()
        {
            if (_onDiagonal)
                _rigidbody2D.AddForce(Time.deltaTime * Vector3.up * ON_DIAGONAL_UP_FORCE, ForceMode2D.Impulse);
        }

        private void Getted(GameObject getter, IUsable getted)
        {
            if (!getter.Equals(gameObject))
                return;

            if (_belongings.ContainsValue(getted))
                throw new UnityException($"{gameObject.name} already have {((MonoBehaviour)getted).name}");

            _belongings.Add(getted.TypeOf, getted);
            
            OnSelectUsable(getted);
        }

        private void OnMoved(Vector3 position)
        {
            Moved?.Invoke(position);
        }

        private void OnSelectUsable(IUsable usable)
        {
            SelectUsable?.Invoke(usable);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;

            if (colliding.CompareTag(Tag.BESTMARE))
                CanMoveX = false;
            if (Equals(colliding.layer, Layer.DIAGONAL))
                _onDiagonal = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;

            if (colliding.CompareTag(Tag.BESTMARE))
                CanMoveX = true;
            if (Equals(colliding.layer, Layer.DIAGONAL))
                _onDiagonal = false;
        }
    }
}