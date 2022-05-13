using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Character;

namespace Assets.Resources.Scripts.Enemies
{
    public class SpawnZone : MonoBehaviour, IDestroyable
    {
        public event IDestroyable.DestroyDelegate DestroyEvent;

        private Blu _blu;

        private float _spawnTime;

        private List<GameObject> _spawnedCreatures;

        private int _limit;

        private float _distanceToSpawn;

        private float SpawnTime
        {
            get
            {
                return Random.Range(2f, Mathf.PI);
            }
        }

        private void Awake()
        {
            _spawnedCreatures = new List<GameObject>();
            _limit = 2;
            _distanceToSpawn = Mathf.PI * 1.5f;
            _spawnTime = SpawnTime;
        }

        private void Start()
        {
            _blu = FindObjectOfType<Blu>();
        }

        private void Update()
        {
            Spawn();
        }

        private void Spawn()
        {
            if (_spawnedCreatures.Count == _limit)
                return;

            if (Vector2.Distance(_blu.transform.position, transform.position) > _distanceToSpawn)
                return;

            _spawnTime -= Time.deltaTime;
            if (_spawnTime <= 0f)
                _spawnTime = SpawnTime;
            else
                return;

            GameObject prefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Enemies/Bestmare");
            GameObject instance = Instantiate(prefab);
            _spawnedCreatures.Add(instance); // NEVER FORGET
            instance.GetComponent<IDestroyable>().DestroyEvent += go => _spawnedCreatures.Remove(go);
            instance.transform.position = transform.position;
        }

        private void OnDestroy()
        {
            DestroyEvent?.Invoke(gameObject);
        }
    }
}