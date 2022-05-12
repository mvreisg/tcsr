using UnityEngine;

namespace Assets.Resources.Scripts.Character
{
    public class Blu : MonoBehaviour, IDestroyable
    {
        public event IDestroyable.DestroyDelegate DestroyEvent;

        private Camera _camera;

        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody2D;

        private bool _canMove;
        private bool _onDiagonal;

        private bool _guiMove;
        private float _guiXDirection;

        private float _speed;

        private bool FlipSprite
        {
            set
            {
                _spriteRenderer.flipX = value;
            }
        }

        private void Awake()
        {
            _canMove = true;
            _onDiagonal = false;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _speed = 2f;
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            Move();
            MoveFixedCamera();
        }

        private void MoveFixedCamera()
        {
            _camera.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0f);
        }

        public void GUIMove(float guiX)
        {
            _guiXDirection = guiX;
            _guiMove = _guiXDirection != 0f;
        }

        private void Move()
        {
            if (!_canMove)
                return;

            float xDirection;
            if (_guiMove)
                xDirection = _guiXDirection;
            else
                xDirection = Input.GetAxisRaw("Horizontal");

            if (xDirection == 0f)
                return;

            FlipSprite = xDirection < 0f;

            transform.Translate(Time.deltaTime * new Vector3(xDirection, 0f, 0f) * _speed);

            if (_onDiagonal)
                _rigidbody2D.AddForce(Time.deltaTime * new Vector3(0f, 10f, 0f), ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _onDiagonal = collision.gameObject.layer == LayerMask.NameToLayer("Diagonal");
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            _onDiagonal = collision.gameObject.layer == LayerMask.NameToLayer("Diagonal");
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("Diagonal"))
                _onDiagonal = false;
        }

        private void OnDestroy()
        {
            DestroyEvent?.Invoke(gameObject);
        }
    }
}