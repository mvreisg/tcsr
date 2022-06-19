using UnityEngine;
using Assets.Components.Entity;
using Assets.ScriptableObjects;

namespace Assets.Model.Spawn
{
    public class BalloonSpawn :
        IModel,
        ISpawn
    {
        public event ISpawn.SpawnEventHandler Spawned;

        private readonly Transform _transform;
        private readonly IScriptableObject _scriptableObject;
        private readonly int _threshold;

        private int _count;
        private float _cooldown;

        public BalloonSpawn(Transform transform, IScriptableObject scriptableObject, int threshold)
        {
            _transform = transform;
            _scriptableObject = scriptableObject;
            _threshold = threshold;
            _count = 0;
            _cooldown = RandomCooldown;
        }

        public Transform Transform => _transform;

        private float RandomCooldown => Random.Range(0.23f, 1.23f);

        public void Awake()
        {
            
        }

        public void Start()
        {
            
        }

        public void Update()
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown > 0f)
                return;

            _cooldown = RandomCooldown;
            Spawn();
        }

        public void Spawn()
        {
            IModel model = Object.Instantiate(
                _scriptableObject.Prefab,
                new Vector3(
                    Random.Range(-5f, 5f),
                    Random.Range(1f, 2.3f),
                    0f
                ),
                Quaternion.identity,
                Transform.parent
            ).GetComponent<BalloonComponent>().Model;

            OnSpawned(new SpawnInfo(model));

            _count++;
            if (_count > _threshold)
                throw new UnityException("o que rolou?");

            if (_count == _threshold)
                Object.Destroy(Transform.gameObject);
        }

        public void OnSpawned(SpawnInfo info)
        {
            Spawned?.Invoke(info);
        }
    }
}