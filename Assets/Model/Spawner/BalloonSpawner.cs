using UnityEngine;
using Assets.Components.Entity;
using Assets.ScriptableObjects;
using Assets.Model.Nature;

namespace Assets.Model.Spawner
{
    public class BalloonSpawner :
        IModel,
        ISpawn,
        IPass
    {
        public event ISpawn.SpawnEventHandler Spawned;
        public event IPass.PassEventHandler Passed;

        private readonly Transform _transform;
        private readonly IScriptableObject _scriptableObject;
        private readonly int _threshold;

        private int _count;
        private float _cooldown;

        public BalloonSpawner(Transform transform, IScriptableObject scriptableObject, int threshold)
        {
            _transform = transform;
            _scriptableObject = scriptableObject;
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
            Earth earth = (Transform.GetComponentInParent<EarthComponent>() as IModelComponent).Model as Earth;
            Spawned += earth.ListenSpawn;
            Passed += earth.ListenLate;
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

        public void Pass()
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
                _scriptableObject.Prefab,
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
                Pass();
        }
    }
}