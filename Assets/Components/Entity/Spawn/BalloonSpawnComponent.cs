using UnityEngine;
using Assets.Model.Spawn;
using Assets.ScriptableObjects;

namespace Assets.Components.Entity.Spawn
{
    public class BalloonSpawnComponent : MonoBehaviour
    {
        [SerializeField]
        private BalloonScriptableObject _balloonScriptableObject;

        [SerializeField]
        private int _threshold;

        private BalloonSpawn _balloonSpawn;

        private void Awake()
        {
            _balloonSpawn = new BalloonSpawn(transform, _balloonScriptableObject, _threshold);
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