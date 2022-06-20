using UnityEngine;
using Assets.Components.Entity;
using Assets.ScriptableObjects;
using Assets.Model.Nature;

namespace Assets.Model.Spawner
{
    public class BalloonSpawner :
        IModel,
        IGenerate,
        ISpawn,
        IPass
    {
        public event IGenerate.GenerateEventHandler Generated;
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
            Generated += earth.ListenGeneration;
            Spawned += earth.ListenSpawn;
            Passed += earth.ListenLate;
            Generate();
        }

        public void Update()
        {
            _cooldown -= Time.deltaTime;
            if (_cooldown > 0f)
                return;

            _cooldown = RandomCooldown;
            Spawn();
        }

        public void Generate()
        {
            OnGenerated(new GenerationInfo(this));
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
                throw new UnityException("what");

            if (_count == _threshold)
                Pass();
        }

        public void Pass()
        {
            OnPassed(new LateInfo(this));
            Object.Destroy(Transform.gameObject);
        }

        public void OnGenerated(GenerationInfo info)
        {
            Generated?.Invoke(info);
        }

        public void OnSpawned(SpawnInfo info)
        {
            Spawned?.Invoke(info);
        }

        public void OnPassed(LateInfo info)
        {
            Passed?.Invoke(info);
        }
    }
}