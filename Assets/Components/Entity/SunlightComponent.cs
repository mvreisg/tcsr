using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class SunLightComponent : MonoBehaviour,
        IEntityComponent
    {
        private LightEmitter _lightEmitter;

        public IEntity Entity => _lightEmitter;

        private void Awake()
        {
            _lightEmitter = new LightEmitter(transform);
        }

        private void Update()
        {
            _lightEmitter.Update();
        }
    }
}