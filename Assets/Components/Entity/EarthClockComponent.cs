using UnityEngine;
using Assets.Model.Belong;

namespace Assets.Components.Entity
{
    public class EarthClockComponent : MonoBehaviour
    {
        private Clock _clock;

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