using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Classes;
using Assets.Resources.Scripts.Character;

namespace Assets.Resources.Scripts.Enemies
{
    public class Bestmare : MonoBehaviour, IDestroyable
    {
        public event IDestroyable.DestroyDelegate DestroyEvent;

        public bool AllowedToBeDestroyed { get; private set; }

        private enum Faces
        {
            NORMAL,
            ALTERED
        }

        private SpriteRenderer _spriteRenderer;

        private Rigidbody2D _rigidbody2D;

        private Blu _blu;

        private bool _canMove;
        private bool _onDiagonal;

        private float _speed;

        [SerializeField]
        private List<Sprite> _faces;

        private Faces _face;

        private float _timeToNextFace;

        private bool FlipSprite
        {
            set
            {
                _spriteRenderer.flipX = value;
            }
        }

        private float TimeToNextFace
        {
            get
            {
                switch (_face)
                {
                    case Faces.NORMAL:
                        return Random.Range(1.2f, Mathf.PI);
                    case Faces.ALTERED:
                        return Random.Range(.1f, .3f);
                    default:
                        throw new UnityException($"unhandled face: {_face}");
                }
            }
        }

        private Sprite NextFace
        {
            get
            {
                switch (_face)
                {
                    case Faces.NORMAL:
                        _face = Faces.ALTERED;
                        return _faces[0];
                    case Faces.ALTERED:
                        _face = Faces.NORMAL;
                        return _faces[1];
                    default:
                        throw new UnityException($"unhandled face: {_face}");
                }
            }
        }

        private void Awake()
        {
            AllowedToBeDestroyed = false;
            _canMove = false;
            _speed = 1.75f;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _face = Faces.NORMAL;
            _timeToNextFace = TimeToNextFace;
        }

        private void Start()
        {
            _blu = FindObjectOfType<Blu>();
    }

        private void Update()
        {
            CheckFaces();
            Move();
        }

        private void CheckFaces()
        {
            _timeToNextFace -= Time.deltaTime;
            if (_timeToNextFace <= 0f){
                _timeToNextFace = TimeToNextFace;
                _spriteRenderer.sprite = NextFace;
            }
        }

        private void Move()
        {
            if (!_canMove)
                return;

            float x = transform.position.x;
            float bluX = _blu.transform.position.x;
            float min = Mathf.Min(x, bluX);
            float xDirection = x == min ? 1 : -1;
            FlipSprite = xDirection == -1;
            transform.Translate(Time.deltaTime * new Vector3(xDirection, 0f, 0f) * _speed);

            if (_onDiagonal)
                _rigidbody2D.AddForce(Time.deltaTime * new Vector3(0f, 10f, 0f), ForceMode2D.Impulse);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;
            int layer = colliding.layer;

            if (Equals(layer, Layer.GROUND))
                _canMove = true;
            if (colliding.CompareTag(Tag.BLU) || colliding.CompareTag(Tag.BESTMARE))
                _canMove = false;
            if (Equals(layer, Layer.DIAGONAL))
                _onDiagonal = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;
            int layer = colliding.layer;

            if (colliding.CompareTag(Tag.BLU) || colliding.CompareTag(Tag.BESTMARE))
                _canMove = true;
            if (Equals(layer, Layer.DIAGONAL))
                _onDiagonal = false;
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag(Tag.BOOK))
            {
                AllowedToBeDestroyed = true;
                AtBrinkOfDestruction();
            }
        }

        public void AtBrinkOfDestruction()
        {
            if (!AllowedToBeDestroyed)
                return;

            DestroyEvent?.Invoke(gameObject);
            Destroy(gameObject);
        }
    }
}