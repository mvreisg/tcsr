using System.Collections.Generic;
using UnityEngine;

namespace Assets.Resources.Components.Belongings
{
    public class InatePower : MonoBehaviour, IUsable
    {
        public IUsable.Type TypeOf => IUsable.Type.INATE_POWER;

        public bool Belong { get; private set; }

        public bool ToUse { get; private set; }

        public bool Using { get; private set; }

        public event IUsable.GetEventHandler Get;

        private readonly List<IDestroyable> _touching = new List<IDestroyable>();

        private float _timeToExplode;

        private float RandomTimeToExplode => Random.Range(0.25f, 0.35f);

        public bool ReadyToExplode => _timeToExplode <= 0f;

        private float RandomForce =>  Random.Range(8000f, 12000f);

        private void Awake()
        {
            ToUse = false;
            _timeToExplode = RandomTimeToExplode;
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
                _timeToExplode = RandomTimeToExplode;
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
                _timeToExplode = RandomTimeToExplode;
            }
            else
                return;

            _touching.ForEach(touched =>
            {
                MonoBehaviour behaviour = (MonoBehaviour)touched;
                Rigidbody2D rigidbody2D = behaviour.GetComponent<Rigidbody2D>();
                if (Equals(rigidbody2D, null))
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
            if (Equals(destroyable, null))
                return;

            if (_touching.Contains(destroyable))
                return;

            _touching.Add(destroyable);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            GameObject colliding = collision.gameObject;
            IDestroyable destroyable = colliding.GetComponent<IDestroyable>();
            if (Equals(destroyable, null))
                return;

            if (_touching.Contains(destroyable))
                _touching.Remove(destroyable);
        }
    }
}