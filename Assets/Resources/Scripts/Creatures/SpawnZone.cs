using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Characters;

namespace Assets.Resources.Scripts.Creatures
{
    public class SpawnZone : MonoBehaviour
    {
        private Blu _blu;

        private List<GameObject> _spawnedCreatures;

        private float _distanceToSpawn = 5f;

        private int _limit = 1;

        private SpawnZone() : base()
        {
            _spawnedCreatures = new List<GameObject>();
        }

        private void Start()
        {
            _blu = FindObjectOfType<Blu>();
        }

        private void Update()
        {
            Spawn();
        }

        private void Remove(GameObject gameObject)
        {
            _spawnedCreatures.Remove(gameObject);
        }

        private void Spawn()
        {
            if (_spawnedCreatures.Count == _limit)
                return;
            if (Vector2.Distance(transform.position, _blu.transform.position) > _distanceToSpawn)
                return;

            // NOTE:
            // Resources.Load returns the SERIALIZED OBJECT
            // Object.Instantiate returns the ACTUAL SCENE OBJECT (IN THE SCENE HIERARCHY)
            // In other words, do nothing with Resources.Load returns unless INSTANTIATE and then get the gameObject
            //  and do what you need.
            // NEVER FORGET THIS :D
            GameObject prefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Creatures/Bestmare");
            GameObject instance = Instantiate(prefab);
            instance.GetComponent<Bestmare>().OnDestroy += Remove;
            instance.transform.position = transform.position;
            _spawnedCreatures.Add(instance);
        }
    }
}