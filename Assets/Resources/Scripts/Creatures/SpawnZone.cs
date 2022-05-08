using System.Collections.Generic;
using UnityEngine;
using Assets.Resources.Scripts.Characters;

namespace Assets.Resources.Scripts.Creatures
{
    public class SpawnZone : MonoBehaviour
    {
        private Blu _blu;

        private List<GameObject> _spawnedCreatures;

        private float _distanceToSpawn = 2f;

        private int _limit = 1;

        private void Awake()
        {
            _blu = FindObjectOfType<Blu>();
        }

        private void Update()
        {
            float distance = Vector2.Distance(transform.position, _blu.transform.position);
            if (distance < _distanceToSpawn && _spawnedCreatures.Count < _limit)
            {
                Spawn();
            }
        }

        private void Spawn()
        {
            GameObject prefab = UnityEngine.Resources.Load<GameObject>("Prefabs/Bestmare");
            prefab.transform.position = transform.position;
            _spawnedCreatures.Add(prefab);
        }
    }
}