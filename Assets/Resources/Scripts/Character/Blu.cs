using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Layer;
using Assets.Resources.Scripts.Tag;

namespace Assets.Resources.Scripts.Character
{
    public class Blu : MonoBehaviour
    {
        private LayerManager _layerManager;

        private Camera _camera;

        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody2D;

        private bool _canMove;
        private bool _onDiagonal;

        private bool _guiMove;
        private float _guiXDirection;

        private float _speed;

        private List<GameObject> _belongings;

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
            _belongings = new List<GameObject>();
        }

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
            _layerManager = FindObjectOfType<LayerManager>();
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

        public void ReceivePickUp(GameObject picker, GameObject picked)
        {
            if (picker.Equals(this))
                _belongings.Add(picked);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;

            if (colliding.CompareTag(TagManager.BESTMARE))
                _canMove = false;
            if (Equals(colliding.layer, _layerManager.Diagonal))
                _onDiagonal = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;

            if (colliding.CompareTag(TagManager.BESTMARE))
                _canMove = true;
            if (Equals(colliding.layer, _layerManager.Diagonal))
                _onDiagonal = false;
        }
    }
}