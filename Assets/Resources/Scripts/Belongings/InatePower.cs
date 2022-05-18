using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Scripts.Belongings
{
    public class InatePower : MonoBehaviour, IUsable
    {
        public IUsable.Type TypeOf { get; private set; }

        public bool Belong { get; private set; }

        public bool ToUse { get; private set; }

        public bool Using { get; private set; }

        public event IUsable.GetDelegate Get;

        private List<IDestroyable> _touching = new List<IDestroyable>();

        private float _timeToExplode;

        private float TimeToExplode
        {
            get
            {
                return Random.Range(0.25f, 0.35f);
            }
        }

        public bool ReadyToExplode
        {
            get
            {
                return _timeToExplode <= 0f;
            }
        }

        private float RandomForce
        {
            get
            {
                return Random.Range(4000f, 8000f);
            }
        }

        private void Awake()
        {
            ToUse = false;
            TypeOf = IUsable.Type.INATE_POWER;
            _timeToExplode = TimeToExplode;
            Get += ReceiveGet;
        }

        private void Start()
        {
            OnGet(gameObject);
        }

        private void ReceiveGet(GameObject getter, IUsable getted)
        {
            if (!getter.Equals(gameObject))
                return;

            if (!getted.Equals(this))
                return;

            Belong = true;
        }

        private void Update()
        {
            Use();
        }

        public void AllowUse()
        {
            if (!Belong)
                throw new UnityException("this shouldn't happen");

            ToUse = true;
        }

        public void ForbidUse()
        {
            if (!Belong)
                throw new UnityException("this shouldn't happen");

            ToUse = false;
        }

        public void Use()
        {
            if (!Belong)
                throw new UnityException("this shouldn't happen");

            if (_touching.Count == 0)
            {
                _timeToExplode = TimeToExplode;
                return;
            }

            _timeToExplode -= Time.deltaTime;
            if (!ReadyToExplode)
                return;

            // EXPLODE!
            if (Input.GetAxisRaw("Use") > 0f || ToUse)
            {
                ToUse = false;
                Using = true;
                _timeToExplode = TimeToExplode;
            }
            else
                return;

            _touching.ForEach(touched =>
            {
                MonoBehaviour behaviour = (MonoBehaviour)touched;
                Rigidbody2D rigidbody2D = behaviour.GetComponent<Rigidbody2D>();
                if (rigidbody2D == null)
                    return;

                float min = Mathf.Min(transform.position.x, behaviour.transform.position.x);
                float x = min == transform.position.x ? 1 : -1;
                rigidbody2D.AddForce(Time.deltaTime * new Vector3(RandomForce * x, RandomForce, 0f));
            });

            Using = false;
        }

        public void OnGet(GameObject picker)
        {
            Get?.Invoke(picker, this);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;
            IDestroyable destroyable = colliding.GetComponent<IDestroyable>();
            if (destroyable == null)
                return;

            if (_touching.Contains(destroyable))
                return;

            _touching.Add(destroyable);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;
            IDestroyable destroyable = colliding.GetComponent<IDestroyable>();
            if (destroyable == null)
                return;

            if (_touching.Contains(destroyable))
                _touching.Remove(destroyable);
        }
    }
}