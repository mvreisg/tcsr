using UnityEngine;
using Assets.Model.Belong;
using Assets.Model;

namespace Assets.Components.Entity
{
    public class ClockComponent : MonoBehaviour,
        IEntityComponent
    {
        private Clock _clock;

        public IEntity Entity => _clock;

        private void Awake()
        {
            _clock = new Clock(transform);
        }

        private void Update()
        {
            _clock.Update();
        }
    }
}