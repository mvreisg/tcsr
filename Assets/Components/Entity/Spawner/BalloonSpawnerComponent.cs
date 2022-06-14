using UnityEngine;
using Assets.Model.Spawn;
using Assets.ScriptableObjects;

namespace Assets.Components.Entity.Spawner
{
    public class BalloonSpawnerComponent : MonoBehaviour
    {
        [SerializeField]
        private BalloonScriptableObject _balloonScriptableObject;

        private BalloonSpawner _balloonSpawner;

        private void Awake()
        {
            _balloonSpawner = new BalloonSpawner(transform);
        }

        private void Start()
        {
            _balloonSpawner.Start(transform.parent.GetComponent<EarthComponent>());
        }

        private void Update()
        {
            _balloonSpawner.Update();
            if (_balloonSpawner.AllowedToSpawn)
                _balloonSpawner.Spawn(_balloonScriptableObject);
        }
    }
}