using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Classes;
using Assets.Resources.Scripts.Belongings;

namespace Assets.Resources.Scripts.Character
{
    public class Blu : MonoBehaviour
    {
        public delegate void BelongingDelegate(IUsable belonging);

        public event BelongingDelegate SelectedBelonging;

        private Camera _camera;

        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody2D;

        private bool _canMove;
        private bool _onDiagonal;

        private float _guiXDirection;

        private float _speed;

        private readonly Dictionary<IUsable.Type, IUsable> _belongings = new Dictionary<IUsable.Type, IUsable>();

        private IUsable _currentBelonging;

        private bool FlipSprite
        {
            set
            {
                _spriteRenderer.flipX = value;
            }
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _speed = 2.25f;
            _canMove = true;
            _onDiagonal = false;
        }

        private void Start()
        {
            _camera = GameObject.FindGameObjectWithTag(Tag.MAIN_CAMERA).GetComponent<Camera>();
            GetComponent<InatePower>().Get += ReceiveGet;
            GameObject.FindGameObjectWithTag(Tag.BOOK).GetComponent<IUsable>().Get += ReceiveGet;
        }

        private void Update()
        {
            Move();
            MoveFixedCamera();
        }

        private void MoveFixedCamera()
        {
            _camera.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, 0f);
        }

        public void GUIMove(float guiX)
        {
            _guiXDirection = guiX;
        }

        private void Move()
        {
            if (!_canMove)
                return;

            float xDirection;
            if (_guiXDirection != 0f)
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

        private void ReceiveGet(GameObject getter, IUsable getted)
        {
            if (!getter.Equals(gameObject))
                return;

            if (_belongings.ContainsValue(getted))
                throw new UnityException($"{gameObject.name} already have {((MonoBehaviour)getted).name}");

            _belongings.Add(getted.TypeOf, getted);
            OnSelectedBelonging(getted);
        }

        private void OnSelectedBelonging(IUsable belonging)
        {
            SelectedBelonging?.Invoke(belonging);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;

            if (colliding.CompareTag(Tag.BESTMARE))
                _canMove = false;
            if (Equals(colliding.layer, Layer.DIAGONAL))
                _onDiagonal = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;

            if (colliding.CompareTag(Tag.BESTMARE))
                _canMove = true;
            if (Equals(colliding.layer, Layer.DIAGONAL))
                _onDiagonal = false;
        }
    }
}