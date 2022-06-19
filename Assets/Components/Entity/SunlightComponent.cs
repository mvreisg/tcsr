using UnityEngine;
using Assets.Model;
using Assets.Model.Nature;

namespace Assets.Components.Entity
{
    public class SunLightComponent : MonoBehaviour,
        IEntityComponent
    {
        private SunLight _sunLight;

        public IEntity Entity => _sunLight;

        private void Awake()
        {
            _sunLight = new SunLight(transform);
        }

        private void Update()
        {
            _sunLight.Update();
        }
    }
}