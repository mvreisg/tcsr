using UnityEngine;

namespace Assets.Resources.Scripts.Belongings
{
    public class Book : MonoBehaviour, IDestroyable
    {
        public event IDestroyable.DestroyDelegate DestroyEvent;

        private SpriteRenderer _spriteRenderer;

        private BoxCollider2D _boxCollider2D;

        private bool _toUse;

        private bool _using;

        private float _degrees;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _boxCollider2D.enabled = false;
        }

        private void Update()
        {
            Use();
        }

        public void AllowUse()
        {
            _toUse = true;
        }

        private void Use()
        {
            if (Input.GetAxisRaw("Use") > 0 || _toUse)
            {
                _toUse = false;
                _using = true;
                _spriteRenderer.enabled = true;
                _boxCollider2D.enabled = true;
            }

            if (!_using)
                return;

            if (_degrees >= 360f)
            {
                _degrees = 0f;
                _using = false;
            }
            else
                _degrees += Time.deltaTime * Mathf.Pow(2f, 10f);

            float x = Mathf.Cos(Mathf.Deg2Rad * _degrees);
            float y = Mathf.Sin(Mathf.Deg2Rad * _degrees);

            transform.localPosition = new Vector3(x, y, 0f);

            if (!_using)
            {
                _spriteRenderer.enabled = false;
                _boxCollider2D.enabled = false;
                transform.localPosition = Vector3.zero;
            }
        }

        private void OnDestroy()
        {
            DestroyEvent?.Invoke(gameObject);
        }
    }
}