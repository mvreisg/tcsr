using UnityEngine;

namespace Assets.Resources.Scripts.Characters
{
    public class Blu : MonoBehaviour
    {
        [SerializeField]
        private float _speed;

        [SerializeField]
        private float _legForce;

        public SpriteRenderer SpriteRenderer { get; private set; }

        public Rigidbody2D Rigidbody2D { get; private set; }

        private void Awake()
        {
            
            _speed = 2;
            _legForce = 200f;
            SpriteRenderer = GetComponent<SpriteRenderer>();
            Rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            ReceiveInput();   
        }

        private void ReceiveInput()
        {
            bool toLeft = Input.GetKey(KeyCode.LeftArrow);
            bool toRight = Input.GetKey(KeyCode.RightArrow);
            FlipSprite(toLeft);
            if (toLeft ^ toRight)
            {
                if (toLeft)
                    Move(-1);
                if (toRight)
                    Move(1);
            }
            if (Input.GetKeyDown(KeyCode.J))
                Jump();
            FindObjectOfType<Camera>().gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, 0f);
        }

        private void FlipSprite(bool x)
        {
            SpriteRenderer.flipX = x;
        }

        private void Move(int xDirection)
        {
            transform.Translate(Time.deltaTime * xDirection * Vector2.right * _speed);
        }

        private void Jump()
        {
            Rigidbody2D.AddForce(Vector2.up * _legForce);
        }
    }
}