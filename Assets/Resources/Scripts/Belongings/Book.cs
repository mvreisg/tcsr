using UnityEngine;
using Assets.Resources.Scripts.Character;
using Assets.Resources.Scripts.GUI;
using Assets.Resources.Scripts.Tag;

namespace Assets.Resources.Scripts.Belongings
{
    public class Book : MonoBehaviour
    {
        public delegate void PickUpDelegate(GameObject picker, GameObject picked);

        public event PickUpDelegate PickUp;

        private SpriteRenderer _spriteRenderer;

        private BoxCollider2D _boxCollider2D;

        private bool _belong;

        private bool _toUse;

        private bool _using;

        private float _degrees;

        private void Awake()
        {
            _belong = false;
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            Blu blu = FindObjectOfType<Blu>();
            InputCanvas inputCanvas = FindObjectOfType<InputCanvas>();
            PickUp += blu.ReceivePickUp;
            PickUp += inputCanvas.ReceivePickUp;
            PickUp += ReceivePickUp;
        }

        private void ReceivePickUp(GameObject picker, GameObject picked)
        {
            if (!picked.Equals(gameObject))
                return;

            if (!_belong && picker.CompareTag(TagManager.BLU))
            {
                transform.SetParent(picker.transform);
                _spriteRenderer.enabled = false;
                _boxCollider2D.enabled = false;
                _boxCollider2D.isTrigger = true;
                transform.position = picker.transform.position;
                transform.localPosition = Vector3.zero;
                _belong = true;
            }
        }

        private void Update()
        {
            Use();
        }

        public void AllowUse()
        {
            if (!_belong)
                return;

            _toUse = true;
        }

        private void Use()
        {
            if (!_belong)
                return;

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

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject collidingObject = collision.gameObject;
            if (collidingObject.CompareTag(TagManager.BLU))
                OnPickUp(collidingObject);
        }

        /// <summary>
        /// Good practice to call events
        /// </summary>
        /// <param name="picker">The object who "picked" this object</param>
        private void OnPickUp(GameObject picker)
        {
            PickUp?.Invoke(picker, gameObject);
        }
    }
}