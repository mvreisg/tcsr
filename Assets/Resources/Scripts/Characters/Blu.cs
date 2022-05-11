using UnityEngine;

namespace Assets.Resources.Scripts.Characters
{
    public class Blu : MonoBehaviour
    {
        private Camera _camera;

        private SpriteRenderer _spriteRenderer;

        private float _speed;

        private bool FlipSprite
        {
            set
            {
                _spriteRenderer.flipX = value;
            }
        }

        private Blu() : base()
        {
            _speed = 2f;
        }

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _camera = FindObjectOfType<Camera>();
        }

        private void Update()
        {
            ReceiveInput();
            MoveLinkedCamera();
        }

        private void ReceiveInput()
        {
            bool toLeft = Input.GetKey(KeyCode.LeftArrow);
            bool toRight = Input.GetKey(KeyCode.RightArrow);
            if (toLeft ^ toRight)
            {
                if (toLeft)
                    Move(-1);
                else if (toRight)
                    Move(1);
                else
                    throw new UnityException("unhandled situation");
            }
        }

        private void Move(int xDirection)
        {
            FlipSprite = xDirection == -1;
            transform.Translate(Time.deltaTime * xDirection * Vector2.right * _speed);
        }

        private void MoveLinkedCamera()
        {
            _camera.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 1f, 0f);
        }
    }
}