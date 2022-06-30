using UnityEngine;
using Assets.Data;
using Assets.Rules;
using Assets.Rules.Spawner;

namespace Assets.Scripts.Spawner
{
    public class BalloonSpawnerScript : MonoBehaviour,
        IRuleScript
    {
        [SerializeField]
        private BalloonObject _balloonObject;

        [SerializeField]
        private int _threshold;

        private IRule _balloonSpawn;

        public IRule Rule => _balloonSpawn;

        private void Awake()
        {
            _balloonSpawn = new BalloonSpawner(transform, _balloonObject, _threshold);
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