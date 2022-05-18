using UnityEngine;
using Assets.Resources.Classes;

namespace Assets.Resources.Scripts.Belongings
{
    public class Book : MonoBehaviour, IUsable
    {
        public event IUsable.GetDelegate Get;

        public IUsable.Type TypeOf { get; private set; }

        public bool Belong { get; private set; }

        public bool ToUse { get; private set; }

        public bool Using { get; private set; }

        private SpriteRenderer _spriteRenderer;

        private BoxCollider2D _boxCollider2D;

        private float _degrees;

        private void Awake()
        {
            TypeOf = IUsable.Type.BOOK_SHEET;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
            _degrees = 90f;
            Get += ReceiveGet;
        }

        private void ReceiveGet(GameObject picker, IUsable picked)
        {
            if (!picked.Equals(this))
                return;

            if (!Belong && picker.CompareTag(Tag.BLU))
            {
                transform.SetParent(picker.transform);
                _spriteRenderer.enabled = false;
                _boxCollider2D.enabled = false;
                _boxCollider2D.isTrigger = true;
                transform.position = picker.transform.position;
                transform.localPosition = Vector3.zero;
                Belong = true;
            }
        }

        private void Update()
        {
            Use();
        }

        public void AllowUse()
        {
            if (!Belong)
                return;

            ToUse = true;
        }

        public void ForbidUse()
        {
            if (!Belong)
                return;

            ToUse = false;
        }

        public void Use()
        {
            if (!Belong)
                return;

            if (Input.GetAxisRaw("Use") > 0f || ToUse){
                Using = true;
                _spriteRenderer.enabled = true;
                _boxCollider2D.enabled = true;
            }

            if (_degrees >= 450f)
            {
                _degrees = 90f;
                Using = false;
                _spriteRenderer.enabled = false;
                _boxCollider2D.enabled = false;
                transform.localPosition = Vector3.zero;
            }

            if (!Using)
                return;

            float x = Mathf.Cos(Mathf.Deg2Rad * _degrees);
            float y = Mathf.Sin(Mathf.Deg2Rad * _degrees);

            transform.localPosition = new Vector3(x, y, 0f);

            _degrees += Time.deltaTime * Mathf.Pow(2f, 10f);
        }

        public void OnGet(GameObject getter)
        {
            Get?.Invoke(getter, this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;
            if (!Belong && colliding.CompareTag(Tag.BLU))
                OnGet(colliding);
        }
    }
}