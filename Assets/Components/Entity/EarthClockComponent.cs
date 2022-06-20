using UnityEngine;
using Assets.Model.Belong;
using Assets.Model;

namespace Assets.Components.Entity
{
    public class EarthClockComponent : MonoBehaviour,
        IModelComponent
    {
        private Clock _clock;

        public IModel Model => _clock;

        private void Awake()
        {
            _clock = new Clock(transform);
            _clock.Awake();
        }

        private void Start()
        {
            _clock.Start();
        }

        private void Update()
        {
            _clock.Update();
        }
    }
}