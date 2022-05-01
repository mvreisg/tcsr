using UnityEngine;

namespace Assets.Resources.Scripts.Blu
{
    public class Blu : MonoBehaviour
    {
        public float Speed { get; private set; }

        public Animator Animator { get; private set; }

        private void Awake()
        {
            Speed = 2.5f;
            Animator = GetComponent<Animator>();
        }

        private void Update()
        {
            Walk();
        }

        private void Walk()
        {
            bool toLeft = Input.GetKey(KeyCode.LeftArrow);
            bool toRight = Input.GetKey(KeyCode.RightArrow);
            Animator.SetBool("isWalking", toLeft ^ toRight);
            if (toRight && !toLeft)
                transform.Translate(Time.deltaTime * Speed * Vector2.right);
            if (toLeft && !toRight)
                transform.Translate(Time.deltaTime * Speed * Vector2.left);
        }
    }
}