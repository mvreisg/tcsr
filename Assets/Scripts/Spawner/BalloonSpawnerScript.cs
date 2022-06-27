using UnityEngine;
using Assets.Objects;
using Assets.Rules;
using Assets.Rules.Spawner;

namespace Assets.Scripts.Spawner
{
    public class BalloonSpawnerScript : MonoBehaviour,
        IRuleScript
    {
        [SerializeField]
        private BalloonObject _balloonScriptableObject;

        [SerializeField]
        private int _threshold;

        private BalloonSpawner _balloonSpawn;

        public IRule Rule => _balloonSpawn;

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