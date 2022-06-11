using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class AtmosphereComponent : MonoBehaviour,
        IEntityComponent
    {
        private Atmosphere _atmosphere;

        public IEntity Entity => _atmosphere;

        private void Awake()
        {
            _atmosphere = new Atmosphere(transform);
        }

        private void Update()
        {
            _atmosphere.Exist();
        }
    }
}