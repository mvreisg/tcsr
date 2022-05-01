using UnityEngine;

namespace Assets.Resources.Scripts.Blu
{
    public class Head : MonoBehaviour
    {
        public SpriteRenderer SpriteRenderer { get; private set; }

        private void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Update()
        {
            bool toLeft = Input.GetKey(KeyCode.LeftArrow);
            bool toRight = Input.GetKey(KeyCode.RightArrow);
            if (toLeft ^ toRight)
                SpriteRenderer.flipX = toLeft ? true : false;
        }
    }
}