using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Belongings;
using Assets.Resources.Scripts.Characters;

namespace Assets.Resources.Scripts.Creatures
{
    public class Bestmare : MonoBehaviour, IDestroyable, IPersecutorCreature
    {
        private enum HowTheySeeMe
        {
            NORMAL,
            ALTERED
        }

        public event IDestroyable.DestroyDelegate DestroyEvent;

        public bool CanPersecute { get; private set; }

        private Blu _blu;

        private SpriteRenderer _spriteRenderer;

        private float _speed;

        [SerializeField]
        private List<Sprite> _sprites;

        private HowTheySeeMe _howTheySeeMe;

        private float _nextChangeTime;

        public float NextChangeTime
        {
            get
            {
                switch (_howTheySeeMe)
                {
                    case HowTheySeeMe.NORMAL:
                        return Random.Range(1f, Mathf.PI);
                    case HowTheySeeMe.ALTERED:
                        return Random.Range(.15f, .3f);
                    default:
                        throw new UnityException($"unhandled state: {_howTheySeeMe}");
                }
            }
        }

        private HowTheySeeMe HowToBeSeen
        {
            set
            {
                int index;
                switch (value)
                {
                    case HowTheySeeMe.NORMAL:
                        _howTheySeeMe = HowTheySeeMe.ALTERED;
                        index = 1;
                        break;
                    case HowTheySeeMe.ALTERED:
                        _howTheySeeMe = HowTheySeeMe.NORMAL;
                        index = 0;
                        break;
                    default:
                        throw new UnityException($"unhandled state: {_howTheySeeMe}");
                }
                _spriteRenderer.sprite = _sprites[index];
            }
        }

        private bool FlipSprite
        {
            set
            {
                _spriteRenderer.flipX = value;
            }
        }

        private Bestmare() : base()
        {
            CanPersecute = true;
            _speed = 1.5f;
            _howTheySeeMe = HowTheySeeMe.NORMAL;
        }

        private void Awake()
        {
            _nextChangeTime = NextChangeTime;
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void Start()
        {
            _blu = FindObjectOfType<Blu>();
        }

        private void Update()
        {
            TimeConsumer();
            Persecute();
        }

        public void Persecute()
        {
            if (!CanPersecute)
                return;
            float x = transform.position.x;
            float min = Mathf.Min(x, _blu.transform.position.x);
            int xDirection = min == x ? 1 : -1;
            FlipSprite = xDirection == -1;
            transform.Translate(Time.deltaTime * Vector2.right * xDirection * _speed);
        }

        private void TimeConsumer()
        {
            _nextChangeTime -= Time.deltaTime;
            if (_nextChangeTime <= 0f)
            {
                HowToBeSeen = _howTheySeeMe;
                _nextChangeTime = NextChangeTime;
            }
        }

        private void OnCollisionStay2D(Collision2D collision)
        {
            CanPersecute = !collision.gameObject.Equals(_blu.gameObject);
        }

        private void OnTriggerEnter2D(Collider2D collider)
        {
            // This condition doesn't look so good...
            if (collider.gameObject.GetComponent<Diary>() != null)
                Destroy(gameObject);
        }

        private void OnDestroy()
        {
            DestroyEvent?.Invoke(gameObject);
        }
    }
}