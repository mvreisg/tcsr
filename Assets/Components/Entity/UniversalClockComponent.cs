using UnityEngine;
using Assets.Model.Belong;
using Assets.Model;

namespace Assets.Components.Entity
{
    public class UniversalClockComponent : MonoBehaviour,
        IEntityComponent
    {
        private Clock _clock;

        public IEntity Entity => _clock;

        private void Awake()
        {
            _clock = new Clock(transform);
        }

        // UC have this permission
        private void Start()
        {
            _clock.Update();
        }

        private void Update()
        {
            _clock.Update();
        }
    }
}