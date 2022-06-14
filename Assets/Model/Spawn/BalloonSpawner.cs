using UnityEngine;
using Assets.Components.Entity;
using Assets.Model.Nature;
using Assets.ScriptableObjects;

namespace Assets.Model.Spawn
{
    public class BalloonSpawner :
        IEntity,
        ISpawn
    {
        public event ISpawn.SpawnEventHandler Spawned;

        private readonly Transform _transform;

        private float _balloonCooldown;

        public BalloonSpawner(Transform transform)
        {
            _transform = transform;
            _balloonCooldown = RandomBalloonCooldown;
        }

        public Transform Transform => _transform;

        public bool AllowedToSpawn => _balloonCooldown <= 0f;

        private float RandomBalloonCooldown => Random.Range(0.23f, 1.23f);

        public void Start(IEntityComponent earthComponent)
        {
            Spawned += (earthComponent.Entity as Earth).ListenSpawn;
        }

        public void Update()
        {
            _balloonCooldown -= Time.deltaTime;
        }

        public void Spawn(IScriptableObject balloonScriptableObject)
        {
            _balloonCooldown = RandomBalloonCooldown;
            IEntity entity = Object.Instantiate(
                balloonScriptableObject.Prefab,
                new Vector3(
                    Random.Range(-5f, 5f),
                    Random.Range(1f, 2.3f),
                    0f
                ),
                Quaternion.identity,
                Transform.parent
            ).GetComponent<BalloonComponent>().Entity;
            OnSpawned(new SpawnInfo(entity));
        }

        public void OnSpawned(SpawnInfo info)
        {
            Spawned?.Invoke(info);
        }
    }
}