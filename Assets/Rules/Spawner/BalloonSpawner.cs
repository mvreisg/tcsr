using UnityEngine;
using Assets.Objects;

namespace Assets.Rules.Spawner
{
    public class BalloonSpawner :
        IRule,
        ISpawn,
        ILate
    {
        public event ISpawn.SpawnEventHandler Spawned;
        public event ILate.PassEventHandler Passed;

        private readonly Transform _transform;
        private readonly IObject _object;
        private readonly int _threshold;

        private int _count;
        private float _cooldown;

        public BalloonSpawner(Transform transform, IObject obj, int threshold)
        {
            _transform = transform;
            _object = obj;
            _threshold = threshold;
        }

        public Transform Transform => _transform;

        private float RandomCooldown => Random.Range(0.23f, 1.23f);

        public void Awake()
        {
            _count = 0;
            _cooldown = RandomCooldown;
        }

        public void Start()
        {
            Spawn();
        }

        public void Update()
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown > 0f)
                return;

            _cooldown = RandomCooldown;
            Instantiate();
        }

        public void Spawn()
        {
            OnSpawned(new SpawnInfo(this));
        }

        public void Late()
        {
            OnPassed(new LateInfo(this));
            Object.Destroy(Transform.gameObject);
        }

        public void OnSpawned(SpawnInfo info)
        {
            Spawned?.Invoke(info);
        }

        public void OnPassed(LateInfo info)
        {
            Passed?.Invoke(info);
        }

        // Class original

        private void Instantiate()
        {
            Object.Instantiate(
                _object.Prefab,
                new Vector3(
                    Transform.position.x,
                    Transform.position.y,
                    Transform.position.z
                ),
                Quaternion.identity,
                Transform.parent
            );

            _count++;

            if (_count == _threshold)
                Late();
        }
    }
}