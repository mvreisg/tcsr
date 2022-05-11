using UnityEngine;

namespace Assets.Resources.Scripts.Belongings
{
    public class Diary : MonoBehaviour, IBelonging
    {
        public bool ToUse { get; private set; }

        public bool Using { get; private set; }

        private float _degrees;

        private Diary() : base()
        {
            _degrees = 0f;
        }

        private void Update()
        {
            ReceiveInput();
        }

        public void Use()
        {
            if (!ToUse)
                return;

            Using = true;

            _degrees += Time.deltaTime * Mathf.Pow(2f, 11f);

            if (_degrees >= 360f)
            {
                _degrees = 0f;
                Using = false;
            }

            float x = Mathf.Cos(Mathf.Deg2Rad * _degrees);
            float y = Mathf.Sin(Mathf.Deg2Rad * _degrees);

            transform.localPosition = new Vector2(x, y);
        }

        private void ReceiveInput()
        {
            if (ToUse)
                Use();
            if (Using)
                return;
            ToUse = Input.GetKeyDown(KeyCode.Space);
        }
    }
}