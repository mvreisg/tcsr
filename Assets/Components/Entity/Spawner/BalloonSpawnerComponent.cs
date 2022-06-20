using UnityEngine;
using Assets.Model.Spawner;
using Assets.ScriptableObjects;
using Assets.Model;

namespace Assets.Components.Entity.Spawner
{
    public class BalloonSpawnerComponent : MonoBehaviour,
        IModelComponent
    {
        [SerializeField]
        private BalloonScriptableObject _balloonScriptableObject;

        [SerializeField]
        private int _threshold;

        private BalloonSpawner _balloonSpawn;

        public IModel Model => _balloonSpawn;

        private void Awake()
        {
            _balloonSpawn = new BalloonSpawner(transform, _balloonScriptableObject, _threshold);
            _balloonSpawn.Awake();
        }

        private void Start()
        {
            _balloonSpawn.Start();
        }

        private void Update()
        {
            _balloonSpawn.Update();
        }
    }
}